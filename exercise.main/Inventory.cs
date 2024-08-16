using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        public struct Product
        {
            public double price;
            public string name;
            public string variant;

            public Product(double price, string name, string variant)
            {
                this.price = price;
                this.name = name;
                this.variant = variant;
            }
        }
        Dictionary<string, Product> stock = new Dictionary<string, Product>();


        public Inventory()
        {
            Product product = new Product(0.49, "Bagel", "onion");
            stock.Add("BGLO", product);
            product = new Product(0.39, "Bagel", "Plain");
            stock.Add("BGLP", product);
            product = new Product(0.49, "Bagel", "Everything");
            stock.Add("BGLE", product);
            product = new Product(0.49, "Bagel", "Sesame");
            stock.Add("BGLS", product);
            product = new Product(0.99, "Coffee", "Black");
            stock.Add("COFB", product);
            product = new Product(1.19, "Coffee", "White");
            stock.Add("COFW", product);
            product = new Product(1.29, "Coffee", "Capuccino");
            stock.Add("COFC", product);
            product = new Product(1.29, "Coffee", "Latte");
            stock.Add("COFL", product);
            product = new Product(0.12, "Filling", "Bacon");
            stock.Add("FILB", product);
            product = new Product(0.12, "Filling", "Egg");
            stock.Add("FILE", product);
            product = new Product(0.12, "Filling", "Cheese");
            stock.Add("FILC", product);
            product = new Product(0.12, "Filling", "Cream Cheese");
            stock.Add("FILX", product);
            product = new Product(0.12, "Filling", "Smoked Salmon");
            stock.Add("FILS", product);
            product = new Product(0.12, "Filling", "Ham");
            stock.Add("FILH", product);
        }

        public bool IsInInventory(string name, string variant)
        {
            foreach (var product in stock)
            {
                if(product.Value.name == name && product.Value.variant == variant)
                {
                    return true;
                }
            }
            return false;
        }

        public double GetPrice(string name, string variant)
        {
            foreach (var product in stock)
            {
                if (product.Value.name == name && product.Value.variant == variant)
                {
                    return product.Value.price;
                }
            }
            return -1;
        }
    }
}
