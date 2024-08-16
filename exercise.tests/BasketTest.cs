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
}
