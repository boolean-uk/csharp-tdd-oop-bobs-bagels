
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

        Item plainBagel = inventory.getInventory().Find(x => x.name == "Plain");

        Item wrongBagel = new Item("BGLW", 0.40, "Cake", "Wrong");

        bool expected = true;

        bool result = basket.addItem(plainBagel);

        Assert.That(expected == result);

    }
}