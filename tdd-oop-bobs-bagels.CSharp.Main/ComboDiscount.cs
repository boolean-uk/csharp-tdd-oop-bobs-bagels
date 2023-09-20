namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class ComboDiscount : Discount
    {
        private decimal comboPrice = 1.25M;

        public override bool IsDiscounted(IProduct product)
        {
            return product is Coffee || product is Bagel;
        }

        public override decimal CalculateDiscount(IProduct product, int quantity, decimal originalPrice, List<OrderItem> basketItems)
        {
            if (product is Coffee && BasketContainsProduct(typeof(Bagel), basketItems))
            {
                return (product.Price + GetProductPriceFromBasket(typeof(Bagel), basketItems)) - comboPrice;
            }
            else if (product is Bagel && BasketContainsProduct(typeof(Coffee), basketItems))
            {
                return 0M; // Return 0 because the discount is already applied when adding the coffee
            }
            return 0M;
        }

        private bool BasketContainsProduct(Type productType, List<OrderItem> basketItems)
        {
            return basketItems.Any(item => item.Product.GetType() == productType);
        }

        private decimal GetProductPriceFromBasket(Type productType, List<OrderItem> basketItems)
        {
            var product = basketItems.FirstOrDefault(item => item.Product.GetType() == productType);
            return product?.Product.Price ?? 0M;
        }
    }
}