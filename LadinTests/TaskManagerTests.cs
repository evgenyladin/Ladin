using LadinLib;
using System;
using System.IO;
using System.Linq;
using TaskStatus = LadinLib.TaskStatus;   // разрешаем конфликт

namespace LadinTests
{
    [TestClass]
    public class TaskManagerTests
    {
        private TaskManager mgr;

        [TestInitialize]
        public void Setup()
        {
            mgr = new TaskManager();
            mgr.AddTask(new TaskItem { Title = "Задача 1", Desc = "Описание 1", Priority = Priority.High, Deadline = DateTime.Now.AddDays(1), Status = TaskStatus.New });
            mgr.AddTask(new TaskItem { Title = "Задача 2", Desc = "Вторая", Priority = Priority.Low, Deadline = DateTime.Now.AddDays(-1), Status = TaskStatus.InProgress });
            mgr.AddTask(new TaskItem { Title = "Test", Desc = "test desc", Priority = Priority.Medium, Deadline = DateTime.Now.AddDays(5), Status = TaskStatus.Completed });
        }

        [TestMethod]
        public void AddTask_ShouldIncreaseCount()
        {
            int countBefore = mgr.GetAllTasks().Count;
            mgr.AddTask(new TaskItem { Title = "Новая", Desc = "", Priority = Priority.Medium, Deadline = DateTime.Now, Status = TaskStatus.New });
            int countAfter = mgr.GetAllTasks().Count;
            Assert.AreEqual(countBefore + 1, countAfter);
        }

        [TestMethod]
        public void FilterByStatus_ShouldReturnCorrect()
        {
            var completed = mgr.FilterByStatus(TaskStatus.Completed);
            Assert.AreEqual(1, completed.Count);
            Assert.AreEqual("Test", completed[0].Title);
        }

        [TestMethod]
        public void Search_ShouldFindByTitle()
        {
            var res = mgr.Search("Задача");
            Assert.AreEqual(2, res.Count);
        }

        [TestMethod]
        public void Search_ShouldFindByDesc()
        {
            var res = mgr.Search("вторая");
            Assert.AreEqual(1, res.Count);
        }

        [TestMethod]
        public void UpdateTask_ShouldChangeTitle()
        {
            var all = mgr.GetAllTasks();
            var t = all.First(x => x.Title == "Задача 1");
            t.Title = "Обновлённая";
            mgr.UpdateTask(t);
            var updated = mgr.GetAllTasks().First(x => x.Id == t.Id);
            Assert.AreEqual("Обновлённая", updated.Title);
        }

        [TestMethod]
        public void DeleteTask_ShouldRemove()
        {
            var all = mgr.GetAllTasks();
            int id = all[0].Id;
            mgr.DeleteTask(id);
            Assert.AreEqual(2, mgr.GetAllTasks().Count);
            Assert.IsFalse(mgr.GetAllTasks().Any(t => t.Id == id));
        }

        [TestMethod]
        public void SortByPriority_ShouldOrderCorrectly()
        {
            mgr.SortByPriority();
            var list = mgr.GetAllTasks();
            Assert.AreEqual(Priority.Low, list[0].Priority);
            Assert.AreEqual(Priority.High, list[2].Priority);
        }

        [TestMethod]
        public void SortByDeadline_ShouldOrderCorrectly()
        {
            mgr.SortByDeadline();
            var list = mgr.GetAllTasks();
            Assert.IsTrue(list[0].Deadline <= list[1].Deadline);
        }

        [TestMethod]
        public void ToggleImportant_ShouldFlip()
        {
            var all = mgr.GetAllTasks();
            int id = all[0].Id;
            bool before = all[0].IsImportant;
            mgr.ToggleImportant(id);
            Assert.AreEqual(!before, mgr.GetAllTasks().First(t => t.Id == id).IsImportant);
        }

        [TestMethod]
        public void GetStats_ShouldReturnCorrect()
        {
            var stats = mgr.GetStats();
            Assert.AreEqual(1, stats.completed);
            Assert.AreEqual(1, stats.overdue);
        }

        [TestMethod]
        public void SaveAndLoad_ShouldPreserveData()
        {
            string path = "test_save.json";
            mgr.SaveToFile(path);
            var newMgr = new TaskManager();
            newMgr.LoadFromFile(path);
            var list = newMgr.GetAllTasks();
            Assert.AreEqual(3, list.Count);
            File.Delete(path);
        }
    }
}