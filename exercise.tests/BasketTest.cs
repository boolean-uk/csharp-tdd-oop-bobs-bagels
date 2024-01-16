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
        Product product1 = new Product("BGLO", 0.154f, ProductType.bagel, "Onion");
        basket.AddToBasket(product1);
        Assert.That(basket.Products.Count != 0);
    }

    [Test]
    public void TestAddIfBasketIsFull()
    {
        Basket basket = new Basket(4);
        Product product1 = new Product("BGLO", 0.154f, ProductType.bagel, "Onion");
        Product product2 = new Product("BGLP", 0.124f, ProductType.bagel, "Plain");
        Product product3 = new Product("BGLE", 0.134f, ProductType.bagel, "Everything");
        Product product4 = new Product("BGLO", 0.14f, ProductType.bagel, "Onion");
        Product product5 = new Product("BGLO", 0.14f, ProductType.coffee, "Black");

        basket.AddToBasket(product1);
        basket.AddToBasket(product2);
        basket.AddToBasket(product3);
        basket.AddToBasket(product4);


        var ex = Assert.Throws<ArgumentException>(() => basket.AddToBasket(product5));
        Assert.That(ex.Message == "No more room in basket");

    }

    [Test]

    public void TestRemove()
    {
        Basket basket = new Basket(4);

        Product product1 = new Product("BGLO", 0.154f, ProductType.bagel, "Onion");
        Product product2 = new Product("BGLP", 0.124f, ProductType.bagel, "Plain");
        Product product3 = new Product("BGLE", 0.134f, ProductType.bagel, "Everything");

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

        Product product1 = new Product("BGLO", 0.154f, ProductType.bagel, "Onion");
        Product product2 = new Product("BGLP", 0.124f, ProductType.bagel, "Plain");
        Product product3 = new Product("BGLE", 0.134f, ProductType.bagel, "Everything");

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

}