using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise
{
    public class Product
    {
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }

        public Product(string sku, decimal price, string name, string variant) 
        {
            SKU = sku;
            Price = price;
            Name = name;
            Variant = variant;
        }
    }
}
