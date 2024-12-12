using exercise.main;
using NuGet.Frameworks;

namespace exercise.tests;
public class Tests
{
    [Test]
    public void ShouldAddToBasket()
    {
        //SetUp
        Basket basket = new Basket();
        basket.Capacity = 10;
        InventoryProducts bagelOnion = new InventoryProducts("BGLO", 0.49d, "Bagel", "Onion");
        InventoryProducts bagelSesame = new InventoryProducts("BGLS", 0.49d, "Bagel", "Sesame");

        //Execute
        basket.AddToBasket(bagelOnion);

        //Verify
        Assert.IsTrue(basket.Items.Contains(bagelOnion));
    }



    [Test]
    public void ShouldRemoveFromBasket()
    {
        //SetUp
        Basket basket = new Basket();
        basket.Capacity = 10;
        InventoryProducts bagelOnion = new InventoryProducts("BGLO", 0.49d, "Bagel", "Onion");
        InventoryProducts bagelSesame = new InventoryProducts("BGLS", 0.49d, "Bagel", "Sesame");

        //Execute
        basket.Items.Add(bagelSesame);
        basket.Items.Add(bagelOnion);
        basket.RemoveFromBasket(bagelOnion);


        //Verify
        Assert.IsFalse(basket.Items.Contains(bagelOnion));
    }

    [Test]
    public void ShouldChooseFilling()
    {
        //SetUp
        Basket basket = new Basket();
        basket.Capacity = 10;
        InventoryProducts eggFilling = new InventoryProducts("FILE", 0.12d, "Filling", "Egg");

        //Execute
        basket.ChooseFilling(eggFilling);

        //Verify
        Assert.IsTrue(basket.Items.Contains(eggFilling));
    }


    [Test]
    public void ShouldChangeBasketcapacity()
    {
        //SetUp
        Basket basket = new Basket();
        basket.Capacity = 10;


        //Execute
        basket.IsManager = true;
        basket.ChangeBasketCapacity(30);

        //Verify
        Assert.IsTrue(basket.Capacity == 30);
    }

    [Test]
    public void ShouldNotChangeBasketcapacity()
    {
        //SetUp
        Basket basket = new Basket();
        Inventory inventory1 = new Inventory();
        basket.Capacity = 10;


        //Execute
        basket.IsManager = false;
        basket.ChangeBasketCapacity(30);

        //Verify
        Assert.IsTrue(basket.Capacity == 10);
    }
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

        Assert.IsTrue(result == (bagelSesame.Price+bagelOnion.Price) );
    }

}