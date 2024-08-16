using exercise.main;

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
}