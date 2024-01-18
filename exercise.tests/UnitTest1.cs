namespace exercise.tests;
using exercise.main;
using System.Xml.Serialization;

public class Tests
{
    Basket _basket;
    [SetUp]
    public void Setup()
    {
        _basket = new Basket();
    }

    [Test]
    public void AddItemTest()
    {
        bool result = _basket.AddItem("BGLO");
        Assert.IsTrue(result);
        Assert.That(_basket.Inventory.First(), Is.InstanceOf(typeof(Bagel)));
    }

    [Test]
    public void AddInvalidItemTest()
    {
        bool result = _basket.AddItem("MEW");
        Assert.IsFalse(result);
        Assert.IsEmpty(_basket.Inventory);
    }
    [Test]
    public void AddFullItemTest()
    {
        _basket.ChangeCapacity(2);
        _basket.AddItem("BGLE");
        _basket.AddItem("COFB");
        bool result = _basket.AddItem("BGLO");
        Assert.IsFalse(result);
        Assert.That(_basket.Inventory.Count, Is.EqualTo(2));
    }

    [TestCase(3, 3)]
    [TestCase(-1, 10)]
    [TestCase(0, 0)]
    [TestCase(1000, 1000)]
    public void ChangeCapacityTest(int capactity, int expectedResult)
    {
        Basket _newBasket = new Basket();
        int result = _newBasket.ChangeCapacity(capactity);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void RemoveTest()
    {
        _basket.AddItem("COFB");
        Assert.That(_basket.Inventory.Count, Is.EqualTo(1));
        bool result = _basket.RemoveItem(_basket.Inventory[0].ID);
        Assert.IsTrue(result);
        Assert.That(_basket.Inventory.Count, Is.EqualTo(0));
    }
    [Test]
    public void RemoveNonexistantItemTest()
    {
        _basket.AddItem("COFB");
        Assert.That(_basket.Inventory.Count, Is.EqualTo(1));
        bool result = _basket.RemoveItem(777777);
        Assert.IsFalse(result);
        Assert.That(_basket.Inventory.Count, Is.EqualTo(1));
    }
    [Test]
    public void RemoveInvalidStringTest()
    {
        _basket.AddItem("COFB");
        Assert.That(_basket.Inventory.Count, Is.EqualTo(1));
        bool result = _basket.RemoveItem(-10);
        Assert.IsFalse(result);
        Assert.That(_basket.Inventory.Count, Is.EqualTo(1));
    }

    [Test]
    public void TotalCostTest()
    {
        float result = _basket.TotalCost();
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void TotalCostFilledBasketTest()
    {
        _basket.AddItem("BGLO");
        _basket.AddItem("COFB");
        float result = _basket.TotalCost();
        Assert.That(result, Is.EqualTo(1.25f));
    }

    [Test]
    public void TotalCostFilledBasket1Test()
    {
        _basket.AddItem("BGLO");
        _basket.AddItem("BGLO");
        _basket.AddItem("BGLO");
        float result = _basket.TotalCost();
        Assert.That(result, Is.EqualTo(1.47f));
    }
    [Test]
    public void GetPriceTest()
    {
        float result = _basket.GetPrice("BGLS");
        Assert.That(result, Is.EqualTo(0.49f));
    }
    [Test]
    public void GetInvalidPriceTest()
    {
        float result = _basket.GetPrice("Something else");
        Assert.That(result, Is.EqualTo(0f));
    }

    [Test]
    public void AddFillingTest()
    {
        _basket.AddItem("BGLO");
        bool result = _basket.AddFilling(_basket.Inventory[0].ID, "FILE");
        Assert.IsTrue(result);
        Assert.That(_basket.Inventory[0].TotalPrice(), Is.EqualTo(0.61f));
    }
    [Test]
    public void AddFillingCoffeeTest()
    {
        _basket.AddItem("COFB");
        bool result = _basket.AddFilling(_basket.Inventory[0].ID, "FILE");
        Assert.IsFalse(result);
        Assert.That(_basket.Inventory[0].TotalPrice(), Is.EqualTo(0.99f));
    }

}