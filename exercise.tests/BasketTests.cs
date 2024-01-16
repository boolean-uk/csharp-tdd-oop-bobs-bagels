using NUnit.Framework;
using exercise.main;

namespace exercise.tests;

[TestFixture]
public class BasketTests
{
    private Basket testBasket;

    [SetUp]
    public void Setup()
    {
        testBasket = new Basket();
    }

    [Test]
    public void AddItem()
    {
        string realSKU = "BGLO";
        bool res = testBasket.AddItem(realSKU);

        Assert.IsTrue(res);

        string fakeSKU = "AAAAA";
        bool res2 = testBasket.AddItem(fakeSKU);

        Assert.IsFalse(res2);

    }

    [Test]
    public void RemoveItem()
    {
        testBasket.AddItem("BGLO");
        testBasket.AddItem("BGLP");

        bool res1 = testBasket.RemoveItem("BGLO");
        Assert.IsTrue(res1);

        bool res2 = testBasket.RemoveItem("AAAA");
        Assert.IsFalse(res2);

    }

    [Test]
    public void CapacityExceededMessage()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        testBasket.AddItem("BGLO");
        testBasket.AddItem("BGLP");
        testBasket.AddItem("COFB");
        testBasket.AddItem("BGLS");
        testBasket.AddItem("COFW");

        bool res = testBasket.AddItem("BGLE");

        var outputLines = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        Assert.That("Basket size exceeded!", Is.EqualTo(outputLines[0]));

        Assert.IsFalse(res);

    }
}