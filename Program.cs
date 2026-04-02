using System;
namespace TaskManager
{
    class Program
    {
        public void ShowCompletedTasks()
        {
            var completedTasks = tasks.Where(t => t.IsCompleted).ToList();

            if(!completedTasks.Any())
            {
                Console.WriteLine("Нет выполненных задач");
                return;
            }
            foreach (var task in completedTasks)
            {
                Console.WriteLine(task);
            }
        }
    
        static void Main(string[] args)
        {
            TaskManager manager = new TaskManager();
            while (true)
            {
                Console.WriteLine("\n1 - Добавить задачу");
                Console.WriteLine("2 - Показать задачи");
                Console.WriteLine("3 - Завершить задачу");
                Console.WriteLine("4 - Удалить задачу");
                Console.WriteLine("5 - Показать выполненные задачи")
                Console.WriteLine("0 - Выход");
                Console.Write("Выбор: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                    Console.Write("Введите название: ");
                    string title = Console.ReadLine();
                    manager.AddTask(title);
                    break;

                    case "2":
                    manager.ShowTasks();
                    break;

                    case "3":
                    Console.Write("Введите ID: ");
                    if (int.TryParse(Console.ReadLine(), out int completeId))
                    manager.CompleteTask(completeId);
                    break;

                    case "4":
                    Console.Write("Введите ID: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                    manager.DeleteTask(deleteId);
                    break;

                    case "5":
                        manager.ShowCompletedTasks();
                        break;

                    case "0":
                    return;

                
                }
            }
        }
    }
}
