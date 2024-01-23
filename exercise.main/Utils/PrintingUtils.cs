using exercise.main.Discounts;
using exercise.main.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main.Utils
{
    public static class PrintingUtils
    {
        /// <summary>
        /// Generate a compact overview of the allProductsInBasket in the form of a Dictionary that that contain most pertinent information for receipt printing.
        /// </summary>
        /// <param name="products"> List<IProduct> of for every item that is to appear on the receipt</param>
        /// <param name="discounts">A List<Discount> of every discount that the List<IProduct> qualify for</param>
        /// <returns> Dictionary<string, Tuple<int, float, bool, float>> The dictionary key is the currentProduct SKU. In the tuple the values are as follows: number of items of the specified SKU, the total SKU cost after applying discounts, boolean of whether any discount was applied to the SKU, the pre-discount price of the SKU items.</returns>
        public static Dictionary<string, Tuple<int, float, bool, float>> CompactProducts(List<IProduct> products, List<Discount> discounts)
        {
            List<string> SKUs = Inventory.GetValidProductSKUs();
            List<IProduct> sortedProducts = products.OrderBy(p => p.GetBasePrice()).ToList();
            List<IProduct> pickListOfProducts = new List<IProduct>(sortedProducts); // Provided to each discount application by reference
            Dictionary<string, Tuple<float, bool>> SKUDiscount = new Dictionary<string, Tuple<float, bool>>(); // Provided to each discount application by reference
            foreach (Discount disc in discounts)
            {
                ApplyDiscountToSKUs(ref pickListOfProducts, SKUs, disc, ref SKUDiscount);
            }

            int itemsOfCurrentSKU;
            float prediscountPrice;
            bool hasAppliedDiscount = false;
            Dictionary<string, Tuple<int, float, bool, float>> compactedProducts = new Dictionary<string, Tuple<int, float, bool, float>>();
            foreach (string SKU in SKUs)
            {
                List<IProduct> productsOfCurrentSKU = (new List<IProduct>(sortedProducts)).Where(prod => prod.GetSKUName() == SKU).ToList();
                prediscountPrice = products.Where(p => p.GetSKUName() == SKU).Sum(x => x.GetBasePrice());
                itemsOfCurrentSKU = productsOfCurrentSKU.Count();

                if (itemsOfCurrentSKU != 0)
                {
                    Tuple<float, bool> discountAmountOnSKU = SKUDiscount.FirstOrDefault(x => x.Key == SKU).Value;
                    float reducedPrice = 0f;
                    if (discountAmountOnSKU.Item2)
                    {
                        reducedPrice = discountAmountOnSKU.Item1;
                        hasAppliedDiscount = true;
                    }
                    else 
                    {
                        reducedPrice = 0f;
                        hasAppliedDiscount = false;
                    }

                    compactedProducts.Add(SKU, new Tuple<int, float, bool, float>(itemsOfCurrentSKU, reducedPrice, hasAppliedDiscount, prediscountPrice));
                }
            }
            return compactedProducts;
        }

        private static void ApplyDiscountToSKUs(ref List<IProduct> allProductsInBasket, List<string> SKUs, Discount discount, ref Dictionary<string, Tuple<float, bool>> SKUDiscount)
        {
            List<Type> discountCondition = new List<Type>(discount.ProductSequence);
            float totalDiscountAmount = discount.DiscountPrice;
            float discountAmountEvenSplit = totalDiscountAmount / discountCondition.Count;

            while (discountCondition.Count != 0) 
            {
                foreach (string SKU in SKUs) 
                {
                    float currentSKUAppliedDiscount = 0f;
                    bool currentSKUDidApplyDiscount = false;
                    List<IProduct> productsOfCurrentSKU = new List<IProduct>(allProductsInBasket.Where(p => p.GetSKUName() == SKU));
                    IProduct? currentProduct = productsOfCurrentSKU.FirstOrDefault();
                    if (currentProduct != null) { 
                        List<Type> matchingConditionType = new List<Type>(discountCondition.Where(d => d == productsOfCurrentSKU.FirstOrDefault()?.GetType()));
                        if (matchingConditionType != null) 
                        {
                            // Need to select the smallest value, we dont give customers money when they buy something!
                            float appliedDiscountValue = Math.Min(discountAmountEvenSplit, currentProduct.GetBasePrice());

                            foreach (Type type in matchingConditionType) // Iterate through each Type for the discount
                            {
                                if (type == typeof(Coffee))
                                {
                                    appliedDiscountValue = Math.Min(totalDiscountAmount, currentProduct.GetBasePrice());
                                }

                                // Count up the remaining and applied discount
                                totalDiscountAmount -= appliedDiscountValue;
                                currentSKUAppliedDiscount += currentProduct.GetBasePrice() - appliedDiscountValue;
                                currentSKUDidApplyDiscount = true;

                                // Need to remove "used" allProductsInBasket, both to prevent double application and keep track of when discount is finished applying.
                                allProductsInBasket.Remove(currentProduct); 
                                productsOfCurrentSKU.Remove(currentProduct);
                                currentProduct = productsOfCurrentSKU.FirstOrDefault();
                                discountCondition.Remove(type);

                                // If no more products of the relevant SKU was found, break discount loop
                                if (currentProduct == null) { break; }
                            }
                        }
                     }

                    // With mulitple discounts applied to basket we might get duplicates. Therefore need two methods to add to the dictionary
                    if (SKUDiscount.ContainsKey(SKU))
                    { // Make new float value, remove old entry from dictionary, then add the new keyvaluepair
                        KeyValuePair<string, Tuple<float, bool>> entry = SKUDiscount.Where(p => p.Key == SKU).First();
                        SKUDiscount.Remove(entry.Key);
                        float newValue = (entry.Value.Item1 + currentSKUAppliedDiscount);
                        SKUDiscount.Add(SKU, new Tuple<float, bool>(newValue, currentSKUDidApplyDiscount));
                    }
                    else 
                    {
                        SKUDiscount.Add(SKU, new Tuple<float, bool>(currentSKUAppliedDiscount, currentSKUDidApplyDiscount));
                    }
                    // No more discount Types to apply
                    if (discountCondition.Count == 0) { break; }
                }
            }
        }

        public static Dictionary<string, float> GetAllCoffeeSKUs() 
        {
            Dictionary<string, float> allIProductSKUs = Inventory.GetValidProductsInformation();
            return allIProductSKUs.Where(sku => sku.Key.Contains("COF")).ToDictionary();
        }

        public static Dictionary<string, float> GetAllBagelSKUs()
        {
            Dictionary<string, float> allSKUs = Inventory.GetValidProductsInformation();
            return allSKUs.Where(sku => sku.Key.Substring(0, 3) == "BGL").ToDictionary();
        }

        public static Dictionary<string, float> GetAllFillingSKUs()
        {
            Dictionary<string, float> allSKUs = Inventory.GetValidFillingInformation();
            return allSKUs.Where(sku => sku.Key.Substring(0, 3) == "FIL").ToDictionary();
        }
    }
}
