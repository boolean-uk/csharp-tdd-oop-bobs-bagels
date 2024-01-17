using NUnit.Framework;
using exercise.main;
using System.Linq;
using static exercise.main.Basket;

namespace exercise.tests;

[TestFixture]
public class Extension1Tests
{
    private Basket basket;
    private Inventory inventory; // Assuming this is your inventory management class

    [SetUp]
    public void Setup()
    {
        basket = new Basket();
        inventory = new Inventory();
        // Assume inventory is populated with items
    }

    [Test]
    public void Add()
    {
        string sku = "BGLO"; // Assuming this SKU exists in inventory
        int id = basket.Add(sku);
        Assert.That(id, Is.Not.EqualTo(0));
        Assert.IsTrue(basket.Order.Bagels.Any(b => b.ID == id));
    }

    [Test]
    public void AddMissingSKU()
    {
        string sku = "INVALID_SKU";
        int id = basket.Add(sku);
        Assert.That(id, Is.EqualTo(0));
    }

    [Test]
    public void AddBasketIsFull()
    {
        basket.ChangeCapacity(0); // Setting basket capacity to full
        string sku = "BGLO";
        int id = basket.Add(sku);
        Assert.That(id, Is.EqualTo(0));
    }

    [Test]
    public void Remove()
    {
        string sku = "BGLO";
        int id = basket.Add(sku);
        basket.Remove(id);
        Assert.IsFalse(basket.Order.Bagels.Any(b => b.ID == id));
    }

    [Test]
    public void RemoveMissingID()
    {
        // Add some items to the basket
        int existingId1 = basket.Add("BGLO"); // Assuming this SKU exists
        int existingId2 = basket.Add("BGLP"); // Assuming this SKU exists

        // Attempt to remove an item with a non-existing ID
        int nonExistingId = 999;
        basket.Remove(nonExistingId);

        // Assert that the basket still contains the originally added items
        Assert.IsTrue(basket.Order.Bagels.Any(b => b.ID == existingId1));
        Assert.IsTrue(basket.Order.Bagels.Any(b => b.ID == existingId2));
        Assert.IsFalse(basket.Order.Bagels.Any(b => b.ID == nonExistingId));
    }

    [Test]
    public void ChangeCapacity()
    {
        int newCapacity = 10;
        basket.ChangeCapacity(newCapacity);
        Assert.That(basket.Capacity, Is.EqualTo(newCapacity));
    }

    [Test]
    public void TotalCost()
    {
        basket.Add("BGLO");
        basket.Add("BGLP");

        double expectedTotalCost = 0.49 + 0.49;

        double totalCost = basket.Cost();
        Assert.That(totalCost, Is.EqualTo(expectedTotalCost));
    }

    [Test]
    public void ProductCost()
    {
        string sku = "BGLO";
        double cost = basket.ProductCost(sku);
        Assert.That(cost, Is.EqualTo(inventory.GetItem(sku).Price));
    }

    [Test]
    public void ProductCostMissingSKU()
    {
        string sku = "INVALID_SKU";
        double cost = basket.ProductCost(sku);
        Assert.That(cost, Is.EqualTo(0));
    }

    [Test]
    public void AddFilling()
    {
        int id = basket.Add("BGLP");
        basket.AddFilling(id, "FILH");
        Assert.IsTrue(basket.Order.Bagels.First(b => b.ID == id).Fillings.Any(f => f.SKU == "FILH"));
    }

    [Test]
    public void AddFillingMissingID()
    {
        basket.AddFilling(999, "FILH"); // Assuming 999 is an invalid ID
        // Assert that filling has not been added to any bagel
    }

    [Test]
    public void AddFillingMissingSKU()
    {
        int id = basket.Add("BGLP");
        basket.AddFilling(id, "INVALID_SKU");
        Assert.IsFalse(basket.Order.Bagels.First(b => b.ID == id).Fillings.Any(f => f.SKU == "INVALID_SKU"));
    }
}
