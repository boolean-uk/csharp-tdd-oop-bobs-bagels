namespace exercise.tests;
using exercise.main;

[TestFixture]
public class BasketTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddItemTest()
    {

        Bagel bagel = new Bagel("BGLO", 0.49, "Bagel", "Onion");
        Coffee coffee = new Coffee("COFB", 0.99, "Coffee", "Black");
        Filling filling = new Filling("FILB", 0.12, "Filling", "Bacon");
        Bagel bagel1 = new Bagel("BGLP", 0.39, "Bagel", "Plain");
        Basket basket = new Basket(3);

        bool added1 = basket.AddItem(bagel); 
        bool added2 = basket.AddItem(coffee); 
        bool added3 = basket.AddItem(filling); 
        bool added4 = basket.AddItem(bagel1); 

        Assert.That(added1, Is.True);
        Assert.That(added2, Is.True);
        Assert.That(added3, Is.True);
        Assert.That(added4, Is.False);
    }

    [Test]
    public void RemoveItemTest()
    {

        Bagel bagel = new Bagel("BGLO", 0.49, "Bagel", "Onion");
        Coffee coffee = new Coffee("COFB", 0.99, "Coffee", "Black");
        Filling filling = new Filling("FILB", 0.12, "Filling", "Bacon");
        Bagel bagel1 = new Bagel("BGLP", 0.39, "Bagel", "Plain");
        Basket basket = new Basket(4);

        basket.AddItem(bagel);
        basket.AddItem(coffee);
        basket.AddItem(filling);

        bool removed1 = basket.RemoveItem(bagel);
        bool removed2 = basket.RemoveItem(coffee);
        bool removed3 = basket.RemoveItem(filling);
        bool removed4 = basket.RemoveItem(bagel1);

        Assert.That(removed1, Is.True);
        Assert.That(removed2, Is.True);
        Assert.That(removed3, Is.True);
        Assert.That(removed4, Is.False);
    }

    [Test]
    public void GetPriceTest()
    {
        Bagel bagel = new Bagel("BGLO", 0.49, "Bagel", "Onion");
        Coffee coffee = new Coffee("COFB", 0.99, "Coffee", "Black");
        Filling filling = new Filling("FILB", 0.12, "Filling", "Bacon");
        Bagel bagel1 = new Bagel("BGLP", 0.39, "Bagel", "Plain");
        Basket basket = new Basket(4);

        double price1 = basket.GetPrice(bagel);
        double price2 = basket.GetPrice(coffee);
        double price3 = basket.GetPrice(filling);
        double price4 = basket.GetPrice(bagel1);

        double actual1 = 0.49;
        double actual2 = 0.99;
        double actual3 = 0.12;
        double actual4 = 0.39;

        Assert.That(price1 == actual1);
        Assert.That(price2 == actual2);
        Assert.That(price3 == actual3);
        Assert.That(price4 == actual4);

    }
}