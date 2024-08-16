using exercise.main;

namespace exercise.tests;

public class Tests
{
    BagelShop shop = new BagelShop();

    [Test]
    public void Test1AddingBagel()
    {
        Basket basket = shop.grabBasket();
        Assert.IsNotNull(basket);

        bool result1 = basket.add("BGLO");
        Assert.IsTrue(result1);
    }

    [Test]
    public void Test2RemovingBagel()
    {
        Basket basket = shop.grabBasket();
        basket.add("BGLO");
        bool result1 = basket.remove("BGLO");
        Assert.IsTrue(result1);
    }
}