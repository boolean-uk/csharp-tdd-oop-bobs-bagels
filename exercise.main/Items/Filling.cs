using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Items
{
    public class Filling : Item
    {
        public Filling(string variant, float price) : base("FIL" + variant.ToUpper().First(), "Filling", variant, price)
        {
        }

        public override Item Clone()
        {
            return new Filling(Variant, Price);
        }
    }
}
