using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class BobsInventory
    {
        // property 
        public List<Item> Inventory { get; set; } = new List<Item>();

        // constructor - adds items to _Inventory when class in instantiated
        public BobsInventory()
        {
            Inventory.Add(new Bagel("BGLO", 0.49, "Bagel", "Onion"));
            Inventory.Add(new Bagel("BGLP", 0.39, "Bagel", "Plain"));
            Inventory.Add(new Bagel("BGLE", 0.49, "Bagel", "Everything"));
            Inventory.Add(new Bagel("BGLS", 0.49, "Bagel", "Sesame"));
            Inventory.Add(new Coffee("COFB", 0.99, "Coffee", "Black"));
            Inventory.Add(new Coffee("COFW", 1.19, "Coffee", "White"));
            Inventory.Add(new Coffee("COFC", 1.29, "Coffee", "Cappucino"));
            Inventory.Add(new Coffee("COFL", 1.29, "Coffee", "Latte"));
            Inventory.Add(new Filling("FILB", 0.12, "Filling", "Bacon"));
            Inventory.Add(new Filling("FILE", 0.12, "Filling", "Egg"));
            Inventory.Add(new Filling("FILC", 0.12, "Filling", "Cheese"));
            Inventory.Add(new Filling("FILX", 0.12, "Filling", "Cream Cheese"));
            Inventory.Add(new Filling("FILS", 0.12, "Filling", "Smoked Salmon"));
            Inventory.Add(new Filling("FILH", 0.12, "Filling", "Ham"));
        }
    }
}


    