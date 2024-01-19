using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Product : IProduct, IFillable
    {
        public string Sku { get; }

        public decimal Price { get; }

        public string Category { get; }

        public string Variant { get; }
        public List<Tuple<string, decimal>> _fillings { get; set ; }

        public Product(string sku, decimal price, string category, string variant) {
            Sku = sku;
            Price = price;
            Category = category;
            Variant = variant;
            _fillings = new List<Tuple<string, decimal>>();
        }
    }
}