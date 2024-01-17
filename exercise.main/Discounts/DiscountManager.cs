using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Discounts
{
    public class DiscountManager
    {

        /// <summary>
        /// Preliminary idea: Translate basket into a NEW list, if discount applies pop all relevant products and note the discount then recursively look if remaining products qualify for additional discounts. 
        /// Finally select the discount combinaation that returns the biggest total discount
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public float ApplyDiscounts(Basket basket, out List<Discount> discounts)
        {
            throw new NotImplementedException();
        }
    }
}
