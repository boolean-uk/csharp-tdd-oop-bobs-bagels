
using exercise.main;

namespace exercise.tests;


public class Tests
{
    Inventory inventory;
    Basket basket;

    [SetUp]
    public void Setup()
    {
        inventory = new Inventory();
        basket = new Basket();

        inventory.CreateNewItem("Bagle", "BGLO", "Onion", 0.49f);
        inventory.CreateNewItem("Bagle", "BGLP", "Plain", 0.39f);
        inventory.CreateNewItem("Bagle", "BGLE", "Everything", 0.49f);
        inventory.CreateNewItem("Bagle", "BGLS", "Sesame", 0.49f);
        inventory.CreateNewItem("Coffee", "COFB", "Black", 0.99f);
        inventory.CreateNewItem("Coffee", "COFW", "White", 1.19f);
        inventory.CreateNewItem("Coffee", "COFC", "Capuccino", 1.29f);
        inventory.CreateNewItem("Coffee", "COFL", "Latte", 1.29f);
        inventory.CreateNewItem("Filling", "FILB", "Bacon", 0.12f);
        inventory.CreateNewItem("Filling", "FILE", "Egg", 0.12f);
        inventory.CreateNewItem("Filling", "FILC", "Cheese", 0.12f);
        inventory.CreateNewItem("Filling", "FILX", "Cream Cheese", 0.12f);
        inventory.CreateNewItem("Filling", "FILS", "Smoked Salmon", 0.12f);
        inventory.CreateNewItem("Filling", "FILH", "Ham", 0.12f);
        
    }

    [Test]
    public void Test1()
    {
        //InventoryTest GetItem()
        Item expectedItem = new Item("Bagle", "BGLE", "Everything", 0.49f);

        Item testItem = inventory.GetItem("BGLE");

        Assert.That(expectedItem, Is.EqualTo(testItem));
        
    }

    [Test]
    public void Test2()
    {
        //ItemTest GetTotalItemCost()

        float expectedCost = 0.73f;

        
        basket.AddItemToBasket("BGLP");
        basket.AddFillingToBagle(basket.GetItemFromBasket("BGLP"),"FILB");
        basket.AddFillingToBagle(basket.GetItemFromBasket("BGLP"),"FILH");
        Item testItem = basket.GetItemFromBasket("BGLP");
        float testCost = testItem.GetTotalItemCost();

        Assert.That(testCost, Is.EqualTo(expectedCost));    

    }

    [Test]
    public void Test3()
    {
        // BasketTest AddItemToBasket() can add to basket
        string expectedString = new string("Capuccino Coffee for: 1.29 was added to the basket");

        string testString = basket.AddItemToBasket("COFC");

        Assert.That(testString, Is.EqualTo(expectedString));

    }

    [Test]
    public  void Test4()
    {
        // BasketTest AddItemToBasket() wrong itemID

        string expectedString = new string("COFF is not a real itemID");

        string testString = basket.AddItemToBasket("COFF");

        Assert.That(testString, Is.EqualTo(expectedString));
    }

    [Test]
    public void Test5()
    {
        // BasketTest AddItemToBasket() baket is full
        string expectedString = new string("Basket is full! did not add Capuccino Coffee for: 1.29 to the basket");

        string testString = basket.AddItemToBasket("COFC");

        Assert.That(testString, Is.EqualTo(expectedString));
    }
    
    [Test]
    public void Test6()
    {
        // BasketTest RemoveItemFromBasket() removed item

        string expectedString = new string("Capuccino Coffee for: 1.29 was removed from basket");

        basket.AddItemToBasket("COFC");

        string testString = basket.RemoveItemFromBasket("COFC");

        Assert.That(testString, Is.EqualTo(expectedString));
    }

    [Test]
    public void Test7()
    {
        // BasketTest RemoveItemFromBasket() item of itemID not in basket.

        string expectedString = new string("No item with ID: COFC found in basket.");

        string testString = basket.RemoveItemFromBasket("COFC");

        Assert.That(testString, Is.EqualTo(expectedString));
    }

    [Test]
    public void Test8()
    {
        // BasketTest ChangeBasketSize() 
        string expectedString = new string("Basket size was changed from 4 to 6");

        string testString = basket.ChangeBasketSize(6);

        Assert.That(testString, Is.EqualTo(expectedString));
    }


    [Test]
    public void Test9()
    {
        // BasketTest GetBasketCost()
        string expectedString = new string("the Cost for all items in the basket is: 2.29");

        basket.AddItemToBasket("BGLE");
        basket.AddItemToBasket("COFC");
        basket.AddItemToBasket("BGLP");
        basket.AddFillingToBagle(basket.GetItemFromBasket("BGLP"), "FILB");

        string testString = basket.GetBasketCost();

        Assert.That(testString, Is.EqualTo(expectedString));
    }

    [Test] public void Test10() 
    {
        //BasketTest GetItemCost
        string expectedString = new string("The Plain Bagle costs: 0.39");
        basket.AddItemToBasket("BGLP");

        string testString = basket.GetItemCost("BGLP");

        Assert.That(testString, Is.EqualTo(expectedString));
    }
    [Test] public void Test11()
    {
        //BasketTest GetItemFromBasket
        Item ExpectedItem = inventory.GetItem("BGLP");
        basket.AddItemToBasket("BGLP");
        Item testItem = basket.GetItemFromBasket("BGLP");

        Assert.That(testItem.Name, Is.EqualTo(ExpectedItem.Name));
        Assert.That(testItem.Variant, Is.EqualTo(ExpectedItem.Variant));
        Assert.That(testItem.itemID, Is.EqualTo(ExpectedItem.itemID));
        Assert.That(testItem.Cost, Is.EqualTo(ExpectedItem.Cost));
    }
    
    [Test] public void Test12() 
    {
        //BasketTest AddFillingToBagle()
        string expectedString = new string("Bacon Filling was added to the Plain Bagle");
        basket.AddItemToBasket("BGLP");

        string testString = basket.AddFillingToBagle(basket.GetItemFromBasket("BGLP"), "FILB");

        Assert.That(testString, Is.EqualTo(expectedString));
    }


    [Test]
    public void Test13()
    {
        //BasketTest AddFillingToBagle()
        string expectedString = new string("FILP is not a real itemID");

        basket.AddItemToBasket("BGLP");

        string testString = basket.AddFillingToBagle(basket.GetItemFromBasket("BGLP"), "FILP"); //intentionaly incorrect ID


        Assert.That(testString, Is.EqualTo(expectedString));

    }

    

}

