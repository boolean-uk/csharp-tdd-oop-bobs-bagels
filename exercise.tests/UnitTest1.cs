using System;
using System.Linq;
using exercise.main;
using static exercise.main.Bagel;

namespace exercise.tests;

public class Tests
{
    Bagel bagelO = (Bagel)Basket.StockItems[0];
    Bagel bagelP = (Bagel)Basket.StockItems[1];

    Coffee coffee = (Coffee)Basket.StockItems[4];

    Filling egg = Bagel.StockItems[1];


    [Test]
    public void TestAddToBasket()
    {
        Basket basket = new Basket
        {
            Items = new List<Item>() { bagelO },
            MaxSize = 2
        };
        Basket expBasket = new Basket { Items = new List<Item>() { bagelO, bagelP } };

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

        Filling fillings = new Filling("FILE", "Filling", "Egg", 0.12);
        bagelO.Fillings_list = new List<Filling>() { fillings };
        double onionWFilling = 0.49 + 0.12;

        Assert.That(bagelO.Fillings_list[0].Price, Is.EqualTo(0.12));
        Assert.That(bagelP.getPrice(), Is.EqualTo(0.39));
        Assert.That(bagelO.getPrice(), Is.EqualTo(onionWFilling));

        basket.Items = new List<Item>() { bagelO, bagelP };
        double totalCost = 0.39 + 0.49 + 0.12;

        Assert.That(basket.getTotalCost(), Is.EqualTo(totalCost));

    }


    [Test]
    public void TestAddFilling()
    {
        bagelO.Fillings_list = new List<Filling>();

        Assert.That(bagelO.Fillings_list, Does.Not.Contain(egg));

        bagelO.addFilling(egg);

        Assert.That(bagelO.Fillings_list, Does.Contain(egg));

        Filling notInStock = new Filling("FILP", "Filling", "Pepperoni", 0.12);

        try
        {
            bagelO.addFilling(notInStock);
            Assert.Fail();
        }
        catch (Exception e) { Console.WriteLine(e); }
    }

    [Test]
    public void TestRemoveFilling()
    {
        bagelO.Fillings_list = new List<Filling>() { egg };
        
        bagelO.removeFilling(egg);

        Assert.That(bagelO.Fillings_list, Does.Not.Contain(egg));

        try
        {
            bagelO.removeFilling(egg);
            Assert.Fail();
        }
        catch (Exception e) { Console.WriteLine(e); }
    }
}


