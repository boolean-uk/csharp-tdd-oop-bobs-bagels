namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Bagel : IProduct
    {
        public string SKU { get; }
        public decimal Price { get; }
        public string Name { get; }
        public string Variant { get; }
        private List<Filling> fillings;

        public Bagel(string sku, decimal price, string name, string variant)
        {
            SKU = sku;
            Price = price;
            Name = name;
            Variant = variant;
            fillings = new List<Filling>();
        }

        public decimal GetPrice() => Price;

        public bool AddFilling(Filling filling)
        {
            if (!fillings.Contains(filling))
            {
                fillings.Add(filling);
                return true;
            }
            return false;
        }

        public bool RemoveFilling(Filling filling) => fillings.Remove(filling);

        public decimal TotalCostWithFilling() => Price + fillings.Sum(f => f.GetPrice());

        public decimal TotalFillingsCost()
        {
            return fillings.Sum(f => f.GetPrice());
        }
    }
}