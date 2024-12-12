
namespace exercise.main
{
    public class InventoryProducts
    {
        public string SKU { get;  set; }
        public double Price { get;  set; }
        public string Name { get;  set; }
        public string Variant { get;  set; }
        public double Save {  get; set; }

        public InventoryProducts() { }
        public InventoryProducts(string SKU, double Price, string Name, string Variant)
        {
            this.SKU = SKU;
            this.Price = Price;
            this.Name = Name;   
            this.Variant = Variant;
        }


    
    }


}