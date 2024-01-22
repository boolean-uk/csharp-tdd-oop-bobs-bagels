using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace exercise.main
{
    public abstract class Item : IItem
    {
        protected string _ID;
        protected string _SKU;
        protected string _Name;
        protected string _Variant;
        protected float _Price;

        public string ID { get { return _ID;  } }
        public string SKU { get { return _SKU; } }
        public string Name { get { return _Name; } }
        public string Variant { get { return _Variant; } }
        public float Price { get { return _Price; } }

        public bool inBundle = false;
        public List<string> inBundleWith = new List<string>();

        public Item(string sku, string name, float price, string variant)
        {
            _ID = Guid.NewGuid().ToString();
            _SKU = sku;
            _Name = name;
            _Price = price;
            _Variant = variant;
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
