using NUnit.Framework;
using exercise.main;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using NuGet.Frameworks;
using System.Security.Cryptography;
using NUnit.Framework.Interfaces;
using System.Drawing;

namespace exercise.tests;

[TestFixture]
public class BasketTests
{
    private Basket testBasket;
    private Dictionary<string, Item> inv;

    [SetUp]
    public void Setup()
    {
        Inventory inventory = new Inventory();
        testBasket = new Basket(inventory);
        inv = inventory.getInventory();
    }

    [Test]
    public void AddItem()
    {
        Item item = inv["BGLO"];

        Item res = testBasket.AddItem(item);

        Assert.That(res.SKU, Is.EqualTo("BGLO"));

        Bagel item2 = new Bagel("AAAA", "Fake", 0.0F, "B");

        Exception ex = Assert.Throws<System.Exception>(() => testBasket.AddItem(item2));
        Assert.That(ex.Message, Is.EqualTo("SKU not found!"));

    }

    [Test]
    public void RemoveItem()
    {

        Item item = inv["BGLO"];
        Item item2 = inv["BGLP"];
        Bagel itemFake = new Bagel("AAAA", "Fake", 0.0F, "B");

        testBasket.AddItem(item);
        testBasket.AddItem(item2);

        bool res1 = testBasket.RemoveItem(item);
        Assert.IsTrue(res1);

        bool res2 = testBasket.RemoveItem(itemFake);
        Assert.IsFalse(res2);

    }

    [Test]
    public void CapacityExceededMessage()
    {

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        testBasket.AddItem(inv["BGLO"]);
        testBasket.AddItem(inv["BGLP"]);
        testBasket.AddItem(inv["COFB"]);
        testBasket.AddItem(inv["BGLS"]);
        testBasket.AddItem(inv["COFW"]);

        Exception ex = Assert.Throws<System.Exception>(() => testBasket.AddItem(inv["BGLE"]));
        Assert.That(ex.Message, Is.EqualTo("Basket size exceeded!"));
  
    }

    [Test]
    public void ChangeCapacity()
    {

        testBasket.ChangeCapacity(3);

        testBasket.AddItem(inv["BGLO"]);
        testBasket.AddItem(inv["BGLP"]);
        testBasket.AddItem(inv["COFB"]);

        Exception ex = Assert.Throws<System.Exception>(() => testBasket.AddItem(inv["BGLE"]));
        Assert.That(ex.Message, Is.EqualTo("Basket size exceeded!"));

        Exception ex2 = Assert.Throws<System.Exception>(() => testBasket.ChangeCapacity(1));
        Assert.That(ex2.Message, Is.EqualTo("Cannot reduce the basket size below current item count!"));

    }

    [Test]
    public void NotRemovable()
    {

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        testBasket.AddItem(inv["BGLO"]);
        testBasket.AddItem(inv["BGLO"]);

        bool res = testBasket.RemoveItem(inv["BGLE"]);

        var outputLines = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        Assert.That("Item not in basket!", Is.EqualTo(outputLines[0]));

        Assert.IsFalse(res);
        

    }

    [Test]
    public void TotalCostReceived()
    {

        float totalInit = testBasket.TotalCost();

        Assert.That(totalInit, Is.EqualTo(0F));

        Item t1 = testBasket.AddItem(inv["BGLO"]);
        testBasket.AddItem(inv["BGLE"]);

        Filling filling = (Filling)inv["FILB"];
       
        testBasket.AddFilling(t1.ID, filling);

        float total = testBasket.TotalCost();

        Assert.That(total, Is.EqualTo(1.1F));

    }

    [Test]
    public void ItemPriceRetreivable()
    {

        float itemPrice1 = testBasket.GetItemPrice(inv["BGLO"]);
        float itemPrice2 = testBasket.GetItemPrice(inv["BGLP"]);

        Assert.That(itemPrice1, Is.EqualTo(0.49F));
        Assert.That(itemPrice2, Is.EqualTo(0.39F));

        Bagel item2 = new Bagel("AAAA", "Fake", 0.0F, "B");

        float itemPrice3 = testBasket.GetItemPrice(item2);
        Assert.That(itemPrice3, Is.EqualTo(0F));
        
    }

