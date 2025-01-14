using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Core
{
    public class Coffee : Inventory
    {
        public Coffee(string sku, double price, string variant)
            : base(sku, price, "Bagel", variant)
        {
        }
    }
}
