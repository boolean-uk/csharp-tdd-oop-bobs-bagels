using System;

namespace exercise.main;

public class Shop
{
    private ShoppingSystem _system = new ShoppingSystem();

    public ActionMessage AddItem(string SKU, Person p)
    {
        return _system.AddItemToCart(SKU, p.id);
    }

    public ActionMessage RemoveItem(string SKU, Person p)
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

    public double GetCartCost(Person p)
    {
        return _system.GetCartCost(p.id);
    }

    public double GetCost(string SKU)
    {
        return _system.GetCost(SKU);
    }
}
