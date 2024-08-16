using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Item
    {
        private string _sku = string.Empty;
        private float _price;
        private string _name = string.Empty;
        private string _variant = string.Empty;

        public Item(string sku, float price, string name, string variant)
        {
            _sku = sku;
            _price = price;
            _name = name;
            _variant = variant;
        }

        public string SKU { get; }
        public string Price { get; }
        public string Name { get; }
        public string Variant { get; }
    }
}
