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

        public static Dictionary<string, Tuple<int, float, bool, float>> CompactProducts(List<IProduct> products, List<Discount> discounts)
        {
            List<string> SKUs = Inventory.GetValidProductSKUs();


            Dictionary<string, Tuple<int, float, bool, float>> compactedProducts = new Dictionary<string, Tuple<int, float, bool, float>>();
            int countOfSKU;
            float prediscountPrice;

            // TODO: Apply discounts to the discount value for each SKU
            List<IProduct> sortedProducts = products.OrderBy(p => p.GetBasePrice()).ToList();

            List<IProduct> pickListOfProducts = new List<IProduct>(sortedProducts);
            Dictionary<string, float> SKUDiscount = new Dictionary<string, float>();

            bool hasAppliedDiscount = false;

            foreach (Discount disc in discounts)
            {
                ApplyDiscountToSKUs(ref pickListOfProducts, SKUs, disc, ref SKUDiscount);
            }

            foreach (string SKU in SKUs)
            {
                List<IProduct> productsOfCurrentSKU = (new List<IProduct>(sortedProducts)).Where(prod => prod.GetSKUName() == SKU).ToList();
                prediscountPrice = products.Where(p => p.GetSKUName() == SKU).Sum(x => x.GetBasePrice());
                countOfSKU = productsOfCurrentSKU.Count();

                float discountAmountOnSKU = SKUDiscount.FirstOrDefault(x => x.Key == SKU).Value;
                float reducedPrice = 0f;
                if (discountAmountOnSKU != 0f) 
                {
                    reducedPrice = discountAmountOnSKU;
                    hasAppliedDiscount = true;
                }

                if (countOfSKU != 0)
                {
                    compactedProducts.Add(SKU, new Tuple<int, float, bool, float>(countOfSKU, reducedPrice, hasAppliedDiscount, prediscountPrice));
                }
            }
            return compactedProducts;

            static void ApplyDiscountToSKUs(ref List<IProduct> products, List<string> SKUs, Discount discount, ref Dictionary<string, float> SKUDiscount)
            {
                List<Type> discountCondition = new List<Type>(discount.ProductSequence);
                float discountAmount = discount.DiscountPrice;
                float discountAmountSplit = discountAmount / discountCondition.Count;

                while (discountCondition.Count != 0) 
                {
                    foreach (string SKU in SKUs) 
                    {
                        float currentDiscount = 0f;
                        List<IProduct> prodsOfSKU = new List<IProduct>(products.Where(p => p.GetSKUName() == SKU));
                        IProduct? product = prodsOfSKU.FirstOrDefault();
                        if (product != null) { 
                            List<Type> matchingConditionType = new List<Type>(discountCondition.Where(d => d == prodsOfSKU.FirstOrDefault()?.GetType()));
                            if (matchingConditionType != null) 
                            {
                                

                                    float appliedDiscountValue = Math.Min(discountAmountSplit, product.GetBasePrice());
                                    foreach (Type type in matchingConditionType) 
                                    {
                                        discountAmount -= appliedDiscountValue;
                                        currentDiscount += product.GetBasePrice() - appliedDiscountValue;

                                        products.Remove(product); // Need to remove from parent method for when applying multiple discounts
                                        prodsOfSKU.Remove(product);
                                        product = prodsOfSKU.FirstOrDefault();
                                        discountCondition.Remove(type);

                                        if (matchingConditionType.Count == 0 || product == null) { break; }
                                    }
                                }
                            }
                        // With mulitple discounts applied to basket we might get duplicates. Therefore need two methods to add to the dictionary
                        if (SKUDiscount.ContainsKey(SKU))
                        {
                            KeyValuePair<string, float> entry = SKUDiscount.Where(p => p.Key == SKU).First();
                            SKUDiscount.Remove(entry.Key);
                            float newValue = (entry.Value + currentDiscount);
                            SKUDiscount.Add(SKU, newValue);
                        }
                        else 
                        {
                            SKUDiscount.Add(SKU, currentDiscount);
                        }
                        

                        if (discountCondition.Count == 0) { break; }
                    }
                }
            }
        }
    }
}
