using exercise.main.Classes;
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

        Product bagelOnion = new Product("BGLO", 10, "Bagel", "Onion");
        Product bagelPlain = new Product("BGLP", 10, "Bagel", "Plain");
        Product bagelEverything = new Product("BGLE", 10, "Bagel", "Everything");

        _inventory = new Inventory();
        _inventory.Add(bagelOnion);
        _inventory.Add(bagelPlain);
        _inventory.Add(bagelEverything);

        _basket = new Basket();

        _basket.Add(bagelOnion);
        _basket.Add(bagelPlain);
        _basket.Add(bagelEverything);

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
        Product bagelOnion = new Product("BGLO", 10, "Bagel", "Onion");
        

        // act
        _basket.Add(bagelOnion);

        // assert
        Assert.That(_basket.GetItems().Count, Is.EqualTo(4));
    }
}