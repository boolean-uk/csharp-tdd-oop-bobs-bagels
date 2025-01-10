using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Models
{
    public class Filling : Product
    {
        public Filling(string sku, string variant, decimal price)
        {
            SKU = sku;
            Variant = variant;
            Price = price;
        }
        public Filling(string sku)
        {
            SKU = sku;
            Variant = Inventory.inventory[sku].Variant;
            Price = Inventory.inventory[sku].Price;
        }
    }
}
