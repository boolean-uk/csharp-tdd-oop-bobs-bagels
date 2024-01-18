using exercise.main;

namespace exercise.tests;

[TestFixture]
public class Tests
{
    Inventory inventory;
    [SetUp]
    public void Setup()
    {
        inventory = new Inventory();
    }

    [TestCase("BGLE", true)]
    [TestCase("COFC", true)]
    [TestCase("FILX", true)]
    [TestCase("NOTX", false)]
    public void InventoryItemExists(string sku, bool shoulReturn)
    {
        Assert.That(inventory.ItemExists(sku), Is.EqualTo(shoulReturn));
    }

    [TestCase("test", 0f)]
    [TestCase("BGLP", 0.39f)]
    [TestCase("COFC", 1.29f)]
    [TestCase("FILB", 0.12f)]
    public void InventoryGetPrice(string sku, float shouldReturn)
    {
        Assert.That(inventory.GetPrice(sku), Is.EqualTo(shouldReturn));
    }

    [TestCase("BGLO", "BGLO", 0.49f, "Bagle", "Onion")]
    [TestCase("BGLX", "BGLO", 0.49f, "Bagle", "Onion")]
    public void InventoryGetItem(string sku, string expectedSKU, float expectedPrice, string expectedName, string expectedVariant)
    {
        if (sku == "BGLO")
        {
            Assert.That(inventory.GetItem(sku), Is.Not.Null);
        }
        else
        {
            Assert.That(inventory.GetItem(sku), Is.Null);
        }
    }

    [TestCase("BGLO", true)]
    [TestCase("COFB", false)]
    [TestCase("FILB", false)]
    public void BasketAddItem(string sku, bool shouldReturn)
    {
        var _basket = new Basket(inventory);
        Assert.That(_basket.AddBagel(sku), Is.EqualTo(shouldReturn));
    }

    [Test]
    public void BasketAddItemFull()
    {
        var _basket = new Basket(inventory);
        for (int i = 0; i < 4; i++)
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
        var _basket = new Basket(inventory);
        _basket.AddBagel("BGLO");
        Assert.That(_basket.RemoveBagel(index), Is.EqualTo(shouldReturn));
    }

    [TestCase(0, "FILB", true)]
    [TestCase(0, "FILE", true)]
    [TestCase(0, "BGLP", false)]
    [TestCase(-1, "FILB", false)]
    public void BasketAddFilling(int index, string fillingSKU, bool shouldReturn)
    {
        var _basket = new Basket(inventory);
        _basket.AddBagel("BGLO");
        _basket.AddBagel("BGLO");
        if (fillingSKU == "FILE")
        {
            _basket.AddFilling(index, fillingSKU);
            _basket.AddFilling(index, fillingSKU);
            Assert.That(_basket._basketList[0].GetPrice(), Is.EqualTo(0.49 + 0.12 + 0.12).Within(0.05));
            Assert.That(_basket._basketList[1].GetPrice(), Is.EqualTo(0.49).Within(0.005));
        }
        else
        {
            Assert.That(_basket.AddFilling(index, fillingSKU), Is.EqualTo(shouldReturn));
            Assert.That(_basket._basketList[1].GetPrice(), Is.EqualTo(0.49).Within(0.005));
        }
    }

    [Test]
    public void BasketTotalCost()
    {
        var _basket = new Basket(inventory);
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
        var _basket = new Basket(inventory);
        int basketCapacity = 5;
        Assert.That(_basket.ChangeCapacity(basketCapacity), Is.True);
        for (int i = 0; i < basketCapacity; i++)
        {
            _basket.AddBagel("BGLO");
        }
        Assert.That(_basket.ChangeCapacity(newCapacity), Is.EqualTo(shouldReturn));
    }

    //TESTS FOR EXTENSION 1
    [Test]
    public void TestDiscount()
    {
        var _basket = new Basket(inventory);
        _basket.ChangeCapacity(16);
        for (int i = 0; i < 16; i++)
        {
            _basket.AddBagel("BGLP");
        }
        float testPrice = 5.55f;
        Assert.That(_basket.TotalCost(), Is.EqualTo(testPrice).Within(0.005));
    }
}