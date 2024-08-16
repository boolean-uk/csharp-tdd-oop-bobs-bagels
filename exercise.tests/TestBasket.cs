using basket.main;
using bagel.main;
using inventory.main;
using item.main;
using System.Security.Cryptography.X509Certificates;

namespace basket.tests;


public class TestsBasket
{

    private Basket _basket;
    [SetUp]
    public void Setup()
    {
        
        // for each test a new Basket() will be created
        _basket = new Basket();
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
        _basket.AddItemToBasket("BGLS");
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
    
    /*
    [Test]
    public void TestDiscountCombo() 
    {
        Item bagel = new Item("BGLS", 0.39, "Bagel", "Sesame");
        Item coffee = new Item("COFB", 0.99, "Coffee", "Black");

        if(!_basket.basketItems.Contains(bagel) && _basket.basketItems.Contains(coffee))
        {
            _basket.basketItems.Add(bagel);
            _basket.basketItems.Add(coffee);
        }

        double comboDiscount = _basket.DiscountPrice();
        Assert.That(comboDiscount, Is.EqualTo(1.25));
    }
    */

    [TestCase("BGLP", "COFB", 1.25)]
    [TestCase("BGLS", "COFB", 1.25)]
    public void TestComboDiscount(string type, string skuCofb, double expectedDiscountPrice)
    {
       
        _basket.AddItemToBasket(type);
        _basket.AddItemToBasket(skuCofb);

        double comboPrice = _basket.DiscountPrice();
        //Assert.AreEqual(expectedTotalPrice, totalPrice);
        Assert.That(comboPrice, Is.EqualTo(expectedDiscountPrice));
    }

    [Test]
    public void TestComboDiscountMoreBagels() 
    {
        // ACT
        // more bagels than coffee --> check amount of combo coffee Black and bagels
        _basket.AddItemToBasket("BGLP");
        _basket.AddItemToBasket("BGLP");
        _basket.AddItemToBasket("BGLP");
        _basket.AddItemToBasket("BGLP");
        _basket.AddItemToBasket("BGLP");
        _basket.AddItemToBasket("BGLP");
        _basket.AddItemToBasket("BGLP");
        _basket.AddItemToBasket("BGLP");
        _basket.AddItemToBasket("COFB");
        _basket.AddItemToBasket("COFB");
        _basket.AddItemToBasket("COFB");

        // Assert
        double totalOfDiscountPrice = _basket.DiscountPrice();
        Assert.That(totalOfDiscountPrice, Is.EqualTo(3 * 1.25));

    }
    [Test]
    public void TestComboDiscountMoreCoffee() 
    {
        // ACT
        // more bagels than coffee --> check amount of combo coffee Black and bagels
        _basket.AddItemToBasket("BGLP");
        _basket.AddItemToBasket("BGLE");
        _basket.AddItemToBasket("BGLS");
        _basket.AddItemToBasket("COFB");
        _basket.AddItemToBasket("COFB");
        _basket.AddItemToBasket("COFB");
        _basket.AddItemToBasket("COFB");
        _basket.AddItemToBasket("COFC");

        // Assert
        double totalOfDiscountPrice = _basket.DiscountPrice();
        Assert.That(totalOfDiscountPrice, Is.EqualTo(3 * 1.25));
    }
    /*
    [Test]
    public void TestComboDiscount2)
    {
        // ACT
        // more bagels than coffee --> check amount of combo coffee Black and bagels
        _basket.AddItemToBasket("BGLP");
        _basket.AddItemToBasket("BGLE");
        _basket.AddItemToBasket("BGLS");
        _basket.AddItemToBasket("COFB");
        _basket.AddItemToBasket("COFB");
        _basket.AddItemToBasket("COFB");
        _basket.AddItemToBasket("COFB");
        _basket.AddItemToBasket("COFC");

        // Assert
        double totalOfDiscountPrice = _basket.DiscountPrice();
        Assert.That(totalOfDiscountPrice, Is.EqualTo(3 * 1.25));
    }
    */ 
}