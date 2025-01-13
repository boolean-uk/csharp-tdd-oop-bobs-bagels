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

        public Bagel(string variant, float cost) : base("BGL" + variant.ToUpper().First(), "Bagel", variant, cost) { }
        public void AddFilling(Item filling)
        {
            _fillings.Add(filling);
        }

        public override List<Item> GetItems()
        {
            return _fillings.Concat([this]).ToList();
        }
    }
}
