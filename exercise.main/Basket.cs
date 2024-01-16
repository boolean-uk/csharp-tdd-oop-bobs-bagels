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
        private Dictionary<string, Item> priceList;
        public Basket(int capacity)
        {
            _capacity = capacity;
            content =  new List<Item>();
            priceList = new Dictionary<string, Item>();
            priceList.Clear();
            priceList.Add("BGLO", new Item(0.49f, "Bagel", "Onion"));
            priceList.Add("BGLP", new Item(0.39f, "Bagel", "Plain"));
            priceList.Add("BGLE", new Item(0.49f, "Bagel", "Everything"));
            priceList.Add("BGLS", new Item(0.49f, "Bagel", "Sesame"));
            priceList.Add("COFB", new Item(0.99f, "Coffee", "Black"));
            priceList.Add("COFW", new Item(1.19f, "Coffee", "White"));
            priceList.Add("COFC", new Item(1.29f, "Coffee", "Capuccino"));
            priceList.Add("COFL", new Item(0.29f, "Coffee", "Latte"));
            priceList.Add("FILB", new Item(0.12f, "Filling", "Bacon"));
            priceList.Add("FILE", new Item(0.12f, "Filling", "Egg"));
            priceList.Add("FILC", new Item(0.12f, "Filling", "Cheese"));
            priceList.Add("FILX", new Item(0.12f, "Filling", "Cream Cheese"));
            priceList.Add("FILS", new Item(0.12f, "Filling", "Smoked Salmon"));
            priceList.Add("FILH", new Item(0.12f, "Filling", "Ham"));
        }
        public Item addItem(string SKU)
        {
            if (content.Count < _capacity)
            {
                content.Add(priceList[SKU]);
                return priceList[SKU];
            }
            else
            {
                throw new Exception("Your basket is full! No new items added!");
            }
        }
        public bool removeItem(string SKU)
        {
            if (content.Contains(priceList[SKU]))
            {
                content.Remove(priceList[SKU]);
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