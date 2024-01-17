using NUnit.Framework;
using exercise.main;
using System.Linq;
using static exercise.main.ShoppingCart;
using static exercise.main.Inventory;

namespace exercise.tests;

[TestFixture]
public class CoreTests
{
    private BagelVariant onionVariant;
    private BagelVariant plainVariant;
    private BagelFilling hamFilling;

    [SetUp]
    public void Setup()
    {
        onionVariant = BagelVariant.AllVariants.First(v => v.Name == "Onion");
        plainVariant = BagelVariant.AllVariants.First(v => v.Name == "Plain");
        hamFilling = BagelFilling.AllFillings.First(f => f.Name == "Ham");
    }

    [Test]
    public void BasketCost()
    {
        var basket = new Basket();
        var bagel = new Bagel(onionVariant);
        basket.Add(bagel);

        double expected = onionVariant.Price;
        double actualCost = basket.Cost();

        Assert.That(actualCost, Is.EqualTo(expected));
    }

    [Test]
    public void AddFilling()
    {
        var bagel = new Bagel(plainVariant);

        bagel.AddFilling(hamFilling);

        bool hasHamFilling = bagel.Fillings.Any(f => f.Name == hamFilling.Name && f.Price == hamFilling.Price);

        Assert.IsTrue(hasHamFilling);
    }

    [Test]
    public void BagelCost()
    {
        var bagel = new Bagel(onionVariant);
        bagel.AddFilling(hamFilling);

        double expected = onionVariant.Price + hamFilling.Price;
        double actualCost = bagel.Cost();

        Assert.That(actualCost, Is.EqualTo(expected));
    }

    [Test]
    public void GetBagelFillings()
    {
        var fillings = BagelFilling.AllFillings;

        Assert.IsNotEmpty(fillings);
        Assert.That(fillings, Contains.Item(hamFilling));
    }
}
