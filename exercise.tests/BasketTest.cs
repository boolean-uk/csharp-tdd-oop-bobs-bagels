using exercise.main;
using Microsoft.Extensions.DependencyInjection;

namespace exercise.tests;

[TestFixture]
public class BasketTest
{
    private Basket _basket;
    private IInventory _inventory;
    
    [SetUp]
    public void Setup()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IInventory, Inventory>();
        var serviceProvider = services.BuildServiceProvider();

        _inventory = serviceProvider.GetService<IInventory>();
        _basket = new Basket(_inventory);
    }
    
    [Test]
    public void TestAdd()
    {
        _basket.Add("A", 1);
        Assert.AreEqual(1, _basket.GetTotal());
    }
    
    [Test]
    public void TestRemove()
    {
        _basket.Add("A", 1);
        _basket.Remove("A", 1);
        Assert.AreEqual(0, _basket.GetTotal());
    }
    
    [Test]
    public void TestSetCapacity()
    {
        _basket.SetCapacity(5);
        Assert.AreEqual(5, _basket.GetCapacity());
    }
}