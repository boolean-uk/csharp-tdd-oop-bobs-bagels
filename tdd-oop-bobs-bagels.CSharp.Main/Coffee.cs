using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Coffee
    {
        public string SKU { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        public string Variant { get; set; }


        public Coffee(string sku, float price, string name, string variant)
        {
            SKU = sku;
            Price = price;
            Name = name;
            Variant = variant;
        }

    }
}
