using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Product
    {
        private string _sku;
        private double _price;
        private string _name;
        private string _variant;
        private int _stock;

        public Product(string sku, double price, string name, string variant)
        {
            _sku = sku;
            _price = price;
            _name = name;
            _variant = variant;
            _stock = 10; // default stock of 10
        }

        public string Sku { get => _sku; set => _sku = value; }
        public double Price { get => _price; set => _price = value; }
        public string Name { get => _name; set => _name = value; }
        public string Variant { get => _variant; set => _variant = value; }
        public int Stock { get => _stock; set => _stock = value; }

    }
}
