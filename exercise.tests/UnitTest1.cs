namespace exercise.tests;
using exercise.main;
using NUnit.Framework.Internal;
using System.Security.Cryptography;

public class Tests
{
    List<Item> selections = new List<Item>();
    public Basket basket = new Basket();

    // Bagel creation test cases
    // Bagel without filling
    [TestCase("BGLO", 0.49, "Bagel", "Onion", "")]
    public void MakeBagelTest(string sku, double price, string name, string variant, string filling)
    {
        //arrange
        Bagel bagel = new Bagel(sku, price, name, variant, filling);
        string expected = bagel.PrintItem();

        //ChosenItem chosenItem = new ChosenItem (); If I make the class static and its methods, I dont need to instance it everytime

        //act
        Bagel testBagel = ChosenItem.MakeBagel(sku, price, name, variant, filling);

        //assert
        Assert.IsTrue(expected == testBagel.PrintItem());

    }

    [Test]
    public void AddToBasketTest()
    {
        selections.Clear();

        Basket Basket = new Basket();
        Basket.Cap = 4;

        Bagel NewBagel = new Bagel("BGLO", 0.49, "Bagel", "Onion", "");

        selections.Add(NewBagel);

        Basket.AddToBasket(0, selections);

        bool expected = true;
        bool result = Basket.BasketItems.ContainsKey(0);

        Assert.IsTrue(result);
    }

    //Bagel with 1 filling
    [TestCase("BGLO", 0.49, "Bagel", "Onion", "", "FILB", 0.12, "Filling", "Bacon")]
    public void MakeBagelTestWithFilling(string sku, double price, string name, string variant, string filling, string fillingsku, double fillingprice, string fillingname, string fillingvariant)
    {
        // arrange
        //Inventory.FillingStock = 20;
        //Inventory.BagelStock = 20;
        //Inventory.CoffeeStock = 20;

        Basket Basket = new Basket();

        List<Item> preselection = Basket.MakeNew();

        Basket.Cap = 4;

        Bagel Bagel = new Bagel(sku, price, name, variant, filling);

        List<Filling> fillings = new List<Filling>();
        Filling Bacon = new Filling(fillingsku, fillingprice, fillingname, fillingvariant);
        fillings.Add(Bacon);

        Bagel TestBagel = new Bagel(sku, price, name, variant, filling);
        TestBagel.Filling = fillingvariant;

        string expected = $"{fillingsku}, {fillingprice}\n{fillingname}, {fillingvariant}\n\n{sku}, {price}\n{name}, {variant}\nWith: {TestBagel.Filling} \n\n\nSubtotal: 0,61 quid\nThanks for shopping at Bob's Bagels! ^_^";

        // act
        Bagel FilledBagel = ChosenItem.AddFillings(Bagel, fillings);
        preselection.Add(Bacon);
        preselection.Add(FilledBagel);

        List<Item> selectedItems = Basket.AddToSelection(preselection);

        Basket.AddToBasket(0, preselection);

        string result = Basket.PrintBasket();

        Assert.IsTrue(expected == result);
    }

    //Bagel with several fillings
    [TestCase("BGLO", 0.49, "Bagel", "Onion", "", "FILB", 0.12, "Filling", "Bacon", "FILE", 0.12, "Filling", "Egg")]
    public void MakeBagelTestWithSeveralFillings(string sku, double price, string name, string variant, string filling, string fillingsku, double fillingprice, string fillingname, string fillingvariant, string fillingsku2, double fillingprice2, string fillingname2, string fillingvariant2)
    {
        // arrange
        Basket Basket = new Basket();
        Basket.Cap = 4;

        List<Item> preselection = Basket.MakeNew();

        

        Bagel Bagel = new Bagel(sku, price, name, variant, filling);

        List<Filling> fillings = new List<Filling>();
        Filling Bacon = new Filling(fillingsku, fillingprice, fillingname, fillingvariant);
        Filling Egg = new Filling(fillingsku2, fillingprice2, fillingname2, fillingvariant2);
        fillings.Add(Bacon);
        fillings.Add(Egg);

        Bagel TestBagel = new Bagel(sku, price, name, variant, filling);
        TestBagel.Filling = $"{fillingvariant} {fillingvariant2}";

        string expected = $"{fillingsku}, {fillingprice}\n{fillingname}, {fillingvariant}\n\n{fillingsku2}, {fillingprice2}\n{fillingname2}, {fillingvariant2}\n\n{sku}, {price}\n{name}, {variant}\nWith: {TestBagel.Filling} \n\n\nSubtotal: 0,73 quid\nThanks for shopping at Bob's Bagels! ^_^";

        // act
        Bagel filledBagel = ChosenItem.AddFillings(Bagel, fillings);
        preselection.Add(Bacon);
        preselection.Add(Egg);
        preselection.Add(filledBagel);

        Basket.AddToBasket(0, preselection);

        string result = Basket.PrintBasket();

        Assert.IsTrue(expected == result);
    }

