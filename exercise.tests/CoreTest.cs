using NUnit.Framework;
using exercise.main;
using System.Linq;
using static exercise.main.BasketManager;
using static exercise.main.Inventory;

namespace exercise.tests;

[TestFixture]
public class CoreTests
{
    Inventory inventory = new Inventory();

    private InventoryItem onionVariant;
    private InventoryItem plainVariant;
    private InventoryItem hamFilling;

    [SetUp]
    public void Setup()
    {
        onionVariant = inventory.GetItem("BGLO");
        plainVariant = inventory.GetItem("BGLP");
        hamFilling = inventory.GetItem("FILH");
    }

    [Test]
    public void BasketCost()
    {
        var basket = new BasketManager.Order();
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
}
