namespace exercise.main
{
    public class Item
    {
        public string Sku { get; }
        public float Price { get; }
        public string ItemName { get; }
        public string Variant { get; }

        protected Item(string sku, float price, string itemName, string variant)
        {
            Sku = sku;
            Price = price;
            ItemName = itemName;
            Variant = variant;
        }

        public virtual float GetPrice()
        {
            return Price;
        }
    }

    public class Bagel : Item
    {
        private List<Filling> _fillings;

        public Bagel(string sku, float price, string itemName, string variant) : base(sku, price, itemName, variant)
        {
            _fillings = new List<Filling>();
        }

        //Used by AddFilling to create a copy of previous bagel
        public Bagel(Bagel bagel, List<Filling> fillings) : base(bagel.Sku, bagel.Price, bagel.ItemName, bagel.Variant)
        {
            _fillings = new List<Filling>(fillings);
        }

        public override float GetPrice()
        {
            float totalPrice = this.Price;
            foreach (Filling filling in _fillings)
            {
                totalPrice += filling.GetPrice();
            }
            return totalPrice;
        }

        public Bagel AddFilling(Filling filling)
        {
            Bagel newBagel = new Bagel(this, this._fillings);
            newBagel._fillings.Add(filling);
            return newBagel;
        }
    }

    public class Coffee : Item
    {
        public Coffee(string sku, float price, string itemName, string variant) : base(sku, price, itemName, variant)
        {
        }
    }

    public class Filling : Item
    {

        public Filling(string sku, float price, string itemName, string variant) : base(sku, price, itemName, variant)
        {
        }
    }
}
