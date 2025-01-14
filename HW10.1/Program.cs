using System;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;

//Console.WriteLine("Введіть прізвище та ім’я:");
//string[] name = Console.ReadLine().Split(' ');

//if (name[0][0] == name[1][0])
//{
//    Console.WriteLine("Прізвище починається на ту ж літеру, що і ім’я");
//}
//else
//{
//    Console.WriteLine("Прізвище не починається на ту ж літеру, що і ім’я");
//}


Console.WriteLine("Введіть прізвище та ім’я:");
string name = Console.ReadLine();

int spaceIndex = name.IndexOf(' ');
if (spaceIndex != -1)
{
    char firstLetterSurname = name[0];
    char firstLetterName = name[spaceIndex + 1];

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
    Console.WriteLine("Помилка: введіть прізвище та ім’я через пробіл.");
}
