﻿namespace UI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        using ParsethingContext db = new();
        ComboBoxItems.Clear();
        foreach (Developer developer in db.Developers)
        {
            ComboBoxItems.Add(new() { Content = developer.FullName });
        }

        InitializeComponent();
        ComboBox.ItemsSource = ComboBoxItems;
        Me.ItemsSource = MeItems;
        My.ItemsSource = MyItems;
    }

    private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        switch (WindowState)
        {
            case WindowState.Normal:
                ChromeMaximize.Content = "";
                break;
            case WindowState.Maximized:
                ChromeMaximize.Content = "";
                break;
        }
    }

    private void DockPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {

        WindowState = WindowState.Normal;
        DragMove();
    }

    private void ChromeMinimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void ChromeMaximize_Click(object sender, RoutedEventArgs e)
    {
        switch (WindowState)
        {
            case WindowState.Normal:
                WindowState = WindowState.Maximized;
                break;
            case WindowState.Maximized:
                WindowState = WindowState.Normal;
                break;
        }
    }

    private void ChromeClose_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
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
        try
        {
            AddWindow add = new(((ComboBoxItem)ComboBox.SelectedItem).Content.ToString());
            if (ComboBox.SelectedItem != null)
            {
                add.Show();
            }
        }
        catch { }
        GetMeItems();
        GetMyItems();
    }

    private void Send_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            using ParsethingContext db = new();
            TaskExecutor def = db.TaskExecutors
                .Where(te => te.Id == ((MyItem)My.SelectedItem).Id).First();
            def.StatusId = 2;
            _ = db.TaskExecutors.Update(def);
            _ = db.SaveChanges();
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