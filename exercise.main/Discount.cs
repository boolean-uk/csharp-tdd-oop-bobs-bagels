namespace exercise.main
{
    public class Discount
    {
        public Item ItemWithDeal { get; }
        private decimal _discount;
        public List<RequiredItemsForDiscount> RequiredItemsForDiscount { get; }

        public Discount(Item item, decimal discount, List<RequiredItemsForDiscount> discountItems)
        {
            this.ItemWithDeal = item;
            this._discount = discount;
            RequiredItemsForDiscount = discountItems;
        }

        public decimal GetDiscountedPrice()
        {
            decimal totalCost = 0;
            foreach (var discountItem in this.RequiredItemsForDiscount)
            {
                decimal price = discountItem.Item.Price;
                int quantity = discountItem.Quantity;

                totalCost += price * quantity;
            }

            var discountedPrice = totalCost - this._discount;

            return discountedPrice;
        }
    }

    public struct RequiredItemsForDiscount
    {
        public Item Item { get; }
        public int Quantity { get; }
        public RequiredItemsForDiscount(Item item, int quantity)
        {
            this.Item = item;
            this.Quantity = quantity;
        }
    }
}
