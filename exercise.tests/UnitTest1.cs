using exercise.main;

namespace exercise.tests;

public class Tests
{
    BagelShop shop = new BagelShop();
    [SetUp] // Initial setup before each test starts

    [Test]
    public void Test1()
    {
        Basket basket = shop.grabBasket();
        Assert.IsNotNull(basket);
    }
}