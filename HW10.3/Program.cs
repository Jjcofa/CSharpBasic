using System;
using System.Text;

Console.WriteLine("Введите текст:");
string input = Console.ReadLine();

StringBuilder sb = new StringBuilder();

foreach (char c in input)
{
    if (c != ' ')
    {
        sb.Append(c);
    }
}

Console.WriteLine("Текст без пробелов:");
Console.WriteLine(sb.ToString());