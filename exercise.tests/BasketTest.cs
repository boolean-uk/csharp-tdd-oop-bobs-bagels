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
    [TestCase("Coffee", "Latte", 1.29)]
    public void TestShowCost(string name, string variant, double cost)
    {
        Basket basket = new Basket();
        Inventory inventory = new Inventory();
        BasketItem item = new BasketItem(inventory.GetCode("Bagel", "Onion"));
        basket.Add(item);
        item = new BasketItem(inventory.GetCode("Bagel", "Plain"));
        basket.Add(item);
        item = new BasketItem(inventory.GetCode("Bagel", "Everything"));
        basket.Add(item);
        item = new BasketItem(inventory.GetCode("Bagel", "Sesame"));
        basket.Add(item);
        item = new BasketItem(inventory.GetCode("Coffee", "White"));
        basket.Add(item);
        item = new BasketItem(inventory.GetCode("Bagel", "Plain"), inventory.GetCode("Filling", "Bacon"));
        basket.Add(item);
        item = new BasketItem(inventory.GetCode(name, variant));
        basket.Add(item);
        double expectedCost = 3.56 + cost;


        double result = basket.ShowCost();

        Assert.That(result == expectedCost);
    }



}
