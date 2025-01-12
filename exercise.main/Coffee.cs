using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Coffee(string sku, double price, Coffee.CoffeeVariant variant) : Product(sku, price)
    {
        private readonly CoffeeVariant _variant = variant;
       
        public string Name 
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