using exercise.main;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestCapacity()
    {
        Store store = new Store();
        Assert.IsNotNull(store);

        Assert.That(store.inventory.Count, Is.EqualTo(14));
        Assert.That(store.discounts.Count, Is.EqualTo(3));

        Assert.That(store.capacity, Is.EqualTo(10));
        store.ChangeCapacity(11);
        Assert.That(store.capacity, Is.EqualTo(11));
        Assert.That(store.inventory[0].Sku, Is.EqualTo("BGLO"));
    }
    [Test]
    public void TestAdding()
    {
        Store store = new Store();

        store.AddItem("wrong");

        Assert.That(store.Basket.Count, Is.EqualTo(0));

        store.ChangeCapacity(0);
        store.AddItem("BGLO");

        Assert.That(store.Basket.Count, Is.EqualTo(0));
        store.ChangeCapacity(5);

        store.AddItem("BGLO");

        Assert.That(store.Basket.Count, Is.EqualTo(1));
        Assert.That(store.Basket[0].Sku, Is.EqualTo("BGLO"));
        Assert.That(store.Basket[0].Price, Is.EqualTo(0.49m));
        Assert.That(store.Basket[0].Name, Is.EqualTo("Bagel"));
        Assert.That(store.Basket[0].Variant, Is.EqualTo("Onion"));

        store.AddFilling("FILH", "BGLO");

        Assert.That(store.Basket.Count, Is.EqualTo(2));
        Assert.That(store.Fills["BGLO"], Is.EqualTo("FILH"));
        Assert.That(store.Basket[1].Sku, Is.EqualTo("FILH"));
        Assert.That(store.Basket[1].Price, Is.EqualTo(0.12m));
        Assert.That(store.Basket[1].Name, Is.EqualTo("Filling"));
        Assert.That(store.Basket[1].Variant, Is.EqualTo("Ham"));
        Assert.That(store.Fills.Count, Is.EqualTo(1));

        store.AddItem("COFB");
        Assert.That(store.Basket.Count, Is.EqualTo(3));
    }
    [Test]
    public void TestRemove()
    {
        Store store = new Store();

        store.AddItem("BGLO");

        Assert.That(store.Basket.Count, Is.EqualTo(1));
        Assert.That(store.Basket[0].Sku, Is.EqualTo("BGLO"));

        store.RemoveItem("BGLO");
        Assert.That(store.Basket.Count, Is.EqualTo(0));


    }
    [Test]
    public void TestPriceChecks()
    {
        Store store = new Store();
        Assert.That(store.CheckItemCost("BGLO"), Is.EqualTo(0.49m));
        Assert.That(store.CheckItemCost("COFC"), Is.EqualTo(1.29m));

        store.AddItem("BGLO");
        store.AddItem("BGLE");

        Assert.That(store.CheckTotal(), Is.EqualTo(0.98m));

        store.AddItem("BGLO");
        store.AddItem("BGLO");
        store.AddItem("BGLO");
        store.AddItem("BGLO");
        store.AddItem("BGLO");
        Assert.That(store.CheckTotal(), Is.EqualTo(2.98m));

    }
    [Test]
    public void TestPriceChecks2()
    {
        Store store = new Store();
        store.ChangeCapacity(14);

        store.AddItem("BGLO");
        store.AddItem("BGLO");
        store.AddItem("BGLO");
        store.AddItem("BGLO");
        store.AddItem("BGLO");
        store.AddItem("BGLO");
        store.AddItem("BGLO");
        store.AddItem("BGLO");
        store.AddItem("BGLO");
        store.AddItem("BGLO");
        store.AddItem("BGLO");
        store.AddItem("BGLO");
        Assert.That(store.CheckTotal(), Is.EqualTo(3.99m));
        store.AddItem("BGLO");

        Assert.That(store.CheckTotal(), Is.EqualTo(4.48m));
        store.AddItem("COFL");
        Assert.That(store.Basket.Count, Is.EqualTo(2));
        Assert.That(store.CheckTotal(), Is.EqualTo(5.24m));

    }
    [Test] 
    public void TestReceipt()
    {
        Store store = new Store();

        store.AddItem("COFL");
        store.CheckTotal();
        string receipt = store.PrintReceipt();
        Assert.That(receipt, Does.Contain("Coffee"));
        Assert.That(receipt, Does.Contain("Latte"));
        Assert.That(receipt, Does.Contain("1,29"));
    }
}