using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using static exercise.main.Filling;

namespace exercise.main
{
    public class Bagel(string sku, double price, Bagel.BagelVariant variant) : Product(sku, price)
    {
        private readonly BagelVariant _variant = variant;

        private readonly List<Filling> _fillings = [];

        public string Name
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

        public double TotalPrice
        {
            get
            {
                double total = this.Price; 
                foreach (var filling in _fillings)
                {
                    total += filling.Price; 
                }
                return total;
            }
        }

    }


}
