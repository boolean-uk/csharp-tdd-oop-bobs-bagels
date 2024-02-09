using exercise.main;

namespace exercise.tests;

[TestFixture]
public class DiscountTests
{
    Inventory inventory;
    [SetUp]
    public void Setup()
    {
        inventory = new Inventory();
    }

    //TESTS FOR EXTENSION 1
    [Test]
    public void TestDiscount()
    {
        var basket = new Basket(inventory);
        basket.ChangeCapacity(16);
        for (int i = 0; i < 16; i++)
        {
            basket.AddProduct("BGLP");
        }
        float excpectedTotalCost = 5.55f;

        var discountedBasket = basket.GetDiscountedBasket();
        decimal actualTotalCost = 0;
        foreach (var item in discountedBasket)
        {
            actualTotalCost += item.Value.TotalCost;
        }


        Assert.That(actualTotalCost, Is.EqualTo(excpectedTotalCost).Within(0.005));
    }

    [Test]
    public void TestDiscount_CoffeBagel()
    {
        var _basket = new Basket(inventory);
        _basket.ChangeCapacity(16);
        _basket.AddProduct("BGLO");
        _basket.AddProduct("BGLO");
        _basket.AddProduct("COFB");
        float testPrice = 1.25f + 0.49f;

        var discountedBasket = _basket.GetDiscountedBasket();
        decimal totalCost = 0;
        foreach (var item in discountedBasket)
        {
            totalCost += item.Value.TotalCost;
        }

        Assert.That(totalCost, Is.EqualTo(testPrice).Within(0.005));
    }
}