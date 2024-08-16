using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace exercise.main
{
    public class BobsBagelStore
    {
        private List<Item> _inventory = new List<Item>();
        private List<Basket> _baskets = new List<Basket>();

        public bool AddBasket(Basket basket)
        {
            if (basket == null) return false;
            if (_baskets.Contains(basket)) return false;
            _baskets.Add(basket);
            return true;
        }

        public Item? GetItem(string sku)
        {
            return _inventory.Find(item => item.SKU == sku);
        }

        public void StockUpInventory()
        {
            _inventory = new List<Item>();
            _inventory.Add(new Item("BGLO", 0.49f, "Bagel", "Onion"));
            _inventory.Add(new Item("BGLP", 0.39f, "Bagel", "Plain"));
            _inventory.Add(new Item("BGLE", 0.49f, "Bagel", "Everything"));
            _inventory.Add(new Item("BGLS", 0.49f, "Bagel", "Sesame"));
            _inventory.Add(new Item("COFB", 0.99f, "Coffee", "Black"));
            _inventory.Add(new Item("COFW", 1.19f, "Coffee", "White"));
            _inventory.Add(new Item("COFC", 1.29f, "Coffee", "Capuccino"));
            _inventory.Add(new Item("COFL", 1.29f, "Coffee", "Latte"));
            _inventory.Add(new Item("FILB", 0.12f, "Filling", "Bacon"));
            _inventory.Add(new Item("FILE", 0.12f, "Filling", "Egg"));
            _inventory.Add(new Item("FILC", 0.12f, "Filling", "Cheese"));
            _inventory.Add(new Item("FILX", 0.12f, "Filling", "Cream Cheese"));
            _inventory.Add(new Item("FILS", 0.12f, "Filling", "Smoked Salmon"));
            _inventory.Add(new Item("FILH", 0.12f, "Filling", "Ham"));
        }

        public bool ViewInventory()
        {
            Console.WriteLine("| SKU  | Price |   Name  |   Variant   |");
            Console.WriteLine("|------|-------|---------|-------------|");
            foreach (Item item in _inventory)
            {
                Console.Write($"| {item.SKU} ");
                Console.Write("| {0:C2} ", item.Price.ToString("C", new CultureInfo("en-GB")));
                Console.Write("| {0} ", item.Name.Length > 8 ? item.Name.Substring(0, 8) : item.Name);
                int spacesAmount = 7 - item.Name.Length;
                for (int i = 0; i < spacesAmount; i++) { Console.Write(" "); }
                Console.Write("| {0} ", item.Variant.Length > 11 ? item.Variant.Substring(0, 11) : item.Variant);
                spacesAmount = 11 - item.Variant.Length;
                for (int i = 0; i < spacesAmount; i++) { Console.Write(" "); }
                Console.Write("|\n");
            }
            return true;
        }
    }
}
