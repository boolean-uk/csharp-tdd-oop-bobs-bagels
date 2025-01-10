using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Items
{
    public class Bagel : Item
    {

        private List<Item> _fillings = [];
        public new float Price { get
            {
                return this._cost + _fillings.Select(a => a.Price).Aggregate((a, b) => a + b);
            }
        }

        public Bagel(string id, string name, string variant, float cost) : base(id, name, variant, cost) { }
        public void AddFilling(Item filling)
        {
            _fillings.Add(filling);
        }

        override
        public string ToString()
        {
            return $"{Name} - {Variant} - {String.Join(", ", _fillings.Select(a => a.Variant))} - {Price}£";
        }
    }
}
