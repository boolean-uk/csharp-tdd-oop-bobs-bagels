using exercise.main;

namespace exercise.tests;

public class Tests
{
    
    //---------------------------------------------------------------------------------
    //Basket

    [Test, Order(1)]
    public void Test_01_addProduct()
    {
        //Arrange
        Basket basket = new Basket();
        Bagel bagel = new Bagel("BGLO");

        //Act

        bool expectedResult = basket.AddProduct(bagel);
        bool actualResult = true;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [Test, Order(2)]
    public void Test_02_Success_RemoveProduct()
    {
        //Arrange
        Basket basket = new Basket();
        Bagel bagel = new Bagel("BGLO");
        basket.AddProduct(bagel);

        //Act
        bool expectedResult = basket.AddProduct(bagel);
        bool actualResult = true;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [Test, Order(2)]
    public void Test_02_Fail_RemoveProduct()
    {
        //Arrange
        Basket basket = new Basket();

        //Act
        bool expectedResult = basket.RemoveProduct("BGLO"); ;
        bool actualResult = false;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [Test, Order(3)]
    public void Test_03_Success_IsProductInBasket()
    {
        //Arrange
        Basket basket = new Basket();
        Bagel bagel = new Bagel("BGLO");
        basket.AddProduct(bagel);

        //Act
        bool expectedResult = basket.IsProductInBasket("BGLO");
        bool actualResult = true;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [Test, Order(3)]
    public void Test_03_Fail_IsProductInBasket()
    {
        //Arrange
        Basket basket = new Basket();
        //Act
        bool expectedResult = basket.IsProductInBasket("BGLO");
        bool actualResult = false;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [Test, Order(4)]
    public void Test_04_TotalCapacity()
    {
        //Arrange
        Basket basket = new Basket();


        //Act
        int expectedResult = basket.TotalCapacity(); ;
        int actualResult = 1;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [Test, Order(5)]
    public void Test_05_CheckCurrentCapacity()
    {
        //Arrange
        Basket basket = new Basket();

        //Act
        int expectedResult = basket.CheckCurrentCapacity();
        int actualResult = 10;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [Test, Order(6)]
    public void Test_06_CheckTotalCost()
    {
        //Arrange
        Basket basket = new Basket();

        //Act
        double expectedResult = basket.CheckTotalCost();
        double actualResult = 1.0d;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    //---------------------------------------------------------------------------------
    //Product

    [Test, Order(7)]
    public void Test_07_CheckPriceOfProduct()
    {
        //Arrange
        Bagel bagel = new Bagel("BGLO");

        //Act
        double expectedResult = bagel.CheckPriceOfProduct();
        double actualResult = 1.0d;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }



    //---------------------------------------------------------------------------------
    //Bagel

    [Test, Order(8)]
    public void Test_08_ChooseFilling()
    {
        //Arrange
        Bagel bagel = new Bagel("BGLO");

        //Act
        bool expectedResult = false; //bagel.ChooseFilling("FILB");
        bool actualResult = true;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [Test, Order(9)]
    public void Test_09_CheckPriceOfProduct()
    {
        //Arrange
        Bagel bagel = new Bagel("BGLO");
        //bagel.ChooseFilling("FILB");

        //Act
        double expectedResult = bagel.CheckPriceOfProduct();
        double actualResult = 1.0d;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }



    //---------------------------------------------------------------------------------
    //Store

    [Test, Order(10)]
    public void Test_10_IsProductInInventory()
    {
        //Arrange
        Store store = new Store();

        //Act
        bool expectedResult = store.IsProductInInventory("BGLO");
        bool actualResult = true;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [Test, Order(11)]
    public void Test_11_Success_ChangeBasketSize()
    {
        //Arrange
        Store store = new Store();

        //Act
        bool expectedResult = store.ChangeBasketSize(true);
        bool actualResult = true;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [Test, Order(11)]
    public void Test_11_Fail_ChangeBasketSize()
    {
        //Arrange
        Store store = new Store();

        //Act
        bool expectedResult = store.ChangeBasketSize(false);
        bool actualResult = false;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }



    //---------------------------------------------------------------------------------
    //Person

    [Test, Order(12)]
    public void Test_12_Person_IsProductInInventory()
    {
        //Arrange
        Store store = new Store();
        Person customer = new Person(null, false);

        //Act
        bool expectedResult = customer.IsProductInInventory("BGLO");
        bool actualResult = true;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }


    [Test, Order(13)]
    public void Test_13_Success_Person_ChangeBasketSize()
    {
        //Arrange
        Store store = new Store();
        Person manager = new Person(null, true);

        //Act
        bool expectedResult = manager.ChangeBasketSize();
        bool actualResult = true;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [Test, Order(13)]
    public void Test_13_Fail_Person_ChangeBasketSize()
    {
        //Arrange
        Store store = new Store();
        Person manager = new Person(null, false);

        //Act
        bool expectedResult = manager.ChangeBasketSize();
        bool actualResult = false;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

}