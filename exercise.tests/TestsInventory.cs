using exercise.main;
using NUnit.Framework;
using System;

namespace exercise.tests;

[TestFixture]
public class TestsInventory
{
    private Inventory inventory;

    [SetUp]
    public void Setup()
    {
        inventory = new Inventory();
    }

    [Test]
    public void TestGetPrice()
    {
        Assert.AreEqual(0.49, inventory.GetPrice("BGLO"));
    }

    [Test]
    public void TestGetPriceInvalid()
    {
        Assert.Throws<ArgumentException>(() => inventory.GetPrice("INVALID"));
    }

    [Test]
    public void TestInStock()
    { 
        Assert.IsTrue(inventory.InStock("BGLO"));
    }

    [Test]
    public void TestInStockInvalid()
    {
        Assert.IsFalse(inventory.InStock("INVALID"));
    }

    [Test]
    public void GetItem_ExistingSku_ReturnsItem()
    {
        Assert.AreEqual("BGLO", inventory.GetItem("BGLO").Sku);
    }

    [Test]
    public void GetItem_NonExistingSku_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => inventory.GetItem("Invalid"));
    }
}