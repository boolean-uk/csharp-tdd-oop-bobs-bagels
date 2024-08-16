using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private int _basketCapacity;
        private Dictionary<Item, int> _items = new Dictionary<Item, int>();

        public Basket(int basketCapacity = 3)
        {
            _basketCapacity = basketCapacity;
        }
        
        public bool AddItem(Item newItem)
        {
            if (_basketCapacity <= _items.Sum(item => item.Value))
            {
                return false;
            }

            Item? itemExists = FindItem(newItem.SKU);
            if (itemExists == null)
            {
                _items.Add(newItem, 1);
                return true;
            }
            else
            {
                _items[itemExists]++;
                return true;
            }
        }

        private Item? FindItem(string sku)
        {
            List<Item> itemsFound = _items.Where(item => item.Key.SKU == sku).Select(item => item.Key).ToList();
            if (itemsFound.Count == 0) return null;
            return itemsFound[0];
        }

        public bool RemoveItem(string sKU)
        {
            return false;
        }

        public int BasketCapacity { get { return _basketCapacity; } }
    }
}
