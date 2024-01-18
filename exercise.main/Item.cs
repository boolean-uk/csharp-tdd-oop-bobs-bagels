using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace exercise.main
{
    public abstract class Item
    {
        public string ID;
        public string SKU;
        public string Name;
        public string Variant;
        public float Price;

        public bool inBundle = false;
        public List<string> inBundleWith = new List<string>(12);

        public Item(string sku, string name, float price, string variant)
        {
            ID = Guid.NewGuid().ToString();
            SKU = sku;
            Name = name;
            Price = price;
            Variant = variant;
        }

        public Item() { }

        public bool isInBundle()
        {
            return inBundle;
        }

        public virtual List<string> ListBundleIds()
        {
            return inBundleWith;
        }

        public virtual void putToBundle(List<string> ids)
        {
            inBundleWith = ids;
            inBundle = true;
        }

        public virtual void RemoveFromBundle()
        {
            inBundleWith.Clear();
            inBundle = false;
        }

    }

}
