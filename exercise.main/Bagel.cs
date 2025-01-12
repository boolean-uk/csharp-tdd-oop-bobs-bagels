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

        private List<Item> _fillings = new List<Item>();

        public Bagel(string variant) : base(variant)
        {
            _SKU = "BGL" + variant[0];

            if (_skuPriceDictionary.ContainsKey(_SKU))
                _cost = _skuPriceDictionary[_SKU];
            else
            {
                Console.WriteLine($"{variant} is not a valid variant.");
                return;
            }

            _name = "Bagel";
        }

        public List<Item> fillings { get { return _fillings; } }
    }
}
