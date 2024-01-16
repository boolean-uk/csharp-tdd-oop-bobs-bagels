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
        private float _price;
        private ProductType _type;
        private string _variant;

        public Product(string sku, float price, ProductType type, string variant)
        {
            _sku = sku;
            _price = price;
            _type = type;
            _variant = variant;
        }

        public string SKU { get { return _sku;} set { _sku = value; } }
        public float Price { get { return _price;} set { _price = value; } }
        public ProductType Type { get { return _type; } set { _type = value; } }
        public string Variant { get { return _variant; } set { _variant = value; } }

    }


}
