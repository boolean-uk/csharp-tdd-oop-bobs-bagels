using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main.Products
{
    public class Bagel : Items
    {
        public string sku { get; set; }
        public float price { get; set; }
        public string variant { get; set; }

        public List<string> fillings { get; set; }

        public Bagel(string sku, float price, string variant)
        {
            this.sku = sku;
            this.price = price;
            this.variant = variant;
            fillings = new List<string>();
        }
    }
}
