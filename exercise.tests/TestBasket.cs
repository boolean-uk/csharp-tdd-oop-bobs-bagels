using basket.main;
using bagel.main;
using inventory.main;
using item.main;

namespace basket.tests;


public class TestsBasket
{
    private Basket _basket = new Basket();

    [SetUp]
    public void Setup()
    {
        // for each test a new Basket() will be created
        //_basket = new Basket(5);
        //_itemsInBasket = new List<string>();
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
    
    // TODO testCase totalPrice()
    [TestCase("BGLO", 0.49, "BGLP", 0.39, 0.88)] 
    public void TestTotalPrice(string skuA, double priceA, string skuB, double priceB, double expectedTotalPrice)
    {
        _basket.AddItemToBasket(skuA);
        _basket.AddItemToBasket(skuB);

        double totalPrice = _basket.TotalPrice();
        //Assert.AreEqual(expectedTotalPrice, totalPrice);
        Assert.That(totalPrice, Is.EqualTo(expectedTotalPrice));
    }

    [Test]
    public void TestDiscountBagels6()
    {
        Bagel bagel = new Bagel("BGLO", 0.49, "Onion");
        
        for (int i = 0; i < 6; i++)
        {
            _basket.basketItems.Add(bagel);
        }

        double discount6 = _basket.DiscountPrice();
        Assert.That(discount6, Is.EqualTo(2.49));
    }  
    
    [Test]
    public void TestDiscountBagels12()
    {
        // Arrange
        Bagel bagel = new Bagel("BGLP", 0.39, "Plain");
        
        for (int i = 0; i < 12; i++)
        {
            _basket.basketItems.Add(bagel);
        }

        // Act
        double discount12 = _basket.DiscountPrice();

        // Assert
        Assert.That(discount12, Is.EqualTo(3.99));
    }


}