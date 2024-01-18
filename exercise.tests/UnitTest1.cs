using exercise.main;
using exercise.main.items;

namespace exercise.tests;

[TestFixture]
public class Tests
{
    Basket basket;
    [SetUp]
    public void Setup()
    {
        basket = new Basket();
    }

    [Test]
    public void TestAddBagel()
    {
        Bagel bagel = new Bagel(BagelVariant.Sesame);
        basket.Add(bagel);
        Assert.That(basket.Products.Count > 0);
    }

    [Test]
    public void TestAddCoffee()
    {
        Coffee coffee = new Coffee(CoffeeVariant.Capuccino);
        basket.Add(coffee);
        Assert.That(basket.Products.Count > 0);
    }

    [Test]
    public void ShouldRemoveBagel()
    {
        Bagel bagel = new Bagel(BagelVariant.Everything);
        basket.Add(bagel);
        bool removed = basket.Remove(bagel);
        Assert.That(removed);
        Assert.That(basket.Products.Count == 0);
    }

    [Test]
    public void ShouldRemoveCoffee()
    {
        Coffee coffee = new Coffee(CoffeeVariant.Latte);
        basket.Add(coffee);
        bool removed = basket.Remove(coffee);
        bool notRemoved = basket.Remove(coffee);
        Assert.That(removed);
        Assert.That(!notRemoved);
        Assert.That(basket.Products.Count == 0);
    }

    [Test]
    public void CapacityShouldBeZero()
    {
        basket.Capacity = -4;
        Assert.That(basket.Capacity == 0);
    }

    [Test]
    public void TestPrice1()
    {
        Coffee coffee = new Coffee(CoffeeVariant.Latte);
        Bagel bagel = new Bagel(BagelVariant.Everything);

        basket.Add(bagel);
        basket.Add(coffee);

        Assert.That(basket.Cost(true), Is.EqualTo(1.78d));
    }

    [Test]
    public void TestPriceBagel()
    {
        Bagel bagel = new Bagel(BagelVariant.Onion);

        Assert.That(bagel.Cost(), Is.EqualTo(0.49d));
    }

    [Test]
    public void ShouldAddFilling()
    {
        Bagel bagel = new Bagel(BagelVariant.Onion);
        Filling filling = new Filling(FillingVariant.Cheese);
        bagel.AddFilling(filling);

        Assert.That(bagel.Fillings.Count, Is.EqualTo(1));
    }

    [Test]
    public void ShouldReturnFillingPrice()
    {
        Filling filling = new Filling(FillingVariant.Cheese);

        Assert.That(filling.Price, Is.EqualTo(0.12));
    }

    [Test]
    public void TestPrice2()
    {
        Bagel bagel = new Bagel(BagelVariant.Everything);
        bagel.AddFilling(new Filling(FillingVariant.Cheese));
        bagel.AddFilling(new Filling(FillingVariant.Ham));

        basket.Add(bagel);
        basket.Add(new Bagel(BagelVariant.Sesame));
        basket.Add(new Coffee(CoffeeVariant.Latte));

        // 0.49 + 0.24 + 0.49 + 1.29
        Assert.That(basket.Cost(true), Is.EqualTo(2.51d));
    }

    [Test]
    public void TestPrice3()
    {
        Bagel onion = new Bagel(BagelVariant.Onion);
        Bagel sesame = new Bagel(BagelVariant.Sesame);
        basket.Add(onion);
        basket.Add(sesame);

        Filling filling = new Filling(FillingVariant.Bacon);
        onion.AddFilling(filling);
        Filling cheese = new Filling(FillingVariant.Cheese);
        onion.AddFilling(cheese);
        Assert.That(basket.Cost(true), Is.EqualTo(0.98d + 0.24d));
    }

    [Test]
    public void TestPrice4()
    {
        Bagel onion = new Bagel(BagelVariant.Onion);
        Bagel sesame = new Bagel(BagelVariant.Sesame);
        basket.Add(onion);
        basket.Add(sesame);

        Coffee coffee = new Coffee(CoffeeVariant.Capuccino);
        basket.Add(coffee);
        Assert.That(basket.Cost(true), Is.EqualTo(0.98d + 1.29d));
    }

    [Test]
    public void TestDiscountPriceSix()
    {
        basket.Capacity = 20;
        for (int i = 0;  i < 10; i++)
        {
            basket.Add(new Bagel(BagelVariant.Onion));
        }


        // 1.96 + 2.49
        Assert.That(Math.Round(basket.Cost(), 4), Is.EqualTo(Math.Round(1.96d + 2.49d, 4)));
    }

    [Test]
    public void TestDiscountPriceTwelve()
    {
        basket.Capacity = 20;
        for (int i = 0; i < 16; i++)
        {
            basket.Add(new Bagel(BagelVariant.Onion));
        }


        // 1.96 + 3.99
        Assert.That(Math.Round(basket.Cost(), 4), Is.EqualTo(Math.Round(1.96d + 3.99, 4)));
    }

    [Test]
    public void TestDiscountPriceBoth()
    {
        basket.Capacity = 20;
        for (int i = 0; i < 19; i++)
        {
            basket.Add(new Bagel(BagelVariant.Onion));
        }
        basket.Add(new Bagel(BagelVariant.Plain));


        // 3.99 + 2.49 + 0.49 + 0.39
        Assert.That(Math.Round(basket.Cost(), 4), Is.EqualTo(Math.Round(3.99d + 2.49d + 0.49d + 0.39d, 4)));
    }

    [Test]
    public void TestDiscountPriceCoffeBagel()
    {
        basket.Capacity = 25;
        for (int i = 0; i < 19; i++)
        {
            basket.Add(new Bagel(BagelVariant.Onion));
        }
        Bagel bagel = new Bagel(BagelVariant.Plain);
        bagel.AddFilling(new Filling(FillingVariant.Ham));
        basket.Add(bagel);
        basket.Add(new Coffee(CoffeeVariant.Capuccino));


        // 3.99 + 2.49 + 0.39 + 1.25
        Assert.That(Math.Round(basket.Cost(), 4), Is.EqualTo(Math.Round(3.99d + 2.49d + 0.39d + 1.25d + 0.12d, 4)));
    }
}