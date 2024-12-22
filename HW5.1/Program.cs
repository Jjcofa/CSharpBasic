string firstNum, secondNum;
int dividend, divisor, result;

Console.WriteLine("Введите первое число:");
firstNum = Console.ReadLine();
Console.WriteLine("Введите второе число:");
secondNum = Console.ReadLine();


try
{
    dividend = int.Parse(firstNum);
    divisor = int.Parse(secondNum);
    result = dividend / divisor;
    Console.WriteLine($"Результат: {result}.");
}
catch (DivideByZeroException)
{
    Console.WriteLine("Деление на ноль невозможно.");
}
catch (FormatException)
{
    Console.WriteLine("Некорректное число.");
}