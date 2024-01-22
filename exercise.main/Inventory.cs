using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    internal class Inventory
    {
        private Dictionary<string, Item> items {  get; set; }
        public Inventory() 
        {
            items = new Dictionary<string, Item>();
            items.Add("BGLO", new Item("BGLO", "Bagel", "Onion", 0.49f));
            items.Add("BGLP", new Item("BGLP", "Bagel", "Plain", 0.39f));
            items.Add("BGLE", new Item("BGLE", "Bagel", "Everything", 0.49f));
            items.Add("BGLS", new Item("BGLS", "Bagel", "Sesame", 0.49f));
            items.Add("COFB", new Item("COFB", "Coffee", "Black", 0.99f));
            items.Add("COFW", new Item("COFW", "Coffee", "White", 1.19f));
            items.Add("COFC", new Item("COFC", "Coffee", "Cappucino", 1.29f));
            items.Add("COFL", new Item("COFL", "Coffee", "Latte", 1.29f));
            items.Add("FILB", new Item("FILB", "Filling", "Bacon", 0.12f));
            items.Add("FILE", new Item("FILE", "Filling", "Egg", 0.12f));
            items.Add("FILC", new Item("FILC", "Filling", "Cheese", 0.12f));
            items.Add("FILX", new Item("FILX", "Filling", "Cream Cheese", 0.12f));
            items.Add("FILS", new Item("FILS", "Filling", "Smoked Salmon", 0.12f));
            items.Add("FILH", new Item("FILH", "Filling", "Ham", 0.12f));

        }
        public Item getItem(string sku)
        {
            Item? item;

            items.TryGetValue(sku, out item);


            return item;
        }
        public bool isFilling(string sku)
        {
            bool result = false;
            Item? item;

            items.TryGetValue(sku, out item);

            if (item != null)
            {
                if (item._name == "Filling")
                {
                    result = true;
                }
            }

            return result;
        }
        public List<Item> giveFillings()
        {
            List<Item> fillings = new List<Item>();


            foreach(KeyValuePair<string,Item> kvp in items)
            {
                if(kvp.Value._name == "Filling")
                {
                    fillings.Add(kvp.Value);
                }
            }

            return fillings;
        }
    }
}
