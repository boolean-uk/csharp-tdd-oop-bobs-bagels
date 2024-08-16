namespace exercise.tests;
using exercise;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

public class CoreTests
{
    private Inventory _inventory;
    private Basket _basket;
    public CoreTests()
    {
        _inventory = new Inventory();
        _basket = new Basket();
    }

    [Test]
    public void CheckInventoryCount()
    {
        Assert.IsTrue(_inventory.Items.Count() == 14);
    }

    [Test]
    public void CheckProductProperty()
    {
        Assert.IsTrue(_inventory.Items[13].SKU == "FILH");
        Assert.IsTrue(_inventory.Items[13].Name == "Filling");
        Assert.IsTrue(_inventory.Items[13].Price == 0.12);
    }

    [TestCase("FILB")]
    public void AddProductToBasket(string sku)
    {
        _basket.AddProduct(sku);

        Assert.IsTrue(_basket.products.Count() == 1);
        Assert.IsTrue(_basket.products[0].SKU == sku);
    }
}