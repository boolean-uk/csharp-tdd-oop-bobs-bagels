using exercise;
namespace exercise.tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Extension1Tests
{
    private Inventory _inventory;
    public Extension1Tests()
    {
        _inventory = new Inventory();
    }

    [Test]
    public void GetDiscountSix()
    {
        Basket basket = new Basket();
        basket.MaxCapacity = 25;
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");

        var discountedTotal = basket.GetTotalCost();
        Console.WriteLine(discountedTotal.ToString());

        Assert.IsTrue(discountedTotal == 2.49m);
    }

    [Test]
    public void GetDiscountsTwelve()
    {
        Basket basket = new Basket();
        basket.MaxCapacity = 25;
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");

        var discountedTotal = basket.GetTotalCost();
        Console.WriteLine(discountedTotal.ToString());
        Assert.IsTrue(discountedTotal == 3.99m);
    }

    [Test]
    public void GetDiscountsMixAll()
    {
        Basket basket = new Basket();
        basket.MaxCapacity = 30;
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");
        basket.AddProduct("BGLP");

        basket.AddProduct("BGLE");
        basket.AddProduct("BGLE");
        basket.AddProduct("BGLE");
        basket.AddProduct("BGLE");
        basket.AddProduct("BGLE");
        basket.AddProduct("BGLE");

        basket.AddProduct("BGLO");
        basket.AddProduct("BGLO");

        basket.AddProduct("COFB");
        basket.AddProduct("COFB");
        basket.AddProduct("COFB");


        var discountedTotal = basket.GetTotalCost();
        Console.WriteLine(discountedTotal);
        Assert.IsTrue(discountedTotal == 9.97m);
    }

    [Test]
    public void GetDiscountsCoffee()
    {
        Basket basket = new Basket();
        basket.MaxCapacity = 25;

        basket.AddProduct("BGLE");
        basket.AddProduct("BGLE");
        basket.AddProduct("BGLE");

        basket.AddProduct("COFB");
        basket.AddProduct("COFB");
        basket.AddProduct("COFB");


        var discountedTotal = basket.GetTotalCost();
        Console.WriteLine(discountedTotal.ToString());
        Assert.IsTrue(discountedTotal == 3.75m);
    }

    [Test]
    public void GetDiscountsMoreCoffee()
    {
        Basket basket = new Basket();
        basket.MaxCapacity = 25;

        basket.AddProduct("BGLE");
        basket.AddProduct("BGLE");
        basket.AddProduct("BGLE");

        basket.AddProduct("COFL");
        basket.AddProduct("COFC");


        var discountedTotal = basket.GetTotalCost();
        Console.WriteLine(discountedTotal.ToString());
        Assert.IsTrue(discountedTotal == 2.99m);
    }




}
