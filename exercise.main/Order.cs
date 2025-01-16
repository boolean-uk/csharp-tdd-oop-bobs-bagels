using System.Text;

namespace exercise.main;

public class Order
{
    private List<OrderLine> _orderLines;
    private DateTime _date;
    
    public Order()
    {
        _orderLines = new List<OrderLine>();
        _date = DateTime.Now;
    }
    
    public override string ToString()
    {
        var sb = new StringBuilder();
        
        sb.AppendLine("------- Bob's Bagels -------\n");
        sb.AppendLine($"    {_date}    \n");

        
        sb.AppendLine("Product         Amt Price");
        
        foreach (var orderLine in _orderLines)
        {
            sb.AppendLine($"{
                FixedLengthString(orderLine.Product, 15)} " +
                          $"{FixedLengthString(orderLine.Amount.ToString(), 2)} " +
                          $"{FormatPrice(orderLine.Price)}");
        }
        
        sb.AppendLine($"\n{"Total:", 18} {FormatPrice(Total())}");
        
        return sb.ToString();
    }

    public void Add(Product product, int amount)
    {
        _orderLines.Add(new OrderLine
        {
            Product = product.Name,
            Amount = amount,
            Price = product.GetPrice()
        });
    }
    
    public void AddModifier(string label, int amount, double price)
    {
        _orderLines.Add(new OrderLine
        {
            Product = label,
            Amount = amount,
            Price = price
        });
    }
    
    public double Total()
    {
        return _orderLines.Sum(ol => ol.Price * Math.Max(1, ol.Amount));
    }
    
    private string FixedLengthString(string value, int length)
    {
        return value.PadRight(length).Substring(0, length);
    }
    
    private string FormatPrice(double price)
    {
        if (price < 0)
        {
            return $"(€{price.ToString("F2")})";
        }

        return $" €{price.ToString("F2")}";
    }
}