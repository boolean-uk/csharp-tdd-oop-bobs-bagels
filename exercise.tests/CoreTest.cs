using exercise.main;
using static exercise.main.Core;

namespace exercise.tests;

public class CoreTests
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void BasketCost()
    {
        Basket basket = new Basket();
        Bagel bagel = new Bagel(BagelVariant.Onion);
        basket.Add(bagel);

        double expected = 0.49;
        double actualCost = basket.Cost();

        Assert.That(actualCost, Is.EqualTo(expected));
    }

    [Test]
    public void AddFilling()
    {
        Bagel bagel = new Bagel(BagelVariant.Plain);

        bagel.AddFilling(BagelFilling.Ham);

        bool hasHamFilling = bagel.Fillings.Any(f => f.Name == BagelFilling.Ham.Name && f.Price == BagelFilling.Ham.Price);

        Assert.IsTrue(hasHamFilling);
    }

    [Test]
    public void BagelCost()
    {
        Bagel bagel = new Bagel(BagelVariant.Onion);
        bagel.AddFilling(BagelFilling.Ham);

        double expected = 0.49 + 0.12;
        double actualCost = bagel.Cost();

        Assert.That(actualCost, Is.EqualTo(expected));
    }

    [Test]
    public void GetBagelFillings()
    {
        IEnumerable<BagelFilling> fillings = BagelFilling.GetAll();

        Assert.IsNotEmpty(fillings);
    }
}