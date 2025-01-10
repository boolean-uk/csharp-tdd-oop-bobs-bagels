using exercise.main;
using exercise.main.Items;
using exercise.main.Exceptions;

namespace exercise.tests;

public class BasketTest
{

    private Basket basket;
    private List<Item> items = [
        new Bagel("Everything", .49f),
        new Bagel("Sesame", .49f),
        new Coffee("Black", .99f),
        new Coffee("White", 1.19f),
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

    public void TestSimple(string item, string variant, float price, Action<Item> func)
    {
        switch (item)
        {
            case "bagel": func(new Bagel(variant, price)); break;
            case "coffee": func(new Coffee(variant, price)); break;
            case "filling": func(new Filling(variant, price)); break;
        }
    }

    [TestCase("bagel", "Onion", .49f)]
    [TestCase("coffee", "Black", .99f)]
    [TestCase("filling", "Bacon", .12f)]
    public void TestAdd(string item, string variant, float price)
    {
        TestSimple(item, variant, price, TestAdd);
    }

    private void TestAdd(Item item)
    {
        Assert.That(basket.Items, Is.Empty);
        basket.Add(item);
        Assert.That(basket.Items, Has.Exactly(1).Items);
        Assert.That(basket.Items, Has.Exactly(1).EqualTo(item));
    }

    [TestCase("bagel", "Onion", .49f)]
    [TestCase("coffee", "Black", .99f)]
    [TestCase("filling", "Bacon", .12f)]
    public void TestRemove(string item, string variant, float price)
    {
        TestSimple(item, variant, price, TestRemove);
    }
    public void TestRemove(Item item)
    {
        Assert.That(basket.Add(item), Is.True);
        AddItems();
        Assert.That(basket.Items, Has.Exactly(1 + items.Count).Items);
        Assert.That(basket.Items, Has.Exactly(1).EqualTo(item));
        Assert.That(basket.Remove(item), Is.True);
        Assert.That(basket.Items, Has.Exactly(items.Count).Items);
        Assert.That(basket.Items, Has.All.Not.EqualTo(item));
    }

    [Test]
    public void TestUpdateCapacity()
    {
        int newCapacity = 1000;
        Role customer = new Role(Role.GetAccessLevel("customer"));
        Assert.Throws<PermissionDeniedException>(() => Basket.UpdateCapacity(newCapacity, customer));
        Role manager = new Role(Role.GetAccessLevel("manager"));
        Assert.DoesNotThrow(() =>  Basket.UpdateCapacity(newCapacity, manager));
        Assert.That(Basket.Capacity, Is.EqualTo(newCapacity));
    }
}

