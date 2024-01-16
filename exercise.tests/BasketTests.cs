using NUnit.Framework;
using exercise.main;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

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

        Assert.That(res.SKU, Is.EqualTo("BGLO"));

        string fakeSKU = "AAAAA";
        Item res2 = testBasket.AddItem(fakeSKU);

        Assert.IsNull(res2);

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

        Assert.IsNull(res);

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

        Assert.IsNull(res);

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
        Item it2 = testBasket.AddItem("BGLE");

        it1.AddFilling("FILE");
        it2.AddFilling("FILS");

        List<Item> fillings1 = it1.ListFillings();
        Assert.That(fillings1[0].Name, Is.EqualTo("FILE"));

        List<Item> fillings2= it2.ListFillings();
        Assert.That(fillings2[0].Name, Is.EqualTo("FILS"));

    }

}