using exercise.main;
namespace exercice.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("BGLP")]
    [TestCase("COFB")]
    public void AddItemBasket(string product)
    {
        Basket basket = new Basket();
        string expectedMSG = "product added to basket";

        string result = basket.Add(product);

        Assert.That(result, Is.EqualTo(expectedMSG));
    }

    [Test]
    public void AddItemFullBasket()
    {
        Basket basket = new Basket();
        string expectedMSG = "your basket is full";
        for (int i = 0; i < basket.Capacity; i++)
        {
            basket.Add("COFB");
        }

        string product = "BGLS";

        string result = basket.Add(product);

        Assert.That(result, Is.EqualTo(expectedMSG));
    }

    public void AddNonExistingItem()
    {
        Basket basket = new Basket();
        string expectedMSG = "product does not exist in the inventory";
        string product = "AAAA";

        string result = basket.Add(product);

        Assert.That(result, Is.EqualTo(expectedMSG));
    }
    [Test]
    public void AddFillingToBagel()
    {
        Basket basket = new Basket();
        string expectedMSG = "Filling added";
        string filling = "FILX";
        string bagel = "BGLO";

        basket.Add(bagel);
        string result = basket.AddAddition(bagel, filling);

        Assert.That(result, Is.EqualTo(expectedMSG));

    }
    [Test]
    public void RemoveExistingItem()
    {
        Basket basket = new Basket();
        string product = "COFB";
        basket.Add(product);

        bool result = basket.Remove(product);

        Assert.That(result, Is.True);
    }
    [Test]
    public void RemoveNonExistingItem()
    {
        Basket basket = new Basket();
        string product = "bag";

        bool result = basket.Remove(product);

        Assert.That(result, Is.False);
    }
    [Test]
    public void ChangeCapacity()
    {
        Basket basket = new Basket();
        int newCapacity = 6;
        string password = "admin";

        int result = basket.ChangeCapacity(6, password);

        Assert.That(result, Is.EqualTo(newCapacity));
    }

    [Test]
    public void ChangeCapacityFailed()
    {
        Basket basket = new Basket();
        int newCapacity = 6;
        int currentCApacity = 50;
        string password = "admi";

        int result = basket.ChangeCapacity(newCapacity, password);

        Assert.That(result, Is.EqualTo(currentCApacity));
    }
    [Test]
    public void GetTotalCostTest()
    {
        Basket basket = new Basket();
        string coffee = "COFW"; //White Coffee
        string bagel = "BGLP";
        double expectedCost = 0.39 + 1.19;

        basket.Add(coffee);
        basket.Add(bagel);
        double result = basket.GetTotalCostNoDiscount();

        Assert.That(result, Is.EqualTo(expectedCost));
    }

    [Test]
    public void CostOfSingleBagelTest()
    {
        Basket basket = new Basket();
        string bagelId = "BGLO";
        double cost = 0.49;

        basket.Add(bagelId);
        double result = basket.GetCostOfProduct(bagelId);

        Assert.That(result, Is.EqualTo(cost));
    }

    public void fillingPriceListTest()
    {
        Basket basket = new Basket();
        double expectedPrice = 0.12;

        Dictionary<string, double> priceList = basket.FillingPriceList;
        double price = priceList.First().Value;

        Assert.That(price, Is.EqualTo(expectedPrice));
    }
}