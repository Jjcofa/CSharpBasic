using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введіть шлях до вихідного файлу: ");
        string sourceFilePath = Console.ReadLine();

        Console.Write("Введіть шлях до файлу, в який потрібно скопіювати дані: ");
        string destinationFilePath = Console.ReadLine();

        try
        {
            if (!File.Exists(sourceFilePath))
            {
                Console.WriteLine("Помилка: Вихідний файл не знайдено!");
                return;
            }

            string fileContent = File.ReadAllText(sourceFilePath);
            File.WriteAllText(destinationFilePath, fileContent);

            Console.WriteLine("Файл успішно скопійовано!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Помилка: Вихідний файл не знайдено!");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Помилка: Каталог не знайдено!");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Помилка: Шлях до файлу містить недопустимі символи!");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Помилка: Недопустимий формат шляху до файлу!");
        }
    }
}