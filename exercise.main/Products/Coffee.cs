using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main.Products
{
    public class Coffee : IProduct
    {
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }

        public Coffee(string sku,  decimal price, string name, string variant)
        {
            SKU = sku;
            Price = price;
            Name = name;
            Variant = variant;
        }


    }
}