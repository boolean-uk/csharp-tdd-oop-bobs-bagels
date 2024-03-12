using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using item.main;
using inventory.main;

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
                // if exists get the matching sku - Item object from the inventory's stong using sku as a keyvalue
                _items.Add(_inventory.Stock[sku]);
                return true;
            }
            return false;
        }
    }
}
