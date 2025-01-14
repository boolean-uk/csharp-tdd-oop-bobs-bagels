using exercise.main.Classes;
using exercise.main.Classes.Products;
using Microsoft.VisualBasic;

namespace exercise.tests.ClassesTests.ProductsTests;

public class BagelTests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    [Category("Bagel.cs")]
    public void CreateBagelTest()
    {
        Bagel bagel = new()
        {
            Sku = "BGLO",
            Price = 0.49M,
            Name = "Bagel",
            Variant = "Onion",
        };

        Assert.That(bagel.Sku, Is.Not.Null);
        Assert.That(bagel.Sku, Is.Not.Empty);
        Assert.That(bagel.Sku, Is.EqualTo("BGLO"));

        Assert.That(bagel.Price, Is.Not.EqualTo(0));
        Assert.That(bagel.Price, Is.EqualTo(0.49M));

        Assert.That(bagel.Name, Is.Not.Null);
        Assert.That(bagel.Name, Is.Not.Empty);
        Assert.That(bagel.Name, Is.EqualTo("Bagel"));

        Assert.That(bagel.Variant, Is.Not.Null);
        Assert.That(bagel.Variant, Is.Not.Empty);
        Assert.That(bagel.Variant, Is.EqualTo("Onion"));
    }

    [Test]
    [Category("Bagel.cs")]
    public void AddFillingTest()
    {
        Inventory inventory = new Inventory();
        Bagel bagel = new()
        {
            Sku = "BGLO",
            Price = 0.49M,
            Name = "Bagel",
            Variant = "Onion",
        };

        bagel.AddFilling("filb", inventory);

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(1));
        Assert.That(bagel.GetFillings()[0].Variant, Is.EqualTo("Bacon"));

        bagel.AddFilling("file", inventory);

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(2));
        Assert.That(bagel.GetFillings()[1].Variant, Is.EqualTo("Egg"));

        bagel.AddFilling("filc", inventory);

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(3));
        Assert.That(bagel.GetFillings()[2].Variant, Is.EqualTo("Cheese"));

        bagel.AddFilling("filx", inventory);

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(4));
        Assert.That(bagel.GetFillings()[3].Variant, Is.EqualTo("Cream Cheese"));

        bagel.AddFilling("fils", inventory);

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(5));
        Assert.That(bagel.GetFillings()[4].Variant, Is.EqualTo("Smoked Salmon"));

        bagel.AddFilling("filh", inventory);

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(6));
        Assert.That(bagel.GetFillings()[5].Variant, Is.EqualTo("Ham"));
    }

    [Test]
    [Category("Bagel.cs")]
    public void RemoveFillingTest()
    {
        Inventory inventory = new Inventory();
        Bagel bagel = new()
        {
            Sku = "BGLO",
            Price = 0.49M,
            Name = "Bagel",
            Variant = "Onion",
        };

        bagel.AddFilling("filb", inventory);

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(1));
        Assert.That(bagel.GetFillings()[0].Variant, Is.EqualTo("Bacon"));

        bagel.AddFilling("file", inventory);

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(2));
        Assert.That(bagel.GetFillings()[1].Variant, Is.EqualTo("Egg"));

        bagel.RemoveFilling("filb");

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(1));
        Assert.That(bagel.GetFillings()[0].Variant, Is.EqualTo("Egg"));

        bagel.RemoveFilling("file");

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(0));

        bagel.RemoveFilling("file");

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(0));
    }

    [Test]
    [Category("Bagel.cs")]
    public void FillingCostTest()
    {
        Inventory inventory = new Inventory();
        Bagel bagel = new()
        {
            Sku = "BGLO",
            Price = 0.49M,
            Name = "Bagel",
            Variant = "Onion",
        };

        Assert.That(bagel.TotalFillingCost(), Is.EqualTo(0));

        bagel.AddFilling("filb", inventory);

        Assert.That(bagel.TotalFillingCost(), Is.EqualTo(0.12M));

        bagel.AddFilling("filh", inventory);

        Assert.That(bagel.TotalFillingCost(), Is.EqualTo(0.24M));
    }
}
