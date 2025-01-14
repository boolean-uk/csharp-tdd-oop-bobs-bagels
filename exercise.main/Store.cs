namespace exercise.core;

// Not tested since it only directs functions to members
public class Store
{
    private IRepository _repository;
    private User? _activeUser;

    public Store(IRepository repository)
    {
        this._repository = repository;
    }

    public void AddUser(User user)
    {
        this._repository.AddUser(user);
    }

    public void setActiveUser(User user)
    {
        this._activeUser = user;
    }

    public bool AddToCart(StoreItem item)
    {
        return this._activeUser?.AddItemToCart(item) ?? false;
    }

    public Receipt? Checkout()
    {
        return this._activeUser?.BuyCart(_repository.GetDiscountContainer());
    }

    public bool RemoveFromCart(StoreItem item)
    {
        if (this._activeUser == null)
        {
            return false;
        }
        return this._activeUser.RemoveItemFromCart(item);
    }

    public bool ModifyCartCapacity(User user, int newCapacity)
    {
        if (this._activeUser == null)
            return false;
        return user.ModifyCartCapacity(this._activeUser, newCapacity);
    }

    public IReadOnlyCollection<StoreItem>? GetCartItems()
    {
        if (this._activeUser == null)
        {
            return null;
        }
        return this._activeUser.GetBasketItems();
    }
}
