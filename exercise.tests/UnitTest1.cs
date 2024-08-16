using exercise.main;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        BagelStore bagelStore = new BagelStore();
        Customer customer = new Customer("Jeff", "Jeffersson");
        customer.grabBasket();
    }

    [Test]
    public void AddOneProductToBasketTest()
    {
        BagelStore bagelStore = new BagelStore();
        Customer customer = new Customer("Jeff", "Jeffersson");
        customer.grabBasket();

        int basketCount = customer.checkBasketContent().Count();

        Assert.That(basketCount == 0);

        bool productAdded = customer.addProduct("BGLP");
        basketCount = customer.checkBasketContent().Count();

        Assert.IsTrue(productAdded);
        Assert.That(basketCount == 1);

    }

    [Test]
    public void AddMultipleProductsToBasketTest()
    {
        BagelStore bagelStore = new BagelStore();
        Customer customer = new Customer("Jeff", "Jeffersson");
        customer.grabBasket();

        int basketCount = customer.checkBasketContent().Count();

        Assert.That(basketCount == 0);

        bool productAdded = customer.addProduct("BGLP");
        basketCount = customer.checkBasketContent().Count();

        Assert.IsTrue(productAdded);
        Assert.That(basketCount == 1);

        productAdded = customer.addProduct("BGLP");
        basketCount = customer.checkBasketContent().Count();

        Assert.IsTrue(productAdded);
        Assert.That(basketCount == 2);

        productAdded = customer.addProduct("BGLP");
        basketCount = customer.checkBasketContent().Count();

        Assert.IsTrue(productAdded);
        Assert.That(basketCount == 3);
    }

    [Test]
    public void RemoveOneItemFromBasketTest()
    {
        BagelStore bagelStore = new BagelStore();
        Customer customer = new Customer("Jeff", "Jeffersson");
        customer.grabBasket();

        int basketCount = customer.checkBasketContent().Count();

        Assert.That(basketCount == 0);

        bool productAdded = customer.addProduct("BGLP");
        basketCount = customer.checkBasketContent().Count();

        Assert.IsTrue(productAdded);
        Assert.That(basketCount == 1);

        bool productRemoved = customer.removeProduct("BGLP");
        basketCount = customer.checkBasketContent().Count();

        Assert.IsTrue(productRemoved);
        Assert.That(basketCount == 0);
    }

    [Test]
    public void Test4()
    {
        Assert.Pass();
    }
}