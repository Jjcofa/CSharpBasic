using System;
using System.Text;

namespace FibonacciApp
{
    public static class FibonacciCalculator
    {

        public static int CalculateFibonacci(int n)
        {
            if (n <= 0)
                return 0;
            if (n == 1)
                return 1;

            return CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Введіть номер числа Фібоначчі:");
            int number = int.Parse(Console.ReadLine());

            int result = FibonacciCalculator.CalculateFibonacci(number);

            Console.WriteLine($"Число Фібоначчі з номером {number} дорівнює {result}");
        }
    }
}