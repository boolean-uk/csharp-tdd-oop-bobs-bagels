using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Coffee : IItem
    {
        public string sku { get; }
        public double price { get; }
        public string name { get; }
        public string variant { get; }

        public Coffee(string sku, double price, string name, string variant)
        {
            this.sku = sku;
            this.price = price;
            this.name = name;
            this.variant = variant;
        }
    }
}
