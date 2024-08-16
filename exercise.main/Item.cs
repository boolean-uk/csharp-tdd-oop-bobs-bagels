using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public abstract class Item
    {
        public string Sku { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }

        public Item (string sku, double price, string name, string variant)
        {
            Sku = sku;
            Price = price;
            Name = name;
            Variant = variant;
        }
    }
}
