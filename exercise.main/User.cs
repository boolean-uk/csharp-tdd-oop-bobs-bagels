namespace exercise.core;

public enum Privilege
{
    User,
    Admin,
}

public class User
{
    public required Privilege priv { get; init; }
    public required string UserId { get; init; }
    private Basket _basket = new Basket { Capacity = 0 };
    public int BasketCapacity
    {
        get { return this._basket.Capacity; }
    }

    public bool AddItemToCart(StoreItem item)
    {
        return this._basket.AddItem(item);
    }

    public bool ModifyCartCapacity(User adminUser, int newCapacity)
    {
        if (adminUser.priv != Privilege.Admin)
        {
            return false;
        }
        return this._basket.UpdateCapacity(newCapacity);
    }

    public bool RemoveItemFromCart(StoreItem item)
    {
        return this._basket.RemoveItem(item);
    }

    public IReadOnlyCollection<StoreItem> GetBasketItems()
    {
        return this._basket.GetItems().AsReadOnly();
    }

    public double GetCartPrice(DiscountContainer discounts)
    {
        return this._basket.GetTotalPrice(discounts);
    }

    public Receipt BuyCart(DiscountContainer discounts)
    {
        return this._basket.Purchase(discounts);
    }
}
