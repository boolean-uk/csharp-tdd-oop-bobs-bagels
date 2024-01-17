using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private int _capacity;
        public List<Item> content;
        private Dictionary<string, Item> itemList;
        public Receipt receipt;
        public Basket(int capacity)
        {
            _capacity = capacity;
            content = new List<Item>();
            receipt = new Receipt();
            itemList = new Dictionary<string, Item>();
            itemList.Clear();
            itemList.Add("BGLO", new Item(0.49f, "Bagel", "Onion"));
            itemList.Add("BGLP", new Item(0.39f, "Bagel", "Plain"));
            itemList.Add("BGLE", new Item(0.49f, "Bagel", "Everything"));
            itemList.Add("BGLS", new Item(0.49f, "Bagel", "Sesame"));
            itemList.Add("COFB", new Item(0.99f, "Coffee", "Black"));
            itemList.Add("COFW", new Item(1.19f, "Coffee", "White"));
            itemList.Add("COFC", new Item(1.29f, "Coffee", "Capuccino"));
            itemList.Add("COFL", new Item(0.29f, "Coffee", "Latte"));
            itemList.Add("FILB", new Item(0.12f, "Filling", "Bacon"));
            itemList.Add("FILE", new Item(0.12f, "Filling", "Egg"));
            itemList.Add("FILC", new Item(0.12f, "Filling", "Cheese"));
            itemList.Add("FILX", new Item(0.12f, "Filling", "Cream Cheese"));
            itemList.Add("FILS", new Item(0.12f, "Filling", "Smoked Salmon"));
            itemList.Add("FILH", new Item(0.12f, "Filling", "Ham"));
        }
        public Item addItem(string SKU)
        {
            if (content.Count < _capacity)
            {
                content.Add(itemList[SKU]);
                receipt.addCost(SKU);
                return itemList[SKU];
            }
            else
            {
                Console.WriteLine("Your basket is full! No new items added!");
                return itemList[SKU];
            }
        }
        public bool removeItem(string SKU)
        {
            if (content.Contains(itemList[SKU]))
            {
                content.Remove(itemList[SKU]);
                return true;
            }
            Console.WriteLine("It is already not in your basket, great!");
            return false;
        }
        public int changeCapacity(int newCapacity)
        {
            return newCapacity;
        }
    }
}