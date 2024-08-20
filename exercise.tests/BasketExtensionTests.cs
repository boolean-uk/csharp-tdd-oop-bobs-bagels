using exercise.main;
namespace exercice.tests;

public class BasketExtentionTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void DiscountTotalPriceTest1()
    {
        Basket basket = new Basket();
        string product1 = "BGLO";
        string product2 = "BGLP";
        string product3 = "BGLE";
        string product4 = "COFB";
        double expectedPrice = 3.99 + 2.49 + 2.50 + 0.99;

        basket.AddMultible(product1, 2);
        basket.AddMultible(product2, 12);
        basket.AddMultible(product3, 6);
        basket.AddMultible(product4 , 3);

        double result = Math.Round(basket.GetTotalCost(basket.basket), 2); 
        Assert.That(result, Is.EqualTo(expectedPrice));
    }

    [Test]
    public void DiscountTotalPriceTest2()
    {
        Basket basket = new Basket();
        string product1 = "BGLP";
        double expectedPrice = 5.55;

        basket.AddMultible(product1, 16);

        //I have some rounding issiues because of my method
        double result = Math.Round(basket.GetTotalCost(basket.basket), 2);
        Assert.That(result, Is.EqualTo(expectedPrice));
    }

    [Test]
    public void PrintRecieptTest()
    {
        Basket basket = new Basket();

        string product1 = "BGLO";
        string product2 = "BGLP";
        string product3 = "BGLE";
        string product4 = "COFB";
        string totalPrice = "";

        basket.AddMultible(product1, 2);
        basket.AddMultible(product2, 12);
        basket.AddMultible(product3, 6);
        basket.AddMultible(product4, 3);

        string reciept = basket.PrintReciept();

        Assert.IsNotNull(reciept);
    }
}