namespace exercise.tests;
using exercise.main;
using NUnit.Framework.Internal;

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

    // Bagel with filling
    [TestCase("BGLO", 0.49, "Bagel", "Onion", "FILB", 0.12, "Filling", "Bacon")]
    public void MakeBagelTestWithFilling(string sku, double price, string name, string variant, string fillingsku, double fillingprice, string fillingname, string fillingvariant) 
    {

    }

}