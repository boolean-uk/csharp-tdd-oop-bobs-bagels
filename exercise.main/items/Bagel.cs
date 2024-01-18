using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.items
{
    public class Bagel
    {
        public string Sku { get; set; }
        public double Price { get; set; }
        public BagelVariant Variant { get; set; }
        public List<Filling> Fillings { get; set; } = new List<Filling>();

        public string ToString() { return $"{Variant.ToString()} Bagel"; }

        public Bagel(BagelVariant variant)
        { 
            Variant = variant;
            Sku = _bagelToData[variant].Sku;
            Price = _bagelToData[variant].Price;
        }


        private Dictionary<BagelVariant, (string Sku, double Price)> _bagelToData = new Dictionary<BagelVariant, (string Sku, double Price)>()
        {
            { BagelVariant.Onion, ("BGLO", 0.49d) }, { BagelVariant.Plain, ("BGLP", 0.39d) }, 
            { BagelVariant.Everything, ("BGLE", 0.49d) }, { BagelVariant.Sesame, ("BGLS", 0.49d) }
        };


        public double Cost()
        {
            return Price + Fillings.Sum(f => f.Cost());
        }

        public void AddFilling(Filling filling)
        {
            Fillings.Add(filling);
        }

        public double FillingCost()
        {
            return Fillings.Sum(f => f.Cost());
        }
    }
}

public enum BagelVariant
{
    Onion, Everything, Sesame, Plain
}