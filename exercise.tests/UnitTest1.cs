namespace exercise.tests;

using exercise.main;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

public class Tests
{
    Basket basket = new Basket();
    List<Item> inventory;

    [SetUp]
    public void Setup()
    {
        basket = new Basket();
        inventory = Inventory.inventory;
    }

    [Test]
    public void TestAddItem()
    {
        Assert.That(basket.items.Count == 0);
        Item added = new Bagel("Onion");
        basket.Add(added);
        Assert.That(basket.items.Count == 1);
        Assert.That(basket.items.Contains(added));
    }
}