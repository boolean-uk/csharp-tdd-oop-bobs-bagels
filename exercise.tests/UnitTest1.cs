using exercise.main;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestFilling()
    {
        Filling filling = new Filling("FILB");

        Assert.That(filling.Variant, Is.EqualTo("Bacon"));
        Assert.That(filling.Price, Is.EqualTo(0.12));
        Assert.That(filling.SKU, Is.EqualTo("FILB"));
    }

    [Test]
    public void TestBagelConstructor()
    {
        Bagel bagel = new Bagel("BGLO");

        Assert.That(bagel.Variant, Is.EqualTo("Onion"));
        Assert.That(bagel.Price, Is.EqualTo(0.49));
        Assert.That(bagel.SKU, Is.EqualTo("BGLO"));
    }

    [Test]
    public void TestBagelSetFilling()
    {
        Filling filling = new Filling("FILB");

        Assert.That(filling.Variant, Is.EqualTo("Bacon"));
    }

    [Test]
    public void TestBasketConstructor()
    {
        Basket basket = new Basket();

        Assert.That(basket.Items.Count, Is.EqualTo(0));
        Assert.That(basket.Capacity, Is.EqualTo(10));
        Assert.That(basket.GetTotal(), Is.EqualTo(0));
    }

    [Test]
    public void TestBasketAdd()
    {
        Basket basket = new Basket();
        Bagel bagel = new Bagel("BGLO");

        basket.Add(bagel);

        Assert.That(basket.Items.Count, Is.EqualTo(1));
        Assert.That(basket.GetTotal(), Is.EqualTo(0.49));
        Assert.That(basket.Items[0], Is.EqualTo(bagel));

        basket.Add(bagel);
        basket.Add(bagel);
        basket.Add(bagel);
        basket.Add(bagel);
        basket.Add(bagel);
        basket.Add(bagel);
        basket.Add(bagel);
        basket.Add(bagel);
        basket.Add(bagel);

        Assert.Throws<Exception>(() => basket.Add(bagel));

    }

    [Test]
    public void TestBasketRemove()
    {
        Basket basket = new Basket();
        Bagel bagel = new Bagel("BGLO");

        basket.Add(bagel);
        basket.Remove(bagel);

        Assert.That(basket.Items.Count, Is.EqualTo(0));

        Assert.Throws<Exception>(() => basket.Remove(bagel));
    }

    [Test]
    public void TestBobsBagelConstructor()
    {
        BobsBagels store = new BobsBagels();

        Assert.That(store.Capacity, Is.EqualTo(10));
        Assert.That(store.Baskets.Count, Is.EqualTo(0));
    }

    [Test]
    public void TestAddBasket()
    {
        BobsBagels store = new BobsBagels();
        Basket basket = new Basket();
        store.AddBasket(basket);

        Assert.That(store.Baskets.Count, Is.EqualTo(1));
        Assert.That(store.Baskets[0], Is.EqualTo(basket));
    }

    [Test]
    public void TestRemoveBasket()
    {
        BobsBagels store = new BobsBagels();
        Basket basket = new Basket();
        store.AddBasket(basket);
        store.RemoveBasket(basket);

        Assert.That(store.Baskets.Count, Is.EqualTo(0));
        Assert.Throws<Exception>(() => store.RemoveBasket(basket));
    }

    [Test]
    public void TestIncreaseCapacity() 
    {
        BobsBagels store = new BobsBagels(); 
        Basket basket = new Basket();
        store.AddBasket(basket);
        store.IncreaseCapacity(10);

        Assert.That(store.Capacity, Is.EqualTo(20));
        Assert.That(basket.Capacity, Is.EqualTo(20));
    }

    [Test]
    public void TestCoffeeConstructor()
    {
        Coffee coffee = new Coffee("COFW");

        Assert.That(coffee.Variant, Is.EqualTo("White"));
        Assert.That(coffee.SKU, Is.EqualTo("COFW"));
        Assert.That(coffee.Price, Is.EqualTo(1.19));
    }

    [Test]
    public void TestAddCoffee()
    {
        Basket basket = new Basket();
        Coffee coffee = new Coffee("COFB");

        basket.Add(coffee);

        Assert.That(basket.Items.Count, Is.EqualTo(1));

        basket.Add(coffee);
        basket.Add(coffee);
        basket.Add(coffee);
        basket.Add(coffee);
        basket.Add(coffee);
        basket.Add(coffee);
        basket.Add(coffee);
        basket.Add(coffee);
        basket.Add(coffee);

        Assert.Throws<Exception>(() => basket.Add(coffee));

    }

    [Test]
    public void TestRemoveCoffee()
    {
        Basket basket = new Basket();
        Coffee coffee = new Coffee("COFB");

        basket.Add(coffee);
        basket.Remove(coffee);

        Assert.That(basket.Items.Count, Is.EqualTo(0));

        Assert.Throws<Exception>(() => basket.Remove(coffee));
    }

    [Test]
    public void TestAddNonExistantBagel()
    {
        Basket basket = new Basket();
        Bagel bagel;

        Assert.Throws<Exception>(() => bagel = new Bagel("Chicken"));
    }

    [Test]
    public void TestNonExistantCoffee()
    {
        Coffee coffee;
        Assert.Throws<Exception>(() => coffee = new Coffee("Mocha"));
    }

    [Test]
    public void TestNonExistantFilling()
    {
        Filling filling;
        Assert.Throws<Exception>(() => filling = new Filling("Choclate"));
    }

    [Test]
    public void TestPricing()
    {
        Basket basket = new Basket();
        Bagel bagel = new Bagel("BGLO");
        Coffee coffee = new Coffee("COFW");

        basket.Add(bagel);
        Assert.That(basket.GetTotal(), Is.EqualTo(0.49));

        basket.Add(coffee);
        Assert.That(basket.GetTotal(), Is.EqualTo(0.49 + 1.19));

        basket.Remove(coffee);
        Assert.That(basket.GetTotal(), Is.EqualTo(0.49));

        basket.Add(new Filling("FILE"));
        Assert.That(basket.GetTotal(), Is.EqualTo(0.49 + 0.12));
    }

    [Test]
    public void TestDiscount()
    {
        BobsBagels store = new BobsBagels();
        Basket basket = new Basket();
        store.AddBasket(basket);
        Bagel bagel;

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
        BobsBagels store = new BobsBagels();
        Basket basket = new Basket();
        store.AddBasket(basket);
        store.IncreaseCapacity(20);
        Bagel bagel;
        

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

        Coffee coffee;
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
        BobsBagels store = new BobsBagels();
        Basket basket = new Basket();
        store.AddBasket(basket);
        store.IncreaseCapacity(20);
        Bagel bagel;


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
        BobsBagels store = new BobsBagels();
        Basket basket = new Basket();
        store.AddBasket(basket);
        store.IncreaseCapacity(20);
        Bagel bagel;


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
        BobsBagels store = new BobsBagels();
        Basket basket = new Basket();
        store.AddBasket(basket);
        store.IncreaseCapacity(20);
        Bagel bagel;

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
        BobsBagels store = new BobsBagels();
        Basket basket = new Basket();
        store.AddBasket(basket);
        store.IncreaseCapacity(30);
        Bagel bagel;

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
        Bagel bagel = new Bagel("BGLO");

        basket.Add(bagel);

        Receipt receipt = new Receipt(basket);
        Assert.That(receipt.Time.Day, Is.EqualTo(DateTime.Now.Day));
        Assert.That(receipt.Time.Year, Is.EqualTo(DateTime.Now.Year));

        Assert.That(receipt.Items.Count, Is.EqualTo(1));
        Assert.That(receipt.Total, Is.EqualTo(0.49));
    }
}