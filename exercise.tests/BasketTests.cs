using exercise.main;
namespace exercice.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("onion")]
    [TestCase("plain")]
    [TestCase("sesame")]
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
        for (int i = 0; i < basket.capacity; i++)
        {
            basket.Add("product" + i);
        }

        string product = "apple";
        int value = 10;

        string result = basket.Add(product);

        Assert.That(result, Is.EqualTo(expectedMSG));
    }

    [Test]
    public void RemoveExistingItem()
    {
        Basket basket = new Basket();
        string product = "salmon";
        int value = 90;
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

        int result = basket.ChangeCapacity(6);

        Assert.That(result, Is.EqualTo(newCapacity));
    }
}