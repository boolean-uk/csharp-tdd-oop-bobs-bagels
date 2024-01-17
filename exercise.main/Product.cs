using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Product
    {
        private string _name;
        private string _SKU;
        private double _price;
        private string _variant;


        public Product(){//string name, string SKU) {
          //  Information information = new Information();
            _name = "Bagel";
            _SKU = "SKU";
           // _price = information.Prices[SKU];
            //_variant = information.Variants[SKU];


        }

     
        public string Name { get =>  _name; set => _name = value;}
        public string SKU { get=> _SKU; set => _SKU = value;}
        public double Price { get => _price;}
        public string Variant { get => _variant;}
    }
}
