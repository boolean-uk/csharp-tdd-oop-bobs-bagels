using exercise.main;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestFilling()
    {
        Filling filling = new Filling("Bacon");

        Assert.That(filling.Variant, Is.EqualTo("Bacon"));
        Assert.That(filling.Price, Is.EqualTo(0.12));
        Assert.That(filling.SKU, Is.EqualTo("FILB"));
    }
}