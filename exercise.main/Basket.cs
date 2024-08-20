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

        // Private helper method for adding items to basket
        private bool AddItem(string[] skus, int amount)
        {
            string sku = skus[0]; // SKU for the bagel
            string skuKey = string.Join("", skus); // SKU Key for the products dictionary
            // Check if the product exists in the category
            if (!_category.ContainsKey(sku)) return false;

            Product value = _category[sku];

            // Check if the basket is full
            if (this.IsFull) return false;

            // Check if there is more of the product in stock
            bool result = value.DecreaseStock();
            if (!result) return false;

            // Check if order already exists, in this case, just increment it by amount
            if (_products.ContainsKey(skuKey))
            {
                _products[skuKey].Amount += amount;
            }
            else
            {
                ProductOrder po = new ProductOrder(value, amount);
                _products.Add(skuKey, po);
            }

            ProductOrder order = _products[skuKey];

            for (int i = 1; i < skus.Length; i++)
            {
                // Currently you can only add a black coffee to an existing order,
                // you could change this by just checking that the type is coffee, if u wanted to...
                if (skus[i] == "COFB")
                {
                    order.Coffee = _category[skus[i]];
                    amount *= 2;
                }
                // Add filling to the bagel!
                if (_category[skus[i]].Name == "Filling") order.AddFilling(_category[skus[i]]);
                // Decrease the stock from the store...
                _category[skus[i]].DecreaseStock();
            }
            _count += amount;
            return true;
        }

        public bool Add(string v)
        {
            return AddItem([v], 1);
        }

        public bool Add(string v1, int v2)
        {
            return AddItem([v1], v2);   
        }

        // This is to add a bagel & coffee order
        public bool Add(string v1, string v2)
        {
            if (!_category.ContainsKey(v1) || !_category.ContainsKey(v2)) return false;
            Product p1 = _category[v1];
            Product p2 = _category[v2];

            if (p1.GetType() == typeof(Bagel) && p2.Sku == "COFB") return AddItem([p1.Sku, p2.Sku], 1);
            if (p2.GetType() == typeof(Bagel) && p1.Sku == "COFB") return AddItem([p2.Sku, p1.Sku], 1);
            else return false;
        }

        // This is to add a bagel with toppings/coffee order
        public bool Add(string v1, string[] v2)
        {
            if (!_category.ContainsKey(v1) && _category[v1].GetType() != typeof(Bagel)) return false;

            string[] orderKey = new string[1 + v2.Length];
            orderKey[0] = v1;
            bool coffeeAdded = false; // can only add one coffee to a bagel

            for (int i = 0; i < v2.Length; i++)
            {
                if (!_category.ContainsKey(v2[i])) return false; else orderKey[i + 1] = v2[i];
                if (_category[v2[i]].GetType() == typeof(Bagel)) return false; // cant add bagel to bagel
                if (_category[v2[i]].GetType() == typeof(Coffee))
                {
                    if (!coffeeAdded) coffeeAdded = true;
                    else return false;
                }
            }

            return AddItem(orderKey, 1);
        }

        private bool RemoveItem(string[] skus)
        {
            string sku = skus[0]; // SKU for the bagel
            string skuKey = string.Join("", skus); // SKU Key for the products dictionary
            // Check if the product exists in the basket before removing
            if (!_products.ContainsKey(skuKey)) return false;

            Product value = _category[sku];
            value.IncreaseStock();

            // If the order had a coffee, we remove twice as many items...
            if (_products[skuKey].Coffee != null) _count--;

            // Loop through the array to increase the stock back on the shop!
            for (int i = 1; i < skus.Length; i++) _category[skus[i]].IncreaseStock();

            // Either remove 1, or if order only consists of one, remove the whole order
            if (_products[skuKey].Amount > 1) _products[skuKey].Amount--;
            else _products.Remove(skuKey);

            _count--;
            return true;
        }

        public bool Remove(string v)
        {
            string[] skus = new string[v.Length / 4];

            int j = 0;
            for (int i = 0; i < v.Length; i+=4)
            {
                skus[j] = v.Substring(i, 4);
                j++;
            }
            return RemoveItem(skus);
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

        public Dictionary<string, ProductOrder> ProductOrders { get { return _products; } }

        public int Capacity { get { return _capacity; } }

        public bool IsFull { get { return _capacity == _count; } }

        public double SumOfItems { get { return Math.Round(_products.Sum(product => product.Value.Cost - product.Value.Discount), 2, MidpointRounding.AwayFromZero); } }
    }
}
