using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Sources;
using exercise.main;
using NUnit.Framework;

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
        Product product = new Product(name);

        basket.AddProduct(bagel);
        basket.AddProduct(coffe);
        
        bool Result = basket.RemoveProduct(product);

        if (Result==true)
        {
            Assert.That(name == bagel.Name, Is.EqualTo(name != coffe.Name));
            Assert.That(name != bagel.Name, Is.EqualTo(name == coffe.Name));
            Assert.That(basket.ProductList.Count < 2);
        }
        else{ 
            Assert.That(name, Is.EqualTo(product.Name));
            Assert.That(basket.ProductList.Count, Is.EqualTo(2)); 
        } 
    }

    [TestCase("BGLO", "BGLP", "BGLE")]
    [TestCase("COFB", "COFW", "COFC")]
    [TestCase("FILB", "FILE", "FILC")]
    [TestCase("BGLS", "COFB", "COFW")]

    public void getTotalCost(string A, string B, string C) {
        Basket basket = new Basket();

        //SKU = { "BGLO", "BGLP", "BGLE", "BGLS", "COFB", "COFW", "COFC", "COFL", "FILB", "FILE", "FILC", "FILX", "FILS", "FILH" };
        Product product1 = new Product(A);
        Product product2 = new Product(B);
        Product product3 = new Product(C);

        basket.AddProduct(product3); basket.AddProduct(product1); basket.AddProduct(product2);

        double Result = basket.GetTotal();
        double sum = product1.Price + product2.Price + product3.Price;

        Assert.That(Result, Is.EqualTo(sum));
    
    }


}