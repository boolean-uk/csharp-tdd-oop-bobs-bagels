namespace exercise.tests;

using exercise.main;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

public class Tests
{
    Basket basket = new Basket();
    List<Item> inventory = Inventory.inventory;

    [SetUp]
    public void Setup()
    {
        basket = new Basket();
    }

    [Test]
    public void TestAddItem()
    {
        Item added = new Bagel("Onion");
        Assert.That(!basket.items.Contains(added));
        basket.Add(added);
        Assert.That(basket.items.Contains(added));
    }

    [Test]
    public void TestRemoveItem()
    {
        Item removed = new Bagel("Onion");
        basket.Add(removed);
        Assert.That(basket.items.Contains(removed));
        basket.Remove(removed);
        Assert.That(!basket.items.Contains(removed));
    }

    [Test]
    public void TestSpaceLeft()
    {
        Assert.That(basket.SpaceLeft() == 10);
        basket.Add(new Bagel("Onion"));
        basket.Add(new Coffee("White"));
        Assert.That(basket.SpaceLeft() == 8);
    }

    [Test]
    public void TestChangeCapacity()
    {
        Assert.That(basket.SpaceLeft() == 10);
        basket.ChangeCapacity(4);
        Assert.That(basket.SpaceLeft() == 4);
    }

    [Test]
    public void TestGetTotalCost()
    {
        basket.Add(new Bagel("Onion"));
        basket.Add(new Coffee("White"));
        basket.Add(new Filling("Cream Cheese"));

        Assert.That(basket.GetTotalCost(), Is.EqualTo(0.49f + 1.19f + 0.12f));
    }

    [Test]
    public void TestGetItemCost()
    {
        Assert.That(new Bagel("Onion").cost, Is.EqualTo(0.49f));
        Assert.That(new Filling("Egg").cost, Is.EqualTo(0.12f));
    }

    [Test]
    public void TestAddFilling()
    {
        Item bagel = new Bagel("Onion");
        Item coffee = new Coffee("White");
        Item filling = new Filling("Egg");

        basket.AddFilling(filling, bagel);
        Assert.That(!basket.items.Contains(filling));

        basket.Add(bagel);

        basket.AddFilling(filling, coffee);
        Assert.That(!basket.items.Contains(filling));

        basket.AddFilling(filling, bagel);
        Assert.That(basket.items.Contains(filling));
    }

    [Test]
    public void TestAddItemNotInInventory()
    {
        Assert.That(basket.items.Count == 0);

        basket.Add(new Bagel("Onionion"));

        Assert.That(basket.items.Count == 0);
    }
}