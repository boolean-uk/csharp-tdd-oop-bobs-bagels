using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using exercise.main.Inventory;



namespace exercise.tests.Inventory;

public class Tests
{
    Bagel _bagel;
    Item _coffee;
    Filling _filling;
    Item Plain;
    Item Egg;
    

    [SetUp]

    public void Setup()
    {
        _bagel = new Bagel("BGLE", 0.49, main.Inventory.Type.Bagel, "Everything");
        _coffee = new Item("COFB", 0.99, main.Inventory.Type.Coffee, "Black");
        _filling = new Filling("FILE", 0.12, main.Inventory.Type.Filling, "Egg");
        Plain = new Bagel("BGLP", 0.39, main.Inventory.Type.Bagel, "Plain");
        Egg = new Filling("FILE", 0.12, main.Inventory.Type.Filling, "Egg");

    }


    [Test]


    //First test to test if you can add items. The test fullfills the 1st and 8th user story
   //as you can add the filling to the bagel individually.
    public void FirstTest()
    {
        //Testing to see if an item gets added.
        Basket basket = new Basket(20);

        basket.AddItem(_bagel);

        Assert.That(basket.Items.Count() == 1);

        //Doublechecking
        basket.AddItem(_coffee);

        Assert.That(basket.Items.Count() == 2);

        //Triplecheck :)
        basket.AddItem(_filling);

        Assert.That(basket.Items.Count() == 3);


    }

    //Next, removing an item
    [Test]
    public void SecondTest()
    {

        Basket basket = new Basket(10);

        basket.AddItem(_bagel);
        basket.AddItem(_coffee);
        basket.AddItem(_filling);

        basket.RemoveItem(_bagel);

        Assert.That(basket.Items.Count() == 2);
    }


    //Checking if you can't add more items than basket size
    [Test]
    public void ThirdTest()
    {
        Basket basket = new Basket(2);

        basket.AddItem(_bagel);
        basket.AddItem(_coffee);
        basket.AddItem(_filling);

        Assert.That(basket.Items.Last() != _filling);
    }


    //Changing basket size
    [Test]
    public void FourthTest()
    {
        Basket basket = new Basket(1);

        basket.changeBasketSize(10);

        Assert.That(basket._capacity == 10);
    }


    //Checking if the item never was in the basket.
    [Test]
    public void FifthTest()
    {
        Basket basket = new Basket(3);

        basket.AddItem(_bagel);
        basket.AddItem(_coffee);

        bool exists = basket.RemoveItem(_filling);

        Assert.That(exists == false);
    }

    //Testing the TotalCost method
    [Test]
    public void SixthTest()
    {
        Basket basket = new Basket(3);

        basket.AddItem(_bagel);
        basket.AddItem(_coffee);
        basket.AddItem(_filling);

        double total = basket.TotalCost();

        Assert.That(total == 1.6d);
    }

    //Checking if PriceOfItem works properly. 
    [Test]

    public void SeventhTest()
    {
        Basket basket = new Basket(7);

        basket.AddItem(_bagel);
        basket.AddItem(_coffee);
        basket.AddItem(_filling);

        string price = basket.PriceOfItem(Plain);

        Assert.That(price != "No such item in inventory");

    }


    //Attempting to check the price of a filling before i add it to my bagel.
    [Test]

    public void NinthTest()
    {
        Basket basket = new Basket(6);
        
        basket.AddItem(_bagel);
        //I want to check the price before adding the filling to my list.
        string price = basket.PriceOfItem(Egg);

        basket.AddItem(Egg);
        basket.AddItem(_coffee);

        Assert.That(price == "Price of item: 0,12");
    }

    [Test]

    public void ReceiptTest()
    {
        Basket basket = new Basket(3);

        basket.AddItem(_bagel);
        basket.AddItem(_coffee);
        basket.AddItem(_filling);

        basket.WriteReceipt();

        Assert.That(basket.WriteReceipt !=  null);
    }
    

    
}