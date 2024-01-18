using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.items
{
    public class Coffee
    {
        public string Sku { get; set; }
        public double Price { get; set; }
        public CoffeeVariant Variant { get; set; }

        public string ToString() { return $"{Variant.ToString()} Coffee"; }

        public Coffee(CoffeeVariant variant)
        {
            Variant = variant;
            Sku = _coffeeToData[variant].Sku;
            Price = _coffeeToData[variant].Price;
        }

        private Dictionary<CoffeeVariant, (string Sku, double Price)> _coffeeToData = new Dictionary<CoffeeVariant, (string Sku, double Price)>()
        {
            { CoffeeVariant.Black, ("COFB", 0.99d) }, { CoffeeVariant.White, ("COFW", 1.19d) },
            { CoffeeVariant.Capuccino, ("COFC", 1.29d) }, { CoffeeVariant.Latte, ("COFL", 1.29d) }
        };

        public double Cost() { return Price; }
    }
}

public enum CoffeeVariant
{
    Black, White, Capuccino, Latte
}
