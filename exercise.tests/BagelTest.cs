namespace exercise.tests;
using exercise.main;

[TestFixture]
public class BagelTest
{
    [Test]
    public void TestGetPrice()
    {
        //setup
        Bagel bagel = new(BagelType.Plain);

        //execute
        double price = bagel.GetPrice();

        //assert
        Assert.That(price, Is.EqualTo(0.39));
        Assert.That(price, Is.EqualTo(bagel.Price));
    }

    [Test]
    public void TestSetFilling()
    {
        //setup
        Bagel bagel = new(BagelType.Onion);
        Filling filling = new(FillingType.CreamCheese);

        //execute
        bagel.AddFilling(filling);

        //verify
        Assert.That(bagel.GetFillings().Count, Is.EqualTo(1));
        Assert.That(bagel.GetFillings()[0], Is.EqualTo(filling));
    }

    [Test]
    public void TestGetsFullPriceWithFillings()
    {
        //setup
        Bagel bagel = new(BagelType.Onion);
        Filling filling = new(FillingType.CreamCheese);
        bagel.AddFilling(filling);

        //execute
        double price = bagel.GetPrice();

        //verify
        Assert.That(price, Is.EqualTo(0.49 + 0.12));
    }
}

