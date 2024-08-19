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

    //adding products verified working
    //
    //removing products verified working
    //
    //test overflow warning verified working
    //
    //test remove warning verified working
    //
    //test basket capacity change
    //
    //test total cost of basket
    //
    //test menu check
    //
    //change so that fillings are attribute of bagel
    //
    //
    //
    //

    //gives customer without basket
    private Customer getCustomer() { return new Customer("test", "testsson"); }

    //gives customer and instanciated basket
    private Customer getCustomerAndBasket() { Customer customer = new Customer("test", "testsson"); customer.grabBasket(); return customer; }

    private Customer addBagel(Customer customer, int amount)
    {
        for (int i = 0; i < amount; i++) { customer.GetBagelStore().getManager().getProduct("BGLP", customer); }
        return customer;
    }

    private Customer addCoffee(Customer customer, int amount)
    {
        for (int i = 0; i < amount; i++) { customer.GetBagelStore().getManager().getProduct("COFB", customer); }
        return customer;
    }

    private Customer addFilling(Customer customer, int amount)
    {
        for (int i = 0; i < amount; i++) { customer.GetBagelStore().getManager().getProduct("FILB", customer); }
        return customer;
    }

    //good idea?
    private void isAllTrue(bool[] bools)
    {
        foreach (bool b in bools) { Assert.IsTrue(b); }
    }

    [Test]
    public void FunctionsInTestFileTest()
    {
        Customer customer = getCustomerAndBasket();
        customer = addBagel(customer, 1);
        List<Product> products = customer.checkBasketContent();

        Assert.IsTrue(products.Count == 1);
        Assert.That(products.First().SKU == "BGLP");
        Assert.That(products.First().name == "Bagel");
        Assert.That(products.First().variant == "Plain");
        Assert.That(products.First().price == 0.39f);
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
    public void overflowTest()
    {
        Customer customer = getCustomerAndBasket();
        customer = addBagel(customer, 4); //standard capacity is 3

        Assert.That(customer.checkBasketContent().Count == 3);
    }

    [Test]
    public void removeFromEmptyBasketTest()
    {
        Customer customer = getCustomerAndBasket();
        customer.removeProduct("BGLP");

        Assert.That(customer.checkBasketContent().Count == 0);
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

    [Test]//probably works wrongly
    public void changeBasketCapacityWithoutNewBasketTest()
    {
        Customer customer = getCustomerAndBasket();
        int basketCapacity = customer.checkBasketCapacity();

        customer = addBagel(customer, 4);

        Assert.That(customer.checkBasketContent().Count == 3);

        customer.GetBagelStore().getManager().changeBasketCapacity(5);

        customer = addBagel(customer, 1);

        Assert.That(customer.checkBasketContent().Count == 3);
        Assert.That(customer.checkBasketCapacity() == 3);


    }

    [Test]
    public void changeBasketCapacityWithNewBasketTest()
    {
        Customer customer = getCustomerAndBasket();
        int basketCapacity = customer.checkBasketCapacity();

        customer = addBagel(customer, 4);

        Assert.That(customer.checkBasketContent().Count == 3);

        customer.GetBagelStore().getManager().changeBasketCapacity(5);

        customer.grabBasket();

        customer = addBagel(customer, 5);

        Assert.That(customer.checkBasketContent().Count == 5);
        Assert.That(customer.checkBasketCapacity() == 5);
    }

    [Test]
    public void checkMenuTest()
    {
        Assert.Pass();
    }

    [Test]
    public void checkBasketTotalCostTest()
    {
        Assert.Pass();
    }

    [Test]
    public void addFillingsToBagelTest()
    {
        Assert.Pass();
    }
}