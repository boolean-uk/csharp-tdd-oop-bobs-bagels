using exercise.main;

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
}