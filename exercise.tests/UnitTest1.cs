namespace exercise.tests;
using exercise.main;

public class Tests
{
    // Bagel creation test cases
    [TestCase("BGLO", 0.49, "Bagel", "Onion")]
    public void MakeBagelTest(string sku, double price, string name, string variant)
    {
        //arrange
        Bagel bagel = new Bagel (sku, price, name, variant);
        string expected = bagel.PrintBagel();

        //ChosenItem chosenItem = new ChosenItem (); If I make the class static and its methods, I dont need to instance it everytime

        //act
        Bagel testBagel = ChosenItem.MakeBagel(sku, price, name, variant);

        //assert
        Assert.IsTrue(expected == testBagel.PrintBagel());

    }
}