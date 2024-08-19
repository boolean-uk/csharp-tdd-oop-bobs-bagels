using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace exercise.main
{
    public class Coffee : Item
    {

        public Coffee(string sku, double price, string name, string variant) : base(sku, price, name, variant)
        {
        }


        public override double CheckItemCost()
        {
            return Price;
        }

        public override string ToString()
        {
            return $"{Sku} - {Variant} {Name} : {Price}";

        }
    }
}
