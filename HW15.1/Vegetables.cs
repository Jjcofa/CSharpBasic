using System;

namespace VegetableShop
{
    public abstract class Product
    {
        public string Name { get; }
        public double Price { get; }

        protected Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public abstract double GetTotalPrice();
    }

    public class Carrot : Product
    {
        public Carrot(double price) : base("Морква", price) { }

        public override double GetTotalPrice()
        {
            return Price;
        }
    }

    public class Potato : Product
    {
        public double Count { get; }

        public Potato(double price, double count) : base("Картопля", price)
        {
            Count = count;
        }

        public override double GetTotalPrice()
        {
            return Price * Count;
        }
    }

    public class Tomato : Product
    {
        public Tomato(double price) : base("Помідор", price) { }

        public override double GetTotalPrice()
        {
            return Price;
        }
    }

    public class Cucumber : Product
    {
        public double Count { get; }

        public Cucumber(double price, double count) : base("Огірок", price)
        {
            Count = count;
        }

        public override double GetTotalPrice()
        {
            return Price * Count;
        }
    }
}