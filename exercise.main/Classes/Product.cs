using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise.main.Enums;
using exercise.main.Interfaces;

namespace exercise.main.Classes
{
    public class Product : IProduct
    {
        private double _price;
        private ProductType _type;
        private string _sku;
        private string _variant;
        public Product(string sku, double price, ProductType type, string variant)
        {
            _sku = sku;
            _price = price;
            _type = type;
            _variant = variant;
        }

        public double Price
        {
            get => _price;
            set => _price = value;
        }

        public ProductType Type
        {
            get => _type;
            set => _type = value;
        }

        public string SKU
        {
            get => _sku;
            set => _sku = value;
        }

        public string Variant
        {
            get => _variant;
            set => _variant = value;
        }
    }
}
