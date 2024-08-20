using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Discount : Item
    {
        private Func<Basket, bool> _condition;
        private Basket _basket;
        public Func<Basket, bool> Condition { get { return this._condition; } }
        public Basket Basket { get { return this._basket; } }

        List<Item> discountedItems;

        public Discount(string sku, string name, Func<Basket, bool> condition, float price, Basket basket) : base(sku, price, name)
        {
            this._condition = condition;
            this._basket = basket;
        }


        public override float GetItemCost()
        {
            return Price;
        }
    }
}
