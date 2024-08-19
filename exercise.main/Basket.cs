using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private Dictionary<string, Product> _category;
        private Dictionary<string, ProductOrder> _products = new Dictionary<string, ProductOrder>();
        private int _capacity = 3;
        private int _count = 0;

        public Basket(Dictionary<string, Product> category)
        {
            _category = category;
        }

        public bool Add(string v)
        {
            // Check if the product exists in the category
            if (!_category.ContainsKey(v)) return false;

            Product value = _category[v];

            // Check if the basket is full
            if (this.IsFull) return false;

            // Check if there is more of the product in stock
            bool result = value.DecreaseStock();
            if (!result) return false;

            // Check if order already exists, in this case, just increment it by 1
            if (_products.ContainsKey(v))
            {
                _products[v].Amount++;
            }
            else
            {
                ProductOrder po = new ProductOrder(value, 1);
                _products.Add(v, po);
            }
            _count++;
            return true;
        }

        public bool Add(string v1, int v2)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string v)
        {
            // Check if the product exists in the category
            if (!_category.ContainsKey(v)) return false;

            // Check if the product exists in the basket before removing
            if (!_products.ContainsKey(v)) return false;

            Product value = _category[v];
            value.IncreaseStock();

            // Either remove 1, or if order only consists of one, remove the whole order
            if (_products[v].Amount > 1) _products[v].Amount--;
            else _products.Remove(v);

            _count--;
            return true;
        }

        public bool ChangeCapacity(int v)
        {
            // Here we could do stuff about checking manager rights etc
            _capacity = v;
            return true;
        }

        public bool Exists(string v)
        {
            return _products.ContainsKey(v);
        }

        public double CostOfProduct(string v)
        {
            Product product = _category[v];
            return product.Price;
        }


        public List<ProductOrder> Products { get { return _products.Values.ToList(); } }

        public int Capacity { get { return _capacity; } }

        public bool IsFull { get { return _capacity == _count; } }

        public double SumOfItems { get { return _products.Sum(product => (product.Value.Amount * product.Value.Product.Price) - product.Value.Discount); } }
    }
}
