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
        Product product1 = new Product("BGLO", 0.154d, ProductType.bagel, "Onion");
        basket.AddToBasket(product1);
        Assert.That(basket.Products.Count != 0);
    }

    [Test]
    public void TestAddIfBasketIsFull()
    {
        Basket basket = new Basket(4);
        Product product1 = new Product("BGLO", 0.154d, ProductType.bagel, "Onion");
        Product product2 = new Product("BGLP", 0.124d, ProductType.bagel, "Plain");
        Product product3 = new Product("BGLE", 0.134d, ProductType.bagel, "Everything");
        Product product4 = new Product("BGLO", 0.14d, ProductType.bagel, "Onion");
        Product product5 = new Product("BGLO", 0.14d, ProductType.coffee, "Black");

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
        Product newProduct = new Product("ABCD", 1.5, ProductType.bagel, "Onion");

        var ex = Assert.Throws<ArgumentException>(() => basket.AddToBasket(newProduct));
        Assert.That(ex.Message == "Product does not exist in inventory");
    }

    [Test]

    public void TestRemove()
    {
        Basket basket = new Basket(4);

        Product product1 = new Product("BGLO", 0.154d, ProductType.bagel, "Onion");
        Product product2 = new Product("BGLP", 0.124d, ProductType.bagel, "Plain");
        Product product3 = new Product("BGLE", 0.134d, ProductType.bagel, "Everything");

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

        Product product1 = new Product("BGLO", 0.154d, ProductType.bagel, "Onion");
        Product product2 = new Product("BGLP", 0.124d, ProductType.bagel, "Plain");
        Product product3 = new Product("BGLE", 0.134d, ProductType.bagel, "Everything");

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

        Product product1 = new Product("BGLO", 0.154d, ProductType.bagel, "Onion");
        Product product2 = new Product("BGLP", 0.124d, ProductType.bagel, "Plain");
        Product product3 = new Product("BGLE", 0.134d, ProductType.bagel, "Everything");

        basket.AddToBasket(product1);
        basket.AddToBasket(product2);
        basket.AddToBasket(product3);

        Assert.That(basket.DisplayTotal() == product1.Price + product2.Price + product3.Price);

    }

    [Test]
    public void TestAddFilling()
    {
        Basket basket = new Basket(4);

        Bagel bagel = new Bagel("BGLO", 0.154d, ProductType.bagel, "Onion");

        Filling filling1 = new Filling("FILS", 0.12d, ProductType.filling, "Smoked Salmon");

        basket.AddFilling(bagel, filling1);

        Assert.That(basket.Products.Count() == 2);
    }

}