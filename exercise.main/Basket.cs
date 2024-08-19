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

        private bool AddItem(string sku, int amount)
        {
            // Since we have a coffee + bagel special offer, we create a special item for it
            // Assuming this offer only applies for Black Coffee (ask customer?!)
            if (sku.StartsWith("COFB") && sku.Length == 8)
            {

            }
            // Check if the product exists in the category
            if (!_category.ContainsKey(sku)) return false;

            Product value = _category[sku];

            // Check if the basket is full
            if (this.IsFull) return false;

            // Check if there is more of the product in stock
            bool result = value.DecreaseStock();
            if (!result) return false;

            // Check if order already exists, in this case, just increment it by amount
            if (_products.ContainsKey(sku))
            {
                _products[sku].Amount += amount;
            }
            else
            {
                ProductOrder po = new ProductOrder(value, amount);
                _products.Add(sku, po);
            }
            _count++;
            return true;
        }

        public bool Add(string v)
        {
            return AddItem(v, 1);
        }

        public bool Add(string v1, int v2)
        {
            return AddItem(v1, v2);   
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

        public bool Add(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        public List<ProductOrder> Products { get { return _products.Values.ToList(); } }

        public Dictionary<string, ProductOrder> ProductOrders { get { return _products; } }

        public int Capacity { get { return _capacity; } }

        public bool IsFull { get { return _capacity == _count; } }

        public double SumOfItems { get { return Math.Round(_products.Sum(product => (product.Value.Amount * product.Value.Product.Price) - product.Value.Discount), 2, MidpointRounding.AwayFromZero); } }
    }
}
