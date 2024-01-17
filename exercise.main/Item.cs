using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public abstract class Item
    {
        public string ID;
        public string SKU;
        public string Name;
        public string Variant;
        public float Price;

        public Item(string sku, string name, float price, string variant)
        {
            ID = Guid.NewGuid().ToString();
            SKU = sku;
            Name = name;
            Price = price;
            Variant = variant;
        }

        public Item() { }

    }

    public class Bagel : Item
    {
        private List<Item> Contents = new List<Item>();

        public Bagel(string sku, string name, float price, string variant) : base(sku, name, price, variant) 
        {
            SKU = sku;
            Name = name;
            Price = price;
            Variant = variant;
        }


        public Bagel()
        {
            SKU = "none";
            Name = "none";
            Variant = "none";
        }

        public void AddFilling(Item item)
        {
            Contents.Add(item);
        }

        public List<Item> ListFillings()
        {
            return Contents;
        }
    }

    public class Coffee : Item
    {

        public Coffee(string sku, string name, float price, string variant) : base(sku, name, price, variant)
        {
            SKU = sku;
            Name = name;
            Price = price;
            Variant = variant;
        }

    }

    public class Filling : Item
    {
        public Filling(string sku, string name, float price, string variant) : base(sku, name, price, variant)
        {
            SKU = sku;
            Name = name;
            Price = price;
            Variant = variant;
        }

    }
}
