using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ParsethingTasks
{
    public partial class AddWindow : Window
    {
        public AddWindow(string developer)
        {
            Developer = developer;
            ComboBoxItems.Clear();
            using ParsethingContext db = new();
            foreach (Developer d in db.Developers)
            {
                ComboBoxItems.Add(new() { Content = d.FullName });
            }

            InitializeComponent();
            ComboBox.ItemsSource = ComboBoxItems;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _ = Executors.Items.Add(((ComboBoxItem)ComboBox.SelectedItem).Content.ToString());
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using ParsethingContext db = new();
                Task task = new()
                {
                    Title = Title.Text,
                    Description = Descriprion.Text,
                    DeveloperId = db.Developers.Where(d => d.FullName == Developer).First().Id
                };
                _ = db.Tasks.Add(task);
                _ = db.SaveChanges();
                foreach (string item in Executors.Items)
                {
                    TaskExecutor executor = new()
                    {
                        DeveloperId = db.Developers.Where(d => d.FullName == item).First().Id,
                        TaskId = task.Id,
                        StatusId = 1
                    };
                    _ = db.TaskExecutors.Add(executor);
                    _ = db.SaveChanges();
                }
                Close();
            }
            catch { }
        }

        private string Developer { get; set; } = null!;
        private static ObservableCollection<ComboBoxItem> ComboBoxItems { get; set; } = new();
    }
}