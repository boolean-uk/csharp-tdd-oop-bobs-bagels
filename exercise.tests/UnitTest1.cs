using System.Reflection.Emit;

namespace exercise.tests;

public class Tests
{
    private int capacity = 6;
    public List<Item> content;
    Basket basket;
    [SetUp]
    public void Setup()
    {
        content = new List<Item>();
        basket = new Basket(capacity);
    }

    [Test]
    public void addBagelTest()
    {
        Item expected = new Item(0.49f, "Bagel", "Everything");
        Item result = basket.addItem("BGLE");
        Assert.That(result._price == expected._price);
        Assert.That(result._type == expected._type);
        Assert.That(result._variant == expected._variant);
    }
}