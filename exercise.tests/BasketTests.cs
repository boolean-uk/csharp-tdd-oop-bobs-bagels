using exercise.main;


namespace exercise.tests;

public class BasketTests
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void TestAddItem()
    {
        Basket basket = new Basket(5);
        Item bagel = new Bagel("BGLO", 0.49d, "Bagel", "Onion");
        Item coffee = new Coffee("COFB", 0.99d, "Coffee", "Black");
        Item filling = new Filling("FILB", 0.12d, "Filling", "Bacon");

        bool addedBagel = basket.AddItem(bagel);
        bool addedCoffee = basket.AddItem(coffee);
        bool addedFilling = basket.AddItem(filling);
        Assert.That(addedBagel == addedCoffee ==  addedFilling, Is.EqualTo(true));
        Assert.That(basket.Items.Count(), Is.EqualTo(3));

    }

    [Test]
    public void TestRemoveItem()
    {
        Basket basket = new Basket(5);
        Item bagel = new Bagel("BGLO", 0.49d, "Bagel", "Onion");
        Item coffee = new Coffee("COFB", 0.99d, "Coffee", "Black");
        Item filling = new Filling("FILB", 0.12d, "Filling", "Bacon");

        basket.AddItem(bagel);
        basket.AddItem(coffee);
        basket.AddItem(filling);

        bool removedBagel = basket.RemoveItem(bagel);

        Assert.That(removedBagel, Is.EqualTo(true));
        Assert.That(basket.Items.Count() == 2);

    }

    [Test]
    public void TestExtendBasket()
    {
        Basket basket = new Basket(3);

        Assert.That(basket.ExtendBasket(-10) == false);
        Assert.That(basket.ExtendBasket(0) == false);

        Item bagel1 = new Bagel("BGLO", 0.49d, "Bagel", "Onion");
        Item bagel2 = new Bagel("BGLP", 0.39d, "Bagel", "Plain");
        Item coffee1 = new Coffee("COFW", 1.19d, "Coffee", "White");
        Item coffee2 = new Coffee("COFB", 0.99d, "Coffee", "Black");

        Item coffee3 = new Coffee("COFB", 0.99d, "Coffee", "Black");

        basket.AddItem(bagel1);
        basket.AddItem(bagel2);
        basket.AddItem(coffee1);
        basket.AddItem(coffee2);

        int bagelCount = basket.Items.Count();
        Assert.That(basket.ExtendBasket(bagelCount - 1) == false);

        // Checks that capacity cannot be set to the same as it was
        Assert.That(basket.ExtendBasket(basket.Capacity) == false);

        // Checks that new bagels can be added after extending capacity
        basket.ExtendBasket(6);
        Assert.That(basket.AddItem(coffee3) == true);

    }


    [Test]
    public void TestCheckBasketCost()
    {
        Basket basket = new Basket(5);
        Item bagel1 = new Bagel("BGLO", 0.49d, "Bagel", "Onion");
        Item bagel2 = new Bagel("BGLP", 0.39d, "Bagel", "Plain");
        Item coffee1 = new Coffee("COFW", 1.19d, "Coffee", "White");
        Item coffee2 = new Coffee("COFB", 0.99d, "Coffee", "Black");

        basket.AddItem(bagel1);
        basket.AddItem(bagel2);
        basket.AddItem(coffee1);
        basket.AddItem(coffee2);

        double cost = basket.CheckBasketCost();

        Assert.That(Math.Round(cost, 2), Is.EqualTo(3.06d));

    }
}