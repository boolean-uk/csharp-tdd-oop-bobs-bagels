using exercise.main;
using NUnit.Framework;

namespace exercise.tests;

[TestFixture]
public class BasketTests
{
    private Basket _basket;

    [SetUp]
    public void Setup()
    {
        _basket = new Basket();
    }

    [Test]
    public void TestAdd()
    {
        Assert.IsTrue(_basket.Add("BGLO"));
    }

    [Test]
    public void TestAddInvalid()
    {
        Assert.IsFalse(_basket.Add("Invalid"));
    }

    [Test]
    public void TestRemove()
    {
        _basket.Add("BGLO");
        Assert.IsTrue(_basket.Remove("BGLO"));
    }

    [Test]
    public void TestRemoveInvalid()
    {
        Assert.IsFalse(_basket.Remove("Invalid"));
    }

    [Test]
    public void TestChangeCapacity()
    {
        _basket.ChangeCapacity(10);
        Assert.AreEqual(10, _basket.Capacity);
    }

    [Test]
    public void TestAddCapacityReached()
    {
        _basket.ChangeCapacity(1);
        _basket.Add("BGLO");
        Assert.IsFalse(_basket.Add("BGLP"));
    }

 

    [Test]
    public void TestTotalPrice()
    {
        _basket.Add("BGLO");
        _basket.Add("BGLP");
        Assert.AreEqual(0.49 + 0.39, _basket.GetTotalCost());
    }

    [Test]
    public void TestTotalPriceEmptyBasket()
    {
        Assert.Throws<InvalidOperationException>(() => _basket.GetTotalCost());
    }

    [Test]
    public void GetTotalCost_CalculatesCorrectTotalCost()
    {
        for (int i = 0; i < 15; i++)
        {
            _basket.Add("BGLO");
        }

        _basket.Add("BGLP");

        // Act
        double totalCost = _basket.GetTotalCost();
        Assert.AreEqual(3.99 + (3*0.49) + 0.39, totalCost);
    }
}