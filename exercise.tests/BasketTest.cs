using exercise.main;
namespace BasketTest.tests;

public class BasketTests
{
    [TestCase("Bagel", "Everything")]
    [TestCase("Filling", "Bacon")]
    [TestCase("Filling", "Smoked Salmon")]
    [TestCase("Bagel", "Plain")]
    [TestCase("Coffee", "Latte")]
    public void TestAdd(string name, string variant)
    {
        Basket basket = new Basket();

        basket.Add(name, variant);

        bool inBasket = basket.OrderInBasket(name, variant);
        
        Assert.IsTrue(inBasket);
    }


    [TestCase("Bagel", "Everything", 0.49)]
    [TestCase("Filling", "Bacon", 0.12)]
    [TestCase("Filling", "Smoked Salmon", 0.12)]
    [TestCase("Bagel", "Plain", 0.39)]
    [TestCase("Coffee", "Latte", 1.29)]
    public void TestShowCost(string name, string variant, double cost)
    {
        Basket basket = new Basket();
        basket.Add("Bagel", "Onion");
        basket.Add("Bagel", "Plain");
        basket.Add("Bagel", "Everything");
        basket.Add("Bagel", "Sesame");
        basket.Add("Coffee", "White");
        basket.Add("Filling", "Bacon");
        basket.Add(name, variant);
        double expectedCost = 3.17 + cost;


        double result = basket.ShowCost();

        Assert.That(result == expectedCost);
    }



}
