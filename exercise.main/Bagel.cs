using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    /**
    public class Bagel
    {
        public string SKU { get; }
        public decimal Price { get; }
        public string Name { get; }
        public string Variant { get; }

        public Bagel(string sku, decimal price, string name, string variant)
        {
            SKU = sku;
            Price = price;
            Name = name;
            Variant = variant;
        }

    }
    **/
    public class Bagel(string SKU) : Product(SKU)
    {
    }
}
