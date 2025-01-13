using exercise.main;
using Microsoft.Extensions.DependencyInjection;

namespace exercise.tests;

[TestFixture]
public class BasketTest
{
    private Basket _basket;
    private Inventory _inventory;
    
    [SetUp]
    public void Setup()
    {
        _inventory = new Inventory();
        Seed.AddData(out _inventory);
        _basket = new Basket(_inventory);
    }
    
    [TestCase("BGLO", 1, 0.49)]
    [TestCase("BGLP", 1, 0.39)]
    [TestCase("BGLP", 3, 3.51)]
    [TestCase("COFC", 1, 1.29)]

    public void TestAdd(string sku, int quantity, double total)
    {
        _basket.Add(sku, quantity);
        Assert.AreEqual(total, _basket.GetTotal());
    }
    
    [Test]
    public void TestRemove()
    {
        _basket.Add("BGLO", 1);
        _basket.Remove("BGLO", 1);
        Assert.AreEqual(0, _basket.GetTotal());
    }
    
    [Test]
    public void TestSetCapacity()
    {
        _basket.SetCapacity(5);
        Assert.AreEqual(5, _basket.GetCapacity());
    }
}