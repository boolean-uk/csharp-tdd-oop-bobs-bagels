namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class BulkDiscount : Discount
    {
        private const decimal BAGEL_PRICE_THRESHOLD = 0.42M;

        public override bool IsDiscounted(IProduct product)
        {
            return product is Bagel && product.Price > BAGEL_PRICE_THRESHOLD;
        }

        public decimal GetDiscountForBulk(int itemCount, decimal totalBagelPrice)
        {
            Console.WriteLine($"Calculating bulk discount for {itemCount} items.");

            if (itemCount >= 12)
            {
                return totalBagelPrice - 3.99M;
            }
            else if (itemCount >= 6)
            {
                return totalBagelPrice - 2.49M;
            }
            else
            {
                return 0M;
            }
        }

        public override decimal CalculateDiscount(IProduct product, int quantity, decimal originalPrice, List<OrderItem> basketItems)
        {
            if (product is Bagel && product.Price > BAGEL_PRICE_THRESHOLD)
            {
                var bagelItems = basketItems.Where(item => item.Product is Bagel).ToList();
                int bagelItemCount = bagelItems.Sum(item => item.Quantity);
                decimal totalBagelPrice = bagelItemCount * originalPrice;

                // Use the GetDiscountForBulk method to calculate the bulk discount
                decimal bulkDiscount = GetDiscountForBulk(bagelItemCount, totalBagelPrice);

                Console.WriteLine($"Bulk discount applied to {product.Name} (Quantity: {quantity}). Original Price: {originalPrice}, Discounted Price: {originalPrice - bulkDiscount}");

                return bulkDiscount;
            }
            return 0M;
        }
    }
}