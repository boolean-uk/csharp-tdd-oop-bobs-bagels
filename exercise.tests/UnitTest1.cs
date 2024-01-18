using exercise.main;
using exercise.main.Items;
using NUnit.Framework;
using System;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void testAdd()
    {
        //Arrange
        Inventory inventory = new Inventory();
        Basket basket = new Basket();
        Bagel bagel1 = new Bagel("Onion");
        Coffe coffe1 = new Coffe("Black");
        Product product1 = new Product(bagel1);
        Product product2 = new Product(coffe1);

        //"Onion","Plain","Everything","Sesame"
        //"Black","White","Capuccino","Latte"
        // "Bacon","Egg","Cheese","Cream Cheese", "Smoked Salmon", "Ham"



        //Act
        basket.Add(product1);
        basket.Add(product2);
        string testProduct1 = "Onion";
        string testProduct2 = "Black";

        List<Product> testResult = new List<Product>() {
            product1, product2
        };


        //Assert
        Assert.AreEqual(testResult, basket.getBasket());

    }

    [Test]
    public void testRemove()
    {
        //Arrange
        Inventory inventory = new Inventory();
        Basket basket = new Basket();
        Bagel bagel1 = new Bagel("Onion");
        Coffe coffe1 = new Coffe("Black");
        Product product1 = new Product(bagel1);
        Product product2 = new Product(coffe1);

        //"Onion","Plain","Everything","Sesame"
        //"Black","White","Capuccino","Latte"
        // "Bacon","Egg","Cheese","Cream Cheese", "Smoked Salmon", "Ham"



        //Act
        basket.Add(product1);
        basket.Add(product2);
        string testProduct1 = "Onion";
        string testProduct2 = "Black";

        List<Product> testResult = new List<Product>() {
            product1, product2
        };
        testResult.Remove(product1);
        basket.Remove(product1);



        //Assert
        Assert.AreEqual(testResult, basket.getBasket());

    }

    [Test]
    public void testAdd2()
    {
        //Arrange
        Inventory inventory = new Inventory();
        Basket basket = new Basket();
        Bagel bagel1 = new Bagel("Onion");
        Bagel bagel2 = new Bagel("Plain");
        Coffe coffe1 = new Coffe("Black");
        Filling filling1 = new Filling("Bacon");

        Product product1 = new Product(bagel1);
        Product product2 = new Product(coffe1);
        Product product3 = new Product(bagel2);
        Product product4 = new Product(filling1);
        

        //"Onion","Plain","Everything","Sesame"
        //"Black","White","Capuccino","Latte"
        // "Bacon","Egg","Cheese","Cream Cheese", "Smoked Salmon", "Ham"



        //Act

        //Assert
        Assert.IsTrue(basket.Add(product1));
        Assert.IsTrue(basket.Add(product2));
        Assert.IsTrue(basket.Add(product3));
        Assert.IsTrue(!basket.Add(product4));

    }

    [Test]
    public void testSetNewCapacity()
    {
        //Arrange

        Basket basket = new Basket();
        int newCapacity = 10;


        //Act
        basket.setNewCapacity(newCapacity);

        //Assert
        Assert.IsTrue(newCapacity == basket.capacity);

    }

    [Test]
    public void testRemove2()
    {
        //Arrange
        Inventory inventory = new Inventory();
        Basket basket = new Basket();
        Bagel bagel1 = new Bagel("Onion");
        Coffe coffe1 = new Coffe("Black");
        Filling filling1 = new Filling("Bacon");

        Product product1 = new Product(bagel1);
        Product product2 = new Product(coffe1);
        Product product4 = new Product(filling1);

        //"Onion","Plain","Everything","Sesame"
        //"Black","White","Capuccino","Latte"
        // "Bacon","Egg","Cheese","Cream Cheese", "Smoked Salmon", "Ham"


        //Act
        basket.Add(product1);
        basket.Add(product2);
       

        //Assert
        Assert.IsTrue(basket.Remove(product1));    // This item in the basket -> true
        Assert.IsTrue(!basket.Remove(product4));    // This item not in the basket -> should returns false
    }

    [Test]
    public void testGetTotalPrice()
    {
        //Arrange
        Inventory inventory = new Inventory();
        Basket basket = new Basket();
        Bagel bagel1 = new Bagel("Onion");
        Coffe coffe1 = new Coffe("Black");
        Filling filling1 = new Filling("Bacon");

        Product product1 = new Product(bagel1);
        Product product2 = new Product(coffe1);
        Product product4 = new Product(filling1);

        //"Onion","Plain","Everything","Sesame"
        //"Black","White","Capuccino","Latte"
        // "Bacon","Egg","Cheese","Cream Cheese", "Smoked Salmon", "Ham"


        //Act
        basket.Add(product1);
        basket.Add(product2);
        basket.Add(product4);


        //Assert
        Assert.IsTrue(basket.getTotalPrice() == 1.6);    // Onion = 0.49, Black = 0.99, Ham = 0.12
    }

    [Test]
    public void testGetPrice()
    {
        //Arrange
        Inventory inventory = new Inventory();
        Basket basket = new Basket();
        Bagel bagel1 = new Bagel("Onion");
        Coffe coffe1 = new Coffe("Black");
        Filling filling1 = new Filling("Bacon");

        Product product1 = new Product(bagel1);
        Product product2 = new Product(coffe1);
        Product product4 = new Product(filling1);

        //"Onion","Plain","Everything","Sesame"
        //"Black","White","Capuccino","Latte"
        // "Bacon","Egg","Cheese","Cream Cheese", "Smoked Salmon", "Ham"


        //Act
       double price = product1.getPrice();


        //Assert
        Assert.IsTrue(price == 0.49);    // Onion = 0.49
    }

    [Test]
    public void testMakebagel()
    {
        //Arrange
        Inventory inventory = new Inventory();
        Basket basket = new Basket();
        Bagel bagel1 = new Bagel("Onion");
        Coffe coffe1 = new Coffe("Black");
        Filling filling1 = new Filling("Bacon");
        Filling filling2 = new Filling("Bacon");
        Filling filling3 = new Filling("Ham");


        Product product1 = new Product(bagel1);
        Product product2 = new Product(coffe1);
        Product product4 = new Product(filling1);
        Product product5 = new Product(filling2);
        Product product6 = new Product(filling3);

        //"Onion","Plain","Everything","Sesame"
        //"Black","White","Capuccino","Latte"
        // "Bacon","Egg","Cheese","Cream Cheese", "Smoked Salmon", "Ham"


        //Act
        basket.Add(product1);
        basket.MakeSandwich(product1, product5);
        basket.MakeSandwich(product1, product6);
        Dictionary<Product,List<Product>> testResult = new Dictionary<Product, List<Product>>() {
            { product1, new List<Product>() { product5,product6} }
        };

        Dictionary<Product, List<Product>> Result = basket.getSandwich();


        //Assert
        Assert.AreEqual(testResult[product1], Result[product1]);    // Checking if result have same filling as testResult
    }

    [Test]
    public void testGetPriceInventory()
    {
        //Arrange
        Inventory inventory = new Inventory();
        Basket basket = new Basket();
        Bagel bagel1 = new Bagel("Onion");
        Coffe coffe1 = new Coffe("Black");
        Filling filling1 = new Filling("Bacon");

        Product product1 = new Product(bagel1);
        Product product2 = new Product(coffe1);
        Product product4 = new Product(filling1);

        //"Onion","Plain","Everything","Sesame"
        //"Black","White","Capuccino","Latte"
        // "Bacon","Egg","Cheese","Cream Cheese", "Smoked Salmon", "Ham"


        //Act
        //Dictionary<string, double> priceList = new Dictionary<string, double>();
        Dictionary<string, double> priceListResult = 
            inventory.getFilling().ToDictionary(pair => pair.Value.variant, pair => pair.Value.getPrice());

        //Values.ToList().ForEach(product => product.getPrice());



        //Assert 
        Assert.IsTrue(priceListResult["Bacon"] == 0.12);    // Onion = 0.49
    }

    [Test]
    public void testUnavailableObject()
    {
        //Arrange
        Inventory inventory = new Inventory();
        Basket basket = new Basket();
        Bagel bagel1 = new Bagel("Onion");
        Object random = new object();

        //Product product1 = new Product(bagel1);
       // Product product2 = new Product(random);
      

        //"Onion","Plain","Everything","Sesame"
        //"Black","White","Capuccino","Latte"
        // "Bacon","Egg","Cheese","Cream Cheese", "Smoked Salmon", "Ham"


        //Act
        //var result = Assert.Throws<ArgumentException>(product1);
        TestDelegate result1 = () => new Product(bagel1);
       

        TestDelegate result2 = () => new Product(random);
        var check2 = Assert.Throws<ArgumentException>(result2);

        //Assert 
        Assert.DoesNotThrow(result1);
        Assert.AreEqual("Unsupported product", check2.Message);
        //Assert.Throws<ArgumentException>(result1);
    }


    [Test]
    public void testDisCount1()
    {
        //Arrange
        Inventory inventory = new Inventory();
        Basket basket = new Basket();

        Bagel bagel1 = new Bagel("Onion");

        Product product1 = new Product(bagel1);
        Product product2 = new Product(bagel1);
        Product product3 = new Product(bagel1);
        Product product4 = new Product(bagel1);
        Product product5 = new Product(bagel1);
        Product product6 = new Product(bagel1);


        //"Onion","Plain","Everything","Sesame"
        //"Black","White","Capuccino","Latte"
        // "Bacon","Egg","Cheese","Cream Cheese", "Smoked Salmon", "Ham"

        //Act
        basket.setNewCapacity(12);
        basket.Add(product1);
        basket.Add(product2);
        basket.Add(product3);
        basket.Add(product4);
        basket.Add(product5);
        basket.Add(product6);
        double totalprice = basket.getTotalPrice();  // Shall returns 2.94 if no discount

        //Assert 
        Assert.That(Math.Round(totalprice, 2), Is.EqualTo(2.49).Within(0.01));

    }

    [Test]
    public void testDisCount2()
    {
        //Arrange
        Inventory inventory = new Inventory();
        Basket basket = new Basket();

        Bagel bagel1 = new Bagel("Onion");

        Product product1 = new Product(bagel1);
        Product product2 = new Product(bagel1);
        Product product3 = new Product(bagel1);
        Product product4 = new Product(bagel1);
        Product product5 = new Product(bagel1);
        Product product6 = new Product(bagel1);
        Product product7 = new Product(bagel1);
        Product product8 = new Product(bagel1);
        Product product9 = new Product(bagel1);
        Product product10 = new Product(bagel1);
        Product product11 = new Product(bagel1);
        Product product12 = new Product(bagel1);


        //"Onion","Plain","Everything","Sesame"
        //"Black","White","Capuccino","Latte"
        // "Bacon","Egg","Cheese","Cream Cheese", "Smoked Salmon", "Ham"

        //Act
        basket.setNewCapacity(12);
        basket.Add(product1);
        basket.Add(product2);
        basket.Add(product3);
        basket.Add(product4);
        basket.Add(product5);
        basket.Add(product6);
        basket.Add(product7);
        basket.Add(product8);
        basket.Add(product9);
        basket.Add(product10);
        basket.Add(product11);
        basket.Add(product12);
        double totalprice = basket.getTotalPrice();  // Shall returns 2.94 if no discount

        //Assert 
        Assert.That(Math.Round(totalprice, 2), Is.EqualTo(3.99).Within(0.01));

    }
}