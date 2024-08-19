using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Coffee : Item
    {
        
        public Coffee(string sku, float price, string name) : base(sku, price, name) { }

        public override float GetItemCost()
        {
            return Price;
        }
    }
}