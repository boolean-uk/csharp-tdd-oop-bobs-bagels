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
            new Product("BGLO", 0.49m, "Bagel", "Onion"),
            new Product("BGLP", 0.39m, "Bagel", "Plain"),
            new Product("BGLE", 0.49m, "Bagel", "Everything"),
            new Product("BGLS", 0.49m, "Bagel", "Sesame"),
            new Product("COFB", 0.99m, "Coffee", "Black"),
            new Product("COFW", 1.19m, "Coffee", "White"),
            new Product("COFC", 1.29m, "Coffee", "Capuccino"),
            new Product("COFL", 1.29m, "Coffee", "Latte"),
            new Product("FILB", 0.12m, "Filling", "Bacon"),
            new Product("FILE", 0.12m, "Filling", "Egg"),
            new Product("FILC", 0.12m, "Filling", "Cheese"),
            new Product("FILX", 0.12m, "Filling", "Cream Cheese"),
            new Product("FILS", 0.12m, "Filling", "Smoked Salmon"),
            new Product("FILH", 0.12m, "Filling", "Ham")
        };


    }
}
