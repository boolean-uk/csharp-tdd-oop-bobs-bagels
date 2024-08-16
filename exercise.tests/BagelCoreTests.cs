
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
}