using System.Reflection.Emit;

namespace exercise.tests;

public class Tests
{
    private int capacity = 6;
    private List<string> contents = new List<string>();
    Basket _basket;
    [SetUp]
    public void Setup()
    {
        _basket = new Basket(capacity, contents);
    }

    [Test]
    public void addBagelTest()
    {
        Assert.IsTrue(_basket.addItem());
    }
}