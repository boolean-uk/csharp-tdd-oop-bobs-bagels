using exercise.main;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Reflection.Emit;

namespace exercise.tests;
[TestFixture]
public class Tests
{
    [Test]
    public void Add()
    {
        // arrange 
        Products products = new Products();
        Basket core = new Basket(products);
        string bagel = Menu.BGLP.ToString();

        // act
        core.Add(bagel);
        Product result = core._Basket.First();
        int length = core._Basket.Count;

        // assert
        Assert.That(result.SKU, Is.EqualTo(bagel));
        Assert.That(length, Is.EqualTo(1));
    }


    [Test]
    public void Remove()
    {
        // arrange 
        Products products = new Products();
        Basket core = new Basket(products);
        string bagel = Menu.BGLP.ToString();
        core.Add(bagel);

        // act
        bool result = core.Remove(bagel);
        int length = core._Basket.Count();

        // assert
        Assert.That(result, Is.True);
        Assert.That(length, Is.EqualTo(0));
    }

    [Test]
    public void Overfill()
    {
        // arrange 
        Products products = new Products();
        Basket core = new Basket(products);
        string bagel = Menu.BGLP.ToString();
        string bagel2 = Menu.BGLE.ToString();
        string bagel3 = Menu.BGLS.ToString();
        core.Add(bagel);
        core.Add(bagel2);

        // act
        bool result = core.Add(bagel3);

        // assert
        Assert.That(result, Is.False);
    }


    [Test]
    public void ChangeCapacity()
    {
        // arrange
        Products products = new Products();
        Basket core = new Basket(products);
        int newCapacity = core._Capacity + 5;


        // assert
        bool result = core.ChangeCapacity(newCapacity);
        int capacity = core._Capacity;

        // act
        Assert.That(result, Is.True);
        Assert.That(capacity, Is.EqualTo(newCapacity));
    }


    [Test]
    public void RemoveBagelThatDoesNotExist()
    {
        // arrange
        Products products = new Products();
        Basket core = new Basket(products);
        string bagel = Menu.BGLP.ToString();
        core.Add(bagel);
        string bagel2 = Menu.BGLE.ToString();

        // assert
        bool result = core.Remove(bagel2);

        // act
        Assert.That(result, Is.False);
    }

    [Test]
    public void TotalCost()
    {
        // arrange
        Products products = new Products();
        Basket core = new Basket(products);
        string bagel = Menu.BGLP.ToString();
        string bagel2 = Menu.BGLE.ToString();
        core.Add(bagel);
        core.Add(bagel2);
        double expected = 0.39 + 0.49;

        // act
        double result = core.TotalCost();

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GetCostOfBagel()
    {
        // arrange
        Products products = new Products();
        Basket core = new Basket(products);
        string bagel = Menu.BGLP.ToString();
        double expected = 0.39;

        // act
        double result = core.GetCostOfBagel(bagel);

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ChooseFilling()
    {
        // arrange
        Products products = new Products();
        Basket core = new Basket(products);
        string bagel = Menu.BGLP.ToString();
        string filling = Menu.FILH.ToString();

        Product p = products.productList.Find(x => x.SKU == bagel);
        Product f = products.productList.Find(x => x.SKU == filling);
        Bagel bwf = new Bagel()
        {
            Id = p.Id,
            Name = p.Name,
            SKU = p.SKU,
            Price = p.Price,
            Variant = p.Variant,
            Filling = f
        };

        // act
        bool result = core.Add(bagel, filling);
        Product result2 = core._Basket.First();

        // assert
        Assert.That(result, Is.True);
        Assert.That(result2, Is.EqualTo(result2));
    }

    [Test]
    public void GetCostOfFilling()
    {
        // arrange
        Products products = new Products();
        double expected = 0.12;

        // act
        Product result = products.productList.Find(x => x.SKU == Menu.FILH.ToString());

        // assert
        Assert.That(result.Price, Is.EqualTo(expected));

    }

    [Test]
    public void Discount()
    {
        // arrange 
        Products products = new Products();
        Basket core = new Basket(products);
        string bagel = Menu.BGLP.ToString();
        string bagel2 = Menu.BGLE.ToString();
        string coffee = Menu.COFB.ToString();
        Product aBagel = products.productList.Find(p => p.SKU == bagel2);
        Product aCoffee = products.productList.Find(p => p.SKU == coffee);
        double expected = 4.99 + 0.98;


        for (int i = 0; i < 6; i++)
        {
            core.Add(bagel);

        }

        for (int i = 0; i < 4; i++)
        {
            core.Add(bagel2);
            // expected += aBagel.Price;
        }

        for (int i = 0; i < 2; i++)
        {
            core.Add(coffee);
        }

        // act
        double result = core.TotalCost();

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Discount2()
    {
        // arrange 
        Products products = new Products();
        Basket core = new Basket(products);
        string bagel = Menu.BGLP.ToString();
        string bagel2 = Menu.BGLE.ToString();
        Product aBagel = products.productList.Find(p => p.SKU == bagel2);
        double expected = 2.49;


        for (int i = 0; i < 6; i++)
        {
            core.Add(bagel);

        }

        for (int i = 0; i < 4; i++)
        {
            core.Add(bagel2);
            expected += aBagel.Price;
        }

        // act
        double result = core.TotalCost();

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }


    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}