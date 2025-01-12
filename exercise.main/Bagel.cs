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

            if (_skuPriceDictionary.ContainsKey(_SKU))
                _cost = _skuPriceDictionary[_SKU];
            else
            {
                Console.WriteLine($"{variant} is not a valid variant.");
                return;
            }

            _name = "Bagel";

            _fillings = new List<Item>();
        }

        public override void AddFilling(Item filling)
        {
            if (Inventory.CheckIfInInventory(filling))
            {
                if (filling.name == "Filling")
                {
                    _fillings.Add(filling);
                    Console.WriteLine($"Item added: {filling.variant} {filling.name}");
                }
                else
                    Console.WriteLine("Not a filling.");
            }
        }

        public override List<Item> GetFillings()
        {
            return _fillings;
        }
    }
}
