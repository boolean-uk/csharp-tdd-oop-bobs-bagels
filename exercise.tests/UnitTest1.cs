namespace exercise.tests;
using exercise.main;

public class Tests
{
    [TestCase("BGLO", 0.49, "Bagel", "Onion")]
    public void MakeBagelTest(string sku, double price, string name, string variant)
    {
        Bagel bagel = new Bagel();
    }
}