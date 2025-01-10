using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Items
{
    public class Coffee : Item
    {
        public Coffee(string variant, float cost) : base("COF" + variant.ToUpper().First(), "Coffee", variant, cost) {}
    }
}
