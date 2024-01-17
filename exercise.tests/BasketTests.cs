using exercise.main;

namespace exercise.tests;

public class BasketTests
{
    [TestCase(2 ,"gggg", false)]
    [TestCase(2, "BGLP", true)]
    [TestCase(2, " COFW ", true)]
    [TestCase(1, " COFW ", false)]
    public void addTest(int id, string sku, bool isValid)
    {
        Basket basket = new Basket();

        basket.add(1, "BGLP");
        bool result = basket.add(id, sku);

        Assert.That(result, Is.EqualTo(isValid));
    }

    [TestCase(1, "gggg", false)]
    [TestCase(1, "FILC", true)]
    [TestCase(2, "FILC", false)]
    [TestCase(1, " FILX ", true)]
    public void addFilling(int id, string sku, bool isValid)
    {
        var basket = new Basket();

        basket.add(1, "BGLP");
        bool result = basket.addFilling(id, sku);

        Assert.That(result, Is.EqualTo(isValid));
    }

    [Test]
    public void capacityTest()
    {
        var basket = new Basket();

        basket.setCapacity(1);
        bool result = basket.add(1, "BGLP");
        bool result1 = basket.add(2, "BGLP");

        Assert.That(result == true);
        Assert.That(result1 == false);
    }

    [Test]
    public void removeTest()
    {
        var basket = new Basket();

        basket.add(1, "BGLP");
        bool result = basket.remove(2);
        bool result1 = basket.remove(1);

        Assert.That(result == false);
        Assert.That(result1 == true);
    }

    [TestCase("", 0.00)]
    [TestCase("BGLP", 0.39)]
    [TestCase("FILE", 0.12)]
    public void getPriceTest(string sku, double expectedPrice)
    {
        var basket = new Basket();

        double result = basket.getItemPrice(sku);

        Assert.That(result, Is.EqualTo(expectedPrice));
    }

    [Test]
    public void getBasketPriceTest()
    {
        Basket basket = new Basket();

        double result = basket.getBasketPrice();
        basket.add(1, "BGLP");
        basket.addFilling(1, "FILE");
        double result1 = basket.getBasketPrice();
        basket.add(2, "COFB");
        double result2 = basket.getBasketPrice();

        Assert.That(result, Is.EqualTo(0.00));
        Assert.That(result1, Is.EqualTo(0.51));
        Assert.That(result2, Is.EqualTo(1.50));
    }
}