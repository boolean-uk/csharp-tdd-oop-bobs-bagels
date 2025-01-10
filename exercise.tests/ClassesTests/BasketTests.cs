using exercise.main.Classes;
using exercise.main.Classes.Products;
using Microsoft.VisualBasic;

namespace exercise.tests.ClassesTests;

public class BasketTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [Category("Basket.cs")]
    public void CreateBasketTest()
    {
        Basket basket = new();

        Assert.That(basket.GetBagels(), Is.Not.Null);
        Assert.That(basket.GetBagels().Count, Is.EqualTo(0));

        Assert.That(basket.Capacity, Is.EqualTo(5));
    }

    [Test]
    [Category("Basket.cs")]
    public void AddBagelTest()
    {
        Basket basket = new();

        basket.AddBagel("BgLo");

        Assert.That(basket.GetBagels().Count, Is.EqualTo(1));
        Assert.That(basket.GetBagels()[0].Variant, Is.EqualTo("onion"));

        basket.AddBagel("pLaIn");

        Assert.That(basket.GetBagels().Count, Is.EqualTo(2));
        Assert.That(basket.GetBagels()[1].Sku, Is.EqualTo("bglp"));

        basket.AddBagel("bGlE");

        Assert.That(basket.GetBagels().Count, Is.EqualTo(3));
        Assert.That(basket.GetBagels()[2].Variant, Is.EqualTo("everything"));

        basket.AddBagel("sEsAmE");

        Assert.That(basket.GetBagels().Count, Is.EqualTo(4));
        Assert.That(basket.GetBagels()[3].Sku, Is.EqualTo("bgls"));

        basket.AddBagel("bglo");
        Assert.That(basket.GetBagels().Count, Is.EqualTo(5));

        basket.AddBagel("bglo");
        Assert.That(basket.GetBagels().Count, Is.EqualTo(5));
    }

    [Test]
    [Category("Basket.cs")]
    public void RemoveBagelTest()
    {
        Basket basket = new();

        basket.AddBagel("BgLo");

        Assert.That(basket.GetBagels().Count, Is.EqualTo(1));
        Assert.That(basket.GetBagels()[0].Variant, Is.EqualTo("onion"));

        basket.AddBagel("pLaIn");

        Assert.That(basket.GetBagels().Count, Is.EqualTo(2));
        Assert.That(basket.GetBagels()[1].Sku, Is.EqualTo("bglp"));

        basket.RemoveBagel("oNiOn");

        Assert.That(basket.GetBagels().Count, Is.EqualTo(1));
        Assert.That(basket.GetBagels()[0].Sku, Is.EqualTo("bglp"));

        basket.RemoveBagel("bGlP");

        Assert.That(basket.GetBagels().Count, Is.EqualTo(0));

        basket.RemoveBagel("bGlP");

        Assert.That(basket.GetBagels().Count, Is.EqualTo(0));
    }

    [Test]
    [Category("Basket.cs")]
    public void ClearBasketTest()
    {
        Basket basket = new();

        basket.AddBagel("BgLo");
        basket.AddBagel("pLaIn");

        Assert.That(basket.GetBagels().Count, Is.EqualTo(2));

        basket.Clear();

        Assert.That(basket.GetBagels().Count, Is.EqualTo(0));

        basket.Clear();

        Assert.That(basket.GetBagels().Count, Is.EqualTo(0));
    }

    [Test]
    [Category("Basket.cs")]
    public void TotalCostTest()
    {
        Basket basket = new();

        basket.AddBagel("BgLo");

        Assert.That(basket.TotalCost(), Is.EqualTo(0.49M));

        basket.AddBagel("pLaIn");

        Assert.That(basket.TotalCost(), Is.EqualTo(0.88M));

        basket.AddBagel("bGlE");

        Assert.That(basket.TotalCost(), Is.EqualTo(1.37M));

        basket.AddBagel("sEsAmE");

        Assert.That(basket.TotalCost(), Is.EqualTo(1.86M));

        basket.Clear();

        Assert.That(basket.TotalCost(), Is.EqualTo(0));
    }

    [Test]
    [Category("Basket.cs")]
    public void IsFullTest()
    {
        Basket basket = new();

        Assert.That(basket.IsFull(), Is.EqualTo(false));

        basket.AddBagel("BgLo");

        Assert.That(basket.IsFull(), Is.EqualTo(false));

        basket.AddBagel("pLaIn");

        Assert.That(basket.IsFull(), Is.EqualTo(false));

        basket.AddBagel("bGlE");

        Assert.That(basket.IsFull(), Is.EqualTo(false));

        basket.AddBagel("sEsAmE");

        Assert.That(basket.IsFull(), Is.EqualTo(false));

        basket.AddBagel("sEsAmE");

        Assert.That(basket.IsFull(), Is.EqualTo(true));
    }

    [Test]
    [Category("Basket.cs")]
    public void ChangeCapacity()
    {
        Basket basket = new Basket();

        for (int i = 0; i < 10; i++)
        {
            basket.AddBagel("bglo");
        }

        List<Bagel> fiveBagels = basket.GetBagels();

        Assert.That(fiveBagels.Count, Is.EqualTo(5));

        basket.ChangeCapacity(10);

        for (int i = 0; i < 10; i++)
        {
            basket.AddBagel("bglo");
        }

        List<Bagel> tenBagels = basket.GetBagels();

        Assert.That(tenBagels.Count, Is.EqualTo(10));

    }
}
