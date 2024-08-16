namespace exercise.tests;
using NUnit.Framework;
using exercise;

public class BasketTests
{
    
    private Inventory _inventory;
    public BasketTests()
    {
        _inventory = new Inventory();

    }

    [Test]
    public void CheckInventory()
    {
        Assert.IsTrue(_inventory.items.Count() == 14);
    }

    [Test]
    public void CheckInventoryItemsExist()
    {
        Assert.IsTrue(_inventory.items[13].SKU == "FILH");
    }
}