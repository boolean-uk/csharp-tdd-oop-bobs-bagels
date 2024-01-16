using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public enum Name
    {
        Coffe, Bagel, Filling
    }

    public class Item
    {
        private string _SKU;
        private double _price;
        private Name _name;
        private string _variant;

        public Item(string sku, double price, Name name, string variant) { 
            _SKU = sku;
            _price = price;
            _name = name;
            _variant = variant;
        }

        public string Sku { get => _SKU; }
        public double Price { get => _price; }
        public Name Name { get => _name; }
        public string Variant { get => _variant; }
    }
}
