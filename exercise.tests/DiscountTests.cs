using exercise.main.Models;

namespace exercise.tests;

public class DiscountTests
{
    Basket basket;


    [SetUp]
    public void Setup()
    {
        basket = new Basket(30);
        Bagel bagel1 = new Bagel("BGLO");
        Bagel bagel2 = new Bagel("BGLO");
        Bagel bagel3 = new Bagel("BGLE");
        Coffee coffee1 = new Coffee("COFB");
        Coffee coffee2 = new Coffee("COFB");
        Coffee coffee3 = new Coffee("COFL");
        Filling filling1 = new Filling("FILS");
        Filling filling2 = new Filling("FILH");
        bagel1.AddFilling(filling1);
        bagel2.AddFilling(filling2);
        basket.Add(bagel1);
        basket.Add(bagel2);
        basket.Add(bagel3);
        basket.Add(coffee1);
        basket.Add(coffee2);
        basket.Add(coffee3);

    }

    [Test]
    public void TestCoffeeDeal()
    {
        Assert.That(basket.GetPriceWithDiscounts(), Is.EqualTo(4.52));
    }
    [Test]
    public void TestSixBagelDeal()
    {
        basket.clear();
        Bagel bagel1 = new Bagel("BGLO");
        Bagel bagel2 = new Bagel("BGLO");
        Bagel bagel3 = new Bagel("BGLO");
        Bagel bagel4 = new Bagel("BGLO");
        Bagel bagel5 = new Bagel("BGLO");
        Bagel bagel6 = new Bagel("BGLO");
        basket.Add(bagel1);
        basket.Add(bagel2);
        basket.Add(bagel3);
        basket.Add(bagel4);
        basket.Add(bagel5);
        basket.Add(bagel6);
        Assert.That(basket.GetPriceWithDiscounts(), Is.EqualTo(2.49));
    }
    [Test]
    public void TestTwelveBagelDeal()
    {
        basket.clear();
        for (int i = 0; i < 12; i++)
        {
            Bagel bagel = new Bagel("BGLO");
            basket.Add(bagel);
        }
        Assert.That(basket.GetPriceWithDiscounts(), Is.EqualTo(3.99));
    }


    [Test]
    public void TestTwelveWithExtra()
    {
        basket.clear();
        for (int i = 0; i < 14; i++)
        {
            Bagel bagel = new Bagel("BGLO");
            basket.Add(bagel);
        }
        Assert.That(basket.GetPriceWithDiscounts(), Is.EqualTo(4.97));
    }

    [Test]
    public void TestTwelveWithExtraCoffee()
    {
        basket.clear();
        for (int i = 0; i < 14; i++)
        {
            Bagel bagel = new Bagel("BGLO");
            basket.Add(bagel);
        }
        Coffee coffee = new Coffee("COFB");
        basket.Add(coffee);
        Assert.That(basket.GetPriceWithDiscounts(), Is.EqualTo(5.73));
    }

    [Test]
    public void TestTwelveSixCoffeCoffe()
    {
        // 12 bagel deal, 6 bagel deal, 2 coffe deals, and an extra bagle
        basket.clear();
        for (int i = 0; i < 21; i++)
        {
            Bagel bagel = new Bagel("BGLO");
            basket.Add(bagel);
        }
        Coffee coffee = new Coffee("COFB");
        Coffee coffee2 = new Coffee("COFB");
        basket.Add(coffee);
        basket.Add(coffee2);
        Assert.That(basket.GetPriceWithDiscounts(), Is.EqualTo(9.47));
    }



    [Test]
    public void TestSixWithFillings()
    {
        basket.clear();
        for (int i = 0; i < 6; i++)
        {
            Bagel bagel = new Bagel("BGLO");
            Filling filling = new Filling("FILS");
            bagel.AddFilling(filling);
            basket.Add(bagel);
        }
        Assert.That(basket.GetPriceWithDiscounts(), Is.EqualTo(3.21));
    }

    [Test]
    public void TestTwelveSomeFilling()
    {
        basket.clear();
        for (int i = 0; i < 12; i++)
        {
            Bagel bagel = new Bagel("BGLO");
            if (i % 2 == 0)
            {
                Filling filling = new Filling("FILS");
                bagel.AddFilling(filling);
            }
            basket.Add(bagel);
        }
        Assert.That(basket.GetPriceWithDiscounts(), Is.EqualTo(4.71));
    }
}