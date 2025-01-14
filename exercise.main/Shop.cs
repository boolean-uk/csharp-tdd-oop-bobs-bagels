using System;

namespace exercise.main;

public class Shop
{
    private ShoppingSystem _system = new ShoppingSystem();

    public ActionMessage<bool> AddItem(string SKU, Person p)
    {
        return _system.AddItemToCart(SKU, p.id);
    }

    public ActionMessage<bool> RemoveItem(string SKU, Person p)
    {
        return _system.RemoveItemFromCart(SKU, p.id);
    }

    public List<Item> GetCart(Person p)
    {
        return _system.Carts[p.id] ?? new List<Item>();
    }

    public int GetCartCapacity()
    {
        return _system.CartSize;
    }

    public void ChangeCartCapacity(int capacity, Person p)
    {
        if (p.SecurityLevel > 0)
        {
            _system.ChangeCapacityOfCart(capacity);
        }
    }

    public ActionMessage<double> GetCartCost(Person p)
    {
        return _system.CalculateCartCost(p.id);
    }

    public double GetCost(string SKU)
    {
        return _system.GetCost(SKU);
    }

    public List<Discount> GetDiscounts()
    {
        return new List<Discount>(_system.Discounts);
    }

    public void NewDiscount(Dictionary<string, int> discountItems, double discountPrice, Person p)
    {
        if (p.SecurityLevel > 0)
        {
            _system.NewDiscount(discountItems, discountPrice);
        }

    }
}
