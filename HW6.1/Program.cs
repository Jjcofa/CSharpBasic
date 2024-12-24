string selectFunction;
do
{
    Console.WriteLine("\nВведiть номер операцiї:\n");
    Console.WriteLine("[1] Обчислення середнього заробiтку");
    Console.WriteLine("[2] Побудова графiку зiрочками");
    Console.WriteLine("[3] Генерацiя простих чисел");
    Console.WriteLine("[4] Перевiрка паролю");
    Console.WriteLine("[5] Генерацiя фiбоначчiвської послiдовностi");
    Console.WriteLine("[6] Калькулятор оплати працi за годину");
    Console.WriteLine("[7] Генерацiя таблицi множення для конкретного числа");
    Console.WriteLine("[8] Перевiрка на простоту");
    Console.WriteLine("[9] Вийти");

    selectFunction = Console.ReadLine();

    switch (selectFunction)
    {
        case "1": // Обчислення середнього заробiтку
            Console.Write("Введiть кiлькiсть працiвникiв: ");
            int count = int.Parse(Console.ReadLine());
            double totalSalary = 0;

            for (int i = 1; i <= count; i++)
            {
                Console.Write($"Введiть зарплату працiвника #{i}: ");
                totalSalary += double.Parse(Console.ReadLine());
            }

            double averageSalary = totalSalary / count;
            Console.WriteLine($"Середнiй заробiток: {averageSalary:F2}");
            break;

        case "2": // Побудова графiку зiрочками
            Console.Write("Введiть кiлькiсть рядкiв для графiка: ");
            int rows = int.Parse(Console.ReadLine());
            for (int i = 1; i <= rows; i++)
            {
                Console.WriteLine(new string('*', i));
            }
            break;

        case "3": // Генерацiя простих чисел
            Console.Write("Введiть межу для простих чисел: ");
            int limit = int.Parse(Console.ReadLine());
            Console.WriteLine("Простi числа:");
            for (int i = 2; i <= limit; i++)
            {
                if (i % 2 != 0)
                    Console.WriteLine($"{i}");
            }
            break;

        case "4": // Перевiрка паролю
            Console.Write("Введiть пароль: ");
            string password = Console.ReadLine();

            if (password.Length < 8)
            {
                Console.WriteLine("Пароль не вiдповiдає вимогам.");
                break;
            }

            bool hasSpecialChar = false, hasDigit = false;
            foreach (char c in password)
            {
                if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
                if (!char.IsLetterOrDigit(c))
                {
                    hasSpecialChar = true;
                }
                if (hasDigit && hasSpecialChar)
                {
                    break;
                }
            }
            if (hasDigit && hasSpecialChar)
            {
                Console.WriteLine("Пароль прийнятний.");
            }
            else
            {
                Console.WriteLine("Пароль не вiдповiдає вимогам.");
            }
            break;

        case "5": // Генерацiя фiбоначчiвської послiдовностi
            Console.Write("Введiть кiлькiсть чисел послiдовностi Фiбоначчi: ");
            int fibCount = int.Parse(Console.ReadLine());
            int a = 0, b = 1;
            Console.Write("Послiдовнiсть: ");
            for (int i = 0; i <= fibCount; i++)
            {
                Console.Write($"{a} ");
                int temp = a;
                a = b;
                b = temp + b;
            }
            Console.WriteLine();
            break;

        case "6": // Калькулятор оплати праці за годину
            Console.Write("Введiть кiлькiсть годин: ");
            int hours = int.Parse(Console.ReadLine());
            Console.Write("Введiть оплату за годину: ");
            double rate = double.Parse(Console.ReadLine());
            Console.WriteLine($"Загальна оплата: {hours * rate}");
            break;

        case "7": // Генерацiя таблицi множення для конкретного числа
            Console.Write("Введiть число для таблицi множення: ");
            int number = int.Parse(Console.ReadLine());
            {
                Console.WriteLine($"Таблиця множення для числа {number}:");
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine($"{number} x {i} = {number * i}");
                }
                break;
            }

        case "8": // Перевірка на простоту
            Console.Write("Введiть число для перевiрки на простоту: ");
            int checkNumber = int.Parse(Console.ReadLine());
            int endFunction = 3;
            for (int i = 2; i < endFunction; i++)
            {
                if (checkNumber % i == 0)
                {
                    Console.WriteLine("Число не є простим");
                }
                else
                    Console.WriteLine("Число є простим");
            }
            break;

        case "9": // Вихід з програми
            Console.WriteLine("Вихiд з програми.");
            break;

        default:
            Console.WriteLine("Невiрний номер операцiї.");
            break;
    }

} while (selectFunction != "9");
