using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : Item
    {
        public Bagel(string sku, double price, string name, string variant) : base(sku, price, name, variant)
        {
            Sku = sku;
            Price = price;
            Name = name;
            Variant = variant;
            //Filling = filling;

        }

        private string Filling {  get; set; }

        
    }
}
