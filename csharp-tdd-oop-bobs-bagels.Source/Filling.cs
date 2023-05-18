using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_tdd_oop_bobs_bagels.Source
{
    public class Filling : IItem
    {
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }
        public int Stock { get; set; }
        public int Amount { get; set; }
        public decimal Cost { get; set; }
        public decimal Savings { get; set; }

        public Filling(string Sku, decimal Price, string Name, string Variant, int Stock, int Amount, decimal Cost, decimal Savings)
        {
            this.SKU = Sku;
            this.Price = Price;
            this.Name = Name;
            this.Variant = Variant;
            this.Stock = Stock;
            this.Amount = Amount;
            this.Cost = Cost;
            this.Savings = Savings;
        }
    }
}
