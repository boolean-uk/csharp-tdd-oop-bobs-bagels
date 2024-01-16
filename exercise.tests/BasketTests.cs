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

        basket.Capacity = 1;
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
}
