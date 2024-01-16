using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_bobs_bagels.CSharp.Main
{
    public class Item
    {
        public string Name, SKU, Variant;
        public float Price;

        public Item(string sku, string name, string variant, float price)
        {
            this.SKU = sku;
            this.Name = name;
            this.Variant = variant;
            this.Price = price;
        }
    }
}


