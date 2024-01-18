using workshop.main;
namespace workshop.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestAddBagel()
    {
        Basket basket = new Basket(5);

        Bagel bagel = new Bagel("BGLO", 0.49, "Onion", new BagelOffer(6, 2.49));
        basket.AddItem(bagel);
        CollectionAssert.Contains(basket.items, bagel);
    }

    [Test]
    public void TestRemoveBagel()
    {
        Basket basket = new Basket(4);
        Bagel bagelOnion = new Bagel("BGLO", 0.49, "Onion", new BagelOffer(6, 2.49));
        Bagel bagelPlain = new Bagel("BGLP", 0.49, "Plain", new BagelOffer(6, 2.49));


        basket.AddItem(bagelOnion);
        basket.AddItem(bagelPlain);
        basket.RemoveItem(bagelPlain);

        CollectionAssert.DoesNotContain(basket.items, bagelPlain);
    }

    [Test]
    public void TestBasketIsFull()
    {
        Basket basket = new Basket(2);

        Bagel bagelOnion = new Bagel("BGLO", 0.49, "Onion", new BagelOffer(6, 2.49));
        Bagel bagelPlain = new Bagel("BGLP", 0.49, "Plain", new BagelOffer(6, 2.49));


        basket.AddItem(bagelOnion);
        basket.AddItem(bagelPlain);
        Assert.IsTrue(basket.IsFull());
    }

    [Test]
    public void TestExpandBasket()
    {
        Basket basket = new Basket(2);
        basket.ExpandCapacity(5);
        Assert.AreEqual(basket.Capacity, 5);

    }

    [Test]
    public void TestRemoveItemDoesNotExist()
    {

        Basket basket = new Basket(5);

        Bagel bagelOnion = new Bagel("BGLO", 0.49, "Onion", new BagelOffer(6, 2.49));
        Bagel bagelPlain = new Bagel("BGLP", 0.49, "Plain", new BagelOffer(6, 2.49));
        Bagel bagelBlueberry = new Bagel("BGLB", 0.49, "Blueberry", new BagelOffer(6, 2.49));



        basket.AddItem(bagelOnion);
        basket.AddItem(bagelPlain);

        Assert.Throws<InvalidOperationException>(() => basket.RemoveItem(bagelBlueberry));

    }

    [Test]
    public void TestTotalCost()
    {
        Bagel bagel = new Bagel("BGLO", 0.49, "Onion", new BagelOffer(6, 2.49));

        double totalCost = bagel.CalculateCost(6);
        Assert.AreEqual(2.49, totalCost);

    }

    [Test]
    public void TestBagelCost()
    {
        Bagel bagel = new Bagel("BGLO", 0.49, "Onion", new BagelOffer(6, 2.49));

        double bagelCost = bagel.Price;

        Assert.AreEqual(0.49, bagelCost);
    }

    [Test]

    public void TestChooseFilling()
    {

        // Create a bagel instance


        Basket basket = new Basket(4);
        Bagel bagelOnion = new Bagel("BGLO", 0.49, "Onion", new BagelOffer(6, 2.49));
        Bagel bagelPlain = new Bagel("BGLP", 0.49, "Plain", new BagelOffer(6, 2.49));

        Filling filling = new Filling("FILB", 0.12);

        basket.AddItem(bagelOnion);
        basket.AddItem(bagelPlain);

        basket.AddItem(filling);

        CollectionAssert.Contains(basket.items, filling);

    }


    [Test]
    public void TestPriceFilling()
    {
        Filling filling = new Filling("FILB", 0.12);
        double fillingCost = filling.Price;
        Assert.AreEqual(0.12, fillingCost);
    }


    [Test]
    public void TestOrderInventory()
    {
        Inventory inventory = new Inventory();

        bool isInInventory = inventory.IsItemInInventory("BGLP");
        Assert.IsTrue(isInInventory);
    }

}

