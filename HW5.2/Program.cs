string input;
int number;

Console.WriteLine("Введите число:");
input = Console.ReadLine();

try
{
    number = int.Parse(input);
    Console.WriteLine($"Вы ввели число: {number}");
}
catch (FormatException)
{
    Console.WriteLine("Вы ввели некорректное число.");
}