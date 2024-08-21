using exercise.main;
using exercise.main.products;
using System.Xml.Serialization;
using static NUnit.Framework.Internal.OSPlatform;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    public Customer createCustomerAndItems()
    {
        Customer p = new Customer("Tom");
        p.Basket.addItemToBascet(productType.BGLO);
        p.Basket.addItemToBascet(productType.COFB);
        p.Basket.addItemToBascet(productType.COFB);
        p.Basket.addItemToBascet(productType.FILS);
        return p;
    }

    [Test]
    public void AddToBasket()
    {
        Customer p = createCustomerAndItems();
        Assert.True(p.Basket.addItemToBascet(productType.BGLE));
        Assert.False(p.Basket.addItemToBascet(productType.FILS));

    }

    [Test]
    public void RemoveFromBasket()
    {
        Customer p = createCustomerAndItems();
        Product item = new Drink(productType.COFB);
        p.Basket.addItemToBascet(item);
        Assert.True(p.Basket.GetBasket().Count == 5);
        Assert.True(p.Basket.removeItemFromBasket(item));
        Assert.True(p.Basket.GetBasket().Count == 4);

    }

    [Test]
    public void GetTotalCostOfBasket()
    {
        Customer p = new Customer("Tom");
        p.Basket.addItemToBascet(productType.BGLO);
        p.Basket.addItemToBascet(productType.COFB);
        p.Basket.addItemToBascet(productType.COFB);
        Assert.True(p.Basket.GetCost() == 2.47f);


    }

    [Test]  
    public void ChangeCapacityOfBasket()
    {
        Customer p = createCustomerAndItems();
        Assert.True(p.Basket.GetBasketMaxSize() == 5);
        Manager M = new Manager("Manager");
        M.SetMaxSize(10, p);
        Assert.True(p.Basket.GetBasketMaxSize() == 10);

    }
}   