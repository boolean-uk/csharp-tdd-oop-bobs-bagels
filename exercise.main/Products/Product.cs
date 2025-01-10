using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public abstract class Product
    {
        public string Sku { get; private set; }
        public double Price { get; private set; }
        public string Name { get; private set; }
        public string Variant { get; private set; }

        protected Product(string sku, double price, string name, string variant)
        {
            Sku = sku;
            Price = price;
            Name = name;
            Variant = variant;
        }
    }
}
