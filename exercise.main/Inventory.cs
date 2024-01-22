using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        public List<Product> Products { get; set; }

        public Inventory() 
        {
            Products = new List<Product>();
            Populate(); 
        }

        public void Populate()
        {
            Products.Add(new Bagel("BGLO", 0.49, "Onion"));
            Products.Add(new Bagel("BGLP", 0.39, "Plain"));
            Products.Add(new Bagel("BGLE", 0.49, "Everything"));
            Products.Add(new Bagel("BGLS", 0.49, "Sesame"));
            Products.Add(new Coffee("COFB", 0.99, "Black"));
            Products.Add(new Coffee("COFW", 1.19, "White"));
            Products.Add(new Coffee("COFC", 1.29, "Cappuccino"));
            Products.Add(new Coffee("COFL", 1.29, "Latte"));
            Products.Add(new Filling("FILB", 0.12, "Bacon"));
            Products.Add(new Filling("FILE", 0.12, "Egg"));
            Products.Add(new Filling("FILC", 0.12, "Cheese"));
            Products.Add(new Filling("FILX", 0.12, "Cream Cheese"));
            Products.Add(new Filling("FILS", 0.12, "Smoked Salmon"));
            Products.Add(new Filling("FILH", 0.12, "Ham"));
        }
    }
}
