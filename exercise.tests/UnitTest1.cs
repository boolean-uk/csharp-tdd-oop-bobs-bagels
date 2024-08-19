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

    //Bagel with filling
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

        string expected = $"{sku}, {price}\n{name}, {variant}\nWith: {TestBagel.Filling}";

        // act
        Bagel filledBagel = ChosenItem.AddFillings(Bagel, fillings);
        Basket.AddToBasket(filledBagel);

        string result = Basket.PrintBasket();

        Assert.IsTrue(expected == result);



    }

}