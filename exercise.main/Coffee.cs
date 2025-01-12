using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Coffee : Item
    {
        private Dictionary<string, float> _skuPriceDictionary = new Dictionary<string, float>()
        {
            { "COFB", 0.99f },
            { "COFW", 1.19f },
            { "COFC", 1.29f },
            { "COFL", 1.29f },
        };

        public Coffee(string variant) : base(variant)
        {
            _SKU = "COF" + variant[0];
            _cost = _skuPriceDictionary[_SKU];
            _name = "Coffee";

            _fillings = new List<Item>();
        }

        public override void AddFilling(Item filling)
        {
            Console.WriteLine("Filling cannot be added to a coffee.");
        }

        public override List<Item> GetFillings()
        {
            Console.WriteLine("Coffee cannot have fillings.");
            return _fillings;
        }

    }
}
