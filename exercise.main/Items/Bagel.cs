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
        public List<Item> Fillings { get { return _fillings; } }
        //public override float Price { get { return _cost + _fillings.Select(a => a.Price).Sum(); } }

        //public override string Id { get { return _id + (_fillings.Count > 0 ? $", {string.Join(", ", _fillings.Select(a => a.Id))}" : ""); }}

        public Bagel(string variant, float cost) : base("BGL" + variant.ToUpper().First(), "Bagel", variant, cost) { }
        public void AddFilling(Item filling)
        {
            _fillings.Add(filling);
        }

        override public string ToString()
        {
            return $"{Name} - {Variant} - {string.Join(", ", _fillings.Select(a => a.Variant))} - {Price}£";
        }
    }
}
