using System.Text;
Console.OutputEncoding = System.Text.Encoding.UTF8;
StringBuilder report = new StringBuilder();

Console.WriteLine("Введіть заголовок звіту:");
string title = Console.ReadLine();

report.AppendLine(title);
report.AppendLine($"Дата: {DateTime.Now:dd.MM.yyyy}");
report.AppendLine("Список подій:");

while (true)
{
    Console.WriteLine("Введіть подію (або натисніть Enter для завершення):");
    string eventInput = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(eventInput))
    {
        break;
    }

    report.AppendLine($"* {eventInput}");
}

Console.WriteLine("\nЗвіт:");
Console.WriteLine(report.ToString());