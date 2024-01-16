using exercise.main;
using System.Threading.Tasks.Sources;
using NUnit.Framework;


namespace exercise.tests;

[TestFixture]
public class BobsBagelsTests
{

    [Test]
    public void TestRun()
    {

    }
    public void TestAdd()
    {
        Core core = new Core();

        core.Add("Plain");

        Assert.That(core.Bagels.Count, Is.EqualTo(1));
        Assert.That(core.Bagels[0], Is.EqualTo("Plain"));
    }

    [Test]
    public void TestAddFull()
    {
        Core core = new Core();

        core.Add("Nutella");
        core.Add("Gluten-free");
        core.Add("Bacon");
        core.Add("Cheese");
        core.Add("Egg");

        Assert.Throws<Exception>(() => core.Add("Cheddar"));
        foreach (var bagel in core.Bagels)
        {
            Console.WriteLine(bagel);
        }

    }

    [Test]
    public void TestRemove()
    {
        Core core = new Core();

        core.Add("Plain");
        core.Remove("Plain");

        Assert.That(core.Bagels.Count, Is.EqualTo(0), "Bagel count should be 0");
        Assert.IsFalse(core.Bagels.Contains("Plain"), "Bagel 'Plain' should be removed"); //checks ifFalse on bagel is in List<>

        Console.WriteLine("Bagels in the list after removal:");
        foreach (var bagel in core.Bagels)
        {
            Console.WriteLine(bagel); //outputs nothing since nothing is in list
        }


    }

    [Test]
    public void TestRemoveNonexistant()
    {
        Core core = new Core();

        core.Add("Plain");

        Assert.Throws<Exception>(() => core.Remove("Cheddar"));
        Console.WriteLine(core.Equals(core));
    }

    [Test]
    public void IncreaseCapacity()
    {
        Core core = new Core();

        core.Add("Nutella");
        core.Add("Gluten-free");
        core.Add("Bacon");
        core.Add("Cheese");
        core.Add("Egg");

        core.IncreaseCapacity();
        core.Add("Cheddar");
        core.Add("Anette");
        core.Add("Mari");

        Assert.That(core.Bagels.Count, Is.EqualTo(8));
        Console.WriteLine($"Bagels count after capacity increase: {core.Bagels.Count}");
        foreach (var bagel in core.Bagels)
        {
            Console.WriteLine(bagel);
        }
    }
    [Test]
    public void ChangeBasketCapacity()
    {
        Core core = new Core();
        OrderManager orderManager = new OrderManager();

        int newCapacity = 10;
        orderManager.ChangeBasketCapacity(core.Basket, newCapacity);

        Assert.AreEqual(newCapacity, core.Basket.Capacity);
    }


    [Test]
    public void IsItemInInventory()
    {
        Core core = new Core();
        BagelInventory inventory = new BagelInventory();

        core.Add("Plain");

        Assert.IsTrue(inventory.IsItemInInventory("BGLP"));
        Assert.IsTrue(inventory.IsItemInInventory("Cheddar"));
    }

    [Test]
    public void GetBagelCost()
    {
        BagelInventory inventory = new BagelInventory();
        double cost = inventory.GetCost("Plain");
        Assert.AreEqual(0.39, cost);
    }

    [Test]
    public void GetTotalCost()
    {
        Core core = new Core();
        BagelInventory inventory = new BagelInventory();
        OrderManager orderManager = new OrderManager();

        core.Add("Plain");
        core.Add("Bacon");
        core.Add("Cheese");

        double expectedTotalCost = inventory.GetCost("Plain") + inventory.GetCost("Bacon") + inventory.GetCost("Cheese");
        double actualTotalCost = orderManager.GetTotalCost(core.Basket);

        Assert.AreEqual(expectedTotalCost, actualTotalCost);
    }


    [Test]
    public void GetFillingsCost() 
    {
        BagelInventory inventory = new BagelInventory();
        double cost = inventory.GetFillingsCost(new string[] { "Bacon", "Cream Cheese" });
    }
}