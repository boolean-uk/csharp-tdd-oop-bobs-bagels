using exercise.main;
using Microsoft.Extensions.DependencyInjection;

namespace exercise.tests;

[TestFixture]
public class OrderTest
{
    private IInventory _inventory;
    
    [SetUp]
    public void Setup()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IInventory, Inventory>();
        var serviceProvider = services.BuildServiceProvider();

        _inventory = serviceProvider.GetService<IInventory>();
    }
    
    [Test]
    public void TestOrder()
    {
        var _basket = new Basket(_inventory);
        
        _basket.Add("BGLO", 1);
        _basket.Add("COFB", 1);
        var order = _basket.Order();
        
        Assert.IsNotEmpty(order.ToString());
    }
}