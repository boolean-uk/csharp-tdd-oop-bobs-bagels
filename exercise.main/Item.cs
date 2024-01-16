using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    internal class Item
    {
        public int ID = 0;  // does this work..?
        public string SKU;
        public string Name;
        public float Price;
        public string Variant;
        public List<Item> Contents;
        public Item(string sku, string name, float price, string variant, List<Item> ? contents) 
        {
            ID = ID + 1;
            SKU = sku;
            Name = name;
            Price = price;
            Variant = variant;
            Contents = contents;
        }

    }
}
