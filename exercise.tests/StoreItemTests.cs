using exercise.core;

namespace exercise.tests;

public class StoreItemTests
{
    public List<StoreItem> items = new List<StoreItem>();
    public List<Bagel> bagels = new List<Bagel>();
    public List<BagelFilling> fillings = new List<BagelFilling>();

    [SetUp]
    public void Setup()
    {
        var bagels = TestUtils.testBagels();
        var coffees = TestUtils.testItems();
        var fillings = TestUtils.testFillings();
        this.items = coffees;
        this.bagels = bagels;
        this.fillings = fillings;
    }

    [Test]
    public void BagelAddFillingGetFlattend()
    {
        var bagel = this.bagels[0];
        var filling1 = this.fillings[0];
        var filling2 = this.fillings[1];
        Assert.That(bagel.GetPrice(), Is.EqualTo(0.49));
        Assert.That(bagel.GetItemsFlattened().Count, Is.EqualTo(1));

        bagel.AddFilling(filling1);
        Assert.That(bagel.GetPrice(), Is.EqualTo(0.49 + 0.12));
        Assert.That(bagel.GetItemsFlattened().Count, Is.EqualTo(2));

        bagel.AddFilling(filling2);
        Assert.That(bagel.GetPrice(), Is.EqualTo(0.49 + 0.12 + 0.12));
        Assert.That(bagel.GetItemsFlattened().Count, Is.EqualTo(3));
    }

    [Test]
    public void Validations()
    {
        Assert.Throws<ArgumentException>(() => new StoreItem("TOOLONG", "A", "A", 0.00));
        Assert.Throws<ArgumentException>(() => new Bagel("NBGL", "Bagel", "A", 0.00));
        Assert.Throws<ArgumentException>(() => new Bagel("BGLA", "NotBagel", "A", 0.00));
        Assert.Throws<ArgumentException>(() => new BagelFilling("NFIL", "Filling", "A", 0.00));
        Assert.Throws<ArgumentException>(() => new BagelFilling("FILB", "NotFilling", "A", 0.00));
    }
}
