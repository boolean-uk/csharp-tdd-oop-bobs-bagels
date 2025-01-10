using exercise.main;

namespace exercise.tests;

public class Tests
{
    [Test]
    public void AddItemToBasket()
    {
        Basket basket = new Basket();
        Item bagel = new Item("BGLO", 0.49, "Bagel", "Onion");

        basket.Add(bagel);
        Assert.That(basket.items[0], Is.EqualTo(bagel));

    }
    [Test]
    public void RemoveItemFromBasket()
    {
        Basket basket = new Basket();
        List<Item> items = new List<Item>
        {
                new Item("BGLS", 0.49, "Bagel", "Sesame"),
                new Item("COFB", 0.99, "Coffee", "Black"),
                new Item("COFW", 1.19, "Coffee", "White"),
                new Item("COFC", 1.29, "Coffee", "Capuccino"),
                new Item("COFL", 1.29, "Coffee", "Latte"),
        };

        foreach (Item item in items)
        {
            basket.Add(item);
        }

        Assert.That(basket.items.Count, Is.EqualTo(items.Count));
        var result = basket.Remove("BGLS");
        Assert.Multiple(() =>
        {
            Assert.That(basket.items, Has.Count.Not.EqualTo(items.Count));
            Assert.That(result, Is.EqualTo(items[0]));
        });
    }
}