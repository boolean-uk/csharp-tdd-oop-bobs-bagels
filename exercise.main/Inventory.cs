using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        
        private List<Item> _items = new List<Item>();
        public List<Item> Items { get { return _items; } }

        public Inventory() {

            _items.Add(new Item("BGLO", 0.49, "Bagel", "Onion"));
            _items.Add(new Item("BGLP", 0.39, "Bagel", "Plain"));
            _items.Add(new Item("BGLE", 0.49, "Bagel", "Everything"));
            _items.Add(new Item("BGLS", 0.49, "Bagel", "Sesame"));
            _items.Add(new Item("COFB", 0.99, "Coffee", "Black"));
            _items.Add(new Item("COFW", 1.19, "Coffee", "White"));
            _items.Add(new Item("COFC", 1.29, "Coffee", "Cappucino"));
            _items.Add(new Item("COFL", 1.29, "Coffee", "Latte"));
            _items.Add(new Item("FILE", 0.12, "Filling", "Egg"));
            _items.Add(new Item("FILC", 0.12, "Filling", "Cheese"));
            _items.Add(new Item("FILX", 0.12, "Filling", "Cream Cheese"));
            _items.Add(new Item("FILS", 0.12, "Filling", "Smoked Salmon"));
            _items.Add(new Item("FILH", 0.12, "Filling", "Ham"));
        
        }


        
        

        

    }
}
