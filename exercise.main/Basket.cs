using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using item.main;
using inventory.main;
using System.Reflection.Emit;

namespace basket.main
{
    //private Dicitonary to find items in Inventory List

    public class Basket
    {
        private List<Item> _items;
        private Inventory _inventory;

        public List<Item> Items => _items;
        public Basket(int basketCapacity) 
        {
            _items = new List<Item>();
            _inventory = new Inventory();

        }
        public bool AddItemToBasket(string sku)
        {
            // check if sku exists in inventory's Stock Dictionary
            if(_inventory.Stock.ContainsKey(sku))
            {
                Item item = _inventory.Stock[sku];
                _items.Add(item);
                // if exists get the matching sku - Item object from the inventory's stong using sku as a keyvalue
                //_items.Add(_inventory.Stock[sku]);
                // print message of which item and which variant is added to your order to see if right.
                Console.WriteLine($"- {sku}: {item.Name} {item.Variant} is added to your order.");
                return true;
            }
            Console.WriteLine($"{sku} is not added to your basket");
            return false;
        }

        public bool RemoveItem(string sku)
        {
            if (_inventory.Stock.ContainsKey(sku))
            {
                Item item = _inventory.Stock[sku];
                _items.Remove(item);
                Console.WriteLine($"{item.Name} {item.Variant} is removed from your order.");
                return true;
            }
            return false;
        }

    }
}
