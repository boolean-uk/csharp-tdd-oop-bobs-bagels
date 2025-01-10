using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public static class Inventory
    {
        public static List<Item> InventoryItems { get; set; } = new List<Item>()
        {
            new Bagel("BGLO", 0.49d, "Bagel", "Onion"),
            new Bagel("BGLP", 0.39d, "Bagel", "Plain"),
            new Bagel("BGLE", 0.49d, "Bagel", "Everything"),
            new Bagel("BGLS", 0.49d, "Bagel", "Sesame"),
            new Coffee("COFB", 0.99d, "Coffee", "Black"),
            new Coffee("COFW", 1.19d, "Coffee", "White"),
            new Coffee("COFC", 1.29d, "Coffee", "Capuccino"),
            new Coffee("COFL", 1.29d, "Coffee", "Latte"),
            new Filling("FILB", 0.12d, "Filling", "Bacon"),
            new Filling("FILE", 0.12d, "Filling", "Egg"),
            new Filling("FILC", 0.12d, "Filling", "Cheese"),
            new Filling("FILX", 0.12d, "Filling", "Cream Cheese"),
            new Filling("FILS", 0.12d, "Filling", "Smoked Salmon"),
            new Filling("FILH", 0.12d, "Filling", "Ham")
        };   
    }
}
