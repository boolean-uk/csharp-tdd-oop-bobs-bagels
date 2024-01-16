using exercise.main;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestFilling()
    {
        Filling filling = new Filling("Bacon");

        Assert.That(filling.Variant, Is.EqualTo("Bacon"));
        Assert.That(filling.Price, Is.EqualTo(0.12));
        Assert.That(filling.SKU, Is.EqualTo("FILB"));
    }

    [Test]
    public void TestBagelConstructor()
    {
        Bagel bagel = new Bagel("Onion");

        Assert.That(bagel.Variant, Is.EqualTo("Onion"));
        Assert.That(bagel.Price, Is.EqualTo(0.49));
        Assert.That(bagel.SKU, Is.EqualTo("BGLO"));
        Assert.That(bagel.Filling, Is.EqualTo(null));
    }

    [Test]
    public void TestBagelSetFilling()
    {
        Bagel bagel = new Bagel("Onion");
        bagel.SetFilling("Bacon");

        Assert.That(bagel.Filling, Is.Not.Null);
        Assert.That(bagel.Filling.Variant, Is.EqualTo("Bacon"));
    }

    [Test]
    public void TestBasketConstructor()
    {
        Basket basket = new Basket();

        Assert.That(basket.Bagels.Count, Is.EqualTo(0));
        Assert.That(basket.Capacity, Is.EqualTo(10));
        Assert.That(basket.Total, Is.EqualTo(0));
    }
}