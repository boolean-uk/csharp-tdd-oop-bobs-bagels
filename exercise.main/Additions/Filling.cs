using exercise.main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Additions
{
    public class Filling : IAddition
    {
        public string SKU { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }

        public string AvailableToProduct { get; set; } = "bagel";
        public Filling(string SKU, double price, string name, string variant)
        {
            this.SKU = SKU;
            Price = price;
            Name = name;
            Variant = variant;
        }
    }
}
