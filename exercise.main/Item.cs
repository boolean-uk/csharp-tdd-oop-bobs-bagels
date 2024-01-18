using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public enum Name
    {
        Coffe, Bagel, Filling, Special
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
        public void updatePrice(double discountPrice)
        {
            _price = discountPrice;
        }

        public string Sku { get => _SKU; set => _SKU = value; }
        public double Price { get => _price; set => _price = value; }
        public Name Name { get => _name; set => Name = value; }
        public string Variant { get => _variant; set => _variant = value; }
    }
}
