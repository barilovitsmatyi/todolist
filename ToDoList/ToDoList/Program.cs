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
                Console.Write("> ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter task: ");
                        string task = Console.ReadLine();
                        tasks.Add(task);

                        // MENTÉS
                        SaveTasks(tasks);

                        Console.WriteLine("Task added!");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.WriteLine("\nYour tasks:");
                        for (int i = 0; i < tasks.Count; i++)
                            Console.WriteLine($"{i + 1}. {tasks[i]}");
                        Console.ReadKey();
                        break;

                    case "3":
                        running = false;
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

