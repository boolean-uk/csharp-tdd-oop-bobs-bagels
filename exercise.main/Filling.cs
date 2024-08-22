using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace exercise.main
{
    public class Filling : Item
    {
        public Filling(string sku, float price, string name) : base(sku, price, name)
        {

        }

        public override float GetItemCost()
        {
            return Price;
        }

    }
}