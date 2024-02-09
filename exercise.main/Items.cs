namespace exercise.main
{
    public class Item
    {
        public string Sku { get; }
        public decimal Price { get; }
        public string ItemName { get; }
        public string Variant { get; }

        protected Item(string sku, decimal price, string itemName, string variant)
        {
            Sku = sku;
            Price = price;
            ItemName = itemName;
            Variant = variant;
        }

        public virtual decimal GetPrice()
        {
            return Price;
        }
    }

    public class Bagel : Item
    {
        public List<Filling> Fillings { get; private set; }

        public Bagel(string sku, decimal price, string itemName, string variant) : base(sku, price, itemName, variant)
        {
            Fillings = new List<Filling>();
        }

        //Used by AddFilling to create a copy of previous bagel
        public Bagel(Bagel bagel, List<Filling> fillings) : base(bagel.Sku, bagel.Price, bagel.ItemName, bagel.Variant)
        {
            Fillings = new List<Filling>(fillings);
        }

        public override decimal GetPrice()
        {
            decimal totalPrice = this.Price;
            foreach (Filling filling in Fillings)
            {
                totalPrice += filling.GetPrice();
            }
            return totalPrice;
        }

        public Bagel AddFilling(Filling filling)
        {
            Bagel newBagel = new Bagel(this, this.Fillings);
            newBagel.Fillings.Add(filling);
            return newBagel;
        }
    }

    public class Coffee : Item
    {
        public Coffee(string sku, decimal price, string itemName, string variant) : base(sku, price, itemName, variant)
        {
        }
    }

    public class Filling : Item
    {

        public Filling(string sku, decimal price, string itemName, string variant) : base(sku, price, itemName, variant)
        {
        }
    }
}
