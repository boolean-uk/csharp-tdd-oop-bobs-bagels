using exercise.main.Classes;
using exercise.main.Enums;
using NUnit.Framework.Interfaces;

namespace exercise.tests;

public class Tests
{
    private Order _order;
    private Inventory _inventory;
    private Basket _basket;

    [SetUp]
    public void Setup()
    {
        _order = new Order();

        Product bagelOnion = new Product("BGLO", 10, ProductType.Bagel, "Onion");
        Product bagelPlain = new Product("BGLP", 10, ProductType.Bagel, "Plain");
        Product bagelEverything = new Product("BGLE", 10, ProductType.Bagel, "Everything");

        _inventory = new Inventory();
        _inventory.Add(bagelOnion, 100);
        _inventory.Add(bagelPlain, 100);
        _inventory.Add(bagelEverything, 100);

        _basket = new Basket();

        _basket.Add(bagelOnion, 1);
        _basket.Add(bagelPlain, 3);
        _basket.Add(bagelEverything, 5);

        List<BasketItem> items = _basket.SubmitOrder();

        foreach (BasketItem item in items) 
        {
            OrderLine orderline = new OrderLine(item);
            _order.AddLine(orderline);
        }

    }

    [Test]
    public void TestAddBagel()
    {
        // arrange
        Product bagelGarlic = new Product("BGLG", 10, ProductType.Bagel, "Garlic");
        

        // act
        _basket.Add(bagelGarlic, 2);

        // assert
        Assert.That(_basket.GetItems().Count, Is.EqualTo(4));
    }

    [Test]
    public void TestAddDuplicateBagels()
    {
        // arrange
        Product bagelGarlic = new Product("BGLG", 10, ProductType.Bagel, "Garlic");


        // act
        _basket.Add(bagelGarlic, 2);
        _basket.Add(bagelGarlic, 3);

        // assert
        Assert.That(_basket.GetItems().Count, Is.EqualTo(4));
        Assert.That(_basket.GetItemBySKU("BGLG").Amount, Is.EqualTo(5));
    }

    [Test]
    public void TestRemoveBagel()
    {
        // arrange


        // act
        _basket.Remove("BGLO");

        // assert
        Assert.That(_basket.GetItems().Count, Is.EqualTo(2));
    }

    [Test]
    public void TestChangeCapacity()
    {
        // arrange


        // act
        _basket.Capacity = 20;

        // assert
        Assert.That(_basket.Capacity, Is.EqualTo(20));
    }

    [Test]
    public void TestBasketFull()
    {
        // arrange
        Product bagelGarlic = new Product("BGLG", 10, ProductType.Bagel, "Garlic");


        // act
        _basket.Capacity = 3;
        bool added = _basket.Add(bagelGarlic, 2);

        // assert
        Assert.That(added, Is.False);
    }

    [Test]
    public void TestCheckIfProductExistsInBasket()
    {
        // arrange
        Product bagelGarlic = new Product("BGLG", 10, ProductType.Bagel, "Garlic");

        // act
        bool exists = _basket.CheckIfProductExistsInBasket(bagelGarlic);

        // assert
        Assert.That(exists, Is.False);
    }

    [Test]
    public void TestCheckTotalCostOfItemsInBasket()
    {
        // arrange


        // act
        double totalCost = _basket.GetTotal();

        // assert
        Assert.That(totalCost, Is.EqualTo(30));
    }
    [Test]
    public void TestCheckCostOfBagel()
    {
        // arrange
        Product bagelGarlic = new Product("BGLG", 10, ProductType.Bagel, "Garlic");

        // act
        double cost = bagelGarlic.GetPrice();

        // assert
        Assert.That(cost, Is.EqualTo(10));
    }

    [Test]
    public void TestAddPromotionToProduct()
    {
        // arrange
        Product bagelGarlic = new Product("BGLG", 10, ProductType.Bagel, "Garlic");
        double discount = 0.3;

        // act
        bagelGarlic.AddDiscount(discount);
        double cost = bagelGarlic.GetPrice();

        // assert
        Assert.That(cost, Is.EqualTo(7));
    }

    [Test]
    public void TestCheckStockOfProduct()
    {
        // arrange
        int amount = _inventory.GetStock("BGLO");

        // act


        // assert
        Assert.That(amount, Is.EqualTo(100));
    }

    [Test]
    public void TestAddAndRemoveStock()
    {
        // arrange
        Product bagelGarlic = new Product("BGLG", 10, ProductType.Bagel, "Garlic");
        Product bagelPlain = new Product("BGLP", 10, ProductType.Bagel, "Plain");

        // act
        _inventory.Remove("BGLO", 10);
        _inventory.Add(bagelGarlic, 10);
        _inventory.Add(bagelPlain, 10);

        int bgloAmount = _inventory.GetStock("BGLO");
        int bglgAmount = _inventory.GetStock("BGLG");
        int bglpAmount = _inventory.GetStock("BGLP");

        // assert
        Assert.That(bgloAmount, Is.EqualTo(90));
        Assert.That(bglgAmount, Is.EqualTo(10));
        Assert.That(bglpAmount, Is.EqualTo(110));
    }
}