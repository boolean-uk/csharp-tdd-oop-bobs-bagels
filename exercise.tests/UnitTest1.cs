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
        Product product = new Product();
        Basket basket = new Basket();

        basket.AddProduct(product);
        basket.AddProduct(product);
        basket.AddProduct(product);
        Assert.That(basket.ProductList.Count == 3);

        basket.RemoveProduct(product);
        
        Assert.That(basket.ProductList.Count < 3);

    }

    [Test]
    public void addingProductBeyondCapacity()
    {
        Product product = new Product();
        Basket basket = new Basket();
        for(int i=0; i<= basket.Capacity;i++)
        {
            basket.AddProduct(product);
        }
        
        Assert.That(basket.ProductList.Count == basket.Capacity);

        bool Result = basket.AddProduct(product);

        Assert.That(basket.ProductList.Count == basket.Capacity && Result==false);

    }

    [TestCase("admin", 32)]
    [TestCase("customer", 12)]
    [TestCase("", 2)]
    [TestCase("admin", 5)]
    [TestCase("customer", 5)]

    public void changeCapacity(string adminLevel, int newCapacity)
    {
        Basket basket = new Basket();
        Person person = new Person(adminLevel);
        
        int oldCapacity = basket.Capacity;
        if (newCapacity != oldCapacity)
        {
            int Result = basket.changeCapacity(person, newCapacity);

            Assert.That(oldCapacity != Result, Is.EqualTo(person.AdminLevel == "admin"));
            Assert.That(oldCapacity != Result, Is.EqualTo(basket.Capacity == newCapacity));
        }
    }
    [TestCase("Coffe")]
    [TestCase("Bagel")]
    [TestCase("Filling")]
    public void removeNotExistingProduct(string name)
    {
        Basket basket = new Basket();
        Product bagel = new Product("Bagel");
        Product coffe = new Product("Coffe");

        basket.AddProduct(bagel);
        basket.AddProduct(coffe);
        
        bool Result = basket.RemoveProduct(bagel);

        basket.ProductList.Contains(bagel);

        Assert.That(name == bagel.Name || name == coffe.Name, Is.EqualTo(Result==true));    
    }



}