using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public class Filling : Item
    {
        public Filling(string sku, double price, Name name, string variant) : base(sku, price, name, variant)
        { 
            SKU = sku;
            Price = price;
            Name = name;
            Variant = variant;
        }

    }
}
