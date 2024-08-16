namespace exercise.tests;
using exercise;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

public class CoreTests
{
    private Inventory _inventory;
    public CoreTests()
    {
        _inventory = new Inventory();
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
        Basket basket = new Basket();
        basket.AddProduct(sku);

        Assert.IsTrue(basket.products.Count() == 1);
        Assert.IsTrue(basket.products[0].SKU == sku);
    }

    [TestCase("FILB")]
    public void RemoveProductFromBasket(string sku)
    {
        Basket basket = new Basket();
        basket.AddProduct(sku);
        basket.RemoveProduct(sku);

        Assert.IsTrue(basket.products.Count() == 0);
    }

    [Test]
    public void BasketIsFull()
    {
        Basket basket = new Basket();
        basket.AddProduct("FILE");
        basket.AddProduct("BGLS");
        basket.AddProduct("FILH");
        basket.AddProduct("COFB");

        Assert.IsTrue(basket.products.Count() == 3);
    }


}