using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Class_Items
{
    public class Basket
    {
        private List<Product> _items;
        private int _capacity;
        public Basket(int c)
        {
            _capacity = c;
            _items = new List<Product>();
        }

        public bool Add(Product product)
        {
            if (_items.Count < _capacity)
            {
                _items.Add(product);
                return true;
            }
            Console.WriteLine("Your basket is full!");
            return false;
        }

        public int Remove(string type)
        {
            if (_items.Exists(x => x.SKU == type))
            {
                _items.RemoveAt(_items.IndexOf(_items.Find(x => x.SKU == type)));
            }
            return _items.Count;
        }

        public int ChangeCapacity(int amount)
        {
            _capacity = amount;
            return _capacity;
        }

        public double TotalCost()
        {
            throw new NotImplementedException();
        }
    }
}
