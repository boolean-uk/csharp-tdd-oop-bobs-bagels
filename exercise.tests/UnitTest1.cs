using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Sources;
using exercise.main;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void addProductToBasket()
    {
        Product product = new Product();  
        Basket basket = new Basket();
        basket.AddProduct(product);
        List<Product> Result = basket.ProductList;

        Assert.That(Result.Count >= 1);
    }

    [Test]
    public void removeProductFromBasket()
    {
       Assert.Pass();

    }

}