using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Classes
{
    public enum Name { Bagel, Coffee, Filling }
    public class Item
    {
        public string SKU { get; set; }
        public double Price { get; set; }
        public Name Name { get; set; }
        public string Variant { get; set; }
        
        public Item(string sku, double price, Name name, string variant)
        {
            SKU = sku;
            Price = price;
            Name = name;
            Variant = variant;
        }

        public virtual void AddFilling(Filling filling) { }
        public virtual List<Filling> GetFilling() { return null; }
        public virtual void RemoveFilling(string sku) { }
    }
}
