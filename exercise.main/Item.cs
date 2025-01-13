using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public abstract class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Variant { get; set; }

        public Item(string name, string variant, double price)
        {
            Name = name;
            Price = price;
            Variant = variant;

        }

        public abstract double getPrice();

    }

    
    
}
