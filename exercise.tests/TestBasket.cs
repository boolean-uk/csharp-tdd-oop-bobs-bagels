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
}