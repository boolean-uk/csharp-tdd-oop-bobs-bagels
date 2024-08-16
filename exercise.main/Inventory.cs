using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise
{
    public class Inventory
    {
        public List<Product> Items { get; set; } = new List<Product>()
        {
            new Product("BGLO", 0.49, "Bagel", "Onion"),
            new Product("BGLP", 0.39, "Bagel", "Plain"),
            new Product("BGLE", 0.49, "Bagel", "Everything"),
            new Product("BGLS", 0.49, "Bagel", "Sesame"),
            new Product("COFB", 0.99, "Coffee", "Black"),
            new Product("COFW", 1.19, "Coffee", "White"),
            new Product("COFC", 1.29, "Coffee", "Capuccino"),
            new Product("COFL", 1.29, "Coffee", "Latte"),
            new Product("FILB", 0.12, "Filling", "Bacon"),
            new Product("FILE", 0.12, "Filling", "Egg"),
            new Product("FILC", 0.12, "Filling", "Cheese"),
            new Product("FILX", 0.12, "Filling", "Cream Cheese"),
            new Product("FILS", 0.12, "Filling", "Smoked Salmon"),
            new Product("FILH", 0.12, "Filling", "Ham")
        };


    }
}
