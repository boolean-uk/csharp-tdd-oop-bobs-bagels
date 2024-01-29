
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
        inventory.CreateNewItem("Bagle",  "BGLO", "Onion",        0.49f);
        inventory.CreateNewItem("Bagle",  "BGLP", "Plain",        0.39f);
        inventory.CreateNewItem("Bagle",  "BGLE", "Everything",   0.49f);
        inventory.CreateNewItem("Bagle",  "BGLS", "Sesame",       0.49f);
        inventory.CreateNewItem("Coffee", "COFB", "Black",        0.99f);
        inventory.CreateNewItem("Coffee", "COFW", "White",        1.19f);
        inventory.CreateNewItem("Coffee", "COFC", "Capuccino",    1.29f);
        inventory.CreateNewItem("Coffee", "COFL", "Latte",        1.29f);
        inventory.CreateNewItem("Filling","FILB", "Bacon",        0.12f);
        inventory.CreateNewItem("Filling","FILE", "Egg",          0.12f);
        inventory.CreateNewItem("Filling","FILC", "Cheese",       0.12f);
        inventory.CreateNewItem("Filling","FILX", "Cream Cheese", 0.12f);
        inventory.CreateNewItem("Filling","FILS", "Smoked Salmon",0.12f);
        inventory.CreateNewItem("Filling","FILH", "Ham",          0.12f);


    }
    #region Inventory Tests
    //inventory Tests

    [Test]
    public void Test1()
    {
        //InventoryTest GetItem()
        Item expectedItem = new Item("Bagle", "BGLE", "Everything", 0.49f);

        Item testItem = inventory.GetItem("BGLE");

        Assert.That(testItem.Name, Is.EqualTo(expectedItem.Name));
        Assert.That(testItem.Variant, Is.EqualTo(expectedItem.Variant));
        Assert.That(testItem.ItemID, Is.EqualTo(expectedItem.ItemID));
        Assert.That(testItem.Cost, Is.EqualTo(expectedItem.Cost));

    }

    [Test] public void Test2() 
    {
        // InventoryTest ContainsItem()
        Item testItem = new Item("Bagle", "BGLE", "Everything", 0.49f);

        bool test = inventory.ContainsItem("BGLE");

        Assert.That(test, Is.EqualTo(true));
    }

    #endregion


    #region ItemTests
    // ItemTests
    [Test]
    public void Test3()
    {
        //ItemTest (Bagle) GetTotalItemCost() && AddFillingToBagle()

        float expectedCost = 0.63f;


        basket.AddItemToBasket("BGLP", inventory);
        Bagle test = (Bagle)basket.GetItemFromBasket("BGLP");
        test.AddFillingToBagle("FILB", inventory); 
        test.AddFillingToBagle("FILH", inventory);

        Bagle test2 = (Bagle)basket.GetItemFromBasket("BGLP");
        Assert.That(test2.BagleFillings.Count, Is.EqualTo(2));


        float testCost = test.GetItemCost();

        Assert.That(testCost, Is.EqualTo(expectedCost));
        

    }

    #endregion

    #region BasketTests

    [Test]
    public void Test4()
    {
        // BasketTest AddItemToBasket() can add to basket
        string expectedString = new string("Capuccino Coffee for: 1,29 was added to the basket");

        string testString = basket.AddItemToBasket("COFC", inventory);

        Assert.That(testString, Is.EqualTo(expectedString));

    }

    [Test]
    public void Test5()
    {
        // BasketTest AddItemToBasket() wrong itemID

        string expectedString = new string("COFF is not a real itemID");

        string testString = basket.AddItemToBasket("COFF",inventory);

        Assert.That(testString, Is.EqualTo(expectedString));
    }

    [Test]
    public void Test6()
    {
        // BasketTest AddItemToBasket() baket is full
        string expectedString = new string("Basket is full! did not add Capuccino Coffee for: 1,29 to the basket");

        basket.AddItemToBasket("COFC", inventory);
        basket.AddItemToBasket("COFC", inventory);
        basket.AddItemToBasket("COFC", inventory);
        basket.AddItemToBasket("COFC", inventory);
        string testString = basket.AddItemToBasket("COFC",inventory);

        Assert.That(testString, Is.EqualTo(expectedString));
    }

    [Test]
    public void Test7()
    {
        // BasketTest RemoveItemFromBasket() removed item

        string expectedString = new string("Capuccino Coffee for: 1,29 was removed from basket");

        basket.AddItemToBasket("COFC", inventory);

        string testString = basket.RemoveItemFromBasket("COFC");

        Assert.That(testString, Is.EqualTo(expectedString));
    }

    [Test]
    public void Test8()
    {
        // BasketTest RemoveItemFromBasket() item of itemID not in basket.

        string expectedString = new string("item with itemID COFC was not found in basket");

        basket.AddItemToBasket("BGLP", inventory);
        string testString = basket.RemoveItemFromBasket("COFC");

        Assert.That(testString, Is.EqualTo(expectedString));
    }

    [Test]
    public void Test9()
    {
        // BasketTest ChangeBasketSize() 
        string expectedString = new string("Basket size was changed from 4 to 6");

        string testString = basket.ChangeBasketSize(6);

        Assert.That(testString, Is.EqualTo(expectedString));
    }


    [Test]
    public void Test10()
    {
        // BasketTest GetBasketCost()
        string expectedString = new string("the Cost for all items in the basket is: 2,29");

        basket.AddItemToBasket("BGLE",inventory);
        basket.AddItemToBasket("COFC",inventory);
        basket.AddItemToBasket("BGLP",inventory);
        Bagle testBagle = (Bagle)basket.GetItemFromBasket("BGLP");
        testBagle.AddFillingToBagle("FILB",inventory);  

        string testString = basket.GetBasketCost();

        Assert.That(testString, Is.EqualTo(expectedString));
    }

    [Test]
    public void Test11()
    {
        //BasketTest GetItemCost
        string expectedString = new string("The Plain Bagle costs: 0,39");
        basket.AddItemToBasket("BGLP",  inventory);

        string testString = basket.GetItemCost("BGLP");

        Assert.That(testString, Is.EqualTo(expectedString));
    }

    [Test]
    public void Test12()
    {
        //BasketTest GetItemCost
        string expectedString = new string("No item with ID: COFF found in basket");
        basket.AddItemToBasket("BGLP", inventory);

        string testString = basket.GetItemCost("COFF");

        Assert.That(testString, Is.EqualTo(expectedString));
    }
    #endregion




    //[Test]
    //public void Test11()
    //{
    //    //BasketTest GetItemFromBasket
    //    Item ExpectedItem = inventory.GetItem("BGLP");
    //    basket.AddItemToBasket("BGLP");
    //    Item testItem = basket.GetItemFromBasket("BGLP");

    //    Assert.That(testItem.Name, Is.EqualTo(ExpectedItem.Name));
    //    Assert.That(testItem.Variant, Is.EqualTo(ExpectedItem.Variant));
    //    Assert.That(testItem.itemID, Is.EqualTo(ExpectedItem.itemID));
    //    Assert.That(testItem.Cost, Is.EqualTo(ExpectedItem.Cost));
    //}

    //[Test]
    //public void Test12()
    //{
    //    //BasketTest AddFillingToBagle()
    //    string expectedString = new string("Bacon Filling was added to the Plain Bagle");
    //    basket.AddItemToBasket("BGLP");

    //    string testString = basket.AddFillingToBagle("FILB"); //basket.GetItemFromBasket("BGLP"),

    //    Assert.That(testString, Is.EqualTo(expectedString));
    //}


    //[Test]
    //public void Test13()
    //{
    //    //BasketTest AddFillingToBagle()
    //    string expectedString = new string("FILP is not a real itemID");

    //    basket.AddItemToBasket("BGLP");

    //    string testString = basket.AddFillingToBagle("FILP"); //intentionaly incorrect ID     basket.GetItemFromBasket("BGLP"), 


    //    Assert.That(testString, Is.EqualTo(expectedString));

    //}



}

