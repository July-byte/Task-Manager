using System.Linq.Expressions;

usingSystem;
usingSystem.Collections.Generic;
usingSystem.IO;
usingSystem.Linq;

namespace TaskManager 
{
    public class TaskManager 
    {
        private List<TaskItem> tasks = new List<TaskItem>();
        private int nextId = 1;
        private string filePath = "tasks.txt";

        public void AddTask(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Название задачи не может быть пустым.");
                return;
            }
            tasks.Add(new TaskItem(nextId++, title));
        }
        public void ShowTasks()
        {
            if (!tasks.Any())
            {
                Console.WriteLine("Список задач пуст.");
                return;
            }
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
        }
        public void CompleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                Console.WriteLine("Задача не найдена");
                return;
            }
            task.IsCompleted = true;
        }
        public void DeleteTask(int id)
        {
            var removeCount = tasks.RemoveAll(t => t.Id == id);
            if (removedCount == 0)
            {
                Console.WriteLine("Задача не найдена");
            }
        }
        public void SaveToFile()
        {
            try
            {
                var lines = tasks.Select(t => $"{tId}|{t.Title}|{t.IsCompleted}");
                File.WriteAllLines(filePath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при сохранении файла: " + ex.Message);
            }
        }
        public void LoadFile()
        {
            try
            {
                if (!File.Exists(filePath))
                return;

                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length != 3)
                    continue;

                    int id = int.Parse(parts[0]);
                    string title = parts[1];
                    bool isCompleted = bool.Parse(parts[2]);
                    var task = new Task.Item(id, title);
                    task.IsCompleted = isCompleted;
                    tasks.Add(task);
                    if (id >= nextId)
                    nextId = id + 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при загрузке файла: " + ex.Message);
            }
        }
          
    }

}
