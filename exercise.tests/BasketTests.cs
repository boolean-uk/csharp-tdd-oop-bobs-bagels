using exercise.main;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace exercise.tests;

public class Tests
{
    [Test]
    public void AddItemTest()
    {
        Basket basket = new Basket();
        BobsInventory inventory = new BobsInventory();
        basket.MaxCapacity = 1;
        Item item1 = inventory.Inventory.Where(x => x.Name == "Bagel").First();
        Item item2 = inventory.Inventory.Where(x => x.Name == "Bagel").First();

        basket.AddItem(item1);
        basket.AddItem(item2);

        Assert.That(basket.BasketItems.Contains(item1), Is.True); // test add to basket
        Assert.That(basket.BasketItems.Count == 1, Is.True); // test not adding to full basket
    }

    [Test]
    public void AddInventoryItemTest()
    {
        Basket basket = new Basket();
        BobsInventory inventory = new BobsInventory();
        Item item = new Bagel("BGLK", 0.49, "Bagel", "Veegan");

        bool result = basket.AddItem(item);

        Assert.That(result, Is.False);
    }

    [Test]
    public void RemoveItemTest()
    {
        Basket basket = new Basket();
        BobsInventory inventory = new BobsInventory();
        Item item = inventory.Inventory.Where(x => x.Name == "Bagel").First();

        basket.AddItem(item);
        basket.RemoveItem(item);

        var result = basket.BasketItems.Contains(item);

        Assert.That(result, Is.False);
    }

    [Test]
    public void RemoveNonExistingItemTest()
    {
        Basket basket = new Basket();
        Item item = new Bagel("BGLP", 0.39, "Bagel", "Vegan");

        var result = basket.RemoveNonExistingItem(item);

        Assert.That(result, Is.True);
    }


    [Test]
    public void GetTotalCostTest()
    {
        Basket basket = new Basket();
        BobsInventory inventory = new BobsInventory();
        Item item1 = inventory.Inventory.Where(x => x.Name == "Bagel").First();
        Bagel bagel1 = new Bagel("BGLE", 0.49, "Bagel", "Everything");
        basket.AddItem(item1);
        basket.AddItem(bagel1);
        double expected = item1.Cost + bagel1.Cost;

        double result = basket.GetTotalCost();

        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void GetBagelCostTest()
    {
        Basket basket = new Basket();
        Item item = new Bagel("BGE", 0.49, "Bagel", "Everything");
        basket.AddItem(item);
        double expected = basket.GetTotalCost();

        double result = Bagel.GetItemCost(item);

        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void GetFillingCostTest()
    {
        Basket basket = new Basket();
        Item item = new Filling("FILB", 0.12, "Filling", "Bacon");
        basket.AddItem(item);
        double expected = basket.GetTotalCost();

        double result = Filling.GetItemCost(item);

        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void AddFillingTest()
    {
        BobsInventory inventory = new BobsInventory();
        Item item = inventory.Inventory.Where(x => x.Name == "Filling").First();
        Bagel.AddFilling(item);
        string expected = item.SKU.ToString();

        string result = inventory.Inventory.Where(x => x.SKU == expected).First().SKU;

        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void ChangeCapacityTest()
    {
        Basket basket = new Basket();
        bool IsManager = true;
        int newCapacity = 1;

        bool result = basket.ChangeCapacity(newCapacity, IsManager);
        int actualCapacity = basket.MaxCapacity;

        Assert.That(result, Is.True);
        Assert.That(newCapacity, Is.EqualTo(actualCapacity));
    }

    [Test]
    public void PrintReceiptTest()
    {
        Basket basket = new Basket();
        Item item = new Bagel("BGLE", 0.49, "Bagel", "Everything");
        basket.AddItem(item);

        string printedReceipt = basket.GetReceipt();

        Assert.That(printedReceipt.Contains("Everything"));
    }

    [Test]
    public void Discount6Test()
    {
        Basket basket = new Basket();
        basket.MaxCapacity = 20;

        for (int i = 0; i <= 5; i++)
        {
            basket.BasketItems.Add(new Bagel("BGLO", 0.49, "Bagel", "Everything"));
        }

        double expected = 2.49;
        double result = basket.GetDiscount();

        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void Discount12Test()
    {
        Basket basket = new Basket();
        basket.MaxCapacity = 20;

        for (int i = 0; i <= 11; i++)
        {
            basket.BasketItems.Add(new Bagel("BGLP", 0.39, "Bagel", "Plain"));
        }

        double expected = 3.99;
        double result = basket.GetDiscount();

        Assert.That(expected, Is.EqualTo(result));
    }

    [Test]
    public void CoffeeAndBagelTest()
    {
        Basket basket = new Basket();
        basket.MaxCapacity = 20;
        basket.BasketItems.Add(new Bagel("BGLP", 0.39, "Bagel", "Plain"));
        basket.BasketItems.Add(new Coffee("COFB", 0.99, "Coffee", "Black"));

        double expected = 1.25;
        double result = basket.GetDiscount();

        Assert.That(expected, Is.EqualTo(result));



    }
}

