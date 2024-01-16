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
        Assert.IsTrue(basket.content.ElementAt(0).Equals("BGLE"));
        Assert.IsTrue(basket.addItem("BGLE"));
    }
}