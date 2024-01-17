using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Filling
    {
        public string SKU { get; }
        public decimal Price { get; }
        public string Name { get; }

        public Filling(string sku, decimal price, string name)
        {
            SKU = sku;
            Price = price;
            Name = name;
        }
    }
}
