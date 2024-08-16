using exercise.main;
using static NUnit.Framework.Internal.OSPlatform;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddToBasket()
    {
        Customer p = new Customer("Tom");
        p.addItemToBascet(productType.BGLO);
        Assert.True(p.addItemToBascet(productType.BGLE));
        p.addItemToBascet(productType.COFB);
        p.addItemToBascet(productType.COFB);
        p.addItemToBascet(productType.COFB);
        Assert.False(p.addItemToBascet(productType.FILS));

    }

    [Test]
    public void RemoveFromBasket()
    {
        Customer p = new Customer("Tom");
        p.addItemToBascet(productType.BGLO);
        p.addItemToBascet(productType.COFB);
        p.addItemToBascet(productType.COFB);
        Product item = new Product(productType.COFB);
        p.addItemToBascet(item);
        Assert.True(p.GetBasket().Count == 4);
        Assert.True(p.removeItemFromBasket(item));
        Assert.True(p.GetBasket().Count == 3);

    }

    [Test]
    public void GetTotalCostOfBasket()
    {
        Customer p = new Customer("Tom");
        p.addItemToBascet(productType.BGLO);
        p.addItemToBascet(productType.COFB);
        p.addItemToBascet(productType.COFB);
        Assert.True(p.GetCost() == 2.47f);


    }
}