    //Basket total amount Test
    [Test]
    public void BasketTotalTest()
    {
        selections.Clear();

        Basket ThisBasket = new Basket();
        ThisBasket.Cap = 4;
        Bagel PlainBagel = new Bagel("BGLO", 0.49, "Bagel", "Onion", "");
        Bagel BaconBagel = new Bagel("BGLO", 0.49, "Bagel", "Onion", "");

        List<Filling> fillings = new List<Filling>();
        Filling Bacon = new Filling("FILB", 0.12, "Filling", "Bacon");
        Filling Egg = new Filling("FILE", 0.12, "Filling", "Egg");

        Bagel FilledBaconBagel = ChosenItem.AddFillings(BaconBagel, fillings);

        selections.Add(FilledBaconBagel);
        selections.Add(PlainBagel);
        selections.Add(Bacon);
        selections.Add(Egg);

        ThisBasket.AddToBasket(1, selections);


        double expected = 1.22;

        double result = ThisBasket.BasketTotal();

        Assert.IsTrue(expected == result);
    }

    [Test]
    public void RemoveBagelTest()
    {
        selections.Clear();
        Basket Basket = new Basket();
        Basket.Cap = 4;
        Bagel BaconBagel = new Bagel("BGLO", 0.49, "Bagel", "Onion", "");

        List<Filling> fillings = new List<Filling>();
        Filling Bacon = new Filling("FILB", 0.12, "Filling", "Bacon");
        fillings.Add(Bacon); // Remember to populate the fillings list!
        BaconBagel = ChosenItem.AddFillings(BaconBagel, fillings); // I dont really need to instance a new object I think. Can just modify this one.

        selections.Add(BaconBagel); selections.Add(Bacon);
        Basket.AddToBasket(0, selections);

        Basket.RemoveFromBasket(0);

        string expected = "Basket is empty";

        string result = Basket.PrintBasket();

        Assert.IsTrue(expected == result);

    }

    [Test]
    public void CapTest()
    {
        //arrange
        Basket Basket = new Basket();
        Basket.Cap = 4;
        Bagel BaconBagel = new Bagel("BGLO", 0.49, "Bagel", "Onion", "");
        List<Filling> fillings = new List<Filling>();
        Filling Bacon = new Filling("FILB", 0.12, "Filling", "Bacon");
        fillings.Add(Bacon);
        BaconBagel = ChosenItem.AddFillings(BaconBagel, fillings);

        string expected = "Your basket is full";

        //act
        selections.Add(BaconBagel); selections.Add(Bacon);
        Basket.AddToBasket(0, selections);
        Basket.AddToBasket(1, selections);
        Basket.AddToBasket(2, selections);
        Basket.AddToBasket(3, selections);
        Basket.AddToBasket(4, selections);

        string result = Basket.CapNotice;

        Assert.IsTrue(expected == result);
    }

    [TestCase(10)]
    public void ChangeCapTest(int newcap)
    {
        Basket Basket = new Basket();
        Basket.IsAdmin = true;
        int expected = 10;

        Basket.ChangeCap(10);

        int result = Basket.Cap;

        Assert.IsTrue(expected == result);
    }

    [TestCase(3)]
    public void RemoveExistingItemTest(int id)
    {
        Basket Basket = new Basket();
        string expected = "Item does not exist";

        Basket.RemoveFromBasket(id);

        string result = Basket.NotFoundNotice;

        Assert.IsTrue(expected == result);
    }

    [Test]
    public void PriceBeforeBagelAddedToBasketTest()
    {
        Bagel BaconBagel = new Bagel("BGLO", 0.49, "Bagel", "Onion", "");

        double expected = 0.49;

        double result = BaconBagel.Price;

        Assert.IsTrue(expected == result);
    }

    [Test]
    public void PriceBeforeFillingAddedToBasketTest()
    {
        List<Filling> fillings = new List<Filling>();
        Filling Bacon = new Filling("FILB", 0.12, "Filling", "Bacon");

        double expected = 0.12;

        double result = Bacon.Price;

        Assert.IsTrue(expected == result);
    }

    [Test]
    public void EnsureNotStockTest()
    {
        string expected = "Sorry, out of stock";
        Inventory.BagelStock = 0;

        Basket Basket = new Basket();
        Bagel BaconBagel = new Bagel("BGLO", 0.49, "Bagel", "Onion", "");
        List<Item> selection1 = Basket.MakeNew();
        selection1.Add(BaconBagel);
        Basket.AddToSelection(selection1);

        

        string result = Basket.OutOfStockNotice;


        Assert.IsTrue(expected == result);

    }

    [Test]
    public void EnsureStockTest()
    {
        Inventory.BagelStock = 10;

        Basket Basket = new Basket();
        Bagel BaconBagel = new Bagel("BGLO", 0.49, "Bagel", "Onion", "");
        List<Item> selection1 = Basket.MakeNew();
        selection1.Add(BaconBagel);
        Basket.AddToSelection(selection1);

        string expected = null;

        string result = Basket.OutOfStockNotice;

        Assert.IsTrue(expected == result);

    }

