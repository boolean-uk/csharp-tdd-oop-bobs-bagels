using exercise.main;
using NuGet.Frameworks;

namespace exercise.tests;
public class Tests
{

    [Test]
    public void TestIsFull()
    {
        //SetUp
        Basket basket = new Basket();
        basket.Capacity = 0;

        //Execute
        //Verify

        Assert.IsTrue(basket.IsFull());
    }    
    
    [Test]
    public void TestIsNotFull()
    {
        //SetUp
        Basket basket = new Basket();
        basket.Capacity = 10;

        //Execute
        //Verify

        Assert.IsFalse(basket.IsFull());
    }


    [Test]
    public void TestTotalCost()
    {
        //SetUp
        Basket basket = new Basket();
        basket.Capacity = 10;
        InventoryProducts bagelOnion = new InventoryProducts("BGLO", 0.49d, "Bagel", "Onion");
        InventoryProducts bagelSesame = new InventoryProducts("BGLS", 0.49d, "Bagel", "Sesame");
        basket.Items.Add(bagelOnion);
        basket.Items.Add(bagelSesame);


        //Execute
        double result  = basket.TotalCost();
        //Verify

        Assert.That(result == (bagelSesame.Price+bagelOnion.Price) );
    }

}