using exercise.main;
using tdd_bobs_bagels.Main;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
    [Test]
    public void TestDiscount()
    {
        Inventory store = new Inventory();
        Basket basket = new Basket();
        store.AddBasket(basket);
        Product bagel;

        for (int i = 0; i < 6; i++)
        {
            bagel = new Bagel("BGLO");
            basket.Add(bagel);
        }

        Assert.That(basket.Items.Count, Is.EqualTo(6));
        Assert.That(basket.GetTotal(), Is.EqualTo(2.49));

        store.IncreaseCapacity(10);
        for (int i = 0; i < 6; i++)
        {
            bagel = new Bagel("BGLO");
            basket.Add(bagel);
        }

        Assert.That(basket.Items.Count, Is.EqualTo(12));
        Assert.That(basket.GetTotal(), Is.EqualTo(3.99));

        basket.Add(new Filling("FILE"));
        Assert.That(basket.GetTotal(), Is.EqualTo(3.99 + 0.12));

        bagel = new Bagel("BGLO");
        basket.Add(bagel);
        Assert.That(basket.Items.Count, Is.EqualTo(14));
        Assert.That(basket.GetTotal(), Is.EqualTo(3.99 + 0.12 + 0.49));

    }

    // Example discount calculation given
    [Test]
    public void TestDiscount2()
    {
        Inventory store = new Inventory();
        Basket basket = new Basket();
        store.AddBasket(basket);
        store.IncreaseCapacity(20);
        Product bagel;


        for (int i = 0; i < 2; i++)
        {
            bagel = new Bagel("BGLO");
            basket.Add(bagel);
        }

        for (int i = 0; i < 12; i++)
        {
            bagel = new Bagel("BGLP");
            basket.Add(bagel);
        }

        for (int i = 0; i < 6; i++)
        {
            bagel = new Bagel("BGLE");
            basket.Add(bagel);
        }

        Product coffee;
        for (int i = 0; i < 3; i++)
        {
            coffee = new Coffee("COFB");
            basket.Add(coffee);
        }

        Assert.That(basket.Items.Count, Is.EqualTo(23));
        Assert.That(basket.GetTotal(), Is.EqualTo(10.43));
    }

    [Test]
    public void TestSeveralDiscounts()
    {
        Inventory store = new Inventory();
        Basket basket = new Basket();
        store.AddBasket(basket);
        store.IncreaseCapacity(20);
        Product bagel;


        for (int i = 0; i < 20; i++)
        {
            bagel = new Bagel("BGLO");
            basket.Add(bagel);
        }

        Assert.That(Math.Round(basket.GetTotal(), 2), Is.EqualTo(7.46));
    }

    [Test]
    public void TestSeveralDiscounts2()
    {
        Inventory store = new Inventory();
        Basket basket = new Basket();
        store.AddBasket(basket);
        store.IncreaseCapacity(20);
        Product bagel;


        for (int i = 0; i < 26; i++)
        {
            bagel = new Bagel("BGLO");
            basket.Add(bagel);
        }

        Assert.That(Math.Round(basket.GetTotal(), 2), Is.EqualTo(8.96));
    }

    [Test]
    public void TestSeveralDiscounts3()
    {
        Inventory store = new Inventory();
        Basket basket = new Basket();
        store.AddBasket(basket);
        store.IncreaseCapacity(20);
        Product bagel;

        for (int i = 0; i < 30; i++)
        {
            bagel = new Bagel("BGLO");
            basket.Add(bagel);
        }

        Assert.That(Math.Round(basket.GetTotal(), 2), Is.EqualTo(10.47));
    }

    [Test]
    public void TestSeveralDiscounts4()
    {
        Inventory store = new Inventory();
        Basket basket = new Basket();
        store.AddBasket(basket);
        store.IncreaseCapacity(30);
        Product bagel;

        for (int i = 0; i < 31; i++)
        {
            bagel = new Bagel("BGLO");
            basket.Add(bagel);
        }

        Assert.That(Math.Round(basket.GetTotal(), 2), Is.EqualTo(10.96));
    }

    [Test]
    public void TestReceiptConstructor()
    {
        Basket basket = new Basket();
        Product bagel = new Bagel("BGLO");

        basket.Add(bagel);

        Receipt receipt = new Receipt(basket);
        Assert.That(receipt.Time.Day, Is.EqualTo(DateTime.Now.Day));
        Assert.That(receipt.Time.Year, Is.EqualTo(DateTime.Now.Year));

        Assert.That(receipt.Items.Count, Is.EqualTo(1));
        Assert.That(receipt.Total, Is.EqualTo(0.49));
    }
}