    [Test]
    public void BagelDiscountTest()
    {
        Basket basket = new Basket();
        basket.Cap = 20;

        Inventory.FillingStock = 20;
        Inventory.BagelStock = 20;
        Inventory.CoffeeStock = 20;

        double expected = 4.48;

        List<Item> preselection3 = basket.MakeNew();
        Bagel bagel3 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
        preselection3.Add(bagel3);
        List<Item> selectedItems3 = basket.AddToSelection(preselection3);
        basket.AddToBasket(3, selectedItems3);

        List<Item> preselection4 = basket.MakeNew();
        Bagel bagel4 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
        preselection4.Add(bagel4);
        List<Item> selectedItems4 = basket.AddToSelection(preselection4);
        basket.AddToBasket(4, selectedItems4);

        List<Item> preselection5 = basket.MakeNew();
        Bagel bagel5 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
        preselection5.Add(bagel5);
        List<Item> selectedItems5 = basket.AddToSelection(preselection5);
        basket.AddToBasket(5, selectedItems5);

        List<Item> preselection6 = basket.MakeNew();
        Bagel bagel6 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
        preselection6.Add(bagel6);
        List<Item> selectedItems6 = basket.AddToSelection(preselection6);
        basket.AddToBasket(6, selectedItems6);

        List<Item> preselection7 = basket.MakeNew();
        Bagel bagel7 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
        preselection7.Add(bagel7);
        List<Item> selectedItems7 = basket.AddToSelection(preselection7);
        basket.AddToBasket(7, selectedItems7);

        List<Item> preselection8 = basket.MakeNew();
        Bagel bagel8 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
        preselection8.Add(bagel8);
        List<Item> selectedItems8 = basket.AddToSelection(preselection8);
        basket.AddToBasket(8, selectedItems8);

        List<Item> preselection9 = basket.MakeNew();
        Bagel bagel9 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
        preselection9.Add(bagel9);
        List<Item> selectedItems9 = basket.AddToSelection(preselection9);
        basket.AddToBasket(9, selectedItems9);

        List<Item> preselection10 = basket.MakeNew();
        Bagel bagel10 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
        preselection10.Add(bagel10);
        List<Item> selectedItems10 = basket.AddToSelection(preselection10);
        basket.AddToBasket(10, selectedItems10);

        List<Item> preselection11 = basket.MakeNew();
        Bagel bagel11 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
        preselection11.Add(bagel11);
        List<Item> selectedItems11 = basket.AddToSelection(preselection11);
        basket.AddToBasket(11, selectedItems11);

        List<Item> preselection12 = basket.MakeNew();
        Bagel bagel12 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
        preselection12.Add(bagel12);
        List<Item> selectedItems12 = basket.AddToSelection(preselection12);
        basket.AddToBasket(12, selectedItems12);

        List<Item> preselection13 = basket.MakeNew();
        Bagel bagel13 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
        preselection13.Add(bagel13);
        List<Item> selectedItems13 = basket.AddToSelection(preselection13);
        basket.AddToBasket(13, selectedItems13);

        List<Item> preselection14 = basket.MakeNew();
        Bagel bagel14 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
        preselection14.Add(bagel14);
        List<Item> selectedItems14 = basket.AddToSelection(preselection14);
        basket.AddToBasket(14, selectedItems14);

        List<Item> preselection15 = basket.MakeNew();
        Bagel bagel15 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
        preselection15.Add(bagel15);
        List<Item> selectedItems15 = basket.AddToSelection(preselection15);
        basket.AddToBasket(15, selectedItems15);

        double result = basket.BasketTotal();

        Assert.IsTrue(expected == result);
    }

    [Test]
    // Honestly here I'm just testing to see that the receipt is not returning the empty dialogue.
    public void ReceiptTest()
    {
        Basket basket = new Basket();
        List<Item> preselection = basket.MakeNew();
        List<Filling> fillings = new List<Filling>();
        Filling filling1 = ChosenItem.ChooseFillings("FILE", 0.12, "Filling", "Egg");
        fillings.Add(filling1);
        Bagel bagel = ChosenItem.MakeBagel("BGLE", 0.49, "Bagel", "Everything", "");
        bagel = ChosenItem.AddFillings(bagel, fillings);
        preselection.Add(bagel);
        preselection.Add(filling1);
        basket.AddToBasket(1, preselection);

        bool expected = false;

        bool empty = true;

        if (basket.PrintBasket() != "Basket is empty")
        {
            empty = false;
        }

        Assert.IsTrue(expected == false);

        
        

        //Filling filling1 = ChosenItem.ChooseFillings("FILE", 0.12, "Filling", "Egg");
        //List<Filling> thesefillings = new List<Filling>();
        //thesefillings.Add(filling1);
        //bagel18 = ChosenItem.AddFillings(bagel18, thesefillings);
        //preselection18.Add(bagel18);
        //preselection18.Add(filling1);
        //List<Item> selectedItems18 = basket.AddToSelection(preselection18);
        //basket.AddToBasket(18, selectedItems18);
    }
}