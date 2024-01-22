using exercise.main;
using System.Reflection.Emit;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddingItemToBasket()
    {
        Basket basket = new Basket();
        Bagel bagel = new Bagel("BGLO", 0.49, "Onion");
        basket.AddItem(bagel);
        Assert.That(basket.GetBasketCount(), Is.EqualTo(1));
        Assert.That(basket.GetItem(0), Is.EqualTo(bagel));
    }

    [Test]
    public void RemoveingItemFromBasket() 
    {
        Basket basket = new Basket();
        Bagel bagel = new Bagel("BGLO", 0.49, "Onion");
        basket.AddItem(bagel);
        basket.RemoveItem(0);
        Assert.That(basket.GetBasketCount() == 0);
    }

    [Test]
    public void CalculatingTotalCostOfBasket()
    {
        Basket basket = new Basket();
        Bagel bagel = new Bagel("BGLO", 0.49, "Onion");
        Coffee coffee = new Coffee("COFB", 0.99, "Black");
        basket.AddItem(bagel);
        basket.AddItem(coffee);
        double total = basket.CalculateTotal();
        Assert.That(total, Is.EqualTo(1.48));
    }

    [Test]
    public void ChangingBasketCapasity()
    {
        Basket basket = new Basket();
        basket.ChangeBasketCapacity(50);
        Assert.That(basket.GetBasketCapacity(), Is.EqualTo(50));
    }

    [Test]
    public void AddingItemToBasketOverCapacity()
    {
        Basket basket = new Basket(2);
        Bagel bagel1 = new Bagel("BGLO", 0.49, "Onion");
        Bagel bagel2 = new Bagel("BGLP", 0.39, "Plain");
        basket.AddItem(bagel1);
        basket.AddItem(bagel2);
        basket.AddItem(new Coffee("COFB", 0.99, "Black"));
        Assert.That(basket.GetBasketCount(), Is.EqualTo(2));
    }

    [Test]
    public void Using6BagelDiscount()
    {
        Basket basket = new Basket();
        Bagel bagel = new Bagel("BGLO", 0.49, "Onion");
        for (int i = 0; i < 6; i++)
        {
            basket.AddItem(bagel);
        }
        double expectedTotal = 2.49; 
        Assert.That(basket.CalculateTotal(), Is.EqualTo(expectedTotal));
    }

    [Test]
    public void Using12BagelDiscount()
    {
        Basket basket = new Basket();
        Bagel bagel = new Bagel("BGLO", 0.49, "Onion");
        for (int i = 0; i < 12; i++)
        {
            basket.AddItem(bagel);
        }
        double expectedTotal = 3.99;
        Assert.That(basket.CalculateTotal(), Is.EqualTo(expectedTotal));
    }
}