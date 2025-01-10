namespace exercise.main;

public class Basket
{
    private int _capacity;
    private Dictionary<string, int> _items;
    
    private readonly IInventory _inventory;
    
    public Basket(IInventory inventory, int capacity = 10)
    {
        _capacity = capacity;
        _items = new Dictionary<string, int>();
        _inventory = inventory;
    }
    public void Add(string SKU, int quantity)
    {
        throw new NotImplementedException();
    }
    
    public void Remove(string SKU, int quantity)
    {
        throw new NotImplementedException();
    }
    
    public void SetCapacity(int capacity)
    {
        throw new NotImplementedException();
    }
    
    public int GetCapacity()
    {
        throw new NotImplementedException();
    }
    
    public double GetTotal()
    {
        throw new NotImplementedException();
    }
    
    public Order Order()
    {
        throw new NotImplementedException();
    }
    
    public override string ToString()
    {
        throw new NotImplementedException();
    }
    
    private Dictionary<string, double> CheckDiscounts()
    {
        throw new NotImplementedException();
    }
    
    private bool CheckCapacity(int numNewItems)
    {
        throw new NotImplementedException();
    }
}