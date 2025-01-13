namespace exercise.main.Discount
{
    public class Discount_XforY : Discount
    {
        Dictionary<string, int> nrOfRequiredProducts = new Dictionary<string, int>();

        public Discount_XforY(Dictionary<string, int> nrOfRequiredProductsSKU, float discountedPrice, Inventory inventory)
            : base(discountedPrice, inventory)
        {
            nrOfRequiredProducts = nrOfRequiredProductsSKU;

        }
        public override bool checkCondition(Basket basket)
        {
            foreach (var discountReq in nrOfRequiredProducts)
            {
                if (basket.countProductTypes(discountReq.Key) < discountReq.Value)
                    return false;
            }
            return true;
        }

        public override DiscountedProductCount getDiscountedPrice(Basket basket)
        {
            Dictionary<string, int> discountedProductSKU = new Dictionary<string, int>();
            float totalCost_withoutDiscount = 0.0f;
            float totalCost_withDiscount = 0.0f;
            float discountedSavings = 0.0f;

            foreach (var discountReq in nrOfRequiredProducts)
            {
                string SKU = discountReq.Key;
                int requiredProduct = discountReq.Value;
                int d = (int)MathF.Floor(basket.countProductTypes(SKU) / discountReq.Value);

                //float? defprice = basket.getDefaultPrice(SKU);
                ////if (defprice == null)
                //Debug.Assert(defprice != null, "expected SKU to exist in basket...");

                var defprice = _inventory.getPrice(SKU);

                //totalCost_withoutDiscount +=  discountReq.Value * d * (defprice ?? 1.0f);
                totalCost_withoutDiscount += discountReq.Value * d * defprice;

                discountedProductSKU[SKU] = d;
            }

            // The max possible discount is limited by the smalletst multiplier
            float maxDiscountMultiplier = discountedProductSKU.ToList().Min(x => x.Value);

            totalCost_withDiscount = this.DiscountPrice * maxDiscountMultiplier;

            discountedSavings = this.DiscountPrice - totalCost_withoutDiscount;

            Dictionary<string, int> nrOfDiscounted = new Dictionary<string, int>();
            foreach (var discountReq in nrOfRequiredProducts)
            {
                string SKU = discountReq.Key;
                int requiredProduct = discountReq.Value;
                nrOfDiscounted[SKU] = (int)maxDiscountMultiplier * requiredProduct;
            }

            DiscountedProductCount dp = new DiscountedProductCount
            {
                //SKU_amount = discountedProductSKU,
                SKU_amount = nrOfDiscounted,
                //discountMultiple = maxDiscountMultiplier ,
                discountMultiple = (int)maxDiscountMultiplier,
                possibleSavings = discountedSavings,
                finalPrice = totalCost_withDiscount
            };

            return dp;
        }
    }




}
