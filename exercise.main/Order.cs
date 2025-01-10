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
        throw new NotImplementedException();
    }
}