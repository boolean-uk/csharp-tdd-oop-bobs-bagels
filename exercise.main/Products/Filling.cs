using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main.Products
{
    public class Filling : IProduct
    {
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }

        public Filling(string sKU, decimal price, string name, string variant)
        {
            SKU = sKU;
            Price = price;
            Name = name;
            Variant = variant;
        }

    }
}