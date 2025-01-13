using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main.Products
{
    public class Coffee(string sku, decimal price, Coffee.CoffeeVariant variant) : Product(sku, price)
    {
        private readonly CoffeeVariant _variant = variant;

        public override string Name
        {
            get { return $"{_variant} Coffee"; }
        }
        public enum CoffeeVariant
        {
            Black,
            White,
            Capuccino,
            Latte
        }

        public CoffeeVariant Variant
        {
            get { return _variant; }
        }
    }
}