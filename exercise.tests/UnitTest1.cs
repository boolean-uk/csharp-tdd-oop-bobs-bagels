using exercise.main;
using NUnit.Framework.Internal.Execution;
using System.Reflection.Emit;

namespace exercise.tests;

[TestFixture]
public class Tests
{
    Inventory inventory;
    [SetUp]
    public void Setup()
    {

        inventory = new Inventory();
        inventory.AddItem("BGLO", 0.49f, "Bagel", "Onion");
        inventory.AddItem("BGLP", 0.39f, "Bagel", "Plain");
        inventory.AddItem("BGLE", 0.49f, "Bagel", "Everything");
        inventory.AddItem("BGLS", 0.49f, "Bagel", "Sesame");
        inventory.AddItem("COFB", 0.99f, "Coffee", "Black");
        inventory.AddItem("COFW", 1.19f, "Coffee", "White");
        inventory.AddItem("COFC", 1.29f, "Coffee", "Cappuccino");
        inventory.AddItem("COFL", 1.29f, "Coffee", "Latte");
        inventory.AddItem("FILB", 0.12f, "Filling", "Bacon");
        inventory.AddItem("FILE", 0.12f, "Filling", "Egg");
        inventory.AddItem("FILC", 0.12f, "Filling", "Cheese");
        inventory.AddItem("FILX", 0.12f, "Filling", "Cream Cheese");
        inventory.AddItem("FILS", 0.12f, "Filling", "Smoked Salmon");
        inventory.AddItem("FILH", 0.12f, "Filling", "Ham");
    }

    [Test]
    public void InventoryAddItem()
    {
        Inventory _inventory = new Inventory();
        Assert.That(_inventory.AddItem("BGLO", 0.49f, "Bagel", "Onion"), Is.True);
    }

    [TestCase("BGLE", true)]
    [TestCase("blge", true)]
    [TestCase("COFC", true)]
    [TestCase("FILX", true)]
    [TestCase("NOTX", false)]
    public void InventoryItemExists(string sku, bool shoulReturn)
    {
        Assert.That(inventory.ItemExists(sku), Is.EqualTo(shoulReturn));
    }

    [TestCase("test", -1f)]
    [TestCase("BGLP", 0.39f)]
    [TestCase("COFC", 1.29f)]
    [TestCase("FILB", 0.12f)]
    public void InventoryGetPrice(string sku, float shouldReturn)
    {
        Assert.That(inventory.GetPrice(sku), Is.EqualTo(shouldReturn));
    }

    [TestCase("BGLO", "BGLO", 0.49f, "Bagle", "Onion", true)]
    [TestCase("BGLE", "BGLO", 0.49f, "Bagle", "Onion", false)]
    public void InventoryGetItem(string sku, string expectedSKU, float expectedPrice, string expectedName, string expectedVariant, bool shouldReturn) 
    {

        Item expectedItem = new Item(expectedSKU, expectedPrice, expectedName, expectedVariant);
        bool actualReturn = expectedItem.Equals(inventory.getItem(sku));
        Assert.That(actualReturn, Is.EqualTo(shouldReturn));
    }

    [TestCase("BGLO", true)]
    [TestCase("COFB", false)]
    [TestCase("FILB", false)]
    public void BasketAddItem(string sku, bool shouldReturn) 
    {
        var _basket = new Basket();
        Assert.That(_basket.AddBagel(sku), Is.EqualTo(shouldReturn));
    }

    [Test]
    public void BasketAddItemFull() 
    {
        var _basket = new Basket();
        for(int i = 0; i < 4; i++)
        {
            _basket.AddBagel("BGLO");
        }
        Assert.That(_basket.AddBagel("BGLO"), Is.False);
        Assert.That(_basket._basketList.Count, Is.EqualTo(4));
    }

    [TestCase(0, true)]
    [TestCase(-1, false)]
    public void BasketRemoveBagle(int index, bool shouldReturn)
    {
        var _basket = new Basket();
        _basket.AddBagel("BGLO");
        Assert.That(_basket.RemoveBagle(index), Is.EqualTo(shouldReturn));
    }

    [TestCase(0,"FILB" ,true)]
    [TestCase(0,"FILE" ,true)]
    [TestCase(0, "BGLP", false)]
    [TestCase(-1, "FILB", false)]
    public void BasketAddFilling(int index, string fillingSKU, bool shouldReturn)
    {
        var _basket = new Basket();
        _basket.AddBagel("BGLO");
        Assert.That(_basket.AddFilling(index, fillingSKU), Is.EqualTo(shouldReturn));
    }

    [Test]
    public void BasketTotalCost()
    {
        var _basket = new Basket();
        Assert.That(_basket.TotalCost(), Is.EqualTo(0));

        //0,49
        _basket.AddBagel("BGLO");
        //0,49
        _basket.AddBagel("BGLE");
        //0,12
        _basket.AddFilling(0, "FILB");
        //0,99
        _basket.AddFilling(0, "COFB");
        float shouldBePrice = 0.49f + 0.49f + 0.12f + 0.99f;
        Assert.That(_basket.TotalCost(), Is.EqualTo(shouldBePrice));
    }

    [TestCase(0, false)]
    [TestCase(1, false)]
    [TestCase(10, true)]
    public void BasketCangeCapacity(int newCapacity, bool shouldReturn)
    {
        var _basket = new Basket();
        int basketCapacity = 5;
        Assert.That(_basket.ChangeCapacity(basketCapacity), Is.True);
        for (int i = 0; i < basketCapacity; i++)
        {
            _basket.AddBagel("BGLO");
        }
        Assert.That(_basket.ChangeCapacity(newCapacity), Is.EqualTo(shouldReturn));
    }
}