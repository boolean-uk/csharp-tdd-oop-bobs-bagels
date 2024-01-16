using NUnit.Framework;
using exercise.main;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using NuGet.Frameworks;

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
        Item res = testBasket.AddItem(realSKU);

        Assert.That(res.data.SKU, Is.EqualTo("BGLO"));
        // Assert.IsTrue(res);

        string fakeSKU = "AAAAA";
        Item res2 = testBasket.AddItem(fakeSKU);

        Assert.That(res2.data.SKU, Is.EqualTo("none"));

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

        Item res = testBasket.AddItem("BGLE");

        var outputLines = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        Assert.That("Basket size exceeded!", Is.EqualTo(outputLines[0]));

        Assert.That(res.data.SKU, Is.EqualTo("none"));

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

        Item res = testBasket.AddItem("BGLE");

        var outputLines = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        Assert.That("Basket size exceeded!", Is.EqualTo(outputLines[0]));

        Assert.That(res.data.SKU, Is.EqualTo("none"));

    }

    [Test]
    public void NotRemovable()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        Item t1 = testBasket.AddItem("BGLO");
        Item t2 = testBasket.AddItem("BGLO");

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

        Item t1 = testBasket.AddItem("BGLO");
        Item t2 = testBasket.AddItem("BGLE");

        float total = testBasket.TotalCost();

        Assert.That(total, Is.EqualTo(0.98F));

    }

    [Test]
    public void ItemPriceRetreivable()
    {

        float itemPrice1 = testBasket.GetItemPrice("BGLO");
        float itemPrice2 = testBasket.GetItemPrice("BGLP");

        Assert.That(itemPrice1, Is.EqualTo(0.49F));
        Assert.That(itemPrice2, Is.EqualTo(0.39F));

        float itemPrice3 = testBasket.GetItemPrice("AAAA");
        Assert.That(itemPrice3, Is.EqualTo(0F));
    }

    [Test]
    public void AddFillings()
    {

        Item it1 = testBasket.AddItem("BGLE");

        Assert.That(it1.data.SKU, Is.EqualTo("BGLE"));

        testBasket.AddFilling(it1.ID, "FILE");

        List<Item> fillings = it1.ListFillings();
        Assert.That(fillings[0].data.Name, Is.EqualTo("FILE"));

    }

}