using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ToDoList
{
    
    class TaskItem
    {
        public string Description { get; set; }
        public bool Done { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Feladatok betöltése induláskor
            List<TaskItem> tasks = LoadTasks();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== TODO LIST ===");
                Console.WriteLine("1) Add task");
                Console.WriteLine("2) List tasks");
                Console.WriteLine("3) Toggle task status (done / not done)");
                Console.WriteLine("4) Edit task");
                Console.WriteLine("5) Delete task");
                Console.WriteLine("6) Exit");
                Console.Write("> ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask(tasks);
                        break;

                    case "2":
                        ListTasks(tasks);
                        break;

                    case "3":
                        ToggleTaskStatus(tasks);
                        break;

                    case "4":
                        EditTask(tasks);
                        break;

                    case "5":
                        DeleteTask(tasks);
                        break;

                    case "6":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // 1) Új feladat hozzáadása
        static void AddTask(List<TaskItem> tasks)
        {
            Console.Write("Enter task: ");
            string taskText = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(taskText))
            {
                tasks.Add(new TaskItem
                {
                    Description = taskText,
                    Done = false
                });

                SaveTasks(tasks);
                Console.WriteLine("Task added!");
            }
            else
            {
                Console.WriteLine("Empty task was not added.");
            }

            Console.ReadKey();
        }

        // 2) Feladatok listázása
        static void ListTasks(List<TaskItem> tasks)
        {
            Console.WriteLine("\nYour tasks:");

            if (tasks.Count == 0)
            {
                Console.WriteLine("There are no tasks yet.");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    string status = tasks[i].Done ? "[X]" : "[ ]";
                    Console.WriteLine($"{i + 1}. {status} {tasks[i].Description}");
                }
            }

            Console.ReadKey();
        }

        // 3) Feladat státuszának váltása (kész / nincs kész)
        static void ToggleTaskStatus(List<TaskItem> tasks)
        {
            Console.WriteLine("\nToggle task status:");

            if (tasks.Count == 0)
            {
                Console.WriteLine("There are no tasks to update.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                string status = tasks[i].Done ? "[X]" : "[ ]";
                Console.WriteLine($"{i + 1}. {status} {tasks[i].Description}");
            }

            Console.Write("\nEnter the number of the task to toggle: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int index) &&
                index >= 1 &&
                index <= tasks.Count)
            {
                TaskItem item = tasks[index - 1];
                item.Done = !item.Done;
                SaveTasks(tasks);

                string newStatus = item.Done ? "done" : "not done";
                Console.WriteLine($"Task status changed to: {newStatus}");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }

            Console.ReadKey();
        }

        // 4) Feladat szövegének módosítása
        static void EditTask(List<TaskItem> tasks)
        {
            Console.WriteLine("\nEdit task:");

            if (tasks.Count == 0)
            {
                Console.WriteLine("There are no tasks to edit.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                string status = tasks[i].Done ? "[X]" : "[ ]";
                Console.WriteLine($"{i + 1}. {status} {tasks[i].Description}");
            }

            Console.Write("\nEnter the number of the task to edit: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int index) &&
                index >= 1 &&
                index <= tasks.Count)
            {
                TaskItem item = tasks[index - 1];

                Console.WriteLine($"\nCurrent text: {item.Description}");
                Console.Write("Enter new text (leave empty to cancel): ");
                string newText = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(newText))
                {
                    item.Description = newText;
                    SaveTasks(tasks);
                    Console.WriteLine("Task updated.");
                }
                else
                {
                    Console.WriteLine("Edit cancelled, task not changed.");
                }
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }

            Console.ReadKey();
        }

        // 5) Feladat törlése
        static void DeleteTask(List<TaskItem> tasks)
        {
            Console.WriteLine("\nDelete task:");

            if (tasks.Count == 0)
            {
                Console.WriteLine("There are no tasks to delete.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                string status = tasks[i].Done ? "[X]" : "[ ]";
                Console.WriteLine($"{i + 1}. {status} {tasks[i].Description}");
            }

            Console.Write("\nEnter the number of the task to delete: ");
            string deleteInput = Console.ReadLine();

            if (int.TryParse(deleteInput, out int deleteIndex) &&
                deleteIndex >= 1 &&
                deleteIndex <= tasks.Count)
            {
                TaskItem removedTask = tasks[deleteIndex - 1];
                tasks.RemoveAt(deleteIndex - 1);
                SaveTasks(tasks);
                Console.WriteLine($"Task deleted: {removedTask.Description}");
            }
            else
            {
                Console.WriteLine("Invalid task number.");
            }

            Console.ReadKey();
        }

        // Feladatok mentése fájlba
        static void SaveTasks(List<TaskItem> tasks)
        {
            
            var lines = tasks.Select(t =>
                (t.Done ? "1" : "0") + ";" + t.Description);

            File.WriteAllLines("tasks.txt", lines);
        }

        // Feladatok betöltése fájlból
        static List<TaskItem> LoadTasks()
        {
            var result = new List<TaskItem>();

            if (!File.Exists("tasks.txt"))
                return result;

            string[] lines = File.ReadAllLines("tasks.txt");

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                
                var parts = line.Split(new[] { ';' }, 2);

                if (parts.Length == 2)
                {
                    bool done = parts[0] == "1";
                    string description = parts[1];

                    result.Add(new TaskItem
                    {
                        Description = description,
                        Done = done
                    });
                }
            }

            return result;
        }
    }
}



