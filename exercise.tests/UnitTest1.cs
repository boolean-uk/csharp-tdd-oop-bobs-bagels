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
        basket.MaxProducts = 5;

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

    [Test]
    public void TestGetReceipt()
    {

        Basket basket = new Basket();
        basket.AddProduct("BGLO");
        basket.AddProduct("BGLE");
        basket.AddProduct("BGLO");
        basket.AddProduct("BGLO");
        basket.AddProduct("BGLO");
        basket.AddProduct("BGLO");
        basket.AddProduct("COFB");
        basket.AddProduct("COFB");
        basket.PrintReceipt();
    }


    [Test]
    public void TestGetDiscount()
    {

        Basket basket = new Basket();
        basket.AddProduct("BGLO");
        basket.AddProduct("BGLO");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLE");
        basket.AddProduct("BGLE");
        basket.AddProduct("BGLE");
        basket.AddProduct("BGLE");
        basket.AddProduct("BGLE");
        basket.AddProduct("BGLE");
        basket.AddProduct("COFB");
        basket.AddProduct("COFB");
        basket.AddProduct("COFB");
        basket.PrintReceiptDiscount();
        Assert.That((decimal)basket.DiscountedPrice(), Is.EqualTo(10.2));
    }

    [Test]
    public void TestGetDiscount1()
    {

        Basket basket = new Basket();
       
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("COFB");
        Assert.That((decimal)basket.DiscountedPrice(), Is.EqualTo(3.74));
    }

    [Test]
    public void TestGetDiscount2()
    {

        Basket basket = new Basket();
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");

        Assert.That((decimal)basket.DiscountedPrice(), Is.EqualTo(5.55));
        basket.PrintReceiptDiscount(); 

        Basket basket2 = new Basket();

        basket2.AddProduct("BGLO");
        basket2.AddProduct("COFB");
        Assert.That((decimal)basket2.DiscountedPrice(), Is.EqualTo(1.25));

        basket2.PrintReceiptDiscount();

        Basket basket3 = new Basket();

        basket3.AddProduct("COFB");
        basket3.AddProduct("COFB");
        basket3.AddProduct("COFB");
        basket3.AddProduct("COFB");
        basket3.AddProduct("COFB");
        basket3.AddProduct("COFB");
        Assert.That((decimal)basket3.DiscountedPrice(), Is.EqualTo(5.94));
        basket3.PrintReceiptDiscount();


    }
}