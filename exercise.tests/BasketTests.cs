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

    [TestCase(0, 0, 0)]
    [TestCase(1, 0, 0.49)]
    [TestCase(0, 1, 0.99)]
    [TestCase(1, 1, 1.25)]
    [TestCase(6, 0, 2.49)]
    [TestCase(7, 1, 2.49 + 1.25)]
    [TestCase(12, 0, 3.99)]
    [TestCase(13, 1, 3.99 + 1.25)]
    [TestCase(18, 0, 3.99 + 2.49)]
    [TestCase(19, 1, 3.99 + 2.49 + 1.25)]
    public void getBasketPriceTest(int bagels, int coffees, double shouldBe)
    {
        Basket basket = new Basket();

        basket.setCapacity(100);
        for (int i = 0; i < bagels; i++)
        {
            basket.add(i, "BGLO");
        }
        for (int i = 0; i < coffees; i++)
        {
            basket.add(i + bagels, "COFB");
        }
        double result = basket.getBasketPrice();

        Assert.That(result, Is.EqualTo(shouldBe));
    }

    [TestCase(0, 0)]
    [TestCase(11, 0)]
    [TestCase(12, 1)]
    [TestCase(13, 1)]
    [TestCase(25, 2)]
    public void calculate12PacksTest(int bagels, int shoudBe)
    {
        Basket basket = new Basket();

        int result = basket.calculate12Packs(bagels);

        Assert.That(result, Is.EqualTo(shoudBe));
    }

    [TestCase(0, false)]
    [TestCase(11, true)]
    [TestCase(12, false)]
    [TestCase(18, true)]
    [TestCase(25, false)]
    public void calculate6PackTest(int bagels, bool shoudBe)
    {
        Basket basket = new Basket();

        bool result = basket.calculate6Pack(bagels);

        Assert.That(result, Is.EqualTo(shoudBe));
    }

    [TestCase(0, 0, 0)]
    [TestCase(11, 0, 0)]
    [TestCase(0, 5, 0)]
    [TestCase(13, 3, 3)]
    public void calculateCoffeDealsTest(int bagels, int coffees, int shoudBe)
    {
        Basket basket = new Basket();

        int result = basket.calculateCoffeDeals(bagels, coffees);

        Assert.That(result, Is.EqualTo(shoudBe));
    }
}