using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Inventory
    {
        private List<Item> _Inventory = new List<Item>();

        public void SetInventory()
        {
            _Inventory.Add(new Item("B1", "BGLO", 0.49f, "Bagel", "Onion"));
            _Inventory.Add(new Item("B2", "BGLP", 0.39f, "Bagel", "Plain"));
            _Inventory.Add(new Item("B3", "BGLE", 0.49f, "Bagel", "Everything"));
            _Inventory.Add(new Item("B4", "BGLS", 0.49f, "Bagel", "Sesame"));
            _Inventory.Add(new Item("C1", "COFB", 0.99f, "Coffee", "Black"));
            _Inventory.Add(new Item("C2", "COFW", 1.19f, "Coffee", "White"));
            _Inventory.Add(new Item("C3", "COFC", 1.29f, "Coffee", "Capuccino"));
            _Inventory.Add(new Item("C4", "COFL", 1.29f, "Coffee", "Latte"));
            _Inventory.Add(new Item("F1", "FILB", 0.12f, "Filling", "Bacon"));
            _Inventory.Add(new Item("F2", "FILE", 0.12f, "Filling", "Egg"));
            _Inventory.Add(new Item("F3", "FILC", 0.12f, "Filling", "Cheese"));
            _Inventory.Add(new Item("F4", "FILX", 0.12f, "Filling", "Cream Cheese"));
            _Inventory.Add(new Item("F5", "FILS", 0.12f, "Filling", "Smoked Salmon"));
            _Inventory.Add(new Item("F6", "FILH", 0.12f, "Filling", "Ham"));
        }

        public List<Item> Stock { get { return _Inventory.ToList(); } }
    }
}
