using exercise.main.Models;

namespace exercise.tests;

public class Tests
{
    Basket basket;
    Bagel bagel1;
    Bagel bagel2;

    [SetUp]
    public void Setup()
    {
        basket = new Basket(6);
        bagel1 = new Bagel("BGLO");
        bagel2 = new Bagel("BGLO");
        Coffee coffee1 = new Coffee("COFL");
        Coffee coffee2 = new Coffee("COFC");
        Filling filling1 = new Filling("FILS");
        Filling filling2 = new Filling("FILH");
        bagel1.AddFilling(filling1);
        bagel2.AddFilling(filling2);
        basket.Add(bagel1);
        basket.Add(bagel2);
        basket.Add(coffee1);
        basket.Add(coffee2);
    }

    [Test]
    public void TestUniqueBagels()
    {
        bagel1.Price = 10;
        Assert.That(bagel2.Price, Is.EqualTo(0.49));
    }
    [Test]
    public void TestBagelPrice()
    {
        Assert.That(bagel1.GetTotalPrice(), Is.EqualTo(0.61));
        Bagel bagel3 = new Bagel("BGLE");
        bagel3.AddFilling(new Filling("FILB"));
        bagel3.AddFilling(new Filling("FILC"));
        Assert.That(bagel3.GetTotalPrice(), Is.EqualTo(0.73));
    }
    [Test]
    public void TestBasketPrice()
    {
        Assert.That(basket.GetTotalPrice(), Is.EqualTo(3.8));
    }
    [Test]
    public void TestAddBagel()
    {
        Bagel bagel3 = new Bagel("BGLP");
        basket.Add(bagel3);
        Assert.That(basket.GetTotalPrice(), Is.EqualTo(4.19));
        Assert.That(basket.Products.Count, Is.EqualTo(5));
    }
    [Test]
    public void TestRemoveBagel()
    {
        bool removed = basket.Remove(bagel1);
        Assert.That(removed, Is.True);
        Assert.That(basket.GetTotalPrice(), Is.EqualTo(3.19M));
        Assert.That(basket.Products.Count, Is.EqualTo(3));
    }
    [Test]
    public void TestRemoveFail()
    {
        Bagel bagel3 = new Bagel("BGLP");
        bool removed = basket.Remove(bagel3);
        Assert.That(removed, Is.False);
        Assert.That(basket.GetTotalPrice(), Is.EqualTo(3.8));
        Assert.That(basket.Products.Count, Is.EqualTo(4));
    }
    [Test]
    public void TestUpdateBasketCapacity()
    {
        basket.UpdateCapacity(10, Role.Manager);
        Assert.That(basket.Capacity, Is.EqualTo(10));
    }
    [Test]
    public void TestUpdateBasketCapacityFail()
    {
        try
        {
            basket.UpdateCapacity(10, Role.Customer);
        }
        catch (Exception e)
        {
            Assert.That(e.Message, Is.EqualTo("You are not authorized to update the capacity"));
        }
    }
    [Test]
    public void TestAddBagelToFullBasket()
    {
        Bagel bagel3 = new Bagel("BGLP");
        Bagel bagel4 = new Bagel("BGLO");
        Bagel bagel5 = new Bagel("BGLS");
        basket.Add(bagel3);
        basket.Add(bagel4);
        bool addedLast = basket.Add(bagel5);
        Assert.That(addedLast, Is.False);

    }
}