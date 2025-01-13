using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Products
{
    public class Bagel : IProduct
    {
        public string Sku         { get; set; }
        public double Price       { get; set; }
        public string Type        { get; set; }
        public string Variant     { get; set; }
        public Filling? filling { get; set; }

        public Bagel(string sku, double price, string type, string variant, Filling filling)
        {
            Sku = sku;
            Price = price;
            Type = type;
            Variant = variant;
            this.filling = filling;
        }
        public Bagel(string sku, double price, string type, string variant)
        {
            Sku = sku;
            Price = price;
            Type = type;
            Variant = variant;
            filling = null;
        }

        public Bagel? AddFilling(Filling item)
        {
            Inventory inv = new Inventory();
            if (inv.ValidateItem(item))
            {
                this.filling = item;
                return this;
            }
            return this;
            
        }
        public double Total()
        {
            return Price + (filling?.Price ?? 0);
        }
    }
}
