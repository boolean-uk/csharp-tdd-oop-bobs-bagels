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
    public void TestAddToFullBasket()
    {
        basket.ChangeCapacity(4);
        basket.Add(new Bagel("Onion"));
        basket.Add(new Bagel("Onion"));
        basket.Add(new Bagel("Onion"));
        basket.Add(new Bagel("Onion"));
        basket.Add(new Bagel("Onion"));
        basket.Add(new Bagel("Onion"));
        Assert.That(basket.items.Count, Is.EqualTo(4));
    }

    [Test]
    public void TestChangeCapacity()
    {
        Assert.That(basket.SpaceLeft() == 40);
        basket.ChangeCapacity(4);
        Assert.That(basket.SpaceLeft() == 4);
    }

    // This is total cost without discount. Discount only added in receipt.
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
    public void TestPrintReceiptAndReturnTotalCost()
    {
        for (int i = 0; i < 32; i++)
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

        Receipt receipt = new Receipt();

        receipt.AddAll(basket.items);

        float trueCost = 0f;

        //Discounts
        trueCost += 3.99f;
        trueCost += 3.99f;
        trueCost += 2.49f;
        trueCost += 1.25f;
        trueCost += 1.25f;

        //Bagels
        trueCost += 0.49f;
        trueCost += 0.49f;
        trueCost += 0.39f;

        //Fillings
        trueCost += 0.12f;
        trueCost += 0.12f;
        trueCost += 0.12f;
        trueCost += 0.12f;
        trueCost += 0.12f;
        trueCost += 0.12f;

        Assert.That(Math.Round(receipt.PrintReceipt(basket.items), 4), Is.EqualTo(Math.Round(trueCost, 4)));
    }

    [Test]
    public void TestPrintReceiptAndReturnTotalCostFullBasket()
    {
        Item bagel = new Bagel("Plain");
        basket.Add(bagel);

        for (int i = 0; i < 100; i++)
            basket.Add(new Coffee("Latte"));

        bagel.AddFilling(new Filling("Egg"));
        bagel.AddFilling(new Filling("Bacon"));

        Receipt receipt = new Receipt();

        receipt.AddAll(basket.items);

        float trueCost = 0f;

        trueCost += 1.25f;
        trueCost += 1.29f * 38;
        trueCost += 0.12f;
        trueCost += 0.12f;

        Assert.That(Math.Round(receipt.PrintReceipt(basket.items), 4), Is.EqualTo(Math.Round(trueCost, 4)));
    }
}