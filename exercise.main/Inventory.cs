using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Inventory
    {

        private Dictionary<string, Item> items = new Dictionary<string, Item>();

        public Inventory()
        {
            items.Add("BGLO", new Item(0.49f, "Bagel", "Onion", "BGLO"));
            items.Add("BGLP", new Item(0.39f, "Bagel", "Plain", "BGLP"));
            items.Add("BGLE", new Item(0.49f, "Bagel", "Everything", "BLE"));
            items.Add("BGLS", new Item(0.49f, "Bagel", "Sesame", "BGLS"));
            items.Add("COFB", new Item(0.99f, "Coffee", "Black", "COFB"));
            items.Add("COFW", new Item(1.19f, "Coffee", "White", "COFW"));
            items.Add("COFC", new Item(1.29f, "Coffee", "Capuccino", "COFC"));
            items.Add("COFL", new Item(1.29f, "Coffe", "Latte", "COFL"));
            items.Add("FILB", new Item(0.12f, "Filling" , "Bacon", "FILB"));
            items.Add("FILE", new Item(0.12f, "Filling", "Egg", "FILE"));
            items.Add("FILC", new Item(0.12f, "Filling", "Cheese", "FILC"));
            items.Add("FILX", new Item(0.12f, "Filling", "CreamCheese", "FILX"));
            items.Add("FILS", new Item(0.12f, "Filling", "SmokedSalmon", "FILS"));
            items.Add("FILH", new Item(0.12f, "Filling", "Ham", "FILH"));
        }

        public bool ContainsProduct(string productSKU)
        {
            return items.ContainsKey(productSKU);
        }

        public Item GetProduct(string productSKU)
        {
            if (items.TryGetValue(productSKU, out Item product))
            {
                return product;
            }
            else
            {
                return null;
            }
        }

    }
}
