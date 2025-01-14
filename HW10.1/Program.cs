using System;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Введіть прізвище та ім’я:");
string name = Console.ReadLine();

string[] parts = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

if (parts.Length == 2)
{
    char firstLetterSurname = parts[0][0]; 
    char firstLetterName = parts[1][0];

    if (firstLetterSurname == firstLetterName)
    {
        Console.WriteLine("Прізвище починається на ту ж літеру, що і ім’я");
    }
    else
    {
        Console.WriteLine("Прізвище не починається на ту ж літеру, що і ім’я");
    }
}

else
{
    Console.WriteLine("Невірний формат");
}