using System;
using System.Collections.Generic;

namespace VegetableShop
{
    public class VegetableShop
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
            Console.WriteLine($"Продукт '{product.Name}' додано до магазину.");
        }
        public void RemoveProduct(int index)
        {
            if (index >= 0 && index < products.Count)
            {
                var product = products[index];
                products.RemoveAt(index);
                Console.WriteLine($"Продукт '{product.Name}' видалено з магазину.");
            }
            else
            {
                Console.WriteLine("Невірний індекс продукту.");
            }
        }

        public void PrintProductsInfo()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Магазин порожній.");
                return;
            }

            Console.WriteLine("Інформація про продукти:");
            double totalPrice = 0;

            for (int i = 0; i < products.Count; i++)
            {
                var product = products[i];
                double totalProductPrice = product.GetTotalPrice();
                totalPrice += totalProductPrice;

                if (product is Potato || product is Cucumber)
                {
                    Console.WriteLine($"{i + 1}. Product: {product.Name}, Price: {product.Price}, Count: {((dynamic)product).Count}, Total price: {totalProductPrice}");
                }
                else
                {
                    Console.WriteLine($"{i + 1}. Product: {product.Name}, Price: {product.Price}, Total price: {totalProductPrice}");
                }
            }

            Console.WriteLine($"Загальна вартість всіх продуктів: {totalPrice}");
        }
    }
}