using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Item {
        public string Sku;
        public float Price;
        public string Name;
        public string Variant;
        public List<string> Fillings;

        public Item(string sku, float price, string name, string variant, List<string> fillings) {
            Sku = sku;
            Price = price;
            Name = name;
            Variant = variant;
            Fillings = fillings;
        }
    }

    
}