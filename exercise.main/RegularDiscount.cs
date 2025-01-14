using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class RegularDiscount : IDiscounts
    {
        public string Item { get; set; } = string.Empty;
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public string Item2 { get; set; } = string.Empty;

        public RegularDiscount(string name, int amount, decimal price)
        {
            this.Item = name;
            this.Amount = amount;
            this.Price = price;
        }
    }
}
