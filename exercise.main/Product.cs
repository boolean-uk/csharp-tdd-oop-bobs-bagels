namespace exercise.main;

public class Product
{
    public string Sku { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public Dictionary<int, double> Promotions { get; }
    public List<ProductModification> AllowedModifications { get; set; }
    public List<string> Modifications { get; set; }

    
    public Product(string sku, string name, double price)
    {
        Sku = sku;
        Name = name;
        Price = price;
        Promotions = new Dictionary<int, double>();
        AllowedModifications = new List<ProductModification>();
    }
    
    public double GetPrice()
    {
        return Price;
    }
    
    public void SetPrice(double price)
    {
        if (price <= 0)
        {
            throw new Exception("Price must be greater than 0");
        }
        
        Price = price;
    }
    
    public void AddModification(ProductModification modification)
    {
        // Checks if the modification SKU is allowed, then add and sort
        if (AllowedModifications.Any(m => m.Sku == modification.Sku))
        {
            Modifications.Add(modification.Sku);
        }
    }
    
    public void AddPromotion(int quantity, double price)
    {
        if (quantity > 0 && price > 0)
        {
            Promotions.Add(quantity, price);
            return;
        }
        
        throw new Exception("Invalid promotion. Quantity and promotional price must be greater than 0");
    }
}