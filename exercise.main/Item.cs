using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop.main
{
    public class Item
    {
        public string SKU { get; }
        public string Name { get; }
        public string Variant { get; }
        public double Price { get; }

        public Item(string sku, string name, string variant, double price)
        {
            SKU = sku;
            Name = name;
            Variant = variant;
            Price = price;
        }

        public virtual double CalculateCost(int quantity)
        {
            return Price * quantity;
        }

        internal double CalculateCost()
        {
            return CalculateCost();
        }

        public double CalculateSavings(int quantity)
        {
            return Price * quantity;
        }

        private double CalculateSavings()
        {
            return CalculateSavings();
        }
    }
}
