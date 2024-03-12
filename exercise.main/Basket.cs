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
        public Basket(int basketCapacity) 
        {
            _items = new List<Item>();
            _inventory = new Inventory();

        }
        public bool AddItemToBasket(string sku)
        {
            return false;
        }
    }
}
