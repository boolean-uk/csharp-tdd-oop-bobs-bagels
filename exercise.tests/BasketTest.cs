namespace exercise.tests;
using exercise.main;

[TestFixture]
public class BasketTest
{
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
        basket.AddItem(bagel);
        basket.AddItem(coffee);
        basket.AddItem(filling);
        basket.AddItem(bagel1);

        double price1 = basket.GetPrice();

        double actual1 = 0.49 + 0.99 + 0.12 + 0.39;
        actual1 = Math.Round(actual1, 2);


        Assert.That(price1, Is.EqualTo(actual1));


    }

    [Test]
    public void ChangeCapacityTest()
    {
        Person manager = new Person(1, true);
        Person customer = new Person(1, false);

        Basket basket = new Basket(4);

        bool changed1 = basket.ChangeCapacity(manager, 5);
        bool changed2 = basket.ChangeCapacity(customer, 5);

        Assert.That(changed1 == true);
        Assert.That(changed2 == false);
    }

    [Test]
    public void AddDiscountTest()
    {
        Bagel bagel1 = new Bagel("BGLE", 0.49, "Bagel", "Everything");

        Basket basket = new Basket(6);

        basket.AddItem(bagel1);
        basket.AddItem(bagel1);
        basket.AddItem(bagel1);
        basket.AddItem(bagel1);
        basket.AddItem(bagel1);
        basket.AddItem(bagel1);

        Basket basket1 = new Basket(12);

        basket1.AddItem(bagel1);
        basket1.AddItem(bagel1);
        basket1.AddItem(bagel1);
        basket1.AddItem(bagel1);
        basket1.AddItem(bagel1);
        basket1.AddItem(bagel1); basket1.AddItem(bagel1);
        basket1.AddItem(bagel1);
        basket1.AddItem(bagel1);
        basket1.AddItem(bagel1);
        basket1.AddItem(bagel1);
        basket1.AddItem(bagel1);



        Assert.That(basket.GetPrice, Is.EqualTo(2.49));
        Assert.That(basket1.GetPrice, Is.EqualTo(3.99));
    }
}