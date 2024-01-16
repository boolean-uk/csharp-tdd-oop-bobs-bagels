using exercise.main;

namespace exercise.tests;

public class Tests
{
    public Basket _basket;

    [SetUp]
    public void Setup()
    {
        _basket = new Basket();
    }

    [Test]
    public void AddProductTest()
    {
        string cheeseBagel = "Cheese Bagel";
        _basket.AddProduct(cheeseBagel);

        Assert.That(_basket.GetItems().Count, Is.EqualTo(1));
    }
    [Test]
    public void RemoveProductTest()
    {
        string cheeseBagel = "Cheese Bagel";
        _basket.AddProduct(cheeseBagel);
        _basket.RemoveProduct(cheeseBagel);

        Assert.That(_basket.GetItems().Count, Is.EqualTo(0));
    }

    [Test]
    public void AddProductOverencumberedTest()
    {
        _basket.ChangeCapacity(1);
        string cheeseBagel = "Cheese Bagel";
        string jellyBagel = "jelly Bagel";
        _basket.AddProduct(cheeseBagel);
        string encumbered = _basket.AddProduct(jellyBagel);

        Assert.That(encumbered, Is.EqualTo("Nope. Overencumbered."));
    }

    [Test]
    public void RemoveNonexistingProductTest()
    {
        string cheeseBagel = "Cheese Bagel";
        string jellyBagel = "jelly Bagel";
        _basket.AddProduct(cheeseBagel);
        string nonexistent = _basket.RemoveProduct(jellyBagel);

        Assert.That(nonexistent, Is.EqualTo("No such product to remove."));
    }

}