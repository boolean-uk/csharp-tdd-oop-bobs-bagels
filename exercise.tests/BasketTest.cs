using System.Reflection.Emit;
using exercise.main;

namespace main.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {


    }

    [Test]
    public void TestAdd()
    {
        Basket basket = new Basket(4);
        Product product1 = new Product("BGLO", 0.154m, ProductType.bagel, "Onion");
        basket.AddToBasket(product1);
        Assert.That(basket.Products.Count != 0);
    }

    [Test]
    public void TestAddIfBasketIsFull()
    {
        Basket basket = new Basket(4);
        Product product1 = new Product("BGLO", 0.154m, ProductType.bagel, "Onion");
        Product product2 = new Product("BGLP", 0.124m, ProductType.bagel, "Plain");
        Product product3 = new Product("BGLE", 0.134m, ProductType.bagel, "Everything");
        Product product4 = new Product("BGLO", 0.14m, ProductType.bagel, "Onion");
        Product product5 = new Product("BGLO", 0.14m, ProductType.coffee, "Black");

        basket.AddToBasket(product1);
        basket.AddToBasket(product2);
        basket.AddToBasket(product3);
        basket.AddToBasket(product4);


        var ex = Assert.Throws<ArgumentException>(() => basket.AddToBasket(product5));
        Assert.That(ex.Message == "No more room in basket");

    }

    [Test]
    public void TestAddIfItemDoesNotExist()
    {
        Basket basket = new Basket(4);
        Product newProduct = new Product("ABCD", 1.5m, ProductType.bagel, "Onion");

        var ex = Assert.Throws<ArgumentException>(() => basket.AddToBasket(newProduct));
        Assert.That(ex.Message == "Product does not exist in inventory");
    }

    [Test]

    public void TestRemove()
    {
        Basket basket = new Basket(4);

        Product product1 = new Product("BGLO", 0.154m, ProductType.bagel, "Onion");
        Product product2 = new Product("BGLP", 0.124m, ProductType.bagel, "Plain");
        Product product3 = new Product("BGLE", 0.134m, ProductType.bagel, "Everything");

        basket.AddToBasket(product1);
        basket.AddToBasket(product2);
        basket.AddToBasket(product3);

        basket.RemoveFromBasket(product3);

        Assert.That(basket.Products.Count, Is.EqualTo(2));
    }
    [Test]
    public void RemoveFromBasketIfItemDoesNotExist()
    {
        Basket basket = new Basket(4);

        Product product1 = new Product("BGLO", 0.154m, ProductType.bagel, "Onion");
        Product product2 = new Product("BGLP", 0.124m, ProductType.bagel, "Plain");
        Product product3 = new Product("BGLE", 0.134m, ProductType.bagel, "Everything");

        basket.AddToBasket(product1);
        basket.AddToBasket(product2);


        var ex = Assert.Throws<ArgumentException>(() => basket.RemoveFromBasket(product3));
        Assert.That(ex.Message == "No bagel here matches that request");
    }

    [Test]
    public void TestExpandBasket()
    {
        Basket basket = new Basket(4);
        basket.ExpandBasket(6);

        Assert.That(basket.BasketSize == 10);
    }

    [Test]
    public void TestGetTotal()
    {
        Basket basket = new Basket(4);

        Product product1 = new Product("BGLO", 0.154m, ProductType.bagel, "Onion");
        Product product2 = new Product("BGLP", 0.124m, ProductType.bagel, "Plain");
        Product product3 = new Product("BGLE", 0.134m, ProductType.bagel, "Everything");

        basket.AddToBasket(product1);
        basket.AddToBasket(product2);
        basket.AddToBasket(product3);

        basket.CalculateTotal();

        Assert.That(basket.Total == product1.Price + product2.Price + product3.Price);

    }

    [Test]
    public void TestAddFilling()
    {
        Basket basket = new Basket(4);

        Bagel bagel = new Bagel("BGLO", 0.154m, ProductType.bagel, "Onion");

        Filling filling1 = new Filling("FILS", 0.12m, ProductType.filling, "Smoked Salmon");

        basket.AddToBasket(bagel);
        basket.AddFilling(bagel, filling1);

        Assert.That(basket.Products.Count() == 2);
    }

    [Test]
    public void TestDiscount6x()
    {
        Basket basket = new Basket(10);

        Bagel bagel = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel2 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel3 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel4 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel5 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel6 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel7 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");

        basket.AddToBasket(bagel);
        basket.AddToBasket(bagel2);
        basket.AddToBasket(bagel3);
        basket.AddToBasket(bagel4);
        basket.AddToBasket(bagel5);
        basket.AddToBasket(bagel6);
        basket.AddToBasket(bagel7);
        
        basket.CalculateTotal();
        
        Assert.That(basket.Total == 2.49m + 0.49m);
    }

    [Test]
    public void TestDiscount12x()
    {
        Basket basket = new Basket(20);

        Bagel bagel = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel2 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel3 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel4 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel5 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel6 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel7 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel8 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel9 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel10 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel11 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel12 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel13 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel14 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");

        basket.AddToBasket(bagel);
        basket.AddToBasket(bagel2);
        basket.AddToBasket(bagel3);
        basket.AddToBasket(bagel4);
        basket.AddToBasket(bagel5);
        basket.AddToBasket(bagel6);
        basket.AddToBasket(bagel7);
        basket.AddToBasket(bagel8);
        basket.AddToBasket(bagel9);
        basket.AddToBasket(bagel10);
        basket.AddToBasket(bagel11);
        basket.AddToBasket(bagel12);
        basket.AddToBasket(bagel13);
        basket.AddToBasket(bagel14);



        basket.CalculateTotal();


        Assert.That(Math.Round(3.99m + bagel13.Price + bagel14.Price), Is.EqualTo(Math.Round(basket.Total)));
    }
    [Test]
    public void TestDiscountWithOtherItems()
    {
        Basket basket = new Basket(20);

        Bagel bagel = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel2 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel3 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel4 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel5 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel6 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");


        Coffee coffee = new Coffee("COFB", 0.99m, ProductType.coffee, "Black");

        basket.AddToBasket(bagel);
        basket.AddToBasket(bagel2);
        basket.AddToBasket(bagel3);
        basket.AddToBasket(bagel4);
        basket.AddToBasket(bagel5);
        basket.AddToBasket(bagel6);
        basket.AddToBasket(coffee);

        basket.CalculateTotal();

        Assert.That(basket.Total == (2.49m + 0.99m));
    }
    [Test]
    public void TestDiscountWithFillings()
    {
        Basket basket = new Basket(20);

        Bagel bagel = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel2 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel3 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel4 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel5 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Bagel bagel6 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");


        basket.AddToBasket(bagel);
        basket.AddToBasket(bagel2);
        basket.AddToBasket(bagel3);
        basket.AddToBasket(bagel4);
        basket.AddToBasket(bagel5);
        basket.AddToBasket(bagel6);


        basket.AddFilling(bagel, new Filling("FILX", 0.12m, ProductType.filling, "Cream Cheese"));
        basket.AddFilling(bagel, new Filling("FILH", 0.12m, ProductType.filling, "Ham"));

        basket.CalculateTotal();

        Assert.That(basket.Total == (2.49m + 0.24m));
    }

    [Test]
    public void TestCoffeeDiscount()
    {
        Basket basket = new Basket(10);
        Bagel bagel = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
        Coffee coffee = new Coffee("COFB", 0.99m, ProductType.coffee, "Black");

        basket.AddToBasket(bagel);
        basket.AddToBasket(coffee);

        basket.CalculateTotal();

        Assert.That(basket.Total == 1.25m);

    }

}