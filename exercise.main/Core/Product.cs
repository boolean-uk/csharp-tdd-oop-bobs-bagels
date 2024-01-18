using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Core
{
    public abstract class Product : PObject
    {

        protected double _price = -1;
        protected string _SKU = "";
        protected string _variant = "";
        public abstract string Name { get; }

        public string SKU { get => _SKU; }
        public string Variant { get => _variant; }

        public Product(string sku, double price, string variant)
        {
            _SKU = sku;
            _variant = variant;
            _price = price;
        }

        public virtual double GetPrice()
        {
            return _price;
        }

        public double GetPriceSingle()
        {
            return _price;
        }
    }
}
