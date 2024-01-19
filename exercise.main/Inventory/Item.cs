using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace exercise.main.Inventory
{
    public enum Type
    {
        Coffee, Bagel, Filling
    }

    public class Item
    {
        public string _SKU { get; set; }
        public double _price { get; set; }
        public Type _type { get; set; }
        public string _variant { get; set; }

        public Item(string sku, double price, Type type, string variant)
        {
            _SKU = sku;
            _price = price;
            _type = type;
            _variant = variant;
        }




    }
}
