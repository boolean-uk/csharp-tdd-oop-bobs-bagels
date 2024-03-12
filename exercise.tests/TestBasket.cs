using basket.main;
using inventory.main;
using item.main;

namespace basket.tests;


public class TestsBasket
{
    private Basket _basket;
    private List<string> _itemsInBasket;

    [SetUp]
    public void Setup()
    {
        // for each test a new Basket() will be created
        _basket = new Basket(5);
        _itemsInBasket = new List<string>();
    }

    [Test]
    public void TestAddItemToBasket()
    {
        // setup is done in global setup
        // execute the actual function to test
        bool addedItem = _basket.AddItemToBasket("BGLS");
        //int itemsInBasket = _itemsInBasket.Count;  
        // Assert test, whether execution is successful ( -> check if results / outputs are ok)
        Assert.IsTrue(addedItem);
    }

    [Test] 
    public void TestRemoveItem() 
    {
        // execute the actual function to test
        bool removeItem = _basket.RemoveItem("BGLS");
        // Assert test, whether execution is successful ( -> check if results / outputs are ok)
        Assert.That(removeItem, Is.True);
    }

    [Test]
    public void TestIfBasketCapacityIsFull() 
    {
        bool basketIsFull = _basket.FullBasket(5);
        Assert.That(basketIsFull, Is.True);
    }

    [TestCase("BGLS", 0.49)] 
    [TestCase("FILB", 0.12)] 
    [TestCase("FILE", 0.12)]
    [TestCase("COFC", 1.29)]
    public void TestTotalPrice(string sku, double expectedTotalPrice)
    {
        _basket.AddItemToBasket(sku);
        double totalPrice = _basket.TotalPrice();
        //Assert.AreEqual(expectedTotalPrice, totalPrice);
        Assert.That(totalPrice, Is.EqualTo(Math.Round(expectedTotalPrice, 2)));

    }
}