    [Test]
    public void FillingPriceRetreivable()
    {

        float itemPrice1 = testBasket.GetItemPrice(inv["FILX"]);
        float itemPrice2 = testBasket.GetItemPrice(inv["FILS"]);

        Assert.That(itemPrice1, Is.EqualTo(0.12F));
        Assert.That(itemPrice2, Is.EqualTo(0.12F));
        
    }

    [Test]
    public void AddFillings()
    {

        Bagel it1 = (Bagel)testBasket.AddItem(inv["BGLE"]);
        Bagel it2 = (Bagel)testBasket.AddItem(inv["BGLE"]);

        Filling f1 = (Filling)inv["FILE"];
        Filling f2 = (Filling)inv["FILH"];
        Filling f3 = (Filling)inv["FILB"];

        Assert.That(it1.SKU, Is.EqualTo("BGLE"));
        Assert.That(it2.SKU, Is.EqualTo("BGLE"));


        testBasket.AddFilling(it1.ID, f1);
        testBasket.AddFilling(it2.ID, f2);
        testBasket.AddFilling(it2.ID, f3);

        List<Item> fillings = it1.ListFillings();
        Assert.That(fillings[0].SKU, Is.EqualTo("FILE"));

        List<Item> fillings2 = it2.ListFillings();
        Assert.That(fillings2[0].SKU, Is.EqualTo("FILH"));
        Assert.That(fillings2[1].SKU, Is.EqualTo("FILB"));
        
    }

    [Test]
    public void OnlyValidOrders()
    {
      
        Bagel item2 = new Bagel("AAAA", "Fake", 0.0F, "B");
        Coffee item4 = new Coffee("AAAA", "Fake", 0.0F, "B");
        Filling item3 = new Filling("AAAA", "Fake", 0.0F, "B");

        Exception ex = Assert.Throws<System.Exception>(() => testBasket.AddItem(item2));
        Assert.That(ex.Message, Is.EqualTo("SKU not found!"));

        Exception ex2 = Assert.Throws<System.Exception>(() => testBasket.AddItem(item3));
        Assert.That(ex2.Message, Is.EqualTo("SKU not found!"));

        Bagel it2 = (Bagel)testBasket.AddItem(inv["BGLE"]);
        testBasket.AddFilling(it2.ID, item3);

        List<Item> fillings = it2.ListFillings();
        Assert.AreEqual(fillings.Count, 0);
        

    }

    [Test]
    public void DiscountBagelBundle6()
    {

        testBasket.ChangeCapacity(15);

        Item i1 = testBasket.AddItem(inv["BGLE"]);
        Item i2 = testBasket.AddItem(inv["BGLE"]);
        Item i3 = testBasket.AddItem(inv["BGLE"]);
        Item i4 = testBasket.AddItem(inv["BGLE"]);
        Item i5 = testBasket.AddItem(inv["BGLE"]);
        Item i6 = testBasket.AddItem(inv["BGLE"]);

        testBasket.BundleOrder("b6", new List<Item> { i1, i2, i3, i4, i5, i6 });

        Assert.IsTrue(i1.isInBundle());
        Assert.IsTrue(i2.isInBundle());
        Assert.IsTrue(i3.isInBundle());
        Assert.IsTrue(i4.isInBundle());
        Assert.IsTrue(i5.isInBundle());
        Assert.IsTrue(i6.isInBundle());

        List<string> bundleList = i1.ListBundleIds();

        Assert.AreEqual(bundleList, new List<string> { i1.ID, i2.ID, i3.ID, i4.ID, i5.ID, i6.ID });

        float totalInit = testBasket.TotalCost();
        Assert.That(totalInit, Is.EqualTo(2.49F));
        
    }

    [Test]
    public void DiscountBagelBundle12()
    {
     
        testBasket.ChangeCapacity(15);

        Item i1 = testBasket.AddItem(inv["BGLE"]);
        Item i2 = testBasket.AddItem(inv["BGLE"]);
        Item i3 = testBasket.AddItem(inv["BGLE"]);
        Item i4 = testBasket.AddItem(inv["BGLE"]);
        Item i5 = testBasket.AddItem(inv["BGLE"]);
        Item i6 = testBasket.AddItem(inv["BGLE"]);
        Item i7 = testBasket.AddItem(inv["BGLE"]);
        Item i8 = testBasket.AddItem(inv["BGLE"]);
        Item i9 = testBasket.AddItem(inv["BGLE"]);
        Item i10 = testBasket.AddItem(inv["BGLE"]);
        Item i11 = testBasket.AddItem(inv["BGLE"]);
        Item i12 = testBasket.AddItem(inv["BGLE"]);

        testBasket.BundleOrder("b12", new List<Item> { i1, i2, i3, i4, i5, i6 , i7 , i8, i9, i10, i11, i12 });

        float totalInit2 = testBasket.TotalCost();
        Assert.That(totalInit2, Is.EqualTo(3.99F));
        
    }

