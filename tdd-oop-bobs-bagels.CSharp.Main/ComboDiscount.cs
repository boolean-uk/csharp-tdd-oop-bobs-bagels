namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class ComboDiscount : Discount
    {
        public static decimal comboPrice = 1.25M;

        public override bool IsDiscounted(IProduct product)
        {
            return product is Coffee || product is Bagel;
        }

        public override decimal CalculateDiscount(IProduct product, int quantity, decimal originalPrice, List<OrderItem> basketItems)
        {
            if (product is Coffee && BasketContainsProduct(typeof(Bagel), basketItems))
            {
                var bagelItem = basketItems.FirstOrDefault(item => item.Product is Bagel);
                if (bagelItem != null)
                {
                    decimal totalBeforeDiscount = product.Price + bagelItem.OriginalPrice;
                    decimal totalDiscount = totalBeforeDiscount - comboPrice;
                    decimal coffeeDiscount = totalDiscount / 2;
                    decimal bagelDiscount = totalDiscount / 2;
                    bagelItem.AdjustDiscountedPrice(bagelItem.OriginalPrice - bagelDiscount);
                    Console.WriteLine($"Applied combo discount to Coffee. New Discounted Price for Bagel: {bagelItem.DiscountedPrice}");
                    return coffeeDiscount;
                }
            }
            else if (product is Bagel && BasketContainsProduct(typeof(Coffee), basketItems))
            {
                var coffeeItem = basketItems.FirstOrDefault(item => item.Product is Coffee);
                if (coffeeItem != null && coffeeItem.DiscountedPrice == coffeeItem.OriginalPrice) // Check if the coffee hasn't received the combo discount
                {
                    decimal totalBeforeDiscount = product.Price + coffeeItem.OriginalPrice;
                    decimal totalDiscount = totalBeforeDiscount - comboPrice;
                    decimal coffeeDiscount = totalDiscount / 2;
                    decimal bagelDiscount = totalDiscount / 2;
                    coffeeItem.AdjustDiscountedPrice(coffeeItem.OriginalPrice - coffeeDiscount);
                    Console.WriteLine($"Applied combo discount to Bagel. New Discounted Price for Coffee: {coffeeItem.DiscountedPrice}");
                    return bagelDiscount;
                }
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