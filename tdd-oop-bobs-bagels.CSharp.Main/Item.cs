using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Item
    {
        private string sku;
        private float price;
        private string name;
        private string variant;

        public string Sku { get { return sku; } set { sku = value; } }
        public float Price { get { return price; } set { price = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Variant { get { return variant; } set { variant = value; } }

        public Item(string Sku, float Price, string Name, string Variant) {
            this.Sku = Sku;
            this.Price = Price;
            this.Name = Name;
            this.Variant = Variant;
        }

    }
}
