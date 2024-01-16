using exercise.main;
using static exercise.main.Core;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void BasketCost()
    {
        Basket basket = new Basket();
        Bagel bagel = new Bagel(BagelVariant.Onion);
        basket.Add(bagel);

        double expected = 0.49;
        double actualCost = basket.Cost();

        Assert.Equals(expected, actualCost);
    }

    [Test]
    public void AddFilling()
    {
        Bagel bagel = new Bagel(BagelVariant.Plain);

        bagel.AddFilling(BagelFilling.Ham);

        Assert.Contains(BagelFilling.Ham, bagel.Fillings);
    }

    [Test]
    public void BagelCost()
    {
        Bagel bagel = new Bagel(BagelVariant.Onion);
        bagel.AddFilling(BagelFilling.Ham);

        double expected = 0.49 + 0.12;
        double actualCost = bagel.Cost();

        Assert.Equals(expected, actualCost);
    }

    [Test]
    public void DisplayBagelFillings()
    {
        Bagel bagel = new Bagel(BagelVariant.Everything);

        string expectedOutput = "Bacon: 0.12\r\n" +
                                "Egg: 0.12\r\n" +
                                "Cheese: 0.12\r\n" +
                                "Cream Cheese: 0.12\r\n" +
                                "Smoked Salmon: 0.12\r\n" +
                                "Ham: 0.12\r\n";

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            bagel.DisplayFillings();

            string actualOutput = sw.ToString();
            Assert.That(actualOutput, Is.EqualTo(expectedOutput));

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }
    }
}