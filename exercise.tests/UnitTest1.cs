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
        Item result = _basket.AddItem("BGLO");
        Assert.IsNotNull(result);
        Assert.That(_basket.Inventory.First(), Is.InstanceOf(typeof(Bagel)));
    }

    [Test]
    public void AddInvalidItemTest()
    {
        Item result = _basket.AddItem("MEW");
        Assert.IsNull(result);
        Assert.IsEmpty(_basket.Inventory);
    }
    [Test]
    public void AddFullItemTest()
    {
        _basket.ChangeCapacity(2);
        _basket.AddItem("BGLE");
        _basket.AddItem("COFB");
        Item result = _basket.AddItem("BGLO");
        Assert.IsNull(result);
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
        bool result = _basket.RemoveItem("COFB");
        Assert.IsTrue(result);
        Assert.That(_basket.Inventory.Count, Is.EqualTo(0));
    }
    [Test]
    public void RemoveNonexistantItemTest()
    {
        _basket.AddItem("COFB");
        Assert.That(_basket.Inventory.Count, Is.EqualTo(1));
        bool result = _basket.RemoveItem("COFL");
        Assert.IsFalse(result);
        Assert.That(_basket.Inventory.Count, Is.EqualTo(1));
    }
    [Test]
    public void RemoveInvalidStringTest()
    {
        _basket.AddItem("COFB");
        Assert.That(_basket.Inventory.Count, Is.EqualTo(1));
        bool result = _basket.RemoveItem("BLABLABLA");
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
        Assert.That(result, Is.EqualTo(1.48f));
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
        Item item = _basket.AddItem("BGLO");
        bool result = item.AddFilling("FILE");
        Assert.IsTrue(result);
        Assert.That(item.TotalPrice(), Is.EqualTo(0.61f));
    }
    [Test]
    public void AddFillingCoffeeTest()
    {
        Item item = _basket.AddItem("COFB");
        bool result = item.AddFilling("FILE");
        Assert.IsFalse(result);
        Assert.That(item.TotalPrice(), Is.EqualTo(0.99f));
    }

}