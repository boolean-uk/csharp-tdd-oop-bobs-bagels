namespace exercise.main
{
    public class Bagel : Item
    {
        public Bagel(string name) : base(name) { }
        public Bagel(string name, string type) : base(name, type) { }
        public Bagel(string sku, double cost, string name, string type) : base(sku, cost, name, type) { }


        public static void AddFilling(Item filling)
        {
            Basket basket = new Basket();
            basket.BasketItems.Add(filling);
        }

    }
}
