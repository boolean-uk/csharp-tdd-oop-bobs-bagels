using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public List<Item> _items { get; set; }
        public double _totalCost { get; set; }

        public Basket()
        {
            _items = new List<Item>();
            _totalCost = 0;
        }

        public double CalculateTotalCost()
        {
            double cost = 0;
            foreach(Item item in _items)
            {
                cost += item.cost;
            }
            _totalCost = cost;
            return _totalCost;
        }
        public void AddItem(Item newItem)
        {
            this._items.Add(newItem);
        }

        public bool DeleteItem(string sku)
        {
            Item? item = _items.Find((x) => (x.SKU == sku));
            if(item != null)
            {
                _items.Remove(item);
                return true;
            }
            return false;
        }

    }
}
