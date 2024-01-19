using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
   {
        public List<Product> Products { get; } = new List<Product>();

       public Inventory()
       {
            Products.Add(new Bagel { SKU = "BGLO", Price = 0.49m, Name = "Bagel", Variant = "Onion" });
            Products.Add(new Bagel { SKU = "BGLP", Price = 0.39m, Name = "Bagel", Variant = "Plain" });
            Products.Add(new Bagel { SKU = "BGLE", Price = 0.49m, Name = "Bagel", Variant = "Everything" });
            Products.Add(new Bagel { SKU = "BGLS", Price = 0.49m, Name = "Bagel", Variant = "Sesame" });
            Products.Add(new Coffee { SKU = "COFB", Price = 0.99m, Name = "Coffee", Variant = "Black" });
            Products.Add(new Coffee { SKU = "COFW", Price = 1.19m, Name = "Coffee", Variant = "White" });
            Products.Add(new Coffee { SKU = "COFC", Price = 1.29m, Name = "Coffee", Variant = "Cappuccino" });
            Products.Add(new Coffee { SKU = "COFL", Price = 1.29m, Name = "Coffee", Variant = "Latte" });
            Products.Add(new Filling { SKU = "FILB", Price = 0.12m, Name = "Filling", Variant = "Bacon" });
            Products.Add(new Filling { SKU = "FILE", Price = 0.12m, Name = "Filling", Variant = "Egg" });
            Products.Add(new Filling { SKU = "FILC", Price = 0.12m, Name = "Filling", Variant = "Cheese" });
            Products.Add(new Filling { SKU = "FILX", Price = 0.12m, Name = "Filling", Variant = "Cream Cheese" });
            Products.Add(new Filling { SKU = "FILS", Price = 0.12m, Name = "Filling", Variant = "Smoked Salmon" });
            Products.Add(new Filling { SKU = "FILH", Price = 0.12m, Name = "Filling", Variant = "Ham" });
       }
    }
}


