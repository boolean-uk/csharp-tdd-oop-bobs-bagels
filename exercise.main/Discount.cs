using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Discount : Item
    {
        private Func<Basket, List<Item>> _condition;
        private Basket _basket;
        public Func<Basket, List<Item>> Condition { get { return this._condition; } }
        public Basket Basket { get { return this._basket; } }

        private List<Item> discountedItems;

        public Discount(string sku, string name, Func<Basket, List<Item>> condition, float price, Basket basket) : base(sku, price, name)
        {
            this._condition = condition;
            this._basket = basket;
        }

        public Discount(Discount discount) : base(discount.Sku, discount.Price, discount.Name)
        {
            this._condition = null;
            this._basket = null;
            this.discountedItems = discount.discountedItems;
        }

        private void getDiscountItems()
        {
            discountedItems = Condition(Basket);
            //return discountedItems;
        }

        private bool checkForDiscount()
        {
            getDiscountItems();
            return discountedItems != null;
        }

        public List<Item> getDiscounts() 
        {
            List<Item> discounts = new List<Item>();
            while (checkForDiscount())
            {
                discounts.Add(new Discount(this));
            }
            return discounts;
        }


        public override float GetItemCost()
        {
            float fillingPrice = discountedItems.Sum(x => x.GetItemCost() - x.Price);
            return Price + fillingPrice;
        }
    }
}
