namespace exercise.main;

public class Basket
{
    private int _capacity;
    private List<BasketItem> _items;
    
    private readonly IInventory _inventory;
    
    public Basket(IInventory inventory, int capacity = 10)
    {
        _capacity = capacity;
        _items = new List<BasketItem>();
        _inventory = inventory;
    }
    public void Add(string SKU, int quantity)
    {
        // Do not allow overfilled bagel basket!
        if (GetNumberOfItems() + quantity > _capacity)
        {
            throw new Exception("Basket is full");
        }
        
        var item = Get(SKU);
        
        if (ReferenceEquals(item, null))
        {
            _items.Add(new BasketItem(SKU, quantity));
            return;
        }
        
        item.Quantity = quantity;
    }
    
    public void Remove(string SKU, int quantity)
    {
        var item = Get(SKU);
        // Check if nullable item is null or empty
        
        if (!ReferenceEquals(item, null))
        {
            Get(SKU).Quantity -= quantity;
        }
    }
    
    public BasketItem? Get(string SKU)
    {
        return _items.FirstOrDefault(x => x.SKU == SKU);
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
            numItems += item.Quantity;
        }

        return numItems;
    }
    
    public double GetTotal()
    {
        double total = 0;
        
        foreach (var item in _items)
        {
            var price = _inventory.GetProduct(item.SKU).GetPrice();
            
            total += price * item.Quantity;
        }
        
        return total;
    }
    
    public Order Order()
    {
        Order order = new Order();
        Dictionary<string, double> discounts = CheckDiscounts();

        foreach (var item in _items)
        {
            var product = _inventory.GetProduct(item.SKU);
            order.Add(product, item.Quantity);
        }

        foreach (var discount in discounts)
        {
            order.AddModifier(discount.Key, 0, discount.Value * -1);
        }
        
        return order;
    }
    
    public override string ToString()
    {
        throw new NotImplementedException();
    }
    
    private Dictionary<string, double> CheckDiscounts()
    {
        var discounts = new Dictionary<string, double>();
        var numBagels = 0;
        var numCoffees = 0;
        var discount = 0.0;

        foreach (var basketItem in _items)
        {
            if (basketItem.SKU.StartsWith("BGL"))
            {
                numBagels += basketItem.Quantity;
            }
            
            if (basketItem.SKU.StartsWith("COF"))
            {
                numCoffees += basketItem.Quantity;
            }
        }

        // Apply the 12 for 3.99 offer
        var twelves = numBagels / 12;
        discount = twelves * (12 * 0.49 - 3.99);
        numBagels %= 12;
        // Discount is only applied when more than 0
        if (discount > 0)
        {
            discounts.Add("12 for 3.99", discount);
        }

        // Apply the 6 for 2.49 offer
        var sixes = numBagels / 6;
        discount = sixes * (6 * 0.49 - 2.49);
        numBagels %= 6;
        if (discount > 0)
        {
            discounts.Add("6 for 2.49", discount);
        }

        // Coffee deal. Not to be combined with other deals
        var qualifyingMealDeals = Math.Min(numBagels, numCoffees);
        discount = qualifyingMealDeals * 0.5;
        if (discount > 0)
        {
            discounts.Add("Coffee and Bagel", discount);
        }
        
        return discounts;
    }
    
    private bool CheckCapacity(int numNewItems)
    {
        throw new NotImplementedException();
    }

    private BasketItem? Contains(string SKU)
    {
        return Contains(SKU, []);
    }
    
    private BasketItem? Contains(string SKU, List<string> modifiers)
    {
        modifiers.Sort();
        try
        {
            return _items.First(x => x.SKU == SKU && x.Modifiers.SequenceEqual(modifiers));
        }
        catch
        {
            return null;
        }
    }
}