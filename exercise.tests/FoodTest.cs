using exercise.main;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetNameOfFoodItemsTest()
    {
        Bagel bagel = new();
        Coffee coffee = new();
        Filling filling = new();

        Assert.That(bagel.Name, Is.EqualTo("Bagel"));
        Assert.That(coffee.Name, Is.EqualTo("Coffee"));
        Assert.That(filling.Name, Is.EqualTo("Filling"));
    }
}