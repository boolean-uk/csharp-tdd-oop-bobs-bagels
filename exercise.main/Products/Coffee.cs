using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class Coffee : IProduct
    {
        public string Sku       { get; set; }
        public double Price     { get; set; }
        public string Type      { get; set; }
        public string Variant   { get; set; }


        public Coffee (string sku, double price, string type, string variant)
        {
            Sku = sku;
            Price = price;
            Type = type;
            Variant = variant;
        }
    }
}
