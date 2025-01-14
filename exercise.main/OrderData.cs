using exercise.main.Discount;
namespace exercise.main
{
    public struct OrderData
    {
        public string name;
        public string productType;
        public int amount;
        public float discounted_price; 
        public float total_price; 
        public float saving;
        private DiscountBase _usedDiscount;

        public DiscountBase UsedDiscount { get => _usedDiscount; set => _usedDiscount = value; }
    }




}
