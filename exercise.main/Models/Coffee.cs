using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Models
{
    public class Coffee : Product
    {
        public Coffee(string sku, string variant, decimal price)
        {
            SKU = sku;
            Variant = variant;
            Price = price;
        }

        public Coffee(string sku)
        {
            SKU = sku;
            Variant = Inventory.inventory[sku].Variant;
            Price = Inventory.inventory[sku].Price;
        }
    }
}
