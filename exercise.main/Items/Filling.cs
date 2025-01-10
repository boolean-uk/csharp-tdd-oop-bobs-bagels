using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Items
{
    public class Filling : Item
    {
        public Filling(string variant, float cost) : base("FIL" + variant.ToUpper().First(), "Filling", variant, cost)
        {
        }
    }
}
