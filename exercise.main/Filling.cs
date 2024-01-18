using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace exercise.main
{

    public class Filling : Item
    {
        public Filling(string sku, string name, float price, string variant) : base(sku, name, price, variant)
        {
            SKU = sku;
            Name = name;
            Price = price;
            Variant = variant;
        }

        public override void putToBundle(List<string> skus)
        {
            // do nothing - fillings can't be added to bundles
        }

        public override void RemoveFromBundle()
        {
            // do nothing - fillings can't be added to bundles
        }

        public override List<string> ListBundleIds()
        {
            List<string> emptyList = new List<string>();
            return emptyList;
        }

    }
}
