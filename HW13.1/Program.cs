using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static List<string> tasks = new List<string>();
    static List<bool> completedTasks = new List<bool>();


    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        while (true)
        {
            Console.WriteLine("Оберіть дію:");
            Console.WriteLine("1. Додати справу");
            Console.WriteLine("2. Показати всі справи");
            Console.WriteLine("3. Відмітити справу як виконану");
            Console.WriteLine("4. Видалити справу");
            Console.WriteLine("5. Вийти");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ShowTasks();
                    break;
                case "3":
                    MarkTask();
                    break;
                case "4":
                    DeleteTask();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Невірний вибір.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.WriteLine("Введіть назву справи:");
        string task = Console.ReadLine();
        tasks.Add(task);
        completedTasks.Add(false);
        Console.WriteLine("Справу додано.");
    }

    static void ShowTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Список справ порожній.");
            return;
        }

        for (int i = 0; i < tasks.Count; i++)
        {
            string status;
            if (completedTasks[i])
            {
                status = "[Виконано]";
            }
            else
            {
                status = "[Не виконано]";
            }
            Console.WriteLine($"{i + 1}. {status} {tasks[i]}");
        }
    }

    static void MarkTask()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Список справ порожній.");
            return;
        }

        Console.WriteLine("Введіть номер справи, яку хочете відмітити як виконану:");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            completedTasks[taskNumber - 1] = true;
            Console.WriteLine("Справу відмічено як виконану.");
        }
        else
        {
            Console.WriteLine("Невірний номер справи.");
        }
    }

    static void DeleteTask()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Список справ порожній.");
            return;
        }

        Console.WriteLine("Введіть номер справи, яку хочете видалити:");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks.RemoveAt(taskNumber - 1);
            completedTasks.RemoveAt(taskNumber - 1);
            Console.WriteLine("Справу видалено.");
        }
        else
        {
            Console.WriteLine("Невірний номер справи.");
        }
    }
}