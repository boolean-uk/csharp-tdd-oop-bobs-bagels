using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        public List<Item> _inventory = new List<Item>();
        
        public List<Item> getInventory() 
        { 
            _inventory.Add(new Item("BGLO", "Bagel", 0.49, "Onion"));
            _inventory.Add(new Item("BGLP", "Bagel", 0.39, "Plain"));
            _inventory.Add(new Item("BGLE", "Bagel", 0.49, "Everything"));
            _inventory.Add(new Item("BGLS", "Bagel", 0.49, "Sesame"));
            _inventory.Add(new Item("COFB", "Coffee", 0.99, "Black"));
            _inventory.Add(new Item("COFW", "Coffee", 1.19, "White"));
            _inventory.Add(new Item("COFC", "Coffee", 1.29, "Capuccino"));
            _inventory.Add(new Item("COFL", "Coffee", 1.29, "Latte"));
            _inventory.Add(new Item("FILB", "Filling", 0.12, "Bacon"));
            _inventory.Add(new Item("FILE", "Filling", 0.12, "Egg"));
            _inventory.Add(new Item("FILC", "Filling", 0.12, "Cheese"));
            _inventory.Add(new Item("FILX", "Filling", 0.12, "Chream Cheese"));
            _inventory.Add(new Item("FILS", "Filling", 0.12, "Smoked Salmon"));
            _inventory.Add(new Item("FILH", "Filling", 0.12, "Ham"));

            return _inventory; 
        }

        public bool isAvaiable(string v)
        {
            throw new NotImplementedException();
        }
    }
}
