using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Items
{
    public class Coffee : Item
    {
        //private Bagel _bagel;
        //public Bagel Bagel { get => _bagel; set => _bagel = value; }
        public Coffee()
        {

        }
        public Coffee(string sku) : base(sku)
        {

        }

        public Coffee(string sku, double price, string variant) : base(sku, price, variant)
        {

        }
    }
}
