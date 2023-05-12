namespace csharp_tdd_oop_bobs_bagels.Source
{
    public class Item
    {
        private string sku;
        private decimal price;
        private string name;
        private string variant;

        public string SKU { get { return sku; } set { sku = value; } }
        public decimal Price { get { return price; } set { price = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Variant { get { return variant; } set { variant = value; } }

        public Item(string Sku, decimal Price, string Name, string Variant)
        {
            this.SKU = Sku;
            this.Price = Price;
            this.Name = Name;
            this.Variant = Variant;
        }
    }
}