using exercise.main;
using NUnit.Framework.Interfaces;

namespace exercise.tests;

public class BobsBagelTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(3, true)]
    [TestCase(2, false)]
    public void TestAddItemToBasken(int basketCapacity, bool expectedResult)
    {
        Basket basket = new Basket(basketCapacity);
        Item item1 = new Item("BGLO", 0.49f, "Bagel", "Onion");
        Item item2 = new Item("BGLP", 0.39f, "Bagel", "Plain");
        Item item3 = new Item("BGLE", 0.49f, "Bagel", "Everything");
        basket.AddItem(item1);
        basket.AddItem(item2);

        bool actualResult = basket.AddItem(item3);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [TestCase(true)]
    [TestCase(false)]
    public void TestRemoveItemFromBasket(bool expectedResult)
    {
        Basket basket = new Basket();
        Item item1 = new Item("BGLO", 0.49f, "Bagel", "Onion");
        Item item2 = new Item("BGLP", 0.39f, "Bagel", "Plain");
        basket.AddItem(item1);
        if (expectedResult)
            basket.AddItem(item2);

        bool actualResult = basket.RemoveItem(item2.SKU);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void TestSumOfItemsCostsInBasket()
    {
        Basket basket = new Basket();
        Item item1 = new Item("BGLO", 0.49f, "Bagel", "Onion");
        Item item2 = new Item("BGLP", 0.39f, "Bagel", "Plain");
        Item item3 = new Item("BGLP", 0.39f, "Bagel", "Plain");
        basket.AddItem(item1);
        basket.AddItem(item2);
        basket.AddItem(item3);
        float expectedResult = 1.27f;

        float actualResult = basket.SumOfItemCosts();

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [TestCase(Role.Manager, 2, true)]
    [TestCase(Role.Manager, 1, false)]
    [TestCase(Role.Customer, 2, false)]
    public void TestChangeBasketCapacity(Role userRole, int basketCapacity, bool expectedResult)
    {
        Basket basket = new Basket(3);
        User customer = new User(userRole);
        Item item1 = new Item("BGLO", 0.49f, "Bagel", "Onion");
        Item item2 = new Item("BGLP", 0.39f, "Bagel", "Plain");
        basket.AddItem(item1);
        basket.AddItem(item2);

        bool actualResult = basket.ChangeCapacity(basketCapacity, customer);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}