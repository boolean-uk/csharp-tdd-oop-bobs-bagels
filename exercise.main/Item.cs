using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Item
    {
        private string _sku;
        private double _price;
        private string _name;
        private string _variant;

        public string Sku { get { return _sku; } set { _sku = value; } }
        public double Price { get { return _price; } set { _price = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Variant { get { return _variant; } set { _variant = value; } }

        public Item(string sku, double price, string name, string variant) 
        {
            _sku = sku;
            _price = price;
            _name = name;
            _variant = variant;
        }

        public override string ToString()
        {
            return $"{this.Sku} - {this.Name} ({this.Variant}): ${this.Price:F2}";
        }
    }
}
