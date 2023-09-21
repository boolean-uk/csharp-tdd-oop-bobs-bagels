namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class OrderItem
    {
        public IProduct Product { get; }
        public int Quantity { get; private set; }
        public decimal OriginalPrice { get; }
        public decimal DiscountedPrice { get; private set; }

        public void AdjustQuantity(int adjustment)
        {
            Quantity += adjustment;
        }

        public OrderItem(IProduct product, int quantity)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
            Quantity = quantity;
            OriginalPrice = product.Price;
            DiscountedPrice = OriginalPrice; // Set the initial discounted price to original price
        }

        public decimal TotalPrice()
        {
            return DiscountedPrice * Quantity;
        }

        public decimal GetSavings()
        {
            return (OriginalPrice - DiscountedPrice) * Quantity;
        }

        public void AdjustDiscountedPrice(decimal newPrice)
        {
            DiscountedPrice = newPrice;
        }
    }
}