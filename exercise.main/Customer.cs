using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Customer
    {
        private static int _counter = 0;
        public int _id { get; set; }
        public string _name { get; set; }
        public Basket _basket { get; set; }
        public Store _store { get; set; }

        public Customer(string name, Store store)
        {
            _counter += 1;
            _id = _counter;
            _name = name;
            _basket = new Basket();
            _store = store;
        }

        public Basket order(string sku)
        {
            // TODO
            Item? item = _store._itemsInStock.Find((x) => x.SKU == sku);
            if (_store._basketCapacity > _basket._items.Count && item != null)
            {
                _basket.AddItem(item);
                Console.WriteLine($"{sku} was added");
                return _basket;
            }
            Console.WriteLine($"{sku} was not added");
            return _basket;
        }
      
        public string DeleteItem(string sku)
        {
            Item? item = _basket._items.Find((x) => x.SKU.Equals(sku));
            if(item != null)
            {
                _basket._items.Remove(item);
                return $"{sku} has been deleted";
            }
            return $"{sku} was not found";
        }

        public double CalculateCostBeforeOrder(string sku)
        {
            Item? item = _basket._items.Find((x) => x.SKU == sku);
            if(item != null)
            {
                return item.cost;
            }
            return 0.0;
        }
    }
}
