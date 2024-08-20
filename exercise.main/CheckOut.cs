using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public static class CheckOut
    {
        private static bool sixBagelDiscount(Basket basket)
        {
            return false;
        } 

        private static bool twelveBagelDiscount(Basket basket) 
        { 
            
            return false; 
        }

        private static bool bagelAndCoffe(Basket basket)
        {
            return false;
        }

        private static bool checkDiscount(Basket basket)
        {
            return false;
        }

        private static List<Discount> populateList(Basket basket)
        {
            List<Discount> discounts = new List<Discount>();
            discounts.Add(new Discount("BGLO", "Bagel", sixBagelDiscount, 2.49f, basket));

            return discounts;
        }

        public static Receipt checkOut(Basket basket)
        {
            List<Discount> discounts = populateList(basket);

            return null;
        }
    }
}
