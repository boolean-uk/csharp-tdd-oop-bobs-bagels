namespace exercise.tests;

public class Tests
{
    private BobsBagel bb;
    private Basket basket;
    private Item fillerItem;
    private Item testItem;
    [SetUp]
    public void Setup()
    {
        bb = new BobsBagel();
        basket = bb.NewBasket();
        fillerItem = new Bagel("Bagel1", 7.3f);
        testItem = new Bagel("Coffee", 1.3f);
    }

    [TestCase(true, 29, 30)]
    [TestCase(false, 30, 30)]
    public void AddItemTest(bool expResult, int basketCount, int basketCapacity)
    {
        basket.ChangeCapasity(basketCapacity);
        for(int i = 0; i < basketCount; i++)
        {
            basket.AddItem(fillerItem);
        }

        bool result = basket.AddItem(testItem);
        Assert.That(result, Is.EqualTo(expResult));
    }


    [Test]
    public void RemoveItemTest()
    {
        basket.ChangeCapasity(basketCapacity);
        for (int i = 0; i < basketCount; i++)
        {
            basket.AddItem(fillerItem);
        }

        bool result = basket.AddItem(testItem);
        Assert.That(result, Is.EqualTo(expResult));
    }


    [Test]
    public void ChangeCapacityTest()
    {
        Assert.Pass();
    }


    [Test]
    public void GetItemCostTest()
    {
        Assert.Pass();
    }


    [Test]
    public void GetCostTest()
    {
        Assert.Pass();
    }


    [Test]
    public void AddFillingTest()
    {
        Assert.Pass();
    }


    [Test]
    public void ChangeBasketCapacityTest()
    {
        Assert.Pass();
    }
}