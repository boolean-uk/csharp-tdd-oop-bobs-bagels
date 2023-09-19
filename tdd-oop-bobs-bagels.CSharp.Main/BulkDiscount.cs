namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class BulkDiscount : Discount
    {
        private readonly Dictionary<int, decimal> _bulkPrices = new Dictionary<int, decimal>
    {
        { 12, 3.99M },
        { 6, 2.49M }
    };

        public override bool IsDiscounted(IProduct product)
        {
            return product is Bagel;
        }

        public override decimal CalculateDiscount(IProduct product, int quantity, decimal originalPrice)
        {
            if (!IsDiscounted(product))
            {
                return 0M;
            }

            decimal discountAmount = 0M;
            decimal bagelPrice = (product as Bagel).Price;

            if (quantity >= 12)
            {
                // Apply the 12 for 3.99 discount
                int setsOf12 = quantity / 12;
                int remaining = quantity % 12;
                discountAmount = setsOf12 * 3.99M + remaining * bagelPrice;
            }
            else if (quantity >= 6)
            {
                // Apply the 6 for 2.49 discount
                int setsOf6 = quantity / 6;
                int remaining = quantity % 6;
                discountAmount = setsOf6 * 2.49M + remaining * bagelPrice;
            }
            else
            {
                // No bulk discount for this quantity
                discountAmount = quantity * bagelPrice;
            }

            return originalPrice - discountAmount;
        }

    }
}