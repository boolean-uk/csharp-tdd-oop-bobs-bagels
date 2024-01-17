using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Discounts
{
    public class DiscountBundleBagelAndCoffee : Discount
    {
        public DiscountBundleBagelAndCoffee(string name, float price) : base(name, price)
        {
            base.ProductSequence.Add(new Bagel("NA", 0f));
            base.ProductSequence.Add(new Coffee("NA", 0f));

        }
    }
}
