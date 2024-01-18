using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Objects
{
    public class Inventory
    {
        public List<Product> items { get; } = new List<Product>
        {
            (new Product("BGLO", 0.49, Product.pType.Bagel, "Onion")),
            (new Product("BGLP", 0.39, Product.pType.Bagel, "Plain")),
            (new Product("BGLE", 0.49, Product.pType.Bagel, "Everything")),
            (new Product("BGLS", 0.49, Product.pType.Bagel, "Sesame")),
            (new Product("COFB", 0.99, Product.pType.Coffee, "Black")),
            (new Product("COFW", 1.19, Product.pType.Coffee, "White")),
            (new Product("COFC", 1.29, Product.pType.Coffee, "Cappuccino")),
            (new Product("COFL", 1.29, Product.pType.Coffee, "Latte")),
            (new Product("FILB", 0.12, Product.pType.Filling, "Bacon")),
            (new Product("FILE", 0.12, Product.pType.Filling, "Egg")),
            (new Product("FILC", 0.12, Product.pType.Filling, "Cheese")),
            (new Product("FILX", 0.12, Product.pType.Filling, "Cream Cheese")),
            (new Product("FILS", 0.12, Product.pType.Filling, "Smoked Salmon")),
            (new Product("FILH", 0.12, Product.pType.Filling, "Ham"))
        };
        public Inventory() { }
       
    }
}
