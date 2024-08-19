using exercise.main;
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
        p.addItemToBascet(bagleType.BGLO);
        p.addItemToBascet(drinkType.COFB);
        p.addItemToBascet(drinkType.COFB);
        p.addItemToBascet(fillingType.FILS);
        return p;
    }

    [Test]
    public void AddToBasket()
    {
        Customer p = createCustomerAndItems();
        Assert.True(p.addItemToBascet(bagleType.BGLE));
        Assert.False(p.addItemToBascet(fillingType.FILS));

    }

    [Test]
    public void RemoveFromBasket()
    {
        Customer p = createCustomerAndItems();
        Product item = new Drink(drinkType.COFB);
        p.addItemToBascet(item);
        Assert.True(p.GetBasket().Count == 5);
        Assert.True(p.removeItemFromBasket(item));
        Assert.True(p.GetBasket().Count == 4);

    }

    [Test]
    public void GetTotalCostOfBasket()
    {
        Customer p = new Customer("Tom");
        p.addItemToBascet(bagleType.BGLO);
        p.addItemToBascet(drinkType.COFB);
        p.addItemToBascet(drinkType.COFB);
        Assert.True(p.GetCost() == 2.47f);


    }

    [Test]
    public void ChangeCapacityOfBasket()
    {
        Customer p = createCustomerAndItems();
        Assert.True(p.GetBasketMaxSize() == 5);
        Manager M = new Manager("Manager");
        M.SetMaxSize(10, p);
        Assert.True(p.GetBasketMaxSize() == 10);

    }
}   