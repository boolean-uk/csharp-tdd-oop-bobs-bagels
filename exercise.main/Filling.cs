using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Filling : Item
    {
        private Dictionary<string, float> _skuPriceDictionary = new Dictionary<string, float>()
        {
            { "FILB", 0.12f },
            { "FILE", 0.12f },
            { "FILC", 0.12f },
            { "FILX", 0.12f },
            { "FILS", 0.12f },
            { "FILH", 0.12f },
        };

        public Filling(string variant) : base(variant)
        {
            if (variant == "Cream Cheese")
                _SKU = "FIL" + "X";
            else
                _SKU = "FIL" + variant[0];

            _cost = _skuPriceDictionary[_SKU];
            _name = "Filling";

            _fillings = new List<Item>();
        }

        public override void AddFilling(Item filling)
        {
            Console.WriteLine("Filling cannot be added to a filling.");
        }

        public override List<Item> GetFillings()
        {
            Console.WriteLine("Filling cannot have fillings.");
            return _fillings;
        }
    }
}
