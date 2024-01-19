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
        private string _sku;
        private double _price;
        private string _name;
        private string _variant;

        //_sku is the field (private variable), and sku is the parameter passed to the constructor.
        public Item(string sku, double price, string name, string variant, SpecialOffer offer = null)
        {
            _sku = sku;
            _price = price;
            _name = name;
            _variant = variant;

            //default
            Offer = offer ?? new SpecialOffer();

        }

        public string Sku { get => _sku; }
        public double Price { get => _price; }
        public string Name { get => _name; }

        public string Variant { get => _variant; }

        //Adding a new property which represent special offers for the item,  Extension1
        public SpecialOffer Offer { get; set; }

    }
}
