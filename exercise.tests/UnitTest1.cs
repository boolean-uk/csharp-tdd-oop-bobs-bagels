using exercise.main;

namespace exercise.tests;

public class Tests
{
    Basket basket;
    Bagel onion, sesame;

    [SetUp]
    public void Setup()
    {
        basket = new Basket();
        onion = new Bagel(BagelType.Onion);
        sesame = new Bagel(BagelType.Sesame);
        basket.Add(onion);
        basket.Add(sesame);
    }

    [Test]
    public void addTest()
    {
        Assert.AreEqual(basket.products, new List<Product>() { onion, sesame });
    }

    [Test]
    public void removeTest()
    {
        basket.Remove(onion);
        Assert.AreEqual(basket.products, new List<Bagel>() { sesame });
    }

    [Test]
    public void addReturnTrue()
    {
        Assert.IsTrue(basket.Add(new Bagel(BagelType.Plain)));
    }

    [Test]
    public void addReturnFalse()
    {
        basket.Add(new Bagel(BagelType.Plain));
        Assert.IsFalse(basket.Add(new Bagel(BagelType.Everything)));
    }

    [Test]
    public void changeCapacityLowerTest()
    {
        basket.ChangeCapacity(2);
        Assert.IsFalse(basket.Add(new Bagel(BagelType.Plain)));
    }

    [Test]
    public void changeCapacityUpperTest()
    {
        basket.ChangeCapacity(5);
        basket.Add(new Bagel(BagelType.Onion));
        basket.Add(new Bagel(BagelType.Onion)); basket.Add(new Bagel(BagelType.Onion));
        Assert.IsFalse(basket.Add(new Bagel(BagelType.Onion)));
    }

    [Test]
    public void removeExisting() => Assert.True(basket.Remove(onion));

    [Test]
    public void removeNonexisting()
    {
        Bagel bagel = new Bagel(BagelType.Everything);
        Assert.False(basket.Remove(bagel));
    }

    [Test]
    public void totalCostsTest()
    {
        string something;
        Assert.AreEqual(basket.TotalCost(), 0.98d);
    }

    [Test]
    public void addTopping()
    {
        Filling filling = new Filling(FillingType.Bacon);
        onion.Add(filling);
        Assert.AreEqual(onion._filling, new List<Filling>{filling});
    }

    [Test]
    public void totalCostsFillingTest() 
    {
        Filling filling = new Filling(FillingType.Bacon);
        onion.Add(filling);
        Filling cheese = new Filling(FillingType.Cheese);
        onion.Add(cheese);
        Assert.AreEqual(basket.TotalCost(), 0.98d + 0.24d);
    }

    [Test]
    public void totalCostCoffee()
    {
        Coffee coffee = new Coffee(CoffeType.Capuccino);
        basket.Add(coffee);
        Assert.AreEqual(basket.TotalCost(), 0.98d + 1.29d);
    }
}