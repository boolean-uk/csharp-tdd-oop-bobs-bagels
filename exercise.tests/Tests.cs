namespace exercise.tests;
using Boolean.CSharp.Main;
using Newtonsoft.Json.Linq;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestAdd()
    {
        Basket basket = new Basket();

        string orderMessage = basket.AddItem("Bagel Onion", 1);
        Assert.That(orderMessage, Is.EqualTo("Bagel Onion has been added to the basket"));
        orderMessage = basket.AddItem("Bagel Everything", 5);
        Assert.That(orderMessage, Is.EqualTo("Bagel Everything has been added to the basket"));
        orderMessage = basket.AddItem("Coffee Latte", 1);
        Assert.That(orderMessage, Is.EqualTo("Coffee Latte has been added to the basket"));
        orderMessage = basket.AddItem("Coffee Black", 2);
        Assert.That(orderMessage, Is.EqualTo("Coffee Black has been added to the basket"));
        orderMessage = basket.AddItem("Filling Ham", 1);
        Assert.That(orderMessage, Is.EqualTo("Filling Ham has been added to the basket"));

        Assert.That(basket.Baskets.Count, Is.EqualTo(5));
        Assert.That(basket.GetNumItemsInBasket(), Is.EqualTo(10));
    }

    [Test]
    public void TestFullBasket()
    {
        Basket basket = new Basket();

        string orderMessage = basket.AddItem("Bagel Onion", 11);
        Assert.That(orderMessage, Is.EqualTo("There is no room in your basket for this order"));
        Assert.That(basket.Baskets.Count, Is.EqualTo(0));


        orderMessage = basket.AddItem("Bagel Everything", 10);
        Assert.That(orderMessage, Is.EqualTo("Bagel Everything has been added to the basket"));

        orderMessage = basket.AddItem("Bagel Onion", 1);
        Assert.That(orderMessage, Is.EqualTo("There is no room in your basket for this order"));


        Assert.That(basket.Baskets.Count, Is.EqualTo(1));
        Assert.That(basket.GetNumItemsInBasket(), Is.EqualTo(10));
    }

    [Test]
    public void TestRemove()
    {
        Basket basket = new Basket();

        string orderMessage = basket.AddItem("Bagel Everything", 10);
        Assert.That(orderMessage, Is.EqualTo("Bagel Everything has been added to the basket"));

        orderMessage = basket.AddItem("Bagel Onion", 1);
        Assert.That(orderMessage, Is.EqualTo("There is no room in your basket for this order"));

        orderMessage = basket.RemoveItem("Bagel Everything");
        Assert.That(orderMessage, Is.EqualTo("Bagel Everything has been removed from the basket"));


        Assert.That(basket.Baskets.Count, Is.EqualTo(0));
        Assert.That(basket.GetNumItemsInBasket(), Is.EqualTo(0));
    }

    [Test]
    public void TestRemoveNotInBasket()
    {
        Basket basket = new Basket();

        string orderMessage = basket.AddItem("Bagel Everything", 5);
        Assert.That(orderMessage, Is.EqualTo("Bagel Everything has been added to the basket"));

        orderMessage = basket.RemoveItem("Bagel Onion");
        Assert.That(orderMessage, Is.EqualTo("Item was not found in your basket"));


        Assert.That(basket.Baskets.Count, Is.EqualTo(1));
        Assert.That(basket.GetNumItemsInBasket(), Is.EqualTo(5));
    }


    [Test]
    public void TestGetTotalPrice()
    {
        Basket basket = new Basket();

        string orderMessage = basket.AddItem("Bagel Onion", 1);
        Assert.That(orderMessage, Is.EqualTo("Bagel Onion has been added to the basket"));
        orderMessage = basket.AddItem("Bagel Everything", 5);
        Assert.That(orderMessage, Is.EqualTo("Bagel Everything has been added to the basket"));
        orderMessage = basket.AddItem("Coffee Latte", 1);
        Assert.That(orderMessage, Is.EqualTo("Coffee Latte has been added to the basket"));
        orderMessage = basket.AddItem("Coffee Black", 2);
        Assert.That(orderMessage, Is.EqualTo("Coffee Black has been added to the basket"));
        orderMessage = basket.AddItem("Filling Ham", 1);
        Assert.That(orderMessage, Is.EqualTo("Filling Ham has been added to the basket"));

        Assert.That(Math.Round(basket.TotalPrice, 2, MidpointRounding.AwayFromZero), Is.EqualTo(6.33));
    }


    [Test]
    public void TestGetPrices()
    {
        Basket basket = new Basket();

        Assert.That(basket.GetInventory.GetInventory["BGLP"].GetPrice, Is.EqualTo(0.39));
        Assert.That(basket.GetInventory.GetInventory["COFW"].GetPrice, Is.EqualTo(1.19));
        Assert.That(basket.GetInventory.GetInventory["FILC"].GetPrice, Is.EqualTo(0.12));
        Assert.That(basket.GetInventory.GetInventory["COFB"].GetPrice, Is.EqualTo(0.99));
    }


    [Test]
    public void TestChangeBasketCapacity()
    {
        Basket basket = new Basket();

        string orderMessage = basket.AddItem("Bagel Onion", 11);
        Assert.That(orderMessage, Is.EqualTo("There is no room in your basket for this order"));
        Assert.That(basket.Baskets.Count, Is.EqualTo(0));

        basket.Capacity = 25;

        orderMessage = basket.AddItem("Bagel Onion", 15);
        Assert.That(orderMessage, Is.EqualTo("Bagel Onion has been added to the basket"));


        orderMessage = basket.AddItem("Bagel Everything", 5);
        Assert.That(orderMessage, Is.EqualTo("Bagel Everything has been added to the basket"));

        Assert.That(basket.Baskets.Count, Is.EqualTo(2));
        Assert.That(basket.GetNumItemsInBasket(), Is.EqualTo(20));
    }


    [Test]
    public void TestOffMenuOrder()
    {
        Basket basket = new Basket();

        string orderMessage = basket.AddItem("Hot Bagel", 1);
        Assert.That(orderMessage, Is.EqualTo("Im sorry, that is not on the menu"));

        Assert.That(basket.Baskets.Count, Is.EqualTo(0));
        Assert.That(basket.GetNumItemsInBasket(), Is.EqualTo(0));
    }

    [Test]
    public void TestBuildYourOwnBagel()
    {
        Basket basket = new Basket();

        List<string> fillings = new List<string>{ "Filling Ham", "Filling Cheese", "Filling Egg" };

        string orderMessage = basket.AddBagelWithFillings(2, fillings);
        Assert.That(orderMessage, Is.EqualTo("Plain Bagel and chosen Fillings has been added to the basket"));

        Assert.That(basket.Baskets.Count, Is.EqualTo(4));
        Assert.That(basket.GetNumItemsInBasket(), Is.EqualTo(8));
    }



}