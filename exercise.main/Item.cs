using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public struct ItemData
    {
        public string SKU;
        public string Name; 
        public string Variant;
        public float Price;
    }
    public class Item
    {
        public string ID = Guid.NewGuid().ToString(); // does this work..?
        public ItemData data;
        public List<Item> Contents = new List<Item>();

        public Item(string sku, string name, float price, string variant) 
        {
            data.SKU = sku;
            data.Name = name;
            data.Price = price;
            data.Variant = variant;
        }

        public Item()
        {
            data.SKU = "none";
            data.Name = "none";
            data.Variant = "none";
        }

        public List<Item> ListFillings()
        {
            return Contents;
        }
    }
}
