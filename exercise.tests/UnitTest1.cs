namespace exercise.tests;

using exercise.main;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

public class Tests
{
    Basket basket = new Basket();

    [SetUp]
    public void Setup()
    {
        basket = new Basket();
    }

    [Test]
    public void TestAddItem()
    {
        Assert.That(basket.items.Count == 0);
        basket.Add(new Bagel())
    }
}