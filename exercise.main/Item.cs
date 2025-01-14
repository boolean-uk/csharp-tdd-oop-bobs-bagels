using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace exercise.main
{
    public class Item
    {

        public string Sku { get;}
        public decimal Price { get;}
        public string Name { get;}
        public string Variant { get;}

        public Item(string sku, decimal price, string name, string variant)
        {
            Sku = sku;
            Price = price;
            Name = name;
            Variant = variant;
        }

    }
}
