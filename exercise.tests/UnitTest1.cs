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

        core.Add("BGLP");
        core.Add("COFW");
        core.Add("COFC");
        core.Add("COFB");
        core.Add("COFL");

        Assert.Throws<InvalidOperationException>(() => core.Add("BGLP"));

    }

    [Test]
    public void TestRemove()
    {
        Core core = new Core();

        core.Add("BGLP");
        core.Remove("BGLP");

        Assert.That(core.Bagels.Count, Is.EqualTo(0), "Bagel count should be 0");
        Assert.IsFalse(core.Bagels.Contains("BGLP"), "Bagel 'Plain' should be removed"); //checks ifFalse on bagel is in List<>

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

        core.Add("Cheddar");

        Assert.Throws<System.InvalidOperationException>(() => core.Remove("Cheddar"));
        Console.WriteLine(core.Equals(core));
    }

    [Test]
    public void IncreaseCapacity()
    {
        Core core = new Core();

        core.Add("BGLP");
        core.Add("COFW");
        core.Add("COFC");
        core.Add("COFL");
        core.Add("COFB");

        core.IncreaseCapacity();

        Assert.That(core.Bagels.Count, Is.EqualTo(5));

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

        Assert.That(core.Basket.Capacity, Is.EqualTo(newCapacity));
    }


    [Test]
    public void IsItemInInventory()
    {
        Core core = new Core();
        BagelInventory inventory = new BagelInventory();

        core.Add("BGLP");

        Assert.IsTrue(inventory.IsItemInInventory("BGLP"));
    }

    [Test]
    public void GetBagelCost()
    {
        BagelInventory inventory = new BagelInventory();
        double cost = inventory.GetCost("BGLP");
        Assert.That(cost, Is.EqualTo(0.39));
    }

    [Test]
    public void GetTotalCost()
    {
        Core core = new Core();
        BagelInventory inventory = new BagelInventory();
        OrderManager orderManager = new OrderManager();

        core.Add("BGLP");
        core.Add("BGLO");

        double expectedTotalCost = inventory.GetCost("BGLP") + inventory.GetCost("BGLO");
        double actualTotalCost = orderManager.GetTotalCost(core.Basket, core.BagelInventory);

        Assert.That(actualTotalCost, Is.EqualTo(expectedTotalCost));
    }





    [Test]
    public void GetFillingsCost()
    {
        BagelInventory inventory = new BagelInventory();
        double cost = inventory.GetFillingsCost(new string[] { "FILB", "FILC" });
        Assert.That(cost, Is.EqualTo(0.24));

    }

}