using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    public class Bank
    {
        private List<Account> accounts = new List<Account>();

        public Bank()
        {
            CreateAccount("Основний");
        }

        public void CreateAccount(string name)
        {
            if (accounts.Exists(a => a.Name == name))
            {
                Console.WriteLine($"Рахунок з назвою '{name}' вже існує. Введіть унікальну назву.");
                return;
            }

            var account = new Account(name, 0);
            accounts.Add(account);
            Console.WriteLine($"Рахунок '{name}' створено з початковим балансом 0.");
        }

        public void Transfer(string fromAccountName, string toAccountName, double amount)
        {
            var fromAccount = accounts.Find(a => a.Name == fromAccountName);
            var toAccount = accounts.Find(a => a.Name == toAccountName);

            if (fromAccount == null || toAccount == null)
            {
                Console.WriteLine("Один з рахунків не знайдено.");
                return;
            }

            try
            {
                fromAccount.Withdrawal(amount);
                toAccount.Deposit(amount);
                Console.WriteLine($"Переказ {amount} з рахунку '{fromAccountName}' на рахунок '{toAccountName}' успішно виконано.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка під час переказу: {ex.Message}");
            }
        }

        public Account GetAccount(string name)
        {
            return accounts.Find(a => a.Name == name);
        }

        public void ListAccounts()
        {
            if (accounts.Count == 0)
            {
                Console.WriteLine("Рахунків немає.");
                return;
            }

            Console.WriteLine("Список рахунків:");
            foreach (var account in accounts)
            {
                Console.WriteLine($"- {account.Name}: {account.Balance}");
            }
        }
    }
}