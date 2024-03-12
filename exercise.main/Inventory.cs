
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using item.main;

namespace inventory.main
{
    public class Inventory
    {
        private Dictionary<string, Item> _stock;
        public Dictionary<string, Item> Stock => _stock;

        public Inventory()
        {
            _stock = new Dictionary<string, Item>();
            _stock.Add("BGLO", new Item("BGLO", 0.49, "Bagel", "Onion"));
            _stock.Add("BGLP", new Item("BGLP", 0.39, "Bagel", "Plain"));
            _stock.Add("BGLE", new Item("BGLE", 0.49, "Bagel", "Everything"));
            _stock.Add("BGLS", new Item("BGLS", 0.49, "Bagel", "Sesame"));
            _stock.Add("COFB", new Item("COFB", 0.99, "Coffee", "Black"));
            _stock.Add("COFW", new Item("COFW", 1.19, "Coffee", "White"));
            _stock.Add("COFC", new Item("COFC", 1.29, "Coffee", "Cappuccino"));
            _stock.Add("COFL", new Item("COFL", 1.29, "Coffee", "Latte"));
            _stock.Add("FILB", new Item("FILB", 0.12, "Filling", "Bacon"));
            _stock.Add("FILE", new Item("FILE", 0.12, "Filling", "Egg"));
            _stock.Add("FILC", new Item("FILC", 0.12, "Filling", "Cheese"));
            _stock.Add("FILX", new Item("FILX", 0.12, "Filling", "Cream Cheese"));
            _stock.Add("FILS", new Item("FILS", 0.12, "Filling", "Smoked Salmon"));
            _stock.Add("FILH", new Item("FILH", 0.12, "Filling", "Ham"));
        }
    }
}
