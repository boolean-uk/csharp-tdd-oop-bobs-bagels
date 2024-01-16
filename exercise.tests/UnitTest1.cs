using exercise.main.Core;
using exercise.main.Objects.Containers;
using exercise.main.Objects.People;
using exercise.main.Objects.Products;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AlterBasketSizeTest()
    {
        // Alter size test
        Manager manager = new Manager();
        Basket basket = new Basket();
        Bagel bagel = new Bagel("", 5, "");

        Assert.That(50, Is.EqualTo(basket.BasketSize));

        manager.AlterSize(basket, 20);
        Assert.That(20, Is.EqualTo(basket.BasketSizeMax));

        // Capacity test
        manager.AlterSize(basket, 2);
        Store store = new Store();

        Assert.IsTrue(basket.AddProduct(bagel));
        Assert.IsTrue(basket.AddProduct(bagel));
        Assert.IsFalse(basket.AddProduct(bagel));

    }

    [Test]
    public void AddProductTest()
    {
        Basket basket = new Basket();
        Product bagel = new Bagel("", 5, "");
        Filling bagelFilling = new Filling("", 5, "");
        Product bagel1 = new Bagel("", 5, "",bagelFilling);
        Product bagel2 = null;
        Product coffee = new Coffee("", 5, "");


        Assert.IsTrue(basket.AddProduct(bagel));
        Assert.IsTrue(basket.AddProduct(bagel1));
        Assert.IsFalse(basket.AddProduct(bagel2));
        Assert.IsTrue(basket.AddProduct(coffee));
    }

    [Test]
    public void RemoveProudctTest()
    {
        Basket basket = new Basket();
        Product bagel = new Bagel("", 5, "");
        Filling bagelFilling = new Filling("", 5, "");
        Product bagel1 = new Bagel("", 5, "",bagelFilling);
        Product bagel2 = null;
        Product coffee = new Coffee("", 5, "");

        basket.AddProduct(bagel);
        basket.AddProduct(bagel1);

        Assert.IsTrue(basket.RemoveProduct(bagel));
        Assert.IsFalse(basket.RemoveProduct(bagel2));
        Assert.IsFalse(basket.RemoveProduct(coffee));

    }

    [Test]
    public void GetPriceTest()
    {
        Product bagel = new Bagel("", 10, "");
        Bagel bagel1 = new Bagel("", 10, "", new Filling("", 5, ""));
        Basket basket = new Basket();


        Assert.AreEqual(bagel.GetPrice(), 10);
        Assert.AreEqual(bagel1.GetPrice(), 15);

        Assert.IsTrue(basket.AddProduct(bagel));
        Assert.IsTrue(basket.AddProduct(bagel1));
        Assert.AreEqual(basket.GetPriceTotal(), 10);
    }
}