using System.Reflection.Emit;

namespace exercise.tests;

public class Tests
{
    private int capacity = 6;
    public List<string> content;
    Basket basket;
    [SetUp]
    public void Setup()
    {
        content = new List<string>();
        basket = new Basket(capacity);
    }

    [Test]
    public void addBagelTest()
    {
        basket.addItem("BGLE");
        Assert.IsTrue(basket.content.Contains("BLGE"));
        Assert.IsTrue(basket.addItem("BGLE"));
    }
}