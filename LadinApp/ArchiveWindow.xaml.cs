using System.Collections.Generic;
using System.Linq;
using System.Windows;
using LadinLib;

namespace LadinApp
{
    public partial class ArchiveWindow : Window
    {
        private List<TaskItem> archiveList;
        private TaskManager manager;

        public ArchiveWindow(List<TaskItem> archive, TaskManager mgr)
        {
            InitializeComponent();
            manager = mgr;
            archiveList = archive;
            ArchiveList.ItemsSource = archiveList;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ArchiveList.SelectedItem is TaskItem selected)
            {
                archiveList.Remove(selected);
                string archivePath = System.IO.Path.Combine(System.Environment.CurrentDirectory, "archive.json");
                manager.SaveArchive(archivePath, archiveList);
                ArchiveList.ItemsSource = null;
                ArchiveList.ItemsSource = archiveList;
            }
            else
            {
                MessageBox.Show("Выберите задачу для удаления.");
            }
        }
    }
}