    [Test]
    public void DiscountCoffeeAndBagel()
    {
       
        Item i1 = testBasket.AddItem(inv["BGLE"]);
        Item i2 = testBasket.AddItem(inv["COFB"]);

        testBasket.BundleOrder("bac", new List<Item> { i1, i2 });

        float totalInit2 = testBasket.TotalCost();
        Assert.That(totalInit2, Is.EqualTo(1.25F));
        
    }

    [Test]
    public void ReceitPrinted()
    {

        testBasket.ChangeCapacity(30);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        Item t1 = testBasket.AddItem(inv["BGLE"]);

        Item b1 = testBasket.AddItem(inv["BGLE"]);
        Item c1 = testBasket.AddItem(inv["COFB"]);

        testBasket.BundleOrder("bac", new List<Item> { b1 , c1 });

        Item i1 = testBasket.AddItem(inv["BGLO"]);
        Item i2 = testBasket.AddItem(inv["BGLO"]);
        Item i3 = testBasket.AddItem(inv["BGLO"]);
        Item i4 = testBasket.AddItem(inv["BGLO"]);
        Item i5 = testBasket.AddItem(inv["BGLO"]);
        Item i6 = testBasket.AddItem(inv["BGLO"]);

        testBasket.BundleOrder("b6", new List<Item> { i1, i2, i3, i4, i5, i6 });

        Item a1 = testBasket.AddItem(inv["BGLE"]);
        Item a2 = testBasket.AddItem(inv["BGLE"]);
        Item a3 = testBasket.AddItem(inv["BGLE"]);
        Item a4 = testBasket.AddItem(inv["BGLE"]);
        Item a5 = testBasket.AddItem(inv["BGLE"]);
        Item a6 = testBasket.AddItem(inv["BGLE"]);
        Item a7 = testBasket.AddItem(inv["BGLE"]);
        Item a8 = testBasket.AddItem(inv["BGLE"]);
        Item a9 = testBasket.AddItem(inv["BGLE"]);
        Item a10 = testBasket.AddItem(inv["BGLE"]);
        Item a11 = testBasket.AddItem(inv["BGLE"]);
        Item a12 = testBasket.AddItem(inv["BGLE"]);

        testBasket.BundleOrder("b12", new List<Item> { a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12 });

        testBasket.PrintReceipt(new Receit());

        var outputLines = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
        
        Assert.That("     ~~~ Bob's Bagels ~~~", Is.EqualTo(outputLines[0]));

        DateTime enteredDate = DateTime.Parse(outputLines[1]);
        DateTime now = DateTime.Now;

        Assert.That(enteredDate, Is.InstanceOf(now.GetType()));
        Assert.That("------------------------------", Is.EqualTo(outputLines[2]));
        Assert.That("Bagel & Coffee        2  £1,25", Is.EqualTo(outputLines[3]));
        Assert.That("                      (-£0,27)", Is.EqualTo(outputLines[4]));
        Assert.That("Everything Bagel     12  £3,99", Is.EqualTo(outputLines[5]));
        Assert.That("                      (-£1,89)", Is.EqualTo(outputLines[6]));
        Assert.That("Onion Bagel           6  £2,49", Is.EqualTo(outputLines[7]));
        Assert.That("                      (-£0,45)", Is.EqualTo(outputLines[8]));
        Assert.That("Everything Bagel      1  £0,49", Is.EqualTo(outputLines[9]));
        Assert.That("------------------------------", Is.EqualTo(outputLines[10]));
        Assert.That("Total                    £8,22", Is.EqualTo(outputLines[11]));

        Assert.That("   You saved a total of £2,61", Is.EqualTo(outputLines[12]));
        Assert.That("         on this shop", Is.EqualTo(outputLines[13]));

        Assert.That("           Thank you", Is.EqualTo(outputLines[15]));
        Assert.That("        for your order!", Is.EqualTo(outputLines[16]));
        
    }

}