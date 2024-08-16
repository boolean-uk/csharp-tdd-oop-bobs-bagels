using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        Dictionary<string, Product> _category;
        private List<Product> _products = new List<Product>();
        private int _capacity = 3;

        public Basket(Dictionary<string, Product> category)
        {
            _category = category;
        }

        public bool add(string v)
        {
            // Check if the product exists in the category
            if (!_category.ContainsKey(v)) return false;

            Product value = _category[v];

            // Check if the basket is full
            if (this.IsFull) return false;

            // Check if there is more of the product in stock
            bool result = value.DecreaseStock();
            if (!result) return false;

            _products.Add(value);
            return true;
        }

        public bool remove(string v)
        {
            // Check if the product exists in the category
            if (!_category.ContainsKey(v)) return false;

            Product value = _category[v];

            // Check if the product exists in the basket before removing
            if (!_products.Contains(value)) return false;

            value.IncreaseStock();

            _products.Remove(value);
            return true;
        }

        public bool changeCapacity(int v)
        {
            // Here we could do stuff about checking manager rights etc
            _capacity = v;
            return true;
        }

        public bool exists(string v)
        {
            Product value = _category[v];
            return _products.Contains(value);
        }

        public double costOfProduct(string v)
        {
            Product product = _category[v];
            return product.Price;
        }

        public List<Product> Products { get { return _products; } }

        public int Capacity { get { return _capacity; } }

        public bool IsFull { get { return _capacity == _products.Count(); } }

        public double SumOfItems { get { return (_products.Sum(product => product.Price)); } }
    }
}
