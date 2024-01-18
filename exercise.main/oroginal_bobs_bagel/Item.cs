using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Item {
        public string Sku;
        public decimal Price;
        public string Name;
        public string Variant;
        public List<Tuple<string, decimal>> Fillings;

        public Item(string sku, decimal price, string name, string variant) {
            Sku = sku;
            Price = price;
            Name = name;
            Variant = variant;
            Fillings = new List<Tuple<string, decimal>>();;
        }
    }

    
}