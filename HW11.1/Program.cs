using System;

class WordGame
{
    private string[] animals = { "собака", "кролик", "кошка", "бегемот", "крокодил", "кенгуру" };
    private string[] fruits = { "яблуко", "банан", "виноград", "апельсин", "персик", "ананас" };
    private string[] capitals = { "Київ", "Вашингтон", "Берлін", "Анкара", "Бухарест", "Варшава" };

    private string secretWord;
    private char[] hiddenWord;
    private int remainingAttempts;
    private bool hintAvailable;
    
    public void Start()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        ChooseCategory();
        ChooseDifficulty();

        hiddenWord = new string('_', secretWord.Length).ToCharArray();

        Console.WriteLine("Вітаємо! Спробуйте вгадати зашифроване слово!");
        Console.WriteLine($"Кількість літер у слові: {secretWord.Length}");
        Console.WriteLine($"Кількість можливих невірних спроб: {remainingAttempts}");

        Stopwatch stopwatch = Stopwatch.StartNew();

        Play();

        stopwatch.Stop();
        TimeSpan elapsedTime = stopwatch.Elapsed;

        Console.Clear();
        if (new string(hiddenWord) == secretWord)
        {
            Console.WriteLine("\nВітаємо, ви вгадали слово!");
        }
        else
        {
            Console.WriteLine("\nВи програли! Невірні спроби закінчились.");
        }

        Console.WriteLine($"Зашифроване слово: {secretWord}");
        Console.WriteLine($"Час, витрачений на гру: {elapsedTime.Seconds} секунд(и).");
        Console.WriteLine("Дякуємо за гру.");
    }

    private void ChooseCategory()
    {
        Console.Clear();
        Console.WriteLine("Оберіть категорію слів:");
        Console.WriteLine("1. Тварини");
        Console.WriteLine("2. Фрукти");
        Console.WriteLine("3. Столиці");
        Console.WriteLine("4. Випадковий вибір");

        int choice;
        while (true)
        {
            Console.Write("Ваш вибір: ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 4)
            {
                break;
            }
            Console.WriteLine("Невірний вибір, спробуйте ще раз.");
        }

        Random random = new Random();
        switch (choice)
        {
            case 1:
                secretWord = animals[random.Next(animals.Length)];
                break;
            case 2:
                secretWord = fruits[random.Next(fruits.Length)];
                break;
            case 3:
                secretWord = capitals[random.Next(capitals.Length)];
                break;
            case 4:
                string[][] categories = { animals, fruits, capitals };
                string[] randomCategory = categories[random.Next(categories.Length)];
                secretWord = randomCategory[random.Next(randomCategory.Length)];
                break;
        }
    }

    private void ChooseDifficulty()
    {
        Console.Clear();
        Console.WriteLine("Оберіть рівень складності:");
        Console.WriteLine("1. Легкий (8 спроб, доступна підказка)");
        Console.WriteLine("2. Середній (6 спроб, доступна підказка)");
        Console.WriteLine("3. Складний (4 спроби, без підказки)");
        Console.WriteLine("4. Випадковий вибір");

        int choice;
        while (true)
        {
            Console.Write("Ваш вибір: ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 4)
            {
                break;
            }
            Console.WriteLine("Невірний вибір, спробуйте ще раз.");
        }

        Random random = new Random();
        if (choice == 4)
        {
            choice = random.Next(1, 4);
        }

        switch (choice)
        {
            case 1:
                remainingAttempts = 8;
                hintAvailable = true;
                break;
            case 2:
                remainingAttempts = 6;
                hintAvailable = true;
                break;
            case 3:
                remainingAttempts = 4;
                hintAvailable = false;
                break;
        }
    }

    private void Play()
    {
        while (remainingAttempts > 0 && new string(hiddenWord) != secretWord)
        {
            Console.Clear();
            Console.WriteLine($"\nЗашифроване слово: {string.Join(" ", hiddenWord)}");
            Console.WriteLine($"Залишилось спроб: {remainingAttempts}");
            if (hintAvailable)
            {
                Console.WriteLine("Натисніть '1', щоб отримати підказку (відкрити випадкову букву).");
            }
            Console.Write("Введіть вашу літеру: ");
            string input = Console.ReadLine();

            if (input == "1" && hintAvailable)
            {
                UseHint();
                hintAvailable = false;
                continue;
            }

            if (input.Length != 1 || !char.IsLetter(input[0]))
            {
                Console.WriteLine("Введіть лише одну літеру!");
                Console.ReadKey();
                continue;
            }

            char guess = input[0];
            if (secretWord.Contains(guess))
            {
                Console.WriteLine("Така літера є у слові!");

                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretWord[i] == guess)
                    {
                        hiddenWord[i] = guess;
                        Console.WriteLine($"Позиція літери: {i + 1}");
                    }
                }
            }
            else
            {
                remainingAttempts--;
                Console.WriteLine($"Такої літери немає! Залишилось спроб: {remainingAttempts}");
            }

            Console.ReadKey();
        }
    }

    private void UseHint()
    {
        Random random = new Random();
        int hintIndex;

        do
        {
            hintIndex = random.Next(secretWord.Length);
        } 
        while (hiddenWord[hintIndex] != '_');

        hiddenWord[hintIndex] = secretWord[hintIndex];
        Console.WriteLine($"\nПідказка: Відкрита буква '{secretWord[hintIndex]}' на позиції {hintIndex + 1}.");
        Console.ReadKey();
    }
}

class Program
{
    static void Main()
    {
        WordGame game = new WordGame();
        game.Start();
    }
}
