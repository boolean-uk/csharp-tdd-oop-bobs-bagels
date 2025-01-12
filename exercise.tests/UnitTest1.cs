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
        Assert.That(basket.SpaceLeft() == 40);
        basket.Add(new Bagel("Onion"));
        basket.Add(new Coffee("White"));
        Assert.That(basket.SpaceLeft() == 38);
    }

    [Test]
    public void TestChangeCapacity()
    {
        Assert.That(basket.SpaceLeft() == 40);
        basket.ChangeCapacity(4);
        Assert.That(basket.SpaceLeft() == 4);
    }

    [Test]
    public void TestGetTotalCost()
    {
        Item bagel = new Bagel("Onion");
        Item coffee = new Coffee("White");
        Item filling = new Filling("Egg");

        basket.Add(bagel);
        basket.Add(coffee);
        bagel.AddFilling(filling);

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

        basket.Add(bagel);

        coffee.AddFilling(filling);
        Assert.That(!coffee.GetFillings().Contains(filling));

        filling.AddFilling(filling);
        Assert.That(!filling.GetFillings().Contains(filling));

        bagel.AddFilling(filling);
        Assert.That(bagel.GetFillings().Contains(filling));

        basket.Add(filling);
        Assert.That(basket.items.Count == 1);
    }

    [Test]
    public void TestAddItemNotInInventory()
    {
        Assert.That(basket.items.Count == 0);

        basket.Add(new Bagel("Onionion"));

        Assert.That(basket.items.Count == 0);
    }

    [Test]
    public void TestDiscount()
    {
        for (int i = 0; i <= 31; i++)
            basket.Add(new Bagel("Everything"));
        basket.Add(new Bagel("Onion"));
        basket.Add(new Bagel("Sesame"));
        basket.Add(new Bagel("Plain"));

        basket.items[0].AddFilling(new Filling("Egg"));
        basket.items[4].AddFilling(new Filling("Egg"));
        basket.items[7].AddFilling(new Filling("Cream Cheese"));
        basket.items[7].AddFilling(new Filling("Smoked Salmon"));
        basket.items[16].AddFilling(new Filling("Bacon"));
        basket.items[28].AddFilling(new Filling("Ham"));

        basket.Add(new Coffee("White"));
        basket.Add(new Coffee("Black"));

        float truePrice = 0f;

        truePrice += new Bagel("Everything").cost * 32;
        truePrice += new Bagel("Onion").cost;
        truePrice += new Bagel("Sesame").cost;
        truePrice += new Bagel("Plain").cost;

        truePrice += new Filling("Egg").cost * 6;

        truePrice += new Coffee("White").cost;
        truePrice += new Coffee("Black").cost;

        truePrice -= 1.29f;
        truePrice -= 1.29f;
        truePrice -= 0.49f;
        truePrice -= 0.25f;
        truePrice -= 0.25f;

        Assert.That(Math.Round(basket.GetCostAfterDiscounts(), 4), Is.EqualTo(Math.Round(truePrice, 4)));
    }
}