using exercise.main;

namespace exercise.tests;

public class Tests
{
    protected static Inventory inventory;
    [SetUp]
    public void Setup()
    {
        inventory = new Inventory();
        Seed.AddData(out inventory);
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}