namespace exercise.main
{
    public interface Iitems
    {
        string Sku { get; }
        float Price { get; }
        string ItemName { get; }
        string Variant { get; }

        float GetPrice();
    }

    public class Bagel : Iitems
    {
        public string Sku { get; }
        public float Price { get; }
        public string ItemName { get; }
        public string Variant { get; }
        private List<Filling> _fillings;

        public Bagel(string sku, float price, string itemName, string variant)
        {
            Sku = sku;
            Price = price;
            ItemName = itemName;
            Variant = variant;
            _fillings = new List<Filling>();
        }

        public Bagel(Bagel bagel, List<Filling> fillings)
        {
            Sku = bagel.Sku;
            Price = bagel.Price;
            ItemName = bagel.ItemName;
            Variant = bagel.Variant;
            _fillings = new List<Filling>(fillings);
        }

        public float GetPrice()
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

    public class Filling : Iitems
    {
        public string Sku { get; }
        public float Price { get; }
        public string ItemName { get; }
        public string Variant { get; }

        public Filling(string sku, float price, string itemName, string variant)
        {
            Sku = sku;
            Price = price;
            ItemName = itemName;
            Variant = variant;
        }

        public float GetPrice()
        {
            return Price;
        }
    }
}
