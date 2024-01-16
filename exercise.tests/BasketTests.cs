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

    [Test]
    public void ChangeCapacity()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        testBasket.ChangeCapacity(3);

        testBasket.AddItem("BGLO");
        testBasket.AddItem("BGLP");
        testBasket.AddItem("COFB");

        bool res = testBasket.AddItem("BGLE");

        var outputLines = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        Assert.That("Basket size exceeded!", Is.EqualTo(outputLines[0]));

        Assert.IsFalse(res);

    }

    [Test]
    public void NotRemovable()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        testBasket.AddItem("BGLO");
        testBasket.AddItem("BGLO");

        bool res = testBasket.RemoveItem("BGLE");

        var outputLines = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        Assert.That("Item not in basket!", Is.EqualTo(outputLines[0]));

        Assert.IsFalse(res);

    }

    [Test]
    public void TotalCostReceived()
    {
        float totalInit = testBasket.TotalCost();

        Assert.That(totalInit, Is.EqualTo(0F));

        testBasket.AddItem("BGLO");
        testBasket.AddItem("BGLE");

        float total = testBasket.TotalCost();

        Assert.That(total, Is.EqualTo(0.98F));

    }
}