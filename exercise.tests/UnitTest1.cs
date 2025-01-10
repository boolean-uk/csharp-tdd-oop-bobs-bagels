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
        var basket = new Basket();
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
    public void TestCapacityCheck()
    {
        var basket = new Basket();
        basket.AddItem("BGLO");
        basket.AddItem("BGLP");
        basket.AddItem("COFB");
        basket.AddItem("COFW");

        Assert.AreEqual(3, basket.BasketList.Count);
    }

    [Test]
    public void TestRemoveItem()
    {
        var basket = new Basket();
        basket.AddItem("BGLO");
        basket.AddItem("BGLP");
        basket.AddItem("COFB");

        Assert.AreEqual(3, basket.BasketList.Count);
        Assert.IsTrue(basket.RemoveItem("BGLP"));
        Assert.AreEqual(2, basket.BasketList.Count);
    }

    [Test]
    public void TestRemoveFakeItem()
    {
        var basket = new Basket();
        basket.AddItem("BGLO");
        basket.AddItem("BGLP");
        basket.AddItem("COFB");

        Assert.AreEqual(3, basket.BasketList.Count);
        Assert.IsFalse(basket.RemoveItem("Carrot"));
        Assert.AreEqual(3, basket.BasketList.Count);
    }

    [Test]
    public void TestTotalPrice()
    {
        var basket = new Basket();
        basket.AddItem("BGLO");
        basket.AddItem("BGLP");
        basket.AddItem("COFB");

        Assert.AreEqual(1.87, basket.TotalCost(), 0.01);
    }

    [Test]
    public void TestTotalPriceNoItem()
    {
        var basket = new Basket();

        Assert.AreEqual(0, basket.TotalCost(), 0.01);
    }

    [Test]
    public void TestChangeCapacity()
    {
        var basket = new Basket();
        basket.AddItem("BGLO");
        basket.AddItem("BGLP");
        basket.AddItem("COFB");

        Assert.AreEqual("[BGLO, BGLP]", basket.ChangeCapacity(2));
        Assert.AreEqual(2, basket.BasketList.Count);
        basket.AddItem("COFB");
        Assert.AreEqual(2, basket.BasketList.Count);
    }

    [Test]
    public void TestCapacityBeforeAdd()
    {
        var basket = new Basket();
        basket.ChangeCapacity(5);

        Assert.AreEqual(5, basket.Capacity);
    }

    [Test]
    public void TestCheckPrice()
    {
        var basket = new Basket();

        Assert.AreEqual(0.39, basket.CheckPrice("BGLP"), 0.01);
    }

    [Test]
    public void TestCheckPriceFilling()
    {
        var basket = new Basket();

        Assert.AreEqual(0.12, basket.CheckPrice("FILE"), 0.01);
    }

    [Test]
    public void TestCheckPriceFakeItem()
    {
        var basket = new Basket();

        Assert.AreEqual(0.0, basket.CheckPrice("Apple"), 0.01);
    }

    [Test]
    public void TestAddFillingToBagel()
    {
        var basket = new Basket();
        basket.AddItem("BGLO");
        basket.AddItem("BGLP");

        Assert.AreEqual("[BGLO, FILE, BGLP]", basket.AddFilling("BGLO", "FILE"));
    }

    [Test]
    public void TestAddFillingToBagel2()
    {
        var basket = new Basket();
        basket.AddItem("BGLO");
        basket.AddItem("BGLP");

        Assert.AreEqual("[BGLO, BGLP, FILE]", basket.AddFilling("BGLP", "FILE"));
    }

    [Test]
    public void TestAddMoreFillingToBagel()
    {
        var basket = new Basket();
        basket.AddItem("BGLO");
        basket.AddItem("BGLP");
        basket.AddItem("COFB");
        basket.AddFilling("BGLO", "FILC");
        basket.AddFilling("BGLO", "FILX");
        basket.AddFilling("BGLP", "FILX");

        Assert.AreEqual("[BGLO, FILE, FILX, FILC, BGLP, FILX, COFB]", basket.AddFilling("BGLO", "FILE"));
    }
}