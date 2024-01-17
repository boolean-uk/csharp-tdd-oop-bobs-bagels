using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Discounts
{
    public static class DiscountManager
    {
        static Discount SmallBagelBundle = new DiscountBundleSmall("6 bagels", 2.49f);
        static Discount LargeBagelBundle = new DiscountBundleLarge("12 bagels", 3.99f);
        static Discount CoffeeBagelBundle = new DiscountBundleBagelAndCoffee("coffee and bagel", 1.25f);

        private static List<Discount> _discountList = new List<Discount> {
            LargeBagelBundle,
            SmallBagelBundle,
            CoffeeBagelBundle 
        };

        /// <summary>
        /// Preliminary idea: Translate basket into a NEW list, if discount applies pop all relevant products and note the discount then recursively look if remaining products qualify for additional discounts. 
        /// Finally select the discount combinaation that returns the biggest total discount
        /// </summary>
        /// <param name="basket"> The basket to apply discounts to </param>
        /// <returns> The final new price of the basket </returns>
        public static float ApplyDiscounts(Basket basket, out List<Discount> discounts)
        {
            List<Product> productsList = basket.GetProducts();
            float discountedItemsTotalPrice = 0f;
            List<Discount> appliedDiscounts = new List<Discount>();
            float totalDiscountExemptCosts = 0f;

            AttemptDiscount(ref discountedItemsTotalPrice, ref productsList, ref appliedDiscounts, ref totalDiscountExemptCosts);


            discounts = new List<Discount>(appliedDiscounts);
            return discountedItemsTotalPrice + totalDiscountExemptCosts;
        }

        private static void AttemptDiscount(ref float discountedItemsTotalPrice, ref List<Product> list, ref List<Discount> appliedDiscounts, ref float totalDiscountExemptCosts) 
        {


            foreach (Discount disc in _discountList) // Need to check each discount instance
            {
                // Check if every product in discount sequence is within the list.
                // If not then addDisc turns false, the list is regenerated and we attempt 
                bool addDisc = true;
                float originalCosts = 0f;
                float discountExemptCosts = 0f;
                List<Product> preAttemptList = new List<Product>(list); // Save snapshot incase we need to restore this list
                foreach (Type discountProduct in disc.GetSequence()) 
                {
                    Product? basketItem = list.FirstOrDefault(prod => prod.GetType() == discountProduct); // null if nothing found
                    if (basketItem != null)
                    {
                        originalCosts += basketItem.GetBasePrice();
                        discountExemptCosts += (basketItem.GetPrice() - basketItem.GetBasePrice());
                        list.Remove(basketItem);
                    }
                    else 
                    {
                        addDisc = false;
                        break; // products does not comply with discount sequence, break loop
                    }
                }
                if (addDisc)
                { // This discount has been applied, remaining basket items run through again.
                    appliedDiscounts.Add(disc);
                    totalDiscountExemptCosts += discountExemptCosts;
                    AttemptDiscount(ref discountedItemsTotalPrice, ref list, ref appliedDiscounts, ref totalDiscountExemptCosts);
                    break;
                }
                else 
                {
                    list = new List<Product>(preAttemptList);
                }
                
            }
            discountedItemsTotalPrice = appliedDiscounts.Sum(x => x.DiscountPrice) + list.Sum(x => x.GetPrice());
        }
    }
}
