namespace exercise.main;

public class Product
{
    public string Sku { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public Dictionary<int, double> Promotions { get; }
    public List<ProductModification> AllowedMofifications { get; set; }

    
    public Product(string sku, string name, double price)
    {
        Sku = sku;
        Name = name;
        Price = price;
        Promotions = new Dictionary<int, double>();
        AllowedMofifications = new List<ProductModification>();
    }
    
    public double GetPrice()
    {
        throw new NotImplementedException();
    }
    
    public void SetPrice(double price)
    {
        throw new NotImplementedException();
    }
    
    public void AddPromotion(int quantity, double price)
    {
        throw new NotImplementedException();
    }
}