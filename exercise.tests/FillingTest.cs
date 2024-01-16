namespace exercise.tests;
using exercise.main;

[TestFixture]
public class FillingTest
{
    [Test]
    public void TestGetPrice()
    {
        //setup
        Filling filling = new(FillingType.Bacon);

        //execute
        double price = filling.GetPrice();

        //assert
        Assert.That(price, Is.EqualTo(0.12));
        Assert.That(price, Is.EqualTo(filling.Price));
    }
}

