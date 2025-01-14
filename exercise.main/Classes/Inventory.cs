using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Enums;

namespace exercise.main.Classes
{
    public class Inventory
    {
        private Dictionary<string, int> _stock;
        private Dictionary<string, Product> _products;

        public Inventory()
        {
            _stock = new Dictionary<string, int>();
            _products = new Dictionary<string, Product>();
        }

        public void Add(Product product, int? amount)
        {
            // If it already exists
            if (_stock.ContainsKey(product.SKU))
            {
                _stock[product.SKU] += amount ?? 1;
            }
            else
            {
                _stock.Add(product.SKU, amount ?? 1);
                _products.Add(product.SKU, product);
            }
        }

        public void Remove(string sku, int amount)
        {
            if (_stock.ContainsKey(sku))
            {
                int stock = _stock[sku];
                if (stock < amount)
                {
                    Console.WriteLine("Stock is empty");
                }
                else
                {
                    _stock[sku] = stock - amount;
                }
            }
            else
            {
                Console.WriteLine("Product not found in inventory!");
            }
        }


        public int GetStock(string sku)
        {
            return _stock.ContainsKey(sku) ? _stock[sku] : 0;
        }

        public Dictionary<string, Product> Products { get { return _products; } }


    }

}
