using exercise.main;

namespace exercise.tests;

public class Tests
{
    //Basket basket = new Basket();
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
        Assert.Pass();
    }
}


