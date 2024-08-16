namespace exercise.tests;
using exercise.main;

public class Tests
{
    [TestCase("BGLO", 0.49, "Bagel", "Onion")]
    public void MakeBagelTest(string sku, double price, string name, string variant)
    {
        //arrange
        Bagel bagel = new Bagel (sku, price, name, variant);
        string expected = bagel.PrintBagel();

        ChosenItem chosenItem = new ChosenItem ();

        //act
        Bagel result = chosenItem.MakeBagel(sku, price, name, variant);

        //assert
        Assert.IsTrue(expected == result);




    }
}