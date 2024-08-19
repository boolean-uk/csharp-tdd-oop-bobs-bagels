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
    //test menu check verified working
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

    private Customer addBagel(Customer customer, int amount, string type)
    {
        for (int i = 0; i < amount; i++) { customer.GetBagelStore().getManager().getProduct(type, customer); }
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
        customer = addBagel(customer, 1, "BGLP");
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
        customer = addBagel(customer, 4, "BGLP"); //standard capacity is 3

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

        customer = addBagel(customer, 4, "BGLP");

        Assert.That(customer.checkBasketContent().Count == 3);

        customer.GetBagelStore().getManager().changeBasketCapacity(5);

        customer = addBagel(customer, 1, "BGLP");

        Assert.That(customer.checkBasketContent().Count == 3);
        Assert.That(customer.checkBasketCapacity() == 3);


    }

    [Test]
    public void changeBasketCapacityWithNewBasketTest()
    {
        Customer customer = getCustomerAndBasket();
        int basketCapacity = customer.checkBasketCapacity();

        customer = addBagel(customer, 4, "BGLP");

        Assert.That(customer.checkBasketContent().Count == 3);

        customer.GetBagelStore().getManager().changeBasketCapacity(5);

        customer.grabBasket();

        customer = addBagel(customer, 5, "BGLP");

        Assert.That(customer.checkBasketContent().Count == 5);
        Assert.That(customer.checkBasketCapacity() == 5);
    }

    [Test]
    public void checkMenuTest()
    {
        Customer customer = getCustomerAndBasket();
        foreach (var product in customer.checkMenu())
        {
            for (int i = 0; i < product.getVariants().Length; i++)
            {
                Console.WriteLine(product.getVariants()[i]);
            }

        }
        Assert.Pass();
    }

    [Test]
    public void checkBasketTotalCostTest() //TODO insert gettotalcost method insted of wth this is
    {
        Customer customer = getCustomerAndBasket();
        bool productAdded = customer.addProduct("BGLP");

        List<Product> products = customer.checkBasketContent();
        
        float totalCost = 0;

        foreach (var product in products) { totalCost += product.price; }

        Assert.That (totalCost == 0.39f);

        productAdded = customer.addProduct("BGLP");
        productAdded = customer.addProduct("BGLP");

        products = customer.checkBasketContent();
        totalCost = 0;
        foreach (var product in products) { totalCost += product.price; }

        Assert.That(totalCost == 0.39f * 3);
    }

    [Test]
    public void CheckDiscountFunctionalityTest()
    {
        Customer customer = getCustomerAndBasket();
        customer.GetBagelStore().getManager().changeBasketCapacity(20);
        customer.grabBasket();
        customer = addBagel(customer, 12, "BGLP");
        customer.addProduct("FILX");

        customer = addBagel(customer, 6, "BGLO");

        customer.checkout();

        Assert.Pass();
    }

    [Test]
    public void CheckDiscountFunctionalityTwoTest()
    {
        Customer customer = getCustomerAndBasket();
        customer.GetBagelStore().getManager().changeBasketCapacity(20);
        customer.grabBasket();
        customer = addBagel(customer, 1, "BGLP");

        customer = addBagel(customer, 1, "COFB");

        customer = addBagel(customer, 12, "BGLP");
        customer.addProduct("FILX");

        customer = addBagel(customer, 6, "BGLO");

        customer.checkout();

        Assert.Pass();
    }

    [Test]
    public void CheckDiscountFunctionalityCheckoutFullTest()
    {
        Customer customer = getCustomerAndBasket();
        customer.GetBagelStore().getManager().changeBasketCapacity(20);
        customer.grabBasket();

        customer = addBagel(customer, 18, "BGLP");

        customer.checkout();

        Assert.Pass();
    }
}