namespace exercise.main
{
    public class Discount
    {
        public Item ItemOnDeal { get; }
        private float _discount;
        public List<DiscountItem> DiscountItems { get; }

        public Discount(Item item, float discount, List<DiscountItem> discountItems)
        {
            this.ItemOnDeal = item;
            this._discount = discount;
            DiscountItems = discountItems;
        }

        public float GetDiscount()
        {
            float totalCost = 0;
            foreach (var discountItem in this.DiscountItems)
            {
                float price = discountItem.Item.Price;
                int quantity = discountItem.Quantity;

                totalCost += price * quantity;
            }
            return totalCost - this._discount;
        }
    }

    public struct DiscountItem
    {
        public Item Item { get; }
        public int Quantity { get; }
        public DiscountItem(Item item, int quantity)
        {
            this.Item = item;
            this.Quantity = quantity;
        }
    }
}
