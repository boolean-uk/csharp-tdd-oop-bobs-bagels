using exercise.main;
using static exercise.main.Basket;
namespace BasketTest.tests;

public class BasketTests
{
    [TestCase("Bagel", "Everything")]
    [TestCase("Coffee", "White")]
    [TestCase("Bagel", "Sesame")]
    [TestCase("Bagel", "Plain")]
    [TestCase("Coffee", "Latte")]
    public void TestAdd(string name, string variant)
    {
        Basket basket = new Basket();

        Inventory inventory = new Inventory();
        BasketItem item = new BasketItem(inventory.GetCode(name, variant));
        basket.Add(item);

        bool inBasket = basket.OrderInBasket(name, variant);
        
        Assert.IsTrue(inBasket);
    }


    [TestCase("Bagel", "Everything", 0.49)]
    [TestCase("Bagel", "Plain", 0.39)]
    [TestCase("Coffee", "Latte", 0.86)] //cost because discount
    public void TestShowCost(string name, string variant, double cost)
    {
        Basket basket = new Basket();
        Inventory inventory = new Inventory();
        BasketItem item = new BasketItem(inventory.GetCode("Bagel", "Onion"));
        basket.Add(item);
        item = new BasketItem(inventory.GetCode("Bagel", "Plain"));
        basket.Add(item);
        item = new BasketItem(inventory.GetCode(name, variant));
        basket.Add(item);

        double expectedCost = 0.88 + cost;


        double result = basket.ShowCost();

        Assert.That(result == expectedCost);
    }



}
