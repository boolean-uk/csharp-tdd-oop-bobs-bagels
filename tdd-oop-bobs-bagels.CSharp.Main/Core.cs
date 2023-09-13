using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Basket
{
    private List<string> items; // private for encap
    private int capacity; // private for encap

    public Core(int initialCapacity = 5) // added constructor for capacity and item list
    {
        capacity = Math.Max(initialCapacity, 0); // used https://learn.microsoft.com/en-us/dotnet/api/system.math.max?view=net-7.0 to prevent negative capacity
        items = new List<string>();
    }
    public bool AddBagel(string bagelType)
    {
        if (string.IsNullOrEmpty(bagelType))
        {
            return false;
        }
        if (items.Contains(bagelType))    // preventing adding duplicates
        {
            return false;
        }
        if (items.Count < capacity)
        {
            items.Add(bagelType);
            return true;
        }
        return false;
    }

    public bool RemoveBagel(string bagelType)
    {
        return items.Contains(bagelType) && items.Remove(bagelType);
    }

    public bool IsFull()
    {
        return items.Count == capacity;
    }

    public void SetCapacity(int newCapacity)
    {
        capacity = Math.Max(newCapacity, 0);

        // example for Enumerable.Max instead of Math.Max method
        // capacity = (new[] { newCapacity, 0}).Max();
    }
}
}
