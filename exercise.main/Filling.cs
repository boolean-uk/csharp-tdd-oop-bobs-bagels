using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Filling : Iproduct
    {

        public string Name { get; set; }
        public string SKU { get; set; }
        public float Price { get; set; }
        public string Variant { get; set; }
        public Filling(string name, string sKU, float price, string variant)
        {
            Name = name;
            SKU = sKU;
            Price = price;
            Variant = variant;
        }

        public float GetPrice()
        {
            return Price;
        }
    }
}
