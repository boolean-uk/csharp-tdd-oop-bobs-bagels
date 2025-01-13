using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class Inventory
    {
        private Dictionary<string, int> _stock;

        public Inventory()
        {
            _stock = new Dictionary<string, int>();
        }

        public void Add(Product product, int? amount)
        {
            if (_stock.ContainsKey(product.GetSKU()))
            {
                _stock[product.GetSKU()] += amount ?? 1;
            }
            else
            {
                _stock.Add(product.GetSKU(), amount ?? 1);
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
    }

}
