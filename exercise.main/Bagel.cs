using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : Iitems
    {
        public string Sku { set; get; }
        public decimal Price { set; get; }
        public string Name { set; get; }
        public string Variant { set; get; }

        public Bagel(string sku, decimal price, string name, string variant) 
        {
            this.Sku = sku;
            this.Price = price;
            this.Name = name;
            this.Variant = variant;
        }
    }
}
