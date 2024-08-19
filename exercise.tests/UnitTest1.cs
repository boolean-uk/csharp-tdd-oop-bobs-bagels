namespace exercise.tests;
using exercise.main;
using NUnit.Framework.Internal;
using System.Security.Cryptography;

public class Tests
{
    // Bagel creation test cases
    // Bagel without filling
    [TestCase("BGLO", 0.49, "Bagel", "Onion", "")]
    public void MakeBagelTest(string sku, double price, string name, string variant, string filling)
    {
        //arrange
        Bagel bagel = new Bagel (sku, price, name, variant, filling);
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
        Basket Basket = new Basket ();
        Bagel NewBagel = new Bagel("BGLO", 0.49, "Bagel", "Onion", "");

        Basket.AddToBasket(NewBagel);

        bool expected = true;
        bool result = Basket.BasketItems.Contains(NewBagel);

        Assert.IsTrue(result);
    }

    //Bagel with 1 filling
   [TestCase("BGLO", 0.49, "Bagel", "Onion", "", "FILB", 0.12, "Filling", "Bacon")]
    public void MakeBagelTestWithFilling(string sku, double price, string name, string variant, string filling, string fillingsku, double fillingprice, string fillingname, string fillingvariant)
    {
        // arrange
        Basket Basket = new Basket ();
        Bagel Bagel = new Bagel(sku, price, name, variant, filling);

        List<Filling> fillings = new List<Filling>();
        Filling Bacon = new Filling(fillingsku, fillingprice, fillingname, fillingvariant);
        fillings.Add(Bacon);

        Bagel TestBagel = new Bagel(sku, price, name, variant, filling);
        TestBagel.Filling = fillingvariant;

        string expected = $"{sku}, {price}\n{name}, {variant}\nWith: {TestBagel.Filling} ";

        // act
        Bagel filledBagel = ChosenItem.AddFillings(Bagel, fillings);
        Basket.AddToBasket(filledBagel);

        string result = Basket.PrintBasket();

        Assert.IsTrue(expected == result);
    }

    //Bagel with several fillings
    [TestCase("BGLO", 0.49, "Bagel", "Onion", "", "FILB", 0.12, "Filling", "Bacon", "FILE", 0.12, "Filling", "Egg")]
    public void MakeBagelTestWithSeveralFillings(string sku, double price, string name, string variant, string filling, string fillingsku, double fillingprice, string fillingname, string fillingvariant, string fillingsku2, double fillingprice2, string fillingname2, string fillingvariant2)
    {
        // arrange
        Basket Basket = new Basket();
        Bagel Bagel = new Bagel(sku, price, name, variant, filling);

        List<Filling> fillings = new List<Filling>();
        Filling Bacon = new Filling(fillingsku, fillingprice, fillingname, fillingvariant);
        Filling Egg = new Filling(fillingsku2, fillingprice2, fillingname2, fillingvariant2);
        fillings.Add(Bacon);
        fillings.Add(Egg);

        Bagel TestBagel = new Bagel(sku, price, name, variant, filling);
        TestBagel.Filling = $"{fillingvariant} {fillingvariant2}";

        string expected = $"{sku}, {price}\n{name}, {variant}\nWith: {TestBagel.Filling} ";

        // act
        Bagel filledBagel = ChosenItem.AddFillings(Bagel, fillings);
        Basket.AddToBasket(filledBagel);

        string result = Basket.PrintBasket();

        Assert.IsTrue(expected == result);
    }

    //Basket total amount Test
    [Test]
    public void BasketTotalTest()
    {
        Basket ThisBasket = new Basket();

        Bagel PlainBagel = new Bagel("BGLO", 0.49, "Bagel", "Onion", "");
        Bagel BaconBagel = new Bagel("BGLO", 0.49, "Bagel", "Onion", "");

        List<Filling> fillings = new List<Filling>();
        Filling Bacon = new Filling("FILB", 0.12, "Filling", "Bacon");
        Filling Egg = new Filling("FILE", 0.12, "Filling", "Egg");

        Bagel FilledBaconBagel = ChosenItem.AddFillings(BaconBagel, fillings);

        ThisBasket.AddToBasket (FilledBaconBagel);
        ThisBasket.AddToBasket(PlainBagel);

        double expected = 1.22;

        double result = ThisBasket.BasketTotal();

        Assert.IsTrue(expected == result);
    }

}