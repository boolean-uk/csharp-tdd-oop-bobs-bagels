using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {
        
        private List<Item> _shopInventory = new List<Item>();
        public List<Item> ShopInventory { get { return _shopInventory; } }

        public Inventory() {

            _shopInventory.Add(new Item("BGLO", 0.49, "Bagel", "Onion"));
            _shopInventory.Add(new Item("BGLP", 0.39, "Bagel", "Plain"));
            _shopInventory.Add(new Item("BGLE", 0.49, "Bagel", "Everything"));
            _shopInventory.Add(new Item("BGLS", 0.49, "Bagel", "Sesame"));
            _shopInventory.Add(new Item("COFB", 0.99, "Coffee", "Black"));
            _shopInventory.Add(new Item("COFW", 1.19, "Coffee", "White"));
            _shopInventory.Add(new Item("COFC", 1.29, "Coffee", "Cappucino"));
            _shopInventory.Add(new Item("COFL", 1.29, "Coffee", "Latte"));
            _shopInventory.Add(new Item("FILB", 0.12, "Filling", "Bacon"));
            _shopInventory.Add(new Item("FILE", 0.12, "Filling", "Egg"));
            _shopInventory.Add(new Item("FILC", 0.12, "Filling", "Cheese"));
            _shopInventory.Add(new Item("FILX", 0.12, "Filling", "Cream Cheese"));
            _shopInventory.Add(new Item("FILS", 0.12, "Filling", "Smoked Salmon"));
            _shopInventory.Add(new Item("FILH", 0.12, "Filling", "Ham"));
        
        }

        public Item GetItembySku(string sku)
        {
            return _shopInventory.Find(item => item.Sku == sku);
        }







    }
}
