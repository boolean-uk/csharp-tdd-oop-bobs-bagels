using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory : Manager
    {
        public struct Base //The base of a product
        {
            public string key;
            public float price;
            public string name;
            public string variant;

            public Base(string key, float price, string name, string variant)
            {
                this.key = key;
                this.price = price;
                this.name = name;
                this.variant = variant;
            }
        }

        //List with all base products
        List<Product> baseProducts = new List<Product>();

        public Inventory() 
        {
            baseProducts.Add(new Product(new Base("BGLO", 0.49f, "Bagel", "Onion")));
            baseProducts.Add(new Product(new Base("BGLP", 0.39f, "Bagel", "Plain")));
            baseProducts.Add(new Product(new Base("BGLE", 0.49f, "Bagel", "Everything")));
            baseProducts.Add(new Product(new Base("BGLS", 0.49f, "Bagel", "Sesame")));
            baseProducts.Add(new Product(new Base("COFB", 0.99f, "Coffee", "Black")));
            baseProducts.Add(new Product(new Base("COFW", 1.19f, "Coffee", "White")));
            baseProducts.Add(new Product(new Base("COFC", 1.29f, "Coffee", "Capuccino")));
            baseProducts.Add(new Product(new Base("COFL", 1.29f, "Coffee", "Latte")));
            baseProducts.Add(new Product(new Base("FILB", 0.12f, "Filling", "Bacon")));
            baseProducts.Add(new Product(new Base("FILE", 0.12f, "Filling", "Egg")));
            baseProducts.Add(new Product(new Base("FILC", 0.12f, "Filling", "Cheese")));
            baseProducts.Add(new Product(new Base("FILX", 0.12f, "Filling", "Cream Cheese")));
            baseProducts.Add(new Product(new Base("FILS", 0.12f, "Filling", "Smoked Salmon")));
            baseProducts.Add(new Product(new Base("FILH", 0.12f, "Filling", "Ham")));
        }

    }
}
