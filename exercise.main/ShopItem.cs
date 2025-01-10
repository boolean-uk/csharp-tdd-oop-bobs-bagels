namespace exercise.main
{
    public class ShopItem
    {
        public string SKU { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }


        public ShopItem(string sku, string description, float price) 
        { 
            SKU = sku;
            Description = description;
            Price = price;
        }
    }
}