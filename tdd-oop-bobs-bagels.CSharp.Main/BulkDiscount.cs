namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class BulkDiscount : Discount
    {
        public override bool IsDiscounted(IProduct product)
        {
            return product is Bagel;
        }

        public override decimal CalculateDiscount(IProduct product, int quantity, decimal originalPrice, List<OrderItem> basketItems)
        {
            if (quantity == 6)
            {
                return 6 * product.Price - 2.49M;
            }
            else if (quantity == 12)
            {
                return 12 * product.Price - 3.99M;
            }
            return 0M;
        }
    }
}