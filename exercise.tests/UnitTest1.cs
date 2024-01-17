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
        _basket.AddBagel(new Bagel(BagelType.Onion));
       // _basket.AddBagel(new Bagel("Mushroom")); //current system makes it impossible to add invalid items to the basket


        Assert.That(2, Is.EqualTo(_basket.BagelList.Count));
    }

    [Test]
    public void Test2()
    {
        Basket _basket = new Basket();

        _basket.AddBagel(new Bagel(BagelType.Onion));
        _basket.AddBagel(new Bagel(BagelType.Onion, BagelFilling.Bacon));

        _basket.RemoveBagel(_basket.BagelList[1]);


        Assert.That(1, Is.EqualTo(_basket.BagelList.Count));
    }

    [Test]
    public void Test3()
    {
        Basket _basket = new Basket(2);

        _basket.AddBagel(new Bagel(BagelType.Onion));
        _basket.AddBagel(new Bagel(BagelType.Onion, BagelFilling.Bacon));
        _basket.AddBagel(new Bagel());
        _basket.AddBagel(new Bagel());


        Assert.That(2, Is.EqualTo(_basket.BagelList.Count));
    }

    [Test]
    public void Test4()
    {
        Basket _basket = new Basket(2);

        _basket.AddBagel(new Bagel(BagelType.Onion));
        _basket.AddBagel(new Bagel(BagelType.Onion, BagelFilling.Bacon));
        _basket.AddBagel(new Bagel());
        _basket.AddBagel(new Bagel());

        _basket.UpdateCapacity(3);

        _basket.AddBagel(new Bagel(BagelType.Onion, BagelFilling.Bacon));


        Assert.That(3, Is.EqualTo(_basket.BagelList.Count));
    }

    [Test]
    public void Test5()
    {
        Basket _basket = new Basket();

        _basket.AddBagel(new Bagel(BagelType.Onion));
        _basket.AddBagel(new Bagel(BagelType.Onion, BagelFilling.Bacon));
        _basket.AddBagel(new Bagel());


        _basket.RemoveBagel(new Bagel(BagelType.Onion, BagelFilling.SmokedSalmon));

        Assert.That(3, Is.EqualTo(_basket.BagelList.Count));
    }

    [Test]
    public void Test6()
    {
        Basket _basket = new Basket();

        _basket.AddBagel(new Bagel(BagelType.Onion));
        _basket.AddBagel(new Bagel(BagelType.Onion, BagelFilling.Bacon));
        _basket.AddBagel(new Bagel(BagelType.Plain, BagelFilling.Bacon));

        double result = _basket.GetBasketTotal();

        result = Math.Round(result, 2);
        Assert.AreEqual(result, 1.61);
    }

    [Test]
    public void Test7()
    {
        double result = Inventory.CheckBagelPrice(new Bagel(BagelType.Onion, BagelFilling.Bacon));

        result = Math.Round(result, 2);
        Assert.AreEqual(result, 0.61);
    }

    [Test]
    public void Test8()
    {
        double result = Inventory.CheckFillingPrice(BagelFilling.Bacon);

        result = Math.Round(result, 2);
        Assert.AreEqual(result, 0.12);
    }

    [Test]
    public void Test9()
    {
        Basket basket = new Basket(16);

        for (int i = 0; i < 13; i++)
        {
            basket.AddBagel(new Bagel());
        }

        basket.AddCoffee(new Coffee());

        double sum = basket.GetBasketTotal();
        sum = Math.Round(sum, 2);
        Assert.AreEqual(5.24, sum);

    }
}