using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        
        private List<Item> _inventory = new List<Item>();
        public List<Item> Items { get { return _inventory; } }

        public Inventory() {

            _inventory.Add(new Item("BGLO", 0.49, "Bagel", "Onion"));
            _inventory.Add(new Item("BGLP", 0.39, "Bagel", "Plain"));
            _inventory.Add(new Item("BGLE", 0.49, "Bagel", "Everything"));
            _inventory.Add(new Item("BGLS", 0.49, "Bagel", "Sesame"));
            _inventory.Add(new Item("COFB", 0.99, "Coffee", "Black"));
            _inventory.Add(new Item("COFW", 1.19, "Coffee", "White"));
            _inventory.Add(new Item("COFC", 1.29, "Coffee", "Cappucino"));
            _inventory.Add(new Item("COFL", 1.29, "Coffee", "Latte"));
            _inventory.Add(new Item("FILE", 0.12, "Filling", "Egg"));
            _inventory.Add(new Item("FILC", 0.12, "Filling", "Cheese"));
            _inventory.Add(new Item("FILX", 0.12, "Filling", "Cream Cheese"));
            _inventory.Add(new Item("FILS", 0.12, "Filling", "Smoked Salmon"));
            _inventory.Add(new Item("FILH", 0.12, "Filling", "Ham"));
        
        }

        public Item GetItembySku(string sku)
        {
            return _inventory.Find(item => item.Sku == sku);
        }


        
        

        

    }
}
