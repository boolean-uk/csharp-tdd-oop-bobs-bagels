using exercise.main;

namespace exercise.tests;

[TestFixture]
public class ProductTest
{
    private static Product _product;
    
    [SetUp]
    public void Setup()
    {
        _product = new Product("SKU0", "Test Product", 10.99);
    }
    
    [Test]
    public void ProductConstructorTest()
    {
        Assert.That(_product.Sku, Is.EqualTo("SKU0"));
        Assert.That(_product.Name, Is.EqualTo("Test Product"));
        Assert.That(_product.Price, Is.EqualTo(10.99));
        Assert.IsEmpty(_product.Promotions);
        Assert.IsEmpty(_product.AllowedMofifications);
    }
    
    [Test]
    public void ProductGetPriceTest()
    {
        Assert.That(_product.GetPrice(), Is.EqualTo(10.99));
    }
    
    [TestCase(9.9)]
    [TestCase(0.01)]
    [TestCase(double.MaxValue)]

    public void ProductSetPriceTest(double newPrice)
    {
        _product.SetPrice(newPrice);
        Assert.That(_product.GetPrice(), Is.EqualTo(newPrice));
    }
    
    [TestCase(0)]
    [TestCase(-1.0)]
    [TestCase(double.MinValue)]
    public void ProductSetNegativePriceTest(double newPrice)
    {
        Assert.Throws<Exception>(() => _product.SetPrice(newPrice));
    }
    
    [Test]
    public void ProductAddPromotionTest()
    {
        _product.AddPromotion(2, 15.99);
        Assert.That(_product.Promotions.First().Value, Is.EqualTo(15.99));
    }
}