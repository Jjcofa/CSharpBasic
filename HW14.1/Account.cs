using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    public class Account
    {
        public string Name { get; }
        public double Balance { get; private set; }

        public Account(string name, double initialBalance)
        {
            Name = name;
            if (initialBalance < 0)
            {
                throw new ArgumentException("Початковий баланс не може бути менше 0.");
            }
            Balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сума для додавання повинна бути більше 0.");
            }
            Balance += amount;
        }

        public void Withdrawal(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сума для зняття повинна бути більше 0.");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Недостатньо коштів на рахунку.");
            }
            Balance -= amount;
        }
    }
}