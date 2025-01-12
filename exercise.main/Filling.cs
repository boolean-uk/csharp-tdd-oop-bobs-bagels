using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Filling(string sku, double price, Filling.FillingVariant variant) : Product(sku, price)
    {
        private readonly FillingVariant _variant = variant;

        public string Name
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