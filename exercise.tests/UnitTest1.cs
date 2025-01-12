using exercise.main;
using static exercise.main.Bagel;

namespace exercise.tests;

public class Tests
{
    Bagel bagelO = new Bagel("BGLO", "Bagel", 0.49);
    Bagel bagelP = new Bagel("BGLP", "Bagel", 0.39);


    [Test]
    public void TestAddToBasket()
    {
        Basket expBasket = new Basket { Items = new List<Item>() { bagelO, bagelP } };
        Basket basket = new Basket 
        { 
            Items = new List<Item>() { bagelO }, 
            MaxSize = 2 
        };

        basket.addToBasket(bagelP);

        Assert.That(basket.Items.Contains(bagelP));
        Assert.That(basket.Items, Is.EqualTo(expBasket.Items));

        try
        {
            basket.addToBasket(bagelO);
            Assert.Fail();
        }
        catch (Exception e) { Console.WriteLine(e); }
    }


    [Test]
    public void TestRemoveBasket()
    {
        Basket basket = new Basket { Items = new List<Item>() { bagelO, bagelP } };
        Basket expBasket = new Basket { Items = new List<Item>() { bagelO } };

        basket.removeFromBasket(bagelP);

        Assert.That(basket.Items, Does.Not.Contain(bagelP));
        Assert.That(basket.Items, Is.EqualTo(expBasket.Items));

        try
        {
            basket.removeFromBasket(bagelP);
            Assert.Fail();
        }
        catch (Exception e) { Console.WriteLine(e); }
    }


    [Test]
    public void TestSetBasketSize()
    {
        Basket basket = new Basket
        {
            Items = new List<Item>() { bagelO },
            MaxSize = 2
        };

        basket.setBasketSize(true, 1);

        Assert.That(basket.MaxSize, Is.EqualTo(1));

        try
        {
            basket.setBasketSize(false, 3);
            Assert.Fail();
        }
        catch (Exception e) { Console.WriteLine(e); }

    }


    [Test]
    public void TestGetTotalCost()
    {
        Basket basket = new Basket { Items = new List<Item>() };

        Assert.That(basket.getTotalCost(), Is.EqualTo(0));

        Fillings fillings = new Fillings("FILE", "Filling", 0.12);
        bagelO.Fillings_list = new List<Fillings>() { fillings };
        double onionWFilling = 0.49 + 0.12;

        Assert.That(bagelP.getPrice(), Is.EqualTo(0.39));
        Assert.That(bagelO.getPrice(), Is.EqualTo(onionWFilling));

        basket.Items = new List<Item>() { bagelO, bagelP };
        double totalCost = 0.39 + 0.49 + 0.12;

        Assert.That(basket.getTotalCost(), Is.EqualTo(totalCost));

    }
}


