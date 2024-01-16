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
        basket.addItem("BGLE");
        Item expected = new Item("BGLE",0.49f,"Bagel","Everything");
        Assert.IsTrue(basket.content.ElementAt(0).Equals(expected));
        Assert.IsTrue(basket.addItem("BGLE"));
    }
}