string oper;
double result, numOne, numTwo;

Console.WriteLine("Выберите действие(+, -, /, *):");
oper = Console.ReadLine();
Console.WriteLine("Введите первое число:");
numOne = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Введите второе число:");
numTwo = Convert.ToDouble(Console.ReadLine());

switch (oper)
{
	case "+":
		result = numOne + numTwo;
		Console.WriteLine($"{result}");
		break;

    case "-":
		result = numOne - numTwo;
        Console.WriteLine($"{result}");
        break;

    case "*":
        result = numOne * numTwo;
        Console.WriteLine($"{result}");
        break;
        
    case "/":
        result = numOne / numTwo;
        Console.WriteLine($"{result}");
        break;

    default:
        Console.WriteLine("Неверный оператор!");
        break;
}
