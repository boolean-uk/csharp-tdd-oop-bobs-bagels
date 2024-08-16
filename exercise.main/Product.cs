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
        private static int _stock;
        private List<Product> _extra;

        public Product(string sku, double price, string name, string variant, List<Product> extra)
        {
            _sku = sku;
            _price = price;
            _name = name;
            _variant = variant;
            _extra = extra;
            _stock = 10; // default stock of 10
        }
    }
}
