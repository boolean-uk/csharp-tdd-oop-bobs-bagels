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
            if (_basketCapacity <= SumOfItems())
            {
                return false;
            }

            Item? itemFound = GetItem(newItem.SKU);
            if (itemFound == null)
            {
                _items.Add(newItem, 1);
                return true;
            }
            else
            {
                _items[itemFound]++;
                return true;
            }
        }

        private Item? GetItem(string sku)
        {
            List<Item> itemsFound = _items.Where(item => item.Key.SKU == sku).Select(item => item.Key).ToList();
            if (itemsFound.Count == 0) return null;
            return itemsFound[0];
        }

        public bool RemoveItem(string sku)
        {
            Item? itemFound = GetItem(sku);
            if (itemFound == null)
            {
                return false;
            }

            if (_items[itemFound] > 1)
            {
                _items[itemFound]--;
            }
            else
            {
                _items.Remove(itemFound);
            }
            return true;
        }

        public int SumOfItems()
        {
            return _items.Sum(item => item.Value);
        }
    }
}
