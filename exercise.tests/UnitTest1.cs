using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using exercise.main.Inventory;



namespace exercise.tests.Inventory;

public class Tests
{
    Bagel _bagel;
    Item _coffee;
    Filling _filling;

    [SetUp]

    public void Setup()
    {
        _bagel = new Bagel("BGLE", 0.49, main.Inventory.Type.Bagel, "Everything");
        _coffee = new Item("COFB", 0.99, main.Inventory.Type.Coffee, "Black");
        _filling = new Filling("FILE", 0.12, main.Inventory.Type.Filling, "Egg");
    }


    [Test]
    
    public void FirstTest()
    {
        //Testing to see if an item gets added.
        Basket basket = new Basket(20);

        basket.AddItem(_bagel);

        Assert.That(basket.Items.Count() == 1);

        //Doublechecking
        basket.AddItem(_coffee);

        Assert.That(basket.Items.Count() == 2);

        //Triplecheck :)
        basket.AddItem(_filling);

        Assert.That(basket.Items.Count() == 3);


    }
    [Test]
    public void SecondTest() 
    {

        Basket basket = new Basket(10);

        basket.AddItem(_bagel);
        basket.AddItem(_coffee);
        basket.AddItem(_filling);

        basket.RemoveItem(_bagel);

        Assert.That(basket.Items.Count() == 2);
    }

    [Test]
    public void ThirdTest()
    {
        Basket basket = new Basket(2);

        basket.AddItem(_bagel);
        basket.AddItem(_coffee);
        basket.AddItem(_filling);

        Assert.That(basket.Items.Last() != _filling);
    }

    [Test]
    public void FourthTest()
    {
        Basket basket = new Basket(1);

        basket.changeBasketSize(10);

        Assert.That(basket._capacity == 10);
    }

    [Test]
    public void FifthTest()
    {
        Basket basket = new Basket(3);

        basket.AddItem(_bagel);
        basket.AddItem(_coffee);

        bool exists = basket.RemoveItem(_filling);

        Assert.That(exists == false);
    }

    [Test]
    public void SixthTest()
    {
        Basket basket = new Basket(3);

        basket.AddItem(_bagel);
        basket.AddItem(_coffee);
        basket.AddItem(_filling);

        double total = basket.TotalCost();

        Assert.That(total == 1.6d);
    }

    [Test]

    public void SeventhTest()
    {
        Basket basket = new Basket(7);

        basket.AddItem(_bagel);
        basket.AddItem(_coffee);
        basket.AddItem(_filling);

        string price = basket.PriceOfItem(_bagel);

    }
}