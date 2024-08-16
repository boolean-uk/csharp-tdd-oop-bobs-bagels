using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        //List with all base products
        public List<Product> baseProducts = new List<Product>();

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

        public bool Find(string product)
        {
            //Attempt to find a product with the same key
            foreach(Product p in baseProducts)
            {
                if(p.info.key == product) return true;
            }
            return false;
        }

        public Product GetProduct(string product)
        {
            //Attempt to find a product with the same key
            foreach (Product p in baseProducts)
            {
                if (p.info.key == product)
                {
                    return p;
                }
            }
            //Throw Exception as this part should not be reached unless a big mistake happened
            throw new Exception();
        }
    }
}
