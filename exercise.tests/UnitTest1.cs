using exercise.main;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Basket _basket = new Basket();

        _basket.AddBagel(new Bagel());
        _basket.AddBagel(new Bagel("Onion"));
        _basket.AddBagel(new Bagel("Mushroom"));


        Assert.That(2, Is.EqualTo(_basket.BagelList.Count));
    }

    [Test]
    public void Test2()
    {
        Basket _basket = new Basket();

        _basket.AddBagel(new Bagel("Onion"));
        _basket.AddBagel(new Bagel("Onion", "Bacon"));

        _basket.RemoveBagel(_basket.BagelList[1]);


        Assert.That(1, Is.EqualTo(_basket.BagelList.Count));
    }

    [Test]
    public void Test3()
    {
        Basket _basket = new Basket(2);

        _basket.AddBagel(new Bagel("Onion"));
        _basket.AddBagel(new Bagel("Onion", "Bacon"));
        _basket.AddBagel(new Bagel());
        _basket.AddBagel(new Bagel());


        Assert.That(2, Is.EqualTo(_basket.BagelList.Count));
    }

    [Test]
    public void Test4()
    {
        Basket _basket = new Basket(2);

        _basket.AddBagel(new Bagel("Onion"));
        _basket.AddBagel(new Bagel("Onion", "Bacon"));
        _basket.AddBagel(new Bagel());
        _basket.AddBagel(new Bagel());

        _basket.UpdateCapacity(3);

        _basket.AddBagel(new Bagel("Plain", "Bacon"));


        Assert.That(3, Is.EqualTo(_basket.BagelList.Count));
    }

    [Test]
    public void Test5()
    {
        Basket _basket = new Basket();

        _basket.AddBagel(new Bagel("Onion"));
        _basket.AddBagel(new Bagel("Onion", "Bacon"));
        _basket.AddBagel(new Bagel());

        _basket.RemoveBagel(new Bagel("Onion", "Sesame"));

        Assert.That(3, Is.EqualTo(_basket.BagelList.Count));
    }

    [Test]
    public void Test6()
    {
        Basket _basket = new Basket();

        _basket.AddBagel(new Bagel("Onion"));
        _basket.AddBagel(new Bagel("Onion", "Bacon"));
        _basket.AddBagel(new Bagel("Plain", "Bacon"));

        double result = _basket.GetBasketTotal();

        result = Math.Round(result, 2);
        Assert.AreEqual(result, 1.61);
    }

    [Test]
    public void Test7()
    {
        double result = Inventory.CheckBagelPrice(new Bagel("Onion", "Bacon"));

        result = Math.Round(result, 2);
        Assert.AreEqual(result, 0.61);
    }

    [Test]
    public void Test8()
    {
        double result = Inventory.CheckFillingPrice("Bacon");

        result = Math.Round(result, 2);
        Assert.AreEqual(result, 0.12);
    }
}