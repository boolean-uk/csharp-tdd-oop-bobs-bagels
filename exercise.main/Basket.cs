using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private List<Product> _products = new List<Product>();
        private int _capacity = 3;

        public bool add(string v)
        {
            Product value = BagelShop.Category[v];
            if (this.IsFull) return false;
            _products.Add(value);
            return true;
        }

        public bool remove(string v)
        {
            Product value = BagelShop.Category[v];
            if (!_products.Contains(value)) return false;

            _products.Remove(value);
            return true;
        }

        public bool changeCapacity(int v)
        {
            _capacity = v;
            return true;
        }

        public bool exists(string v)
        {
            Product value = BagelShop.Category[v];
            return _products.Contains(value);
        }

        public List<Product> Products { get { return _products; } }

        public bool IsFull { get { return _capacity == _products.Count(); } }

        public int SumOfItems { get { return ((int)_products.Sum(product => product.Price)); } }
    }
}
