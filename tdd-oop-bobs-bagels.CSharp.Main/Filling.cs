using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Filling : IProduct
    {
        public string SKU { get; }
        public decimal Price { get; }
        public string Name { get; }

        public Filling(string sku, decimal price, string name)
        {
            SKU = sku;
            Price = price;
            Name = name;
        }

        public decimal GetPrice() => Price;
    }
}