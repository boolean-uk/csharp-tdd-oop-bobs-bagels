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

        Assert.That(basket.GetProducts(), Is.Not.Null);
        Assert.That(basket.GetProducts().Count, Is.EqualTo(0));

        Assert.That(basket.capacity, Is.EqualTo(5));
    }

    [Test]
    [Category("Basket.cs")]
    public void AddProductTest()
    {
        Inventory inventory = new Inventory();
        Basket basket = new();

        basket.AddProduct("bglo", inventory);

        Assert.That(basket.GetProducts().Count, Is.EqualTo(1));
        Assert.That(basket.GetProducts()[0].Variant, Is.EqualTo("Onion"));

        basket.AddProduct("bglp", inventory);

        Assert.That(basket.GetProducts().Count, Is.EqualTo(2));
        Assert.That(basket.GetProducts()[1].Variant, Is.EqualTo("Plain"));

        basket.AddProduct("cofb", inventory);

        Assert.That(basket.GetProducts().Count, Is.EqualTo(3));
        Assert.That(basket.GetProducts()[2].Variant, Is.EqualTo("Black"));

        basket.AddProduct("cofw", inventory);

        Assert.That(basket.GetProducts().Count, Is.EqualTo(4));
        Assert.That(basket.GetProducts()[3].Variant, Is.EqualTo("White"));

        basket.AddProduct("filb", inventory);
        Assert.That(basket.GetProducts().Count, Is.EqualTo(5));
        Assert.That(basket.GetProducts()[4].Variant, Is.EqualTo("Bacon"));

        basket.AddProduct("file", inventory);
        Assert.That(basket.GetProducts().Count, Is.EqualTo(5));
    }

    [Test]
    [Category("Basket.cs")]
    public void RemoveProductTest()
    {
        Inventory inventory = new Inventory();
        Basket basket = new();

        basket.AddProduct("bglo", inventory);

        Assert.That(basket.GetProducts().Count, Is.EqualTo(1));
        Assert.That(basket.GetProducts()[0].Variant, Is.EqualTo("Onion"));

        basket.AddProduct("bglp", inventory);

        Assert.That(basket.GetProducts().Count, Is.EqualTo(2));
        Assert.That(basket.GetProducts()[1].Variant, Is.EqualTo("Plain"));

        basket.RemoveProduct("bglo");

        Assert.That(basket.GetProducts().Count, Is.EqualTo(1));
        Assert.That(basket.GetProducts()[0].Variant, Is.EqualTo("Plain"));

        basket.RemoveProduct("bglo");

        Assert.That(basket.GetProducts().Count, Is.EqualTo(1));

        basket.RemoveProduct("bglp");

        Assert.That(basket.GetProducts().Count, Is.EqualTo(0));

    }

    [Test]
    [Category("Basket.cs")]
    public void ClearBasketTest()
    {
        Inventory inventory = new Inventory();
        Basket basket = new();

        basket.AddProduct("bglo", inventory);
        basket.AddProduct("bglp", inventory);

        Assert.That(basket.GetProducts().Count, Is.EqualTo(2));

        basket.Clear();

        Assert.That(basket.GetProducts().Count, Is.EqualTo(0));

        basket.Clear();

        Assert.That(basket.GetProducts().Count, Is.EqualTo(0));
    }

    [Test]
    [Category("Basket.cs")]
    public void TotalCostTest()
    {
        Inventory inventory = new Inventory();
        Basket basket = new();

        basket.AddProduct("bglo", inventory);

        Assert.That(basket.TotalCost(), Is.EqualTo(0.49M));

        basket.AddProduct("bglp", inventory);

        Assert.That(basket.TotalCost(), Is.EqualTo(0.88M));

        basket.AddProduct("bgle", inventory);

        Assert.That(basket.TotalCost(), Is.EqualTo(1.37M));

        basket.AddProduct("bgls", inventory);

        Assert.That(basket.TotalCost(), Is.EqualTo(1.86M));

        basket.Clear();

        Assert.That(basket.TotalCost(), Is.EqualTo(0));
    }

    [Test]
    [Category("Basket.cs")]
    public void IsFullTest()
    {
        Inventory inventory = new Inventory();
        Basket basket = new();

        Assert.That(basket.IsFull(), Is.EqualTo(false));

        basket.AddProduct("bglo", inventory);

        Assert.That(basket.IsFull(), Is.EqualTo(false));

        basket.AddProduct("bglp", inventory);

        Assert.That(basket.IsFull(), Is.EqualTo(false));

        basket.AddProduct("bgle", inventory);

        Assert.That(basket.IsFull(), Is.EqualTo(false));

        basket.AddProduct("bgls", inventory);

        Assert.That(basket.IsFull(), Is.EqualTo(false));

        basket.AddProduct("bgls", inventory);

        Assert.That(basket.IsFull(), Is.EqualTo(true));
    }

    [Test]
    [Category("Basket.cs")]
    public void ChangeCapacityTest()
    {
        Inventory inventory = new Inventory();
        Basket basket = new();

        for (int i = 0; i < 10; i++)
        {
            basket.AddProduct("bglo", inventory);
        }

        List<Product> fiveBagels = basket.GetProducts();

        Assert.That(fiveBagels.Count, Is.EqualTo(5));

        basket.ChangeCapacity(10);

        for (int i = 0; i < 10; i++)
        {
            basket.AddProduct("cofb", inventory);
        }

        List<Product> bagelsAndCoffes = basket.GetProducts();

        Assert.That(bagelsAndCoffes.Count, Is.EqualTo(10));
    }

    [Test]
    [Category("Basket.cs")]
    public void GetProductCountTest()
    {
        Inventory inventory = new Inventory();
        Basket basket = new();

        for (int i = 0; i < 10; i++)
        {
            basket.AddProduct("bglo", inventory);
        }

        int fiveBagelCount = basket.GetProductCount("BGLO");

        Assert.That(fiveBagelCount, Is.EqualTo(5)); 

        basket.ChangeCapacity(512);

        for (int i = 0; i < 512; i++)
        {
            basket.AddProduct("cofb", inventory);
        }

        int manyCoffees = basket.GetProductCount("COFB");

        Assert.That(manyCoffees, Is.EqualTo(507));
    }
}
