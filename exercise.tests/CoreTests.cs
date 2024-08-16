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
        Assert.IsTrue(_inventory.Items[13].Price == 0.12m);
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

    [Test]
    public void GetTotalCost()
    {
        Basket basket = new Basket();
        basket.AddProduct("FILE");
        basket.AddProduct("BGLS");

        Assert.IsTrue(basket.GetTotalCost() == 0.61m);
    }

    [Test]
    public void GetTotalCost2()
    {
        Basket basket = new Basket();
        basket.AddProduct("COFC"); //1.29
        basket.AddProduct("COFB"); //0.99
        Console.WriteLine(basket.GetTotalCost());
        Assert.IsTrue(basket.GetTotalCost() == 2.28m);
    }

    [Test]
    public void GetPrice()
    {
        Basket basket = new Basket();

        Assert.IsTrue(basket.GetPrice("COFC") == 1.29m);
        Assert.IsTrue(basket.GetPrice("BGLP") == 0.39m);
        Assert.IsTrue(basket.GetPrice("FILX") == 0.12m);
        Assert.IsTrue(basket.GetPrice("COFW") == 1.19m);
    }
}