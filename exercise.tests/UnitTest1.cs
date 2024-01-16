using exercise.main;
using System.Linq;
using System.Reflection.Emit;
namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [TestCase]
    public void AddBagel()
    {
        //Arrange
        Basket basket = new Basket();
        Product prod = new Product("BGLO", 0.49, "Bagel", "Onion");
        //Act
        basket.addProductToBasket(prod);

        //Assert
        Assert.IsTrue(basket._basketList.Contains(prod));
    }

    [Test]
    public void RemoveBagel()
    {
        //Arrange
        Basket basket = new Basket();
        Product prod = new Product("BGLO", 0.49, "Bagel", "Onion");
        //Act
        basket.addProductToBasket(prod);
        basket.removeProduct(prod);

        //Assert
        Assert.IsTrue(!basket._basketList.Contains(prod));
    }

    [Test]
    public void BasketFull()
    {
        //Arrange
        Basket basket = new Basket();
        Product prod1 = new Product("BGLO", 0.49, "Bagel", "Onion");
        Product prod2 = new Product("BGLP", 0.39, "Bagel", "Plain");
        Product prod3 = new Product("BGLE", 0.49, "Bagel", "Everything");

        basket.addProductToBasket(prod1);
        basket.addProductToBasket(prod2);

        //Act
        basket.addProductToBasket(prod3);

        //Assert
        Assert.IsTrue(!basket._basketList.Contains(prod3));
    }

    [Test]

    public void ChangeCapacity()
    {
        //Arrange 
        Basket basket = new Basket();
        int s = 5;
        //Act
        basket.changeBasketCapacity(s);
        //Assert
        Assert.AreEqual(5, basket._capacity);
    }

    [Test]

    public void RemoveNonexistentItemMessage()
    {
        //Arrange
        Basket basket = new Basket();
        Product prod = new Product("BGLO", 0.49, "Bagel", "Onion");
        string s = ($"{prod} is not in the basket");

        //Act
        string msg = basket.ProductNotInBasket(prod);

        //Assert
        Assert.AreEqual(s, msg);
    }

    [Test]

    public void SumTotalCost() 
    {
        //Arrange
        Basket basket = new Basket();
        double sum = 0.88;
        
        Product prod1 = new Product("BGLP", 0.39, "Bagel", "Plain");
        Product prod2 = new Product("BGLE", 0.49, "Bagel", "Everything");


        //Act
        basket.addProductToBasket(prod1);
        basket.addProductToBasket(prod2);
        double totalCost = basket.totalCost();

        //Assert
        Assert.AreEqual(sum, totalCost);
    
    }

    [Test]

    public void ShowMenu()
    {
        //Arrange
        Basket basket = new Basket();

        //Act
        string s = basket.printMenu();
        //Assert
        Assert.IsTrue(s.Equals(basket.printMenu()));
    }
}

    