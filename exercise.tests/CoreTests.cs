using exercise.main;
using System.Reflection.Emit;

namespace exercise.tests;

public class Core
{

    //---------------------------------------------------------------------------------
    //Basket


    /// <summary>
    /// I'd like to add a specific type of bagel to my basket
    /// </summary>
    [Test, Order(1)]
    public void Test_01_Success_addProduct()
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


    /// <summary>
    /// I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
    /// </summary>
    [Test, Order(1)]
    public void Test_01_Fail_addProduct()
    {
        //Arrange
        Basket basket = new Basket();
        Store.ChangeBasketSize(true, 1);
        Bagel bagel1 = new Bagel("BGLO");
        Bagel bagel2 = new Bagel("BGLO");
        basket.AddProduct(bagel1);

        //Act
        bool expectedResult = basket.AddProduct(bagel2);
        bool actualResult = false;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }



    /// <summary>
    /// I'd like to remove a bagel from my basket.
    /// </summary>
    [Test, Order(2)]
    public void Test_02_Success_RemoveProduct()
    {
        //Arrange
        Basket basket = new Basket();
        Bagel bagel = new Bagel("BGLO");
        basket.AddProduct(bagel);

        //Act
        bool expectedResult = basket.RemoveProduct(bagel);
        bool actualResult = true;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    /// <summary>
    /// I'd like to know if I try to remove an item that doesn't exist in my basket.
    /// </summary>
    [Test, Order(2)]
    public void Test_02_Fail_RemoveProduct()
    {
        //Arrange
        Basket basket = new Basket();
        Bagel bagel = new Bagel("BGLO");

        //Act
        bool expectedResult = basket.RemoveProduct(bagel); //The bagel was not added to the list and does not exist.
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
        bool expectedResult = basket.IsProductInBasket(bagel);
        bool actualResult = true;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    [Test, Order(3)]
    public void Test_03_Fail_IsProductInBasket()
    {
        //Arrange
        Basket basket = new Basket();
        Bagel bagel = new Bagel("BGLO");
        //Act
        bool expectedResult = basket.IsProductInBasket(bagel);
        bool actualResult = false;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    /// <summary>
    /// I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
    /// </summary>
    [Test, Order(4)]
    public void Test_04_TotalCapacity()
    {
        //Arrange
        Basket basket = new Basket();
        Store.ChangeBasketSize(true, 12);


        //Act
        int expectedResult = basket.TotalCapacity(); ;
        int actualResult = 12; //default

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    /// <summary>
    /// I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
    /// </summary>
    [Test, Order(5)]
    public void Test_05_CheckCurrentCapacity()
    {
        //Arrange
        Basket basket = new Basket();
        Bagel bagel1 = new Bagel("BGLO");
        Bagel bagel2 = new Bagel("BGLO");
        Bagel bagel3 = new Bagel("BGLO");
        Bagel bagel4 = new Bagel("BGLO");
        Bagel bagel5 = new Bagel("BGLO");
        Bagel bagel6 = new Bagel("BGLO");
        basket.AddProduct(bagel1);
        basket.AddProduct(bagel2);
        basket.AddProduct(bagel3);
        basket.AddProduct(bagel4);
        basket.AddProduct(bagel5);
        basket.AddProduct(bagel6);


        //Act
        int expectedResult = basket.CheckCurrentCapacity();
        int actualResult = 6;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    /// <summary>
    /// I'd like to know the total cost of items in my basket.
    /// </summary>
    [Test, Order(6)]
    public void Test_06_CheckTotalCost()
    {
        //Arrange
        Basket basket = new Basket();
        Bagel bagel1 = new Bagel("BGLO");
        Bagel bagel2 = new Bagel("BGLO");
        basket.AddProduct(bagel1);
        basket.AddProduct(bagel2);

        //Act
        double expectedResult = basket.CheckTotalCost();
        double actualResult = 0.98d;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    //---------------------------------------------------------------------------------
    //Product

    /// <summary>
    /// I'd like to know the cost of a bagel before I add it to my basket.
    /// </summary>
    [Test, Order(7)]
    public void Test_07_CheckPriceOfProduct_Bagel()
    {
        //Arrange
        Bagel bagel = new Bagel("BGLO");

        //Act
        double expectedResult = bagel.CheckPriceOfProduct();
        double actualResult = 0.49d;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    /// <summary>
    /// I'd like to know the cost of each filling before I add it to my bagel order.
    /// </summary>
    [Test, Order(7)]
    public void Test_07_CheckPriceOfProduct_Filling()
    {
        //Arrange
        Bagel bagel = new Bagel("BGLO");
        Filling baconFilling = new Filling("FILB");
        //Act
        double expectedResult = baconFilling.CheckPriceOfProduct();
        double actualResult = 0.12d;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    //---------------------------------------------------------------------------------
    //Bagel

    /// <summary>
    /// I'd like to be able to choose fillings for my bagel.
    /// </summary>
    [Test, Order(8)]
    public void Test_08_ChooseFilling()
    {
        //Arrange
        Bagel bagel = new Bagel("BGLO");
        Filling baconFilling = new Filling("FILB");
        Filling eggFilling = new Filling("FILE");
        Filling cheeseFilling = new Filling("FILC");
        Filling creamCheeseFilling = new Filling("FILX");
        Filling smokedSalmonFilling = new Filling("FILS");
        Filling hamFilling = new Filling("FILH");

        //Act
        bool expectedResult = bagel.ChooseFilling(baconFilling);
        bool actualResult = true;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    /// <summary>
    /// I'd like to know the cost of a bagel before I add it to my basket. WORKS WITH FILLING
    /// </summary>
    [Test, Order(9)]
    public void Test_09_CheckPriceOfProduct()
    {
        //Arrange
        Bagel bagel = new Bagel("BGLO");
        Filling baconFilling = new Filling("FILB");
        bagel.ChooseFilling(baconFilling);

        //Act
        double expectedResult = bagel.CheckPriceOfProduct();
        double actualResult = 0.61d;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }



    //---------------------------------------------------------------------------------
    //Store

    /// <summary>
    /// I want customers to only be able to order things that we stock in our inventory.
    /// </summary>
    [Test, Order(10)]
    public void Test_10_Success_IsProductInInventory()
    {
        //Arrange

        //Act
        bool expectedResult = Store.IsProductInInventory("BGLO");
        bool actualResult = true;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    /// <summary>
    /// I want customers to only be able to order things that we stock in our inventory.
    /// </summary>
    [Test, Order(10)]
    public void Test_10_Fail_IsProductInInventory()
    {
        //Arrange

        //Act
        bool expectedResult = Store.IsProductInInventory("FAIL");
        bool actualResult = false;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    /// <summary>
    /// I’d like to change the capacity of baskets.
    /// </summary>
    [Test, Order(11)]
    public void Test_11_Success_ChangeBasketSize()
    {
        //Arrange
        Basket basket = new Basket(); //to check if it's changed in debugging

        //Act
        int actualResult = 666;
        Store.ChangeBasketSize(true, actualResult);
        int expectedResult = basket.TotalCapacity();

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    /// <summary>
    /// I’d like to change the capacity of baskets.
    /// </summary>
    [Test, Order(11)]
    public void Test_11_Fail_ChangeBasketSize()
    {
        //Arrange
        Basket basket = new Basket(); //to check if it's changed in debugging

        //Act
        bool expectedResult = Store.ChangeBasketSize(false, 14);
        bool actualResult = false;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }



    //---------------------------------------------------------------------------------
    //Person

    /// <summary>
    /// I want customers to only be able to order things that we stock in our inventory.
    /// </summary>
    [Test, Order(12)]
    public void Test_12_Person_IsProductInInventory()
    {
        //Arrange
        Person customer = new Person(null, false);

        //Act
        bool expectedResult = customer.IsProductInInventory("BGLO");
        bool actualResult = true;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }


    /// <summary>
    /// I’d like to change the capacity of baskets.
    /// </summary>
    [Test, Order(13)]
    public void Test_13_Success_Person_ChangeBasketSize()
    {
        //Arrange
        Person manager = new Person(null, true);

        //Act
        bool expectedResult = manager.ChangeBasketSize(manager.IsManager, 666);
        bool actualResult = true;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

    /// <summary>
    /// I’d like to change the capacity of baskets.
    /// </summary>
    [Test, Order(13)]
    public void Test_13_Fail_Person_ChangeBasketSize()
    {
        //Arrange
        Person customer = new Person(null, false);

        //Act
        bool expectedResult = customer.ChangeBasketSize(customer.IsManager, 666);
        bool actualResult = false;

        //Assert
        Assert.That(expectedResult, Is.EqualTo(actualResult));
    }

}