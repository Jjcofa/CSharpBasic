using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Bank bank = new Bank();

            while (true)
            {
                Console.WriteLine("\nОберіть дію:");
                Console.WriteLine("1. Створити новий рахунок");
                Console.WriteLine("2. Переглянути список рахунків");
                Console.WriteLine("3. Додати кошти на рахунок");
                Console.WriteLine("4. Зняти кошти з рахунку");
                Console.WriteLine("5. Переказати кошти між рахунками");
                Console.WriteLine("6. Вийти");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateAccount(bank);
                        break;
                    case "2":
                        bank.ListAccounts();
                        break;
                    case "3":
                        DepositMoney(bank);
                        break;
                    case "4":
                        WithdrawMoney(bank);
                        break;
                    case "5":
                        TransferMoney(bank);
                        break;
                    case "6":
                        Console.WriteLine("Дякуємо за використання нашого банку!");
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        static void CreateAccount(Bank bank)
        {
            Console.WriteLine("Введіть назву рахунку:");
            string name = Console.ReadLine();
            bank.CreateAccount(name);
        }

        static void DepositMoney(Bank bank)
        {
            Console.WriteLine("Введіть назву рахунку:");
            string name = Console.ReadLine();
            Console.WriteLine("Введіть суму для додавання:");
            if (double.TryParse(Console.ReadLine(), out double amount))
            {
                var account = bank.GetAccount(name);
                if (account != null)
                {
                    try
                    {
                        account.Deposit(amount);
                        Console.WriteLine($"Сума {amount} успішно додана. Новий баланс: {account.Balance}");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Рахунок не знайдено.");
                }
            }
            else
            {
                Console.WriteLine("Невірний формат суми.");
            }
        }

        static void WithdrawMoney(Bank bank)
        {
            Console.WriteLine("Введіть назву рахунку:");
            string name = Console.ReadLine();
            Console.WriteLine("Введіть суму для зняття:");
            if (double.TryParse(Console.ReadLine(), out double amount))
            {
                var account = bank.GetAccount(name);
                if (account != null)
                {
                    try
                    {
                        account.Withdrawal(amount);
                        Console.WriteLine($"Сума {amount} успішно знята. Новий баланс: {account.Balance}");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Рахунок не знайдено.");
                }
            }
            else
            {
                Console.WriteLine("Невірний формат суми.");
            }
        }

        static void TransferMoney(Bank bank)
        {
            Console.WriteLine("Введіть назву рахунку, з якого переказувати кошти:");
            string fromAccount = Console.ReadLine();
            Console.WriteLine("Введіть назву рахунку, на який переказувати кошти:");
            string toAccount = Console.ReadLine();
            Console.WriteLine("Введіть суму для переказу:");
            if (double.TryParse(Console.ReadLine(), out double amount))
            {
                bank.Transfer(fromAccount, toAccount, amount);
            }
            else
            {
                Console.WriteLine("Невірний формат суми.");
            }
        }
    }
}