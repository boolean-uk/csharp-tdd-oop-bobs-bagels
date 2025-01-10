using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Products;

namespace exercise.main.Inventory
{
    public class Inventory : IInventory
    {

        private Dictionary<string, Product> _inventoryDictionary;

        public Inventory()
        {
            _inventoryDictionary = new Dictionary<string, Product>();
        }


        public double GetPrice(Product p)
        {
            if (IsInStock(p))
            {
                return p.Price;
            }
            return -1d;
        }

        public bool IsInStock(Product p)
        {
            return _inventoryDictionary.ContainsKey(p.Sku);
        }
    }
}
