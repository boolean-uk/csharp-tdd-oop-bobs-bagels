using exercise.main;

namespace exercise.tests;

[TestFixture]
public class ProductModificationTest
{
    private static Product _product;
    
    [SetUp]
    public void Setup()
    {
        _product = new Product("SKU0", "Test Product", 10.99);
        _product.AllowedModifications
            .Add(new ProductModification("MOD1", "Test Modification", 9.99));
    }
    
    [Test]
    public void ProductModConstructorTest()
    {
        Assert.That(_product.AllowedModifications.First().Sku, Is.EqualTo("MOD1"));
        Assert.That(_product.AllowedModifications.First().Name, Is.EqualTo("Test Modification"));
        Assert.That(_product.AllowedModifications.First().Price, Is.EqualTo(9.99));
    }
    
    [Test]
    public void ProductModGetPriceTest()
    {
        // Checks total price of product and modification
        Assert.That(_product.GetPrice(), Is.EqualTo(20.99));
    }
    
    [Test]
    public void ProductSetPriceTest()
    {
        _product.SetPrice(8.99);
        Assert.That(_product.AllowedModifications.First().GetPrice(), Is.EqualTo(8.99));
    }
}