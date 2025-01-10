using System;

Random random = new Random();
int[] array = new int[10];
int[,] multiplicationTable = new int[9, 9];
int[,] matrix = new int[5, 5];

while (true)
{
    Console.WriteLine("\nВыберите операцию:");
    Console.WriteLine("1. Заполнить массив из 10 элементов и вывести значения с парным индексом.");
    Console.WriteLine("2. Проверить, является ли сумма элементов массива из пункта 1 неотрицательной.");
    Console.WriteLine("3. Создать и вывести таблицу умножения 9x9.");
    Console.WriteLine("4. Создать массив 5x5, найти минимум, максимум и их координаты.");
    Console.WriteLine("5. Вычислить день недели через заданное количество дней.");
    Console.WriteLine("0. Выйти.");

    int choice = int.Parse(Console.ReadLine());

    if (choice == 0)
    {
        Console.WriteLine("Выход из программы.");
        return;
    }

    if (choice == 1)
    {
        Console.WriteLine("\nМассив из 10 элементов:");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(-10, 11);
        }
        Console.WriteLine(string.Join(", ", array));

        Console.WriteLine("\nЭлементы массива с парным индексом:");
        for (int i = 0; i < array.Length; i += 2)
        {
            Console.WriteLine($"Index {i}: {array[i]}");
        }
    }

    if (choice == 2)
    {
        Console.WriteLine("\nПроверка суммы элементов массива:");
        int sum = 0;
        foreach (int num in array)
        {
            sum += num;
        }
        Console.WriteLine($"Сумма элементов массива: {sum}");
        if (sum >= 0)
            Console.WriteLine("Сумма неотрицательная.");
        else
            Console.WriteLine("Сумма отрицательная.");
    }

    if (choice == 3)
    {
        Console.WriteLine("\nТаблица умножения 9x9:");
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                multiplicationTable[i, j] = (i + 1) * (j + 1);
                Console.Write(multiplicationTable[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    if (choice == 4)
    {
        Console.WriteLine("\nМассив 5x5:");
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                matrix[i, j] = random.Next(-10, 21);
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        int max = matrix[0, 0], min = matrix[0, 0];
        (int maxRow, int maxCol) = (0, 0);
        (int minRow, int minCol) = (0, 0);

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    maxRow = i;
                    maxCol = j;
                }
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    minRow = i;
                    minCol = j;
                }
            }
        }

        Console.WriteLine($"\nМаксимальный элемент: {max} (Строка: {maxRow}, Столбец: {maxCol})");
        Console.WriteLine($"Минимальный элемент: {min} (Строка: {minRow}, Столбец: {minCol})");
    }

    if (choice == 5)
    {
        Console.WriteLine("\nВведите количество дней:");
        int days = int.Parse(Console.ReadLine());
        int dayIndex;
        if (days % 7 == 0)
        {
            dayIndex = 7;
        }
        else
        {
            dayIndex = days % 7;
        }
        DaysOfWeek resultDay = (DaysOfWeek)dayIndex;

        Console.WriteLine($"Через {days} дней будет: {resultDay}");

    }

    Console.WriteLine("\nОперация завершена.");
}

enum DaysOfWeek
{
    Monday = 1,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}
