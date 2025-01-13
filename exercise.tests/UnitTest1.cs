using System;
using System.Linq;
using exercise.main;
using static exercise.main.Bagel;

namespace exercise.tests;

public class Tests
{
    Bagel bagelO = new Bagel("Bagel", "Onion", 0.49);
    Bagel bagelP = new Bagel("Bagel", "Plain", 0.39);

    Coffee coffee = new Coffee("COFB", "Coffee", 0.99);

    //public Dictionary<string, Item> Inventory = new Dictionary<string, Item>()
    //    {
    //        {"BGLO", new Bagel("Bagel", "Onion", 0.49)},
    //        {"BGLP", new Bagel("Bagel", "Plain", 0.39)},
    //        {"BGLE", new Bagel("Bagel", "Everything", 0.49)},
    //        {"BGLS", new Bagel("Bagel", "Sesame", 0.49)},
    //        {"COFB", new Coffee("Coffee", "Black", 0.99)},
    //        {"COFW", new Coffee("Coffee", "White", 1.19)},
    //        {"COFC", new Coffee("Coffee", "Cappucino", 1.29)},
    //        {"COFL", new Coffee("Coffee", "Latte", 1.29)}
    //    };


    [Test]
    public void TestAddToBasket()
    {
        Basket expBasket = new Basket { Items = new List<Item>() { bagelO, bagelP } };
        Basket basket = new Basket 
        { 
            Items = new List<Item>() { bagelO }, 
            MaxSize = 2 
        };

        Assert.That(basket.Items.Count, Is.EqualTo(1));

        basket.addToBasketByID("BGLP");

        Assert.That(basket.Items.Count, Is.EqualTo(2));
        Assert.That(basket.Items.Contains(basket.StockItems["BGLP"]));
        Assert.That(basket.Items[1].Variant, Is.EqualTo(expBasket.Items[1].Variant));
        Assert.That(basket.Items[1].Variant.ToString(), Is.EqualTo("Plain"));

        try
        {
            basket.addToBasketByID("BGLO");
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

        Assert.That(bagelO.Fillings_list[0].Price, Is.EqualTo(0.12));
        Assert.That(bagelP.getPrice(), Is.EqualTo(0.39));
        Assert.That(bagelO.getPrice(), Is.EqualTo(onionWFilling));

        basket.Items = new List<Item>() { bagelO, bagelP };
        double totalCost = 0.39 + 0.49 + 0.12;

        Assert.That(basket.getTotalCost(), Is.EqualTo(totalCost));

    }
}


