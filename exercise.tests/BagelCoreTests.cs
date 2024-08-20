
using exercise.main;
namespace exercise.tests;


public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddItemTest()
    {

        Basket basket = new Basket();
        
        Inventory inventory = new Inventory();

        Item plainBagel = new Item("BGLP", 0.39, "Bagel", "Plain");

        Item wrongBagel = new Item("BGLW", 0.40, "Cake", "Wrong");

        bool expectedTrue = true;
        bool expectedFalse = false;

        basket.addItem(plainBagel);
        basket.addItem(plainBagel);
        basket.addItem(plainBagel);
        basket.addItem(plainBagel);
       // basket.addItem(plainBagel);

        bool resultTrue = basket.addItem(plainBagel);
        bool resultWrong = basket.addItem(wrongBagel);

        Assert.That(expectedTrue == resultTrue);
       // Assert.That(expectedFalse == resultWrong);

    }


    [Test]
    public void RemoveBagelOrItemTest()
    {
        Basket basket = new Basket();

        Inventory inventory = new Inventory();

        Item plainBagel = new Item("BGLP", 0.39, "Bagel", "Plain");

        Item wrongBagel = new Item("BGLW", 0.40, "Cake", "Wrong");

        basket.addItem(plainBagel);
        
        bool expectedTrue = true;
        bool expectedFalse = false;

        bool result = basket.removeBagelOrItem(plainBagel);

        Assert.That(expectedTrue == result);
    }

    [Test]
    public void ChangeBasketCapacityTest()
    {
        Basket basket = new Basket();

        Inventory inventory = new Inventory();

        Person bob = new Person("Bob", Role.MANAGER);
        Person customer = new Person("Jimmy", Role.CUSTOMER);


        int expectedCapacity = 7;
        int result = basket.changeBasketCapacity(7, bob.role);

        Assert.That(expectedCapacity == result);
    }

    [Test]
    public void TotalCostTest() 
    { 
        Basket basket = new Basket();

        Inventory inventory = new Inventory();

        Item plainBagel = new Item("BGLP", 0.39, "Bagel", "Plain");
        Item blackCoffe = new Item("COFB", 0.99, "Coffee", "Black");

        basket.addItem(plainBagel);
        basket.addItem(plainBagel);
        basket.addItem(blackCoffe);

        double expected = plainBagel.price + plainBagel.price + blackCoffe.price;

        double result = basket.totalCost();

        Assert.That(expected == result);
    }

    [Test]
    public void GetPriceOfItemTest()
    {
        Basket basket = new Basket();

        Inventory inventory = new Inventory();

        Item plainBagel = new Item("BGLP", 0.39, "Bagel", "Plain");
        Item blackCoffe = new Item("COFB", 0.99, "Coffee", "Black");

        Item wrongBagel = new Item("BGLW", 0.40, "Cake", "Wrong");

        double expected = plainBagel.price;

        double result = basket.getPriceOfItem(plainBagel);
       
        Assert.That(expected == result);
    }

    [TestCase(1.25, 2.49, 3.99)]
    public void DiscountTest(double d1, double d2, double d3)
    {
        Basket basket = new Basket();

        Inventory inventory = new Inventory();

        Item plainBagel = new Item("BGLP", 0.39, "Bagel", "Plain");
        Item blackCoffe = new Item("COFB", 0.99, "Coffee", "Black");

         basket.changeBasketCapacity(14, Role.MANAGER);

        // IF ADDING COFFEE FIRST IT DOESENT WORK

        basket.addItem(plainBagel);
        basket.addItem(blackCoffe);

        
       // basket.addItem(plainBagel);
        basket.addItem(plainBagel);
        basket.addItem(plainBagel);
        basket.addItem(plainBagel);
        basket.addItem(plainBagel);
        basket.addItem(plainBagel);

        
        //basket.addItem(plainBagel);
        //basket.addItem(plainBagel);
        //basket.addItem(plainBagel);
        //basket.addItem(plainBagel);
        //basket.addItem(plainBagel);
        //basket.addItem(plainBagel);
        

        double expectedCofBag = d1;
        double expectedSixBagel = d2;
        double expectedTwelBagel = d3;

        double result = basket.discount();

        Assert.That(expectedSixBagel == result);

    }
}