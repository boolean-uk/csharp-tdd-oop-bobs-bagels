using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public abstract class Product(string sku, double price)
    {
        public string SKU { get { return sku; } set { sku = value; } }
        public double Price { get { return price; } set { price = value; } }

    }
}