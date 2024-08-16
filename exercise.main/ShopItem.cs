namespace exercise.main
{
    public class ShopItem
    {
        public string SKU { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public char Type { get; set; }

        public ShopItem(string sku, string description, float price, char type) 
        { 
            SKU = sku;
            Description = description;
            Price = price;
            Type = type;
        }
    }
}