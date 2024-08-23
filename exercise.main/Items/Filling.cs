using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Items
{
    public class Filling : Item
    {
        public Filling()
        {

        }
        public Filling(string sku) : base(sku)
        {

        }

        public Filling(string sku, double price, string variant) : base(sku, price, variant)
        {

        }
    }
}
