using basket.main;
using inventory.main;
using NUnit.Framework.Internal;

namespace inventory.tests;

public class TestInventory
{
    private Inventory _inventory;
    public Basket basket;

    [SetUp]
    public void Setup()
    {
        _inventory = new Inventory();
    }

    /* same test as test with testCase
    [Test]
    public void TestGetPriceOfItem()
    {
        Assert.That(1.29, Is.EqualTo(_inventory.GetPriceOfItem("COFC")));
    }
    */

    // same test as TestGetPriceOfItem
    [TestCase("BGLS", 0.49)]
    [TestCase("FILB", 0.12)]
    [TestCase("FILE", 0.12)]
    [TestCase("COFC", 1.29)]
    public void TestGetPrice(string sku, double price)
    {
        double getPrice = _inventory.GetPriceOfItem(sku);
        //Assert.AreEqual(expectedTotalPrice, totalPrice);
        Assert.That(getPrice, Is.EqualTo(Math.Round(price, 2)));
    }
    

    [Test]
    public void TestsGetFilling()
    {
       //_inventory.GetFilling("FILB");
        bool getFilling = _inventory.GetFilling("FILB");
        Assert.That(getFilling, Is.True);
    }

    // test if sku is in inventory List with expected result
    [TestCase("BGLO", true)]
    [TestCase("bglo", true)]
    [TestCase("COFB", true)]
    [TestCase("FALSE", false)]
    public void TestsItemInStock(string sku, bool exectedResult) 
    {
        bool itemInStock = basket.ItemInStock(sku);
        Assert.That(itemInStock, Is.EqualTo(exectedResult));
    }

}