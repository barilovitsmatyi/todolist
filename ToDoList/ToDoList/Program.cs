using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ToDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Feladatok betöltése induláskor
            List<string> tasks = LoadTasks();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== TODO LIST ===");
                Console.WriteLine("1) Add task");
                Console.WriteLine("2) List tasks");
                Console.WriteLine("3) Exit");
                Console.WriteLine("4) Delete task");
                Console.Write("> ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter task: ");
                        string task = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(task))
                        {
                            tasks.Add(task);
                            SaveTasks(tasks);
                            Console.WriteLine("Task added!");
                        }
                        else
                        {
                            Console.WriteLine("Empty task was not added.");
                        }

                        Console.ReadKey();
                        break;

                    case "2":
                        Console.WriteLine("\nYour tasks:");

                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("There are no tasks yet.");
                        }
                        else
                        {
                            for (int i = 0; i < tasks.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {tasks[i]}");
                            }
                        }

                        Console.ReadKey();
                        break;

                    case "3":
                        running = false;
                        break;

                    case "4":
                        Console.WriteLine("\nCurrent tasks:");

                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("There are no tasks to delete.");
                            Console.ReadKey();
                            break;
                        }

                        for (int i = 0; i < tasks.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {tasks[i]}");
                        }

                        Console.Write("\nEnter the number of the task to delete: ");
                        string deleteInput = Console.ReadLine();

                        int deleteIndex;
                        if (int.TryParse(deleteInput, out deleteIndex) &&
                            deleteIndex >= 1 &&
                            deleteIndex <= tasks.Count)
                        {
                            string removedTask = tasks[deleteIndex - 1];
                            tasks.RemoveAt(deleteIndex - 1);
                            SaveTasks(tasks);
                            Console.WriteLine($"Task deleted: {removedTask}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid task number.");
                        }

                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Invalid option!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Feladatok mentése fájlba
        static void SaveTasks(List<string> tasks)
        {
            File.WriteAllLines("tasks.txt", tasks);
        }

        // Feladatok betöltése fájlból
        static List<string> LoadTasks()
        {
            if (File.Exists("tasks.txt"))
                return File.ReadAllLines("tasks.txt").ToList();
            else
                return new List<string>();
        }
    }
}


