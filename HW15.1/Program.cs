using System;
using System.Text;

namespace VegetableShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            VegetableShop shop = new VegetableShop();

            while (true)
            {
                Console.WriteLine("\nОберіть дію:");
                Console.WriteLine("1. Додати продукт");
                Console.WriteLine("2. Видалити продукт");
                Console.WriteLine("3. Переглянути інформацію про продукти");
                Console.WriteLine("4. Вийти");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct(shop);
                        break;
                    case "2":
                        RemoveProduct(shop);
                        break;
                    case "3":
                        shop.PrintProductsInfo();
                        break;
                    case "4":
                        Console.WriteLine("Дякуємо за використання нашого магазину!");
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }
        static void AddProduct(VegetableShop shop)
        {
            Console.WriteLine("Оберіть тип продукту:");
            Console.WriteLine("1. Морква");
            Console.WriteLine("2. Картопля");
            Console.WriteLine("3. Помідор");
            Console.WriteLine("4. Огірок");

            string productChoice = Console.ReadLine();

            Console.WriteLine("Введіть ціну продукту:");
            if (!double.TryParse(Console.ReadLine(), out double price))
            {
                Console.WriteLine("Невірний формат ціни.");
                return;
            }

            Product product;

            switch (productChoice)
            {
                case "1":
                    product = new Carrot(price);
                    break;
                case "2":
                    Console.WriteLine("Введіть кількість кілограмів:");
                    if (!double.TryParse(Console.ReadLine(), out double potatoCount))
                    {
                        Console.WriteLine("Невірний формат кількості.");
                        return;
                    }
                    product = new Potato(price, potatoCount);
                    break;
                case "3":
                    product = new Tomato(price);
                    break;
                case "4":
                    Console.WriteLine("Введіть кількість кілограмів:");
                    if (!double.TryParse(Console.ReadLine(), out double cucumberCount))
                    {
                        Console.WriteLine("Невірний формат кількості.");
                        return;
                    }
                    product = new Cucumber(price, cucumberCount);
                    break;
                default:
                    Console.WriteLine("Невірний вибір продукту.");
                    return;
            }

            shop.AddProduct(product);
        }

        static void RemoveProduct(VegetableShop shop)
        {
            Console.WriteLine("Введіть номер продукту для видалення:");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                shop.RemoveProduct(index - 1);
            }
            else
            {
                Console.WriteLine("Невірний формат номера.");
            }
        }
    }
}