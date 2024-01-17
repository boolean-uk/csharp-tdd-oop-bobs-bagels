using exercise.main;

public class Core
{
    private Basket _basket;
    private BagelInventory _bagelInventory;

    public List<string> Bagels
    {
        get { return _basket.Bagels; }
    }

    public Core()
    {
        _basket = new Basket(5);
        _bagelInventory = new BagelInventory();
    }

    public Basket Basket
    {
        get { return _basket; }
    }

    public BagelInventory BagelInventory
    {
        get { return _bagelInventory; }
    }

    public void Add(string bagelType)
    {
        // Check if bagelType is in the inventory before attempting to add
        if (BagelInventory.IsItemInInventory(bagelType))
        {
            double bagelCost = BagelInventory.GetCost(bagelType);
            Basket.AddBagel(bagelType);
        }
        else
        {
            Console.WriteLine($"Invalid bagel type: {bagelType}. Could not add to the basket.");
        }
    }

    public void Remove(string bagelType)
    {
        Basket.RemoveBagel(bagelType);
    }

    public void IncreaseCapacity()
    {
        _basket.Capacity *= 3; // Increase capacity 3 times

        // Output the count of Bagels after increasing the capacity
        Console.WriteLine($"Increased capacity to: {_basket.Capacity}");
    }
}
