namespace exercise.main
{
    public class Discount
    {
        public Item ItemOnDeal { get; }
        private float _savedMoney;
        private float _discount;
        public List<DiscountItem> DiscountItems { get; }

        public Discount(Item item, float discount, float savedMoney, List<DiscountItem> discountItems)
        {
            this.ItemOnDeal = item;
            this._discount = discount;
            this._savedMoney = savedMoney;
            DiscountItems = discountItems;
        }

        public float GetDiscount()
        {

            return _savedMoney;
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
