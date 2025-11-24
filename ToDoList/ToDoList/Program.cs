using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> tasks = new List<string>();
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
    }
}
