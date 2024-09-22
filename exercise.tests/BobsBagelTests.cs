using exercise.main;
using NUnit.Framework.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace exercise.tests;

public class BobsBagelTests
{
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

    [TestCase("BGLO", "BGLO", true)]
    [TestCase("BLGO", "", false)]
    public void TestGetItemFromInventory(string sku, string expectedStringResult, bool expectedBoolResult)
    {
        BobsBagelStore store = new BobsBagelStore();
        store.StockUpInventory();

        Item? actualResult = store.GetItem(sku);

        Assert.That((actualResult != null) == expectedBoolResult);
        if (actualResult != null)
        {
            Assert.That(actualResult.SKU, Is.EqualTo(expectedStringResult));
        }
    }

    [Test]
    public void TestViewInventory()
    {
        BobsBagelStore store = new BobsBagelStore();
        store.StockUpInventory();

        string result = store.ViewInventory();

        Assert.That(result, Is.Not.Empty);
    }

    [Test]
    public void TestGetPriceFromItem()
    {
        Item item = new Item("BGLP", 0.39f, "Bagel", "Plain");
        
        float expectedResult = 0.39f;

        float acutalResult = item.Price;

        Assert.That(acutalResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void TestAddItemToReceipt()
    {
        BobsBagelStore store = new BobsBagelStore();
        Basket basket = new Basket(3);
        Item item1 = new Item("BGLO", 0.49f, "Bagel", "Onion");
        Item item2 = new Item("BGLP", 0.39f, "Bagel", "Plain");
        basket.AddItem(item1);
        basket.AddItem(item2);
        Receipt receipt = new Receipt(basket);

        bool expectedResult = true;
        
        bool actualResult = store.AddReceipt(basket, receipt);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void TestViewTodaysStoreProfits()
    {
        BobsBagelStore store = new BobsBagelStore();
        Basket basket = new Basket(3);
        Item item1 = new Item("BGLO", 0.49f, "Bagel", "Onion");
        Item item2 = new Item("BGLP", 0.39f, "Bagel", "Plain");
        basket.AddItem(item1);
        basket.AddItem(item2);
        Receipt receipt = new Receipt(basket);

        float expectedResult = 0.88f;

        store.AddReceipt(basket, receipt);

        float actualResult = store.ViewProfits();

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void TestPrintReceipt()
    {
        Basket basket = new Basket(30);
        Item item1 = new Item("BGLO", 0.49f, "Bagel", "Onion");
        Item item2 = new Item("BGLP", 0.39f, "Bagel", "Plain");
        Item item3 = new Item("COFB", 0.99f, "Coffee", "Black");
        Item item4 = new Item("BGLE", 0.49f, "Bagel", "Everything");

        basket.AddItem(item1);
        basket.AddItem(item1);

        for (int i = 0; i < 12; i++)
        {
            basket.AddItem(item2);
        }

        for (int i = 0; i < 6; i++)
        {
            basket.AddItem(item4);
        }
        basket.AddItem(item3);
        basket.AddItem(item3);
        basket.AddItem(item3);

        Receipt receipt = new Receipt(basket);

        string result = receipt.PrintReceipt();

        Assert.That(result, Is.Not.Empty);
    }
}