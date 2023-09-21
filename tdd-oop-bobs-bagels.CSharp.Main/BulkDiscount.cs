namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class BulkDiscount : Discount
    {
        private const decimal BAGEL_PRICE_THRESHOLD = 0.42M;

        public override bool IsDiscounted(IProduct product)
        {
            return product is Bagel && product.Price > BAGEL_PRICE_THRESHOLD;
        }

        public override decimal CalculateDiscount(IProduct product, int quantity, decimal originalPrice, List<OrderItem> basketItems)
        {
            int totalBagels = basketItems.Where(item => item.Product is Bagel).Sum(item => item.Quantity);

            if (product is Bagel && product.Price > BAGEL_PRICE_THRESHOLD)
            {
                if (totalBagels >= 6 && totalBagels < 12)
                {
                    decimal totalDiscountFor6 = (6 * originalPrice) - 2.49M;
                    return totalDiscountFor6 / 6;
                }
                else if (totalBagels >= 12)
                {
                    decimal totalDiscountFor12 = (12 * originalPrice) - 3.99M;
                    return totalDiscountFor12 / 12;
                }
            }
            return 0M;
        }
    }
}