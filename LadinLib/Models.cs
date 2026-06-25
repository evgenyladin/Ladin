using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace LadinLib
{
    public enum Priority { Low = 0, Medium = 1, High = 2 }
    public enum TaskStatus { New, InProgress, Completed }
    public enum Category { Work, Study, Personal, Other }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public Priority Priority { get; set; }
        public DateTime Deadline { get; set; }
        public TaskStatus Status { get; set; }
        public bool IsImportant { get; set; }
        public Category Category { get; set; }
    }

    public class TaskManager
    {
        private List<TaskItem> tasks;
        public TaskManager() { tasks = new List<TaskItem>(); }

        public void AddTask(TaskItem t)
        {
            if (tasks.Count == 0) t.Id = 1;
            else t.Id = tasks.Max(x => x.Id) + 1;
            tasks.Add(t);
        }

        public List<TaskItem> GetAllTasks() { return tasks.ToList(); }
        public List<TaskItem> FilterByStatus(TaskStatus st) { return tasks.Where(t => t.Status == st).ToList(); }
        public List<TaskItem> FilterByCategory(Category cat) { return tasks.Where(t => t.Category == cat).ToList(); }

        public List<TaskItem> Search(string query)
        {
            return tasks.Where(t => t.Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    t.Desc.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        public void UpdateTask(TaskItem updated)
        {
            var e = tasks.FirstOrDefault(t => t.Id == updated.Id);
            if (e != null) { e.Title = updated.Title; e.Desc = updated.Desc; e.Priority = updated.Priority; e.Deadline = updated.Deadline; e.Status = updated.Status; e.IsImportant = updated.IsImportant; e.Category = updated.Category; }
        }

        public void DeleteTask(int id) { var t = tasks.FirstOrDefault(x => x.Id == id); if (t != null) tasks.Remove(t); }
        public void SortByPriority() { tasks = tasks.OrderBy(t => t.Priority).ToList(); }
        public void SortByDeadline() { tasks = tasks.OrderBy(t => t.Deadline).ToList(); }

        public void ToggleImportant(int id) { var t = tasks.FirstOrDefault(x => x.Id == id); if (t != null) t.IsImportant = !t.IsImportant; }

        public (int completed, int overdue) GetStats()
        {
            int d = tasks.Count(t => t.Status == TaskStatus.Completed);
            int o = tasks.Count(t => t.Status != TaskStatus.Completed && t.Deadline < DateTime.Now);
            return (d, o);
        }

        public List<TaskItem> ArchiveCompleted()
        {
            var comp = tasks.Where(t => t.Status == TaskStatus.Completed).ToList();
            tasks = tasks.Where(t => t.Status != TaskStatus.Completed).ToList();
            return comp;
        }

        public void SaveToFile(string path) { File.WriteAllText(path, JsonConvert.SerializeObject(tasks, Formatting.Indented)); }
        public void LoadFromFile(string path) { if (File.Exists(path)) tasks = JsonConvert.DeserializeObject<List<TaskItem>>(File.ReadAllText(path)) ?? new List<TaskItem>(); }

        public void SaveArchive(string path, List<TaskItem> archive) { File.WriteAllText(path, JsonConvert.SerializeObject(archive, Formatting.Indented)); }
        public List<TaskItem> LoadArchive(string path) { if (File.Exists(path)) return JsonConvert.DeserializeObject<List<TaskItem>>(File.ReadAllText(path)) ?? new List<TaskItem>(); return new List<TaskItem>(); }

        public void ExportToCsv(List<TaskItem> list, string path)
        {
            using (var w = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                w.WriteLine("Id,Title,Desc,Priority,Deadline,Status,IsImportant,Category");
                foreach (var t in list) w.WriteLine($"{t.Id},{Esc(t.Title)},{Esc(t.Desc)},{t.Priority},{t.Deadline:yyyy-MM-dd},{t.Status},{t.IsImportant},{t.Category}");
            }
        }
        private string Esc(string s) { if (s.Contains(",") || s.Contains("\"")) return "\"" + s.Replace("\"", "\"\"") + "\""; return s; }
    }
}