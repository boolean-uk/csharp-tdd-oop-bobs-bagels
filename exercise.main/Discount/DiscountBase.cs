namespace exercise.main.Discount
{
    public abstract class DiscountBase
    {
        public DiscountBase(float discountedPrice, Inventory inventory)
        {
            discountPrice = discountedPrice;
            _inventory = inventory;
        }
        //private Func<int, int> discountConditionFunc;
        //private Action discountConditionFunc;

        //public void defineCondition(Func<int,int> func )
        private float discountPrice;
        protected Inventory _inventory;

        public float DiscountPrice { get => discountPrice; }

        public abstract bool checkCondition(Basket basket);
        public abstract DiscountedProductCount getDiscountedPrice(Basket basket);
        public abstract string stringify();
    }




}
