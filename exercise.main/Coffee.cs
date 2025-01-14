using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Coffee : Item
    {
        public Coffee(string id, string name, string variant, double price) : base(id, name, variant, price) { }

        public override double getPrice()
        {
            return base.Price;
        }
    }
}
