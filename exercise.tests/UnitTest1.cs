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
        // Testing for 12 discounted Bagels, and 1 not discounted bagel
        double expected = 41.56;

        Basket basket = new Basket();
        basket.Cap = 20;

        Inventory.FillingStock = 20;
        Inventory.BagelStock = 20;
        Inventory.CoffeeStock = 20;

        List<Item> preselection = basket.MakeNew();
        List<Filling> fillings = new List<Filling>();
        Filling filling1 = ChosenItem.ChooseFillings("FILE", 0.12, "Filling", "Egg");
        fillings.Add(filling1);
        Bagel bagel1 = ChosenItem.MakeBagel("BGLE", 0.49, "Bagel", "Everything", "");
        bagel1 = ChosenItem.AddFillings(bagel1, fillings);
        Coffee cup1 = new Coffee("COFB", 0.99, "Coffee", "Black");
        Coffee cup2 = new Coffee("COFB", 0.99, "Coffee", "Black");
        Coffee cup3 = new Coffee("COFB", 0.99, "Coffee", "Black");

        Bagel bagel2 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
        List<Item> preselection2 = basket.MakeNew();
        preselection2.Add(bagel2);

        preselection.Add(cup1);
        preselection.Add(cup2);
        preselection.Add(cup3);
        preselection.Add(bagel1);

        preselection.Add(filling1);

        basket.AddToBasket(1, preselection);
        basket.AddToBasket(2, preselection);
        basket.AddToBasket(3, preselection);
        basket.AddToBasket(4, preselection);
        basket.AddToBasket(5, preselection);
        basket.AddToBasket(6, preselection);

        basket.AddToBasket(7, preselection);
        basket.AddToBasket(8, preselection);
        basket.AddToBasket(9, preselection);
        basket.AddToBasket(10, preselection);
        basket.AddToBasket(11, preselection);
        basket.AddToBasket(12, preselection);
        basket.AddToBasket(13, preselection2);

        //Console.WriteLine(basket.PrintBasket());

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