using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Discounts
{
    public class DiscountManager
    {
        Discount SmallBagelBundle = new DiscountBundleSmall("6 bagels", 2.49f);
        Discount LargeBagelBundle = new DiscountBundleLarge("12 bagels", 3.99f);
        Discount CoffeeBagelBundle = new DiscountBundleSmall("coffee and bagel", 1.25f);

        private List<Discount> _discountList;
        public DiscountManager()
        {
            _discountList = new List<Discount> { 
                SmallBagelBundle,
                LargeBagelBundle,
                CoffeeBagelBundle
            };
        }
        /// <summary>
        /// Preliminary idea: Translate basket into a NEW list, if discount applies pop all relevant products and note the discount then recursively look if remaining products qualify for additional discounts. 
        /// Finally select the discount combinaation that returns the biggest total discount
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public float ApplyDiscounts(Basket basket, out List<Discount> discounts)
        {
            List<Product> productsList = basket.GetProducts();
            foreach (Discount disc in _discountList) 
            {
                var something = "Hello";
            }
            discounts = new List<Discount> { SmallBagelBundle };
            return 0f;
        }

        private float AttemptDiscount(List<Product> productList, out List<Discount> tempDiscounts) 
        {
            foreach (Discount disc in _discountList) // Need to check each discount instance
            {
                // Check if every product
                foreach (Product discountProduct in disc.GetSequence()) 
                {
                    productList.Where(prod => typeof(prod) == typeof(discountProduct))
                    if (typeof(discountProduct) == typeof(productList))
                    {

                    }
                    else 
                    {
                        break; // produts does not comply with discount sequence, break loop
                    }
                }
            }
        }
    }
}
