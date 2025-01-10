using exercise.main;
using exercise.main.Items;

namespace exercise.tests;

public class BasketTest
{

    private Basket basket;
    private List<Item> items = [
        new Item("BGLE", "Bagel", "Everything", .49f),
        new Item("BGLS", "Bagel", "Sesame", .49f),
        new Item("COFB", "Coffee", "Black", .99f),
        new Item("COFW", "Coffee", "White", 1.19f),
    ];

    [SetUp]
    public void SetUp()
    {
        basket = new Basket();
    }

    private void AddItems()
    {
        items.ForEach(a => basket.Add(a));
    }


    [TestCase("BGLO", "Bagel", "Onion", .49f)]
    public void TestAdd(string id, string name, string variant, float price)
    {
        Item item = new(id, name, variant, price);
        Assert.That(basket.Items, Is.Empty);
        basket.Add(item);
        Assert.That(basket.Items, Has.Exactly(1).Items);
        Assert.That(basket.Items, Has.Exactly(1).EqualTo(item));
    }

    [TestCase("BGLO", "Bagel", "Onion", .49f)]
    public void TestRemove(string id, string name, string variant, float price)
    {
        Item item = new(id, name, variant, price);
        Assert.That(basket.Add(item), Is.True);
        AddItems();
        Assert.That(basket.Items, Has.Exactly(1 + items.Count).Items);
        Assert.That(basket.Items, Has.Exactly(1).EqualTo(item));
        Assert.That(basket.Remove(item), Is.True);
        Assert.That(basket.Items, Has.Exactly(items.Count).Items);
        Assert.That(basket.Items, Has.All.Not.EqualTo(item));
    }
}

