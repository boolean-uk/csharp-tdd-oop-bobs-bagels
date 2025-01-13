using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main.Products
{
    public class Filling(string sku, decimal price, Filling.FillingVariant variant) : Product(sku, price)
    {
        private readonly FillingVariant _variant = variant;

        public override string Name
        {
            get { return $"{_variant} Filling"; }
        }
        public enum FillingVariant
        {
            Bacon,
            Egg,
            Cheese,
            CreamCheese,
            SmokedSalmon,
            Ham,
        }

        public FillingVariant Variant
        {
            get { return _variant; }
        }
    }
}