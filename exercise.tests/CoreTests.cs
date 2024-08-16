namespace exercise.tests;
using exercise;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

public class CoreTests
{
    private Inventory _inventory;
    public CoreTests()
    {
        _inventory = new Inventory();
    }

    [Test]
    public void CheckInventoryCount()
    {
        Assert.IsTrue(_inventory.Items.Count() == 14);
    }

    [Test]
    public void CheckProductProperty()
    {
        Assert.IsTrue(_inventory.Items[13].SKU == "FILH");
    }

    [Test]
    public void CheckProductProperty2()
    {
        Assert.IsTrue(_inventory.Items[13].Name == "Filling");
    }

    [Test]
    public void CheckProductProperty3()
    {
        Assert.IsTrue(_inventory.Items[13].Price == 0.12);
    }

}