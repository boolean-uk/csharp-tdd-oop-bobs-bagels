using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Bagel : Item
    {
        private Dictionary<string, float> _skuPriceDictionary = new Dictionary<string, float>()
        {
            { "BGLO", 0.49f },
            { "BGLP", 0.39f },
            { "BGLE", 0.49f },
            { "BGLS", 0.49f },
        };

        public Bagel(string variant) : base(variant)
        {
            _SKU = "BGL" + variant[0];
            _cost = _skuPriceDictionary[_SKU];
            _name = "Bagel";
        }
    }
}
