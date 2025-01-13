using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using static exercise.main.Products.Filling;

namespace exercise.main.Products
{
    public class Bagel(string sku, decimal price, Bagel.BagelVariant variant) : Product(sku, price)
    {
        private readonly BagelVariant _variant = variant;

        private readonly List<Filling> _fillings = [];

        public override string Name
        {
            get { return $"{_variant} Bagel"; }
        }

        public enum BagelVariant
        {
            Onion,
            Plain,
            Everything,
            Sesame,
        }
        public BagelVariant Variant
        {
            get { return _variant; }
        }

        public void AddFilling(Filling filling)
        {
            _fillings.Add(filling);
        }

        public List<Filling> Fillings
        {
            get { return _fillings; }
        }

        public decimal PriceWithFillings
        {
            get
            {
                decimal total = Price;
                foreach (var filling in _fillings)
                {
                    total += filling.Price;
                }
                return total;
            }
        }

    }


}
