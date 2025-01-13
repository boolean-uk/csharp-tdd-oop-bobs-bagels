using exercise.main;
using Microsoft.Extensions.DependencyInjection;

namespace exercise.tests;

[TestFixture]
public class OrderTest
{
    private Inventory _inventory;
    
    [SetUp]
    public void Setup()
    {
        _inventory = new Inventory();
        
        Seed.AddData(out _inventory);
    }
    
    [Test]
    public void TestOrder()
    {
        var _basket = new Basket(_inventory);
        
        _basket.Add("BGLO", 3);
        _basket.Add("COFB", 1);
        var order = _basket.Order();
        
        Console.WriteLine(order);
        
        Assert.IsNotEmpty(order.ToString());
    }
}