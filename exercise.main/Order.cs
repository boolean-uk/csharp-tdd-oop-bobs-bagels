using System.Text;

namespace exercise.main;

public class Order
{
    private List<OrderLine> _orderLines;
    
    public Order()
    {
        _orderLines = new List<OrderLine>();
    }
    
    
    
    public override string ToString()
    {
        var sb = new StringBuilder();
        
        foreach (var orderLine in _orderLines)
        {
            sb.AppendLine($"{
                FixedLengthString(orderLine.Product.Name, 15)} " +
                          $"{FixedLengthString(orderLine.Amount.ToString(), 2)} " +
                          $"{FormatPrice(orderLine.Price)}");
        }
        
        return sb.ToString();
    }

    public void Add(Product product, int amount)
    {
        _orderLines.Add(new OrderLine
        {
            Product = product,
            Amount = amount,
            Price = product.GetPrice()
        });
    }
    
    private string FixedLengthString(string value, int length)
    {
        return value.PadRight(length).Substring(0, length);
    }
    
    private string FormatPrice(double price)
    {
        if (price < 0)
        {
            return $"(-€{price})";
        }

        return $" €{price}";
    }
}