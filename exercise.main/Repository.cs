namespace exercise.core;

public interface IRepository
{
    public List<StoreItem> getRegisteredItems();
    public DiscountContainer GetDiscountContainer();
    public bool AddUser(User user);
    public bool RemoveUser(User user);
}

public class LocalRepository : IRepository
{
    public required List<StoreItem> _items { get; init; }
    public required Dictionary<string, User> _users { get; init; }
    public required DiscountContainer _discounts { get; init; }
    private User? _activeUser = null;

    public List<StoreItem> getRegisteredItems()
    {
        return this._items;
    }

    public bool AddUser(User user)
    {
        if (this._users.ContainsKey(user.UserId))
        {
            return false;
        }
        this._users.Add(user.UserId, user);
        return true;
    }

    public bool RemoveUser(User user)
    {
        if (!this._users.ContainsKey(user.UserId))
        {
            return false;
        }
        this._users.Remove(user.UserId);
        return true;
    }

    public static LocalRepository Default()
    {
        var storeItems = new List<StoreItem>
        {
            new Bagel("BGLO", "Bagel", "Onion", 0.49),
            new Bagel("BGLP", "Bagel", "Plain", 0.39),
            new Bagel("BGLE", "Bagel", "Everything", 0.49),
            new Bagel("BGLS", "Bagel", "Sesame", 0.49),
            new StoreItem("COFB", "Coffee", "Black", 0.99),
            new StoreItem("COFW", "Coffee", "White", 1.19),
            new StoreItem("COFC", "Coffee", "Capuccino", 1.29),
            new StoreItem("COFL", "Coffee", "Latte", 1.29),
            new BagelFilling("FILB", "Filling", "Bacon", 0.12),
            new BagelFilling("FILE", "Filling", "Egg", 0.12),
            new BagelFilling("FILC", "Filling", "Cheese", 0.12),
            new BagelFilling("FILX", "Filling", "Cream Cheese", 0.12),
            new BagelFilling("FILX", "Filling", "Smoked Salmon", 0.12),
            new BagelFilling("FILH", "Filling", "Ham", 0.12),
        };

        var discounts = new DiscountContainer();
        discounts.AddDiscount(
            new Discount
            {
                newPrice = 2.49,
                DiscountRequirement = new List<(Predicate<StoreItem>, int)>
                {
                    ((it) => it.ProductCode.Substring(0, 3).ToLower() == "bgl", 6),
                },
                priority = 0,
            }
        );
        discounts.AddDiscount(
            new Discount
            {
                newPrice = 3.99,
                DiscountRequirement = new List<(Predicate<StoreItem>, int)>
                {
                    ((it) => it.ProductCode.Substring(0, 3).ToLower() == "bgl", 12),
                },
                priority = 1,
            }
        );
        discounts.AddDiscount(
            new Discount
            {
                newPrice = 1.25,
                DiscountRequirement = new List<(Predicate<StoreItem>, int)>
                {
                    ((it) => it.ProductCode.Substring(0, 3).ToLower() == "bgl", 1),
                    ((it) => it.ProductCode.Substring(0, 3).ToLower() == "cof", 1),
                },
                priority = 2,
            }
        );

        var users = new Dictionary<string, User>();
        return new LocalRepository
        {
            _items = storeItems,
            _users = users,
            _discounts = discounts,
        };
    }

    public DiscountContainer GetDiscountContainer()
    {
        return this._discounts;
    }
}
