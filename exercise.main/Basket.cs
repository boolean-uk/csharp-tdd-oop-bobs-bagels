namespace exercise.core;

public class Basket
{
    private List<StoreItem> items = new List<StoreItem>();
    public required int Capacity { get; set; }

    public List<StoreItem> GetItems()
    {
        return this.items;
    }

    public Receipt Purchase(DiscountContainer discounts)
    {
        var discounted = discounts.ApplyDiscounts(items);
        this.items = new List<StoreItem>();
        return new Receipt(discounted);
    }

    public double GetTotalPrice(DiscountContainer discounts)
    {
        var discounted = discounts.ApplyDiscounts(items);
        return discounted.Select(i => i.GetPrice()).Sum();
    }

    public bool AddItem(StoreItem item)
    {
        if (this.items.Count >= this.Capacity)
        {
            return false;
        }
        this.items.Add(item);
        return true;
    }

    public bool RemoveItem(StoreItem storeItem)
    {
        var found = this.items.Find(i => i.Equals(storeItem));
        if (found == null)
        {
            return false;
        }
        this.items.Remove(found);
        return true;
    }

    public bool UpdateCapacity(int newCapacity)
    {
        if (newCapacity < this.items.Count)
        {
            return false;
        }
        this.Capacity = newCapacity;
        return true;
    }
}
