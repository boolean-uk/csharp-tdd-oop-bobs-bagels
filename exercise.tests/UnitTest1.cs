using exercise.main;

namespace exercise.tests;

public class Tests
{
    [Test]
    public void AddItemToBasket()
    {
        Inventory inventory = new Inventory();
        Basket basket = new Basket();

        Item bagel = new Item("BGLO", 0.49, "Bagel", "Onion");

        basket.Add(bagel);
        Assert.That(basket.items[0], Is.EqualTo(bagel));

    }
}