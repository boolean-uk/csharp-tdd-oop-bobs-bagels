using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Discounts
{
    public class DiscountBundleSmall : Discount
    {
        public DiscountBundleSmall(string name, float price) : base(name, price)
        {
            ProductSequence.Add(typeof(Bagel));
            ProductSequence.Add(typeof(Bagel));
            ProductSequence.Add(typeof(Bagel));
            ProductSequence.Add(typeof(Bagel));
            ProductSequence.Add(typeof(Bagel));
            ProductSequence.Add(typeof(Bagel));
        }
    }
}
