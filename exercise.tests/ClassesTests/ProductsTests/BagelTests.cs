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
            Sku = "bglo",
            Price = 0.49M,
            Name = "bagel",
            Variant = "onion",
            /*_stock = int.MaxValue*/
        };

        Assert.That(bagel.Sku, Is.Not.Null);
        Assert.That(bagel.Sku, Is.Not.Empty);
        Assert.That(bagel.Sku, Is.EqualTo("bglo"));

        Assert.That(bagel.Price, Is.Not.EqualTo(0));
        Assert.That(bagel.Price, Is.EqualTo(0.49M));

        Assert.That(bagel.Name, Is.Not.Null);
        Assert.That(bagel.Name, Is.Not.Empty);
        Assert.That(bagel.Name, Is.EqualTo("bagel"));

        Assert.That(bagel.Variant, Is.Not.Null);
        Assert.That(bagel.Variant, Is.Not.Empty);
        Assert.That(bagel.Variant, Is.EqualTo("onion"));

        /*Assert.That(firstBagel._stock, Is.GreaterThan(0));*/
    }

    [Test]
    [Category("Bagel.cs")]
    public void AddFillingTest()
    {
        Bagel bagel = new()
        {
            Sku = "bglo",
            Price = 0.49M,
            Name = "bagel",
            Variant = "onion",
        };

        bagel.AddFilling("filb");

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(1));
        Assert.That(bagel.GetFillings()[0].Variant, Is.EqualTo("bacon"));

        bagel.AddFilling("egg");

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(2));
        Assert.That(bagel.GetFillings()[1].Sku, Is.EqualTo("file"));

        bagel.AddFilling("filc");

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(3));
        Assert.That(bagel.GetFillings()[2].Variant, Is.EqualTo("cheese"));

        bagel.AddFilling("Cream Cheese");

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(4));
        Assert.That(bagel.GetFillings()[3].Sku, Is.EqualTo("filx"));

        bagel.AddFilling("fils");

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(5));
        Assert.That(bagel.GetFillings()[4].Variant, Is.EqualTo("smokedsalmon"));

        bagel.AddFilling("ham");

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(6));
        Assert.That(bagel.GetFillings()[5].Sku, Is.EqualTo("filh"));
    }

    [Test]
    [Category("Bagel.cs")]
    public void RemoveFillingTest()
    {
        Bagel bagel = new()
        {
            Sku = "bglo",
            Price = 0.49M,
            Name = "bagel",
            Variant = "onion",
        };

        bagel.AddFilling("filb");

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(1));
        Assert.That(bagel.GetFillings()[0].Variant, Is.EqualTo("bacon"));

        bagel.AddFilling("egg");

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(2));
        Assert.That(bagel.GetFillings()[1].Sku, Is.EqualTo("file"));

        bagel.RemoveFilling("filb");

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(1));
        Assert.That(bagel.GetFillings()[0].Sku, Is.EqualTo("file"));

        bagel.RemoveFilling("egg");

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(0));

        bagel.RemoveFilling("egg");

        Assert.That(bagel.GetFillings().Count, Is.EqualTo(0));
    }

    [Test]
    [Category("Bagel.cs")]
    public void FillingCostTest()
    {
        Bagel bagel = new()
        {
            Sku = "bglo",
            Price = 0.49M,
            Name = "bagel",
            Variant = "onion",
        };

        Assert.That(bagel.FillingCost(), Is.EqualTo(0));

        bagel.AddFilling("filb");

        Assert.That(bagel.FillingCost(), Is.EqualTo(0.12M));

        bagel.AddFilling("filh");

        Assert.That(bagel.FillingCost(), Is.EqualTo(0.24M));
    }
}
