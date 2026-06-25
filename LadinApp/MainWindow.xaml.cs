using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using LadinLib;

namespace LadinApp
{
    public partial class MainWindow : Window
    {
        private TaskManager manager;
        private TaskItem editingTask;

        public MainWindow()
        {
            InitializeComponent();
            manager = new TaskManager();
            editingTask = null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, "tasks.json");
            manager.LoadFromFile(path);
            RefreshList(manager.GetAllTasks());
            StatusFilter.SelectedIndex = 0;
            CategoryFilter.SelectedIndex = 0;
            CategoryBox.SelectedIndex = 0;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, "tasks.json");
            manager.SaveToFile(path);
        }

        private void RefreshList(List<TaskItem> list)
        {
            TasksList.ItemsSource = null;
            TasksList.ItemsSource = list;
        }

        private void ClearFields()
        {
            TitleBox.Text = "";
            DescBox.Text = "";
            PriorityBox.SelectedIndex = 0;
            StatusBox.SelectedIndex = 0;
            CategoryBox.SelectedIndex = 0;
            DeadlinePicker.SelectedDate = DateTime.Today;
            editingTask = null;
        }

        private TaskItem ReadFields()
        {
            string title = TitleBox.Text.Trim();
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Введите название задачи.");
                return null;
            }
            if (!DeadlinePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Выберите срок.");
                return null;
            }

            TaskItem t = editingTask != null ? new TaskItem { Id = editingTask.Id } : new TaskItem();
            t.Title = title;
            t.Desc = DescBox.Text.Trim();
            t.Priority = (Priority)PriorityBox.SelectedIndex;
            t.Status = (TaskStatus)StatusBox.SelectedIndex;
            t.Category = (Category)CategoryBox.SelectedIndex;
            t.Deadline = DeadlinePicker.SelectedDate.Value;
            return t;
        }

        private void TasksList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (TasksList.SelectedItem is TaskItem selected)
            {
                editingTask = selected;
                TitleBox.Text = selected.Title;
                DescBox.Text = selected.Desc;
                PriorityBox.SelectedIndex = (int)selected.Priority;
                StatusBox.SelectedIndex = (int)selected.Status;
                CategoryBox.SelectedIndex = (int)selected.Category;
                DeadlinePicker.SelectedDate = selected.Deadline;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            TaskItem t = ReadFields();
            if (t == null) return;
            manager.AddTask(t);
            RefreshList(manager.GetAllTasks());
            ClearFields();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (editingTask == null)
            {
                MessageBox.Show("Сначала выберите задачу в списке.");
                return;
            }
            TaskItem t = ReadFields();
            if (t == null) return;
            manager.UpdateTask(t);
            RefreshList(manager.GetAllTasks());
            ClearFields();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (editingTask == null)
            {
                MessageBox.Show("Выберите задачу.");
                return;
            }
            manager.DeleteTask(editingTask.Id);
            RefreshList(manager.GetAllTasks());
            ClearFields();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string q = SearchBox.Text.Trim();
            if (string.IsNullOrEmpty(q))
                RefreshList(manager.GetAllTasks());
            else
                RefreshList(manager.Search(q));
        }

        private void StatusFilter_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void CategoryFilter_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            List<TaskItem> result = manager.GetAllTasks();

            if (StatusFilter.SelectedIndex > 0)
            {
                TaskStatus st = (TaskStatus)(StatusFilter.SelectedIndex - 1);
                result = result.Where(t => t.Status == st).ToList();
            }

            if (CategoryFilter.SelectedIndex > 0)
            {
                Category cat = (Category)(CategoryFilter.SelectedIndex - 1);
                result = result.Where(t => t.Category == cat).ToList();
            }

            string q = SearchBox.Text.Trim();
            if (!string.IsNullOrEmpty(q))
            {
                result = result.Where(t =>
                    t.Title.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    t.Desc.IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            RefreshList(result);
        }

        private void ResetFilter_Click(object sender, RoutedEventArgs e)
        {
            StatusFilter.SelectedIndex = 0;
            CategoryFilter.SelectedIndex = 0;
            SearchBox.Text = "";
            RefreshList(manager.GetAllTasks());
        }

        private void SortPriority_Click(object sender, RoutedEventArgs e)
        {
            manager.SortByPriority();
            RefreshList(manager.GetAllTasks());
        }

        private void SortDeadline_Click(object sender, RoutedEventArgs e)
        {
            manager.SortByDeadline();
            RefreshList(manager.GetAllTasks());
        }

        private void ToggleImportant_Click(object sender, RoutedEventArgs e)
        {
            if (editingTask == null)
            {
                MessageBox.Show("Выберите задачу.");
                return;
            }
            manager.ToggleImportant(editingTask.Id);
            RefreshList(manager.GetAllTasks());
        }

        private void Stats_Click(object sender, RoutedEventArgs e)
        {
            var stats = manager.GetStats();
            MessageBox.Show($"Завершено: {stats.completed}\nПросрочено: {stats.overdue}");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, "tasks.json");
            manager.SaveToFile(path);
            MessageBox.Show("Сохранено.");
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, "tasks.json");
            manager.LoadFromFile(path);
            RefreshList(manager.GetAllTasks());
            MessageBox.Show("Загружено.");
        }

        private void Archive_Click(object sender, RoutedEventArgs e)
        {
            var archiveList = manager.ArchiveCompleted();
            string archivePath = System.IO.Path.Combine(Environment.CurrentDirectory, "archive.json");
            List<TaskItem> existingArchive = manager.LoadArchive(archivePath);
            existingArchive.AddRange(archiveList);
            manager.SaveArchive(archivePath, existingArchive);
            RefreshList(manager.GetAllTasks());
            MessageBox.Show($"Завершённые задачи ({archiveList.Count} шт.) перемещены в архив.");
        }

        private void ShowArchive_Click(object sender, RoutedEventArgs e)
        {
            string archivePath = System.IO.Path.Combine(Environment.CurrentDirectory, "archive.json");
            var archiveList = manager.LoadArchive(archivePath);
            ArchiveWindow win = new ArchiveWindow(archiveList, manager);
            win.Owner = this;
            win.ShowDialog();
        }

        private void ExportCsv_Click(object sender, RoutedEventArgs e)
        {
            string csvPath = System.IO.Path.Combine(Environment.CurrentDirectory, "tasks_export.csv");
            List<TaskItem> current = manager.GetAllTasks();
            manager.ExportToCsv(current, csvPath);
            MessageBox.Show($"Экспортировано в {csvPath}");
        }
    }
}