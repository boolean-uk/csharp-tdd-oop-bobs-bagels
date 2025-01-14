using exercise.main;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestAddingToBasket()
    {
        Person person = new Customer();
        Basket basket = new Basket(10,person);
        //Product product=basket.ChooseProduct();
        Product product = new Coffee("COFB", 0.99m, "coffee", "black");
        basket.AddToBasket(product);
        int result = basket.FindBasketSize();
        int expected = 1;



        Assert.That(result == expected);
    }

    [Test]
    public void TestRemovingFromBasket()
    {
        Person person = new Customer();
        Basket basket = new Basket(10,person);
        //Product product=basket.ChooseProduct();
        Product product = new Coffee("COFB", 0.99m, "coffee", "black");
        Product product2 = new Coffee("COFB", 0.99m, "coffee", "black");
        Product product3 = new Coffee("COFB", 0.99m, "coffee", "black");
        basket.AddToBasket(product);
        basket.AddToBasket(product2);
        basket.AddToBasket(product3);

        string result= basket.RemoveFromBasket(product);
        String expected = "product is succesfully removed from basket";

        int resultSize = basket.FindBasketSize();
        int expectedSize = 2;



        Assert.That(result == expected && expectedSize == resultSize);
    }
    [Test]
    public void TestAddingToMuchToBasket()
    {
        Person person = new Customer();
        Basket basket = new Basket(2,person);
        //Product product=basket.ChooseProduct();
        Product product = new Coffee("COFB", 0.99m, "coffee", "black");
        Product product1 = new Coffee("COFB", 0.99m, "coffee", "black");
        Product product2 = new Coffee("COFB", 0.99m, "coffee", "black");
        Product product3 = new Coffee("COFB", 0.99m, "coffee", "black");
        basket.AddToBasket(product);
        basket.AddToBasket(product1);
        basket.AddToBasket(product2);
        basket.AddToBasket(product3);
        int result = basket.FindBasketSize();
        int expected = 2;



        Assert.That(result == expected);
    }

    [Test]
    public void TestExpansionByManager()
    {
        Person person = new Manager();
        Basket basket = new Basket(2, person);
        //Product product=basket.ChooseProduct();
      
        Product product = new Coffee("COFB", 0.99m, "coffee", "black");
        Product product1 = new Coffee("COFB", 0.99m, "coffee", "black");
        Product product2 = new Coffee("COFB", 0.99m, "coffee", "black");
        Product product3 = new Coffee("COFB", 0.99m, "coffee", "black");
        basket.AddToBasket(product);
        basket.AddToBasket(product1);
        basket.ExpandBaskets(4);
        basket.AddToBasket(product2);
        basket.AddToBasket(product3);
        int result = basket.FindBasketSize();
        int expected = 4;



        Assert.That(result == expected);

    }

    [Test]
    public void TestExpansionNotByManager()
    {
        Person person = new Customer();
        Basket basket = new Basket(2, person);
        //Product product=basket.ChooseProduct();
      
        Product product = new Coffee("COFB", 0.99m, "coffee", "black");
        Product product1 = new Coffee("COFB", 0.99m, "coffee", "black");
        Product product2 = new Coffee("COFB", 0.99m, "coffee", "black");
        Product product3 = new Coffee("COFB", 0.99m, "coffee", "black");
        basket.AddToBasket(product);
        basket.AddToBasket(product1);
        basket.ExpandBaskets(4);
        basket.AddToBasket(product2);
        basket.AddToBasket(product3);
        int result = basket.FindBasketSize();
        int expected = 2;



        Assert.That(result == expected);

    }
    [Test]
    public void TestTotalCostBycustomer()
    {
        Person person = new Customer();
        Basket basket = new Basket(10,person);
        //Product product=basket.ChooseProduct();
        
        Product product = new Bagel("BGLO", 0.49m, "bagel", "onion",null);
        Product product1 = new Coffee("COFB", 0.99m, "coffee", "black");
        Product product2 = new Coffee("COFB", 0.99m, "coffee", "black");
        Product product3 = new Coffee("COFB", 0.99m, "coffee", "black");
        basket.AddToBasket(product);
        basket.AddToBasket(product1);
        basket.AddToBasket(product2);
        basket.AddToBasket(product3);
        decimal result = basket.TotalCost();
        decimal expected = 2.97m+0.49m;



        Assert.That(result == expected);
    }

    [Test]
    public void TestAddBagelWithFilling()
    {
        Person person = new Customer();
        Basket basket = new Basket(4, person);
        Product bagewithnofilling=new Bagel("BGLO",0.49m,"bagel","onion",null);
        Filling filling = new Filling("FILB", 0.12m, "filling", "bacon");
        Product bagewithfilling = new Bagel("BGLS", 0.49m, "bagel", "sesame", filling);
        basket.AddToBasket(bagewithnofilling);
        basket.AddToBasket(bagewithfilling);
        decimal result = basket.TotalCost();
        decimal expected = 1.10m;
        Assert.That(result == expected);    




    }

    

    }