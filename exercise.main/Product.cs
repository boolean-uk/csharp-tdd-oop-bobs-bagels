using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public abstract class Product(string sku, decimal price)
    {
        public string SKU { get { return sku; } set { sku = value; } }
        public decimal Price { get { return price; } set { price = value; } }
        public virtual string? Name { get; set; } 

    }
}