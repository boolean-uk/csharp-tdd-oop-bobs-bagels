using System.Reflection.Emit;
using exercise.main;
using Newtonsoft.Json;

namespace exercise.tests;

public class Tests
{
    private int capacity = 6;
    Basket basket;
    Inventory inventory;
    [SetUp]
    public void Setup()
    {
        basket = new Basket();
        inventory = new Inventory();
    }
    [TestCase("BLGO", true)]
    [TestCase("COFB", true)]
    [TestCase("FILB", true)]
    [TestCase("FILX", true)]
    [TestCase("BGLS", true)]
    [TestCase("BGLA", false)]
    [TestCase("AKAK", false)]
    [TestCase("FILY", false)]
    public void inventoryCheckTest(string excpected, bool real)
    {
        Assert.That(inventory.inInventory(excpected).Equals(real));
    }
    [Test]
    public void addItemTest()
    {
        
    }
    [Test]
    public void removeItemTest()
    {
        
    }
    [Test]
    public void changeCapacitytest()
    {
        
    }
    [Test]
    public void printTotalCostTest()
    {
        
    }
}