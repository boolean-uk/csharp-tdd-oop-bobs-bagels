using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_tdd_oop_bobs_bagels.Source
{
    public class Bagel : IItem
    {
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }
        public int Stock { get; set; }
        public int Amount { get; set; }
        public decimal Cost { get; set; }

        public Bagel(string Sku, decimal Price, string Name, string Variant, int Stock, int Amount, decimal Cost)
        {
            this.SKU = Sku;
            this.Price = Price;
            this.Name = Name;
            this.Variant = Variant;
            this.Stock = Stock;
            this.Amount = Amount;
            this.Cost = Cost;
        }
    }
}
