using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class Bagel : IProduct, IDiscountable
    {
        public string Sku         { get; set; }
        public double Price       { get; set; }
        public string Type        { get; set; }
        public string Variant     { get; set; }
        public Filling? Filling { get; set; }
        public bool Discount {  get; set; }

        public Bagel(string sku, double price, string type, string variant, Filling filling)
        {
            Sku = sku;
            Price = price;
            Type = type;
            Variant = variant;
            this.Filling = filling;
        }
        public Bagel(string sku, double price, string type, string variant)
        {
            Sku = sku;
            Price = price;
            Type = type;
            Variant = variant;
            Filling = null;
        }

        public Bagel? AddFilling(Filling item)
        {
            Inventory inv = new Inventory();
            if (inv.ValidateItem(item))
            {
                this.Filling = item;
                return this;
            }
            return this;
            
        }
        public double Total()
        {
            return Price + (Filling?.Price ?? 0);
        }
    }
}
