using exercise.main;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestPriceSingleItem()
    {
        Basket basket = new Basket();

        basket.AddProduct("BGLO");
        Assert.That(basket.TotalPrice(), Is.EqualTo(0.49));
    }

    [Test]
    public void TestPriceMultipleItems()
    {
        Basket basket = new Basket();

        basket.AddProduct("BGLO");
        basket.AddProduct("COFB");
        basket.AddProduct("FILE");
        Assert.That(basket.TotalPrice(), Is.EqualTo(1.60));
    }

    [Test]
    public void TestRemoveItem()
    {
        Basket basket = new Basket();

        basket.AddProduct("BGLO");
        Assert.That(basket.RemoveProduct("Onion"));
        Assert.That(!basket.RemoveProduct("Onion"));
    }

    [Test]
    public void TestLimit()
    {
        Basket basket = new Basket();

        basket.AddProduct("BGLO");
        basket.AddProduct("BGLO");
        basket.AddProduct("BGLO");
        basket.AddProduct("BGLO");
        basket.AddProduct("BGLO");
        basket.AddProduct("BGLO");
        Assert.That(basket.BasketList.Count, Is.LessThanOrEqualTo(5));
    }

    [Test]
    public void TestSetLimit()
    {
        Basket basket = new Basket();
        basket.MaxProducts = 3;

        basket.AddProduct("BGLO");
        basket.AddProduct("BGLO");
        basket.AddProduct("BGLO");
        basket.AddProduct("BGLO");
        Assert.That(basket.BasketList.Count, Is.LessThanOrEqualTo(3));
    }

    [Test]
    public void TestGetBagels()
    {
        
        ProductList productList = new ProductList();
        productList.GetBagels();
    }

    [Test]
    public void TestGetFillings()
    {

        ProductList productList = new ProductList();
        productList.GetFillings();
    }

    [Test]
    public void TestGetPriceBagel()
    {

        ProductList productList = new ProductList();
        Assert.That(productList.GetPriceBagle("Onion"), Is.EqualTo(0.49));
    }
}