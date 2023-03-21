using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ParsethingTasks
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            using ParsethingContext db = new();
            foreach (Developer developer in db.Developers)
            {
                ComboBoxItems.Add(new() { Content = developer.FullName });
            }

            InitializeComponent();
            ComboBox.ItemsSource = ComboBoxItems;
            Me.ItemsSource = MeItems;
            My.ItemsSource = MyItems;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetMeItems();
            GetMyItems();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            GetMeItems();
            GetMyItems();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox.SelectedItem != null)
            {
                new AddWindow(((ComboBoxItem)ComboBox.SelectedItem).Content.ToString()).Show();
            }
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using ParsethingContext db = new();
                TaskExecutor def = db.TaskExecutors
                    .Where(te => te.Id == ((MyItem)My.SelectedItem).Id).First();
                def.StatusId = 3;
                db.TaskExecutors.Update(def);
                db.SaveChanges();
            }
            catch { }
            GetMeItems();
            GetMyItems();
        }

        private ObservableCollection<ComboBoxItem> ComboBoxItems { get; set; } = new();
        private ObservableCollection<MeItem> MeItems { get; set; } = new();
        private ObservableCollection<MyItem> MyItems { get; set; } = new();

        private class MeItem
        {
            public int Id { get; set; }
            public string Title { get; set; } = null!;
            public string Description { get; set; } = null!;
            public string Executor { get; set; } = null!;
            public string Status { get; set; } = null!;
        }
        private void GetMeItems()
        {
            using ParsethingContext db = new();
            List<TaskExecutor> taskExecutors = db.TaskExecutors
                .Include(te => te.Developer)
                .Include(te => te.Task)
                .Include(te => te.Task.Developer)
                .Include(te => te.Status)
                .Where(te => te.Task.Developer.FullName == ((ComboBoxItem)ComboBox.SelectedItem).Content.ToString())
                .ToList();
            MeItems.Clear();
            foreach (TaskExecutor taskExecutor in taskExecutors)
            {
                MeItems.Add(new MeItem
                {
                    Id = taskExecutor.Id,
                    Title = taskExecutor.Task.Title,
                    Description = taskExecutor.Task.Description,
                    Executor = taskExecutor.Developer.FullName,
                    Status = taskExecutor.Status.Title
                });
            }
        }

        private class MyItem
        {
            public int Id { get; set; }
            public string Title { get; set; } = null!;
            public string Description { get; set; } = null!;
            public string Autor { get; set; } = null!;
        }
        private void GetMyItems()
        {
            using ParsethingContext db = new();
            List<TaskExecutor> taskExecutors = db.TaskExecutors
                .Include(te => te.Developer)
                .Include(te => te.Task)
                .Include(te => te.Task.Developer)
                .Include(te => te.Status)
                .Where(te => te.Developer.FullName == ((ComboBoxItem)ComboBox.SelectedItem).Content.ToString())
                .Where(te => te.StatusId == 1)
                .ToList();
            MyItems.Clear();
            foreach (TaskExecutor taskExecutor in taskExecutors)
            {
                MyItems.Add(new MyItem
                {
                    Id = taskExecutor.Id,
                    Title = taskExecutor.Task.Title,
                    Description = taskExecutor.Task.Description,
                    Autor = taskExecutor.Task.Developer.FullName
                });
            }
        }
    }
}