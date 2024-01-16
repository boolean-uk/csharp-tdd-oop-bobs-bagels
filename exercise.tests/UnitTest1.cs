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

        Assert.That(basket.Cost(), Is.EqualTo(1.78d));
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
        Assert.That(basket.Cost(), Is.EqualTo(2.51d));
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
        Assert.That(basket.Cost(), Is.EqualTo(0.98d + 0.24d));
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
        Assert.That(basket.Cost(), Is.EqualTo(0.98d + 1.29d));
    }
}