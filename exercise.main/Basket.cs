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
        // Do not allow overfilled bagel basket!
        if (GetNumberOfItems() + quantity > _capacity)
        {
            throw new Exception("Basket is full");
        }
        
        if (!_items.ContainsKey(SKU))
        {
            _items.Add(SKU, quantity);
            return;
        }
        
        _items[SKU] += quantity;
    }
    
    public void Remove(string SKU, int quantity)
    {
        if (!_items.ContainsKey(SKU))
        {
            return;
        }
        
        _items[SKU] -= quantity;
    }
    
    public void SetCapacity(int capacity)
    {
        _capacity = capacity;
    }
    
    public int GetCapacity()
    {
        return _capacity;
    }
    
    private int GetNumberOfItems()
    {
        var numItems = 0;

        foreach (var item in _items)
        {
            numItems += item.Value;
        }

        return numItems;
    }
    
    public double GetTotal()
    {
        double total = 0;
        
        foreach (var item in _items)
        {
            var price = _inventory.GetProduct(item.Key).GetPrice();
            
            total += price * item.Value * item.Value;
        }
        
        return total;
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