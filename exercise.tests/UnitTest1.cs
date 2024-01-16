using System.Reflection.Emit;
using Newtonsoft.Json;

namespace exercise.tests;

public class Tests
{
    private int capacity = 6;
    Basket basket;
    [SetUp]
    public void Setup()
    {
        basket = new Basket(capacity);
    }

    [Test]
    public void addBagelTest()
    {
        Item expected = new Item(0.49f, "Bagel", "Everything");
        Item result = basket.addItem("BGLE");
        string expectedJson = JsonConvert.SerializeObject(expected);
        string resultJson = JsonConvert.SerializeObject(result);
        Assert.That(resultJson, Is.EqualTo(expectedJson));
    }
    [Test]
    public void addCoffeeTest()
    {
        Item expected = new Item(0.99f, "Coffee", "Black");
        Item result = basket.addItem("COFB");
        string expectedJson = JsonConvert.SerializeObject(expected);
        string resultJson = JsonConvert.SerializeObject(result);
        Assert.That(resultJson, Is.EqualTo(expectedJson));
    }
    [Test]
    public void removeBagelTest()
    {
        Item testItem = basket.addItem("BGLE");
        basket.removeItem("BGLE");
        string itemJson = JsonConvert.SerializeObject(testItem);
        Assert.IsFalse(basket.content.Contains(testItem));
    }
}