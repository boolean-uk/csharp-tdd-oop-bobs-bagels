namespace exercise.main;

public class BasketItem
{
    public string SKU { get; set; }
    public int Quantity { get; set; }
    public List<string> Modifiers { get; set; }
    
    public BasketItem(string sku, int quantity)
    {
        SKU = sku;
        Quantity = quantity;
        Modifiers = new List<string>();
    }
}