using NUnit.Framework;
using exercise.main;
using System.Linq;
using static exercise.main.Basket;

namespace exercise.tests;

[TestFixture]
public class Extension1Tests
{
    private Basket basket;
    private Inventory inventory; 

    [SetUp]
    public void Setup()
    {
        basket = new Basket();
        inventory = new Inventory();
    }

    [Test]
    public void Add()
    {
        string sku = "BGLO";
        int id = basket.Add(sku);
        Assert.That(id, Is.Not.EqualTo(0));
        Assert.IsTrue(basket.CustomerOrder.Bagels.Any(b => b.ID == id));
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
        basket.ChangeCapacity(0);
        string sku = "BGLO";

        var exception = Assert.Throws<Exception>(() => basket.Add(sku));
        Assert.That(exception.Message, Is.EqualTo("Bagel was not added to basket, because basket is full."));
    }

    [Test]
    public void Remove()
    {
        string sku = "BGLO";
        int id = basket.Add(sku);
        basket.Remove(id);
        Assert.IsFalse(basket.CustomerOrder.Bagels.Any(b => b.ID == id));
    }

    [Test]
    public void RemoveMissingID()
    {
        var exception = Assert.Throws<Exception>(() => basket.Remove(999));
        Assert.That(exception.Message, Is.EqualTo("No product with specified ID."));
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

        double expectedTotalCost = 0.49 + 0.39;

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
        var exception = Assert.Throws<Exception>(() => basket.ProductCost(sku));
        Assert.That(exception.Message, Is.EqualTo("No item with the specified SKU."));
    }

    [Test]
    public void AddFilling()
    {
        int id = basket.Add("BGLP");
        basket.AddFilling(id, "FILH");
        Assert.IsTrue(basket.CustomerOrder.Bagels.First(b => b.ID == id).Fillings.Any(f => f.SKU == "FILH"));
    }

    [Test]
    public void AddFillingMissingID()
    {
        var exception = Assert.Throws<Exception>(() => basket.AddFilling(999, "FILH"));
        Assert.That(exception.Message, Is.EqualTo("No bagel with the specified ID."));
    }

    [Test]
    public void AddFillingMissingSKU()
    {
        int id = basket.Add("BGLP"); // Assuming "BGLP" is a valid SKU for a BagelVariant
        var exception = Assert.Throws<Exception>(() => basket.AddFilling(id, "INVALID_SKU"));
        Assert.That(exception.Message, Is.EqualTo("No item with the specified SKU."));
    }
}
