using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class InventoryItem(string sku, double price, string name, string variant)
    {
        public string SKU { get; set; } = sku;

        public double Price { get; set; } = price;

        public string Name { get; set; } = name;

        public string Variant { get; set; } = variant;
    }
}
