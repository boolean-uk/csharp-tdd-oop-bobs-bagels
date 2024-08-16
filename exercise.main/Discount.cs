using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Discount
    {
        public Dictionary<string, int> DiscountProducts { get; set; }
        public double price { get; set; }
        
        public string ?DiscountDescription { get; set; }

        public Discount(Dictionary<string, int> products, double price)
        {
            this.DiscountProducts = products;
            this.price = price;
        }
    }
}
