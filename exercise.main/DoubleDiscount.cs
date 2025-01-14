using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class DoubleDiscount : IDiscounts
    {
        public string Item { get; set; } = string.Empty;
        public string Item2 { get; set; } = string.Empty;
        public int Amount { get; set; }
        public decimal Price { get; set; }


        public DoubleDiscount(string name, string name2, int amount, decimal price)
        {
            this.Item = name;
            this.Item2 = name2;
            this.Amount = amount;
            this.Price = price;
        }
    }
}
