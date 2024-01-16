using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
   
    public class Basket
    {
        private List<Item> _items;
        private int _basketSize;

        public Basket() {
            _items = new List<Item>();
            _basketSize = 10;
        }

        public Basket(int basketSize)
        {
            _basketSize = basketSize;
            _items = new List<Item>();
        }

        public string PutInBasket(Item item)
        {
            if (!DefaultInventory.Inventory.Contains(item))
            {
                return $"{item.Variant} is not in inventory";
            }
            else if (items.Count >= _basketSize)
            {
                return "Basket is full";
            } 
            else
            {
                _items.Add(item);
                return $"{item.Variant} is added to basket";
            }
        }

        public string RemoveFromBasket(Item item)
        {
            if (_items.Contains(item))
            {
                _items.Remove(item);
                return $"{item.Variant} is removed from basket";
            } else
            {
                return "There is no such item in basket";
            }

        }

        public void ChangeBasketCapacity(int NewBasketSize)
        {
            _basketSize = NewBasketSize;
        }

        public double SumTotal()
        {
            return _items.Sum(item => item.Price);
        }
        
        public List<Item> items { get => _items; }
    }
}
