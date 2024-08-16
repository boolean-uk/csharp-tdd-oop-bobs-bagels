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
        BobsBagelStore store = new BobsBagelStore();
        Basket basket = new Basket(basketCapacity);
        store.AddBasket(basket);
        Item item1 = new Item("BGLO", 0.49f, "Bagel", "Onion");
        Item item2 = new Item("BGLP", 0.39f, "Bagel", "Plain");
        Item item3 = new Item("BGLE", 0.49f, "Bagel", "Everything");
        basket.AddItem(item1);
        basket.AddItem(item2);

        bool actualResult = basket.AddItem(item3);

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}