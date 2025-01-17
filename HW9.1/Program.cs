using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("Оберіть дію:");
            Console.WriteLine("1. Знайти другий найбільший елемент у масиві");
            Console.WriteLine("2. Відсортувати двовимірний масив за зростанням");
            Console.WriteLine("3. Видалити елемент з масиву за індексом");
            Console.WriteLine("4. Знайти суму елементів по діагоналі у двовимірному масиві");
            Console.WriteLine("5. Вийти");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    FindSecondLargestElement();
                    break;
                case 2:
                    Sort2DArray();
                    break;
                case 3:
                    RemoveElementByIndex();
                    break;
                case 4:
                    CalculateDiagonalSum();
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    static void FindSecondLargestElement()
    {
        Random random = new Random();
        int[] array = new int[random.Next(5, 15)];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 100);
        }

        Console.WriteLine("Згенерований масив:");
        Console.WriteLine(string.Join(", ", array));

        int firstLargest = int.MinValue;
        int secondLargest = int.MinValue;

        foreach (int num in array)
        {
            if (num > firstLargest)
            {
                secondLargest = firstLargest;
                firstLargest = num;
            }
            else if (num > secondLargest && num != firstLargest)
            {
                secondLargest = num;
            }
        }

        if (secondLargest == int.MinValue)
        {
            Console.WriteLine("У масиві немає другого найбільшого елемента.");
        }
        else
        {
            Console.WriteLine("Другий найбільший елемент у масиві: " + secondLargest);
        }
    }

    static void Sort2DArray()
    {
        int[,] matrix = new int[3, 3];
        Random random = new Random();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = random.Next(1, 101);
            }
        }

        Console.WriteLine("Початковий двовимірний масив:");
        Print2DArray(matrix);

        bool swapped;
        do
        {
            swapped = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                    int nextI, nextJ;
                    if (j == matrix.GetLength(1) - 1)
                    {
                        nextI = i + 1;
                        nextJ = 0;
                    }
                    else
                    {
                        nextI = i;
                        nextJ = j + 1;
                    }

                    if (nextI < matrix.GetLength(0) && matrix[i, j] > matrix[nextI, nextJ])
                    {
                        int temp = matrix[i, j];
                        matrix[i, j] = matrix[nextI, nextJ];
                        matrix[nextI, nextJ] = temp;
                        swapped = true;
                    }
                }
            }
        } while (swapped);

        Console.WriteLine("Відсортований двовимірний масив:");
        Print2DArray(matrix);
    }


    static void RemoveElementByIndex()
    {
        Random random = new Random();
        int[] array = new int[random.Next(5, 15)];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 100);
        }

        Console.WriteLine("Згенерований масив:");
        Console.WriteLine(string.Join(", ", array));

        Console.WriteLine("Введіть індекс елемента для видалення:");
        int index = int.Parse(Console.ReadLine());

        if (index < 0 || index >= array.Length)
        {
            Console.WriteLine("Невірний індекс.");
            return;
        }

        int[] newArray = new int[array.Length - 1];
        for (int i = 0, j = 0; i < array.Length; i++)
        {
            if (i != index)
            {
                newArray[j++] = array[i];
            }
        }

        Console.WriteLine("Масив після видалення елемента:");
        Console.WriteLine(string.Join(", ", newArray));
    }

    static void CalculateDiagonalSum()
    {
        int[,] matrix = new int[3, 3];
        Random random = new Random();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = random.Next(1, 101);
            }
        }

        Console.WriteLine("Початковий двовимірний масив:");
        Print2DArray(matrix);

        int sum = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            sum += matrix[i, i];
        }

        Console.WriteLine("Сума елементів по діагоналі: " + sum);
    }

    static void Print2DArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }
    }
}