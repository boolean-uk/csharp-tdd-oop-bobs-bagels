
using exercise.main;

namespace exercise.tests;

public class Tests
{
    /*[SetUp]
    public void Setup()
    {
    }*/

    [Test]
    public void TestAddItem()
    {
        Basket basket = new Basket();
        string bagel = "BGLO";

        Assert.IsTrue(basket.AddItem(bagel));
    }

    [Test]
    public void TestAddingFake()
    {
        var basket = new Basket();

        Assert.IsFalse(basket.AddItem("Carrot"));
    }

    [Test]
    public void TestCapacityFull()
    {
        var basket = new Basket();
        basket.AddItem("BGLO");
        basket.AddItem("BGLP");
        basket.AddItem("COFB");
        basket.AddItem("COFW");

        Assert.AreEqual(3, basket.basketList.Count);
    }

    [Test]
    public void TestRemoveItem()
    {
        var basket = new Basket();
        basket.AddItem("BGLO");
        basket.AddItem("BGLP");
        basket.AddItem("COFB");

        Assert.AreEqual(3, basket.basketList.Count);
        Assert.IsTrue(basket.RemoveItem("BGLP"));
        Assert.AreEqual(2, basket.basketList.Count);
    }

    [Test]
    public void TestRemoveFakeItem()
    {
        var basket = new Basket();
        basket.AddItem("BGLO");
        basket.AddItem("BGLP");
        basket.AddItem("COFB");

        Assert.AreEqual(3, basket.basketList.Count);
        Assert.IsFalse(basket.RemoveItem("Carrot"));
        Assert.AreEqual(3, basket.basketList.Count);
    }

    [Test]
    public void TestTotalPrice()
    {
        var basket = new Basket();
        basket.AddItem("BGLO");
        basket.AddItem("BGLP");
        basket.AddItem("COFB");

        Assert.AreEqual(1.87, basket.totalCost(), 0.01);
    }

    [Test]
    public void TestTotalPriceNoItem()
    {
        var basket = new Basket();

        Assert.AreEqual(0, basket.totalCost(), 0.01);
    }

    [Test]
    public void TestChangeCapacity()
    {
        var basket = new Basket();
        basket.AddItem("BGLO");
        basket.AddItem("BGLP");
        basket.AddItem("COFB");

        basket.changeCapacity(2);
        Assert.AreEqual(2, basket.basketList.Count);
        basket.AddItem("COFB");
        Assert.AreEqual(2, basket.basketList.Count);
    }

    [Test]
    public void TestChangeCapacityWithFilling()
    {
        var basket = new Basket();
        basket.AddItem("BGLO");
        basket.AddItem("FILE");
        basket.AddItem("BGLP");
        

        basket.changeCapacity(2);
        Assert.AreEqual(3, basket.basketList.Count);
        
    }

    [Test]
    public void TestCapacityBeforeAdd()
    {
        var basket = new Basket();
        basket.changeCapacity(5);

        Assert.AreEqual(5, basket.capacity);
    }

    [Test]
    public void TestCheckPrice()
    {
        var basket = new Basket();

        Assert.AreEqual(0.39, basket.checkPrice("BGLP"), 0.01);
    }

    [Test]
    public void TestCheckPriceFilling()
    {
        var basket = new Basket();

        Assert.AreEqual(0.12, basket.checkPrice("FILE"), 0.01);
    }

    [Test]
    public void TestCheckPriceFakeItem()
    {
        var basket = new Basket();

        Assert.AreEqual(0.0, basket.checkPrice("Apple"), 0.01);
    }

    [Test]
    
    public void TestAddFillingToBagel()
    {
        var basket = new Basket();
        basket.AddItem("BGLO");
        basket.AddItem("BGLP");

        Assert.IsTrue(basket.AddFilling(1, "FILE"));
    }

    [Test]
    public void TestAddFillingToBagel2()
    {
        var basket = new Basket();
        basket.AddItem("BGLO");
        basket.AddItem("BGLP");

        Assert.IsTrue(basket.AddFilling(0, "FILE"));
    }

    [Test]
    public void TestAddMoreFillingToBagel()
    {
        var basket = new Basket();
        basket.AddItem("BGLO");
        basket.AddItem("BGLP");
        basket.AddItem("COFB");

        Assert.IsTrue(basket.AddFilling(0, "FILC"));
        Assert.IsTrue(basket.AddFilling(2, "FILX"));
        Assert.IsTrue(basket.AddFilling(2, "FILX"));
    }

    [Test]
    public void TestDiscount()
    {
        var basket = new Basket();
        basket.changeCapacity(200);
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("COFB");
        Assert.AreEqual(1.64, basket.Discount(), 0.01);
    }

    [Test]
    public void TestDiscount2()
    {
        var basket = new Basket();
        basket.changeCapacity(200);
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        Assert.AreEqual(5.55, basket.Discount(), 0.01);
    }

    [Test]
    public void testDiscount3()
    {
        Basket basket = new Basket();
        basket.changeCapacity(25);
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("BGLP");
        basket.AddItem("COFB"); //0.99 => 1.25
        basket.AddItem("COFC"); //1.29 => 1.25

        Assert.AreEqual(3.99 + 1.25 + 1.25 + 0.39 + 0.39, basket.Discount());
    }


}