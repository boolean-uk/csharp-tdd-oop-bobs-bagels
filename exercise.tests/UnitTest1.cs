using System.Reflection.Metadata;
using exercise.main;
using NUnit.Framework.Interfaces;

namespace exercise.tests;

public class Tests
{

    [Test]
    public void AddBagelTest()
    {
        User user = new User();

        user.AddToBasket("bglo");

        Assert.That(user.UserBasket.Items[0].Description, Is.EqualTo("Onion"));
    }

    [Test]
    public void RemoveBagelTest() 
    {
        User user = new User();
        user.AddToBasket("bglo");
        user.AddToBasket("bglo");

        user.RemoveFromBasket("bglo");

        Assert.That(user.UserBasket.Items.Count, Is.EqualTo(1));
    }

    [Test]
    public void AddBeyondCapacityTest()
    {
        User user = new User();
        user.AddToBasket("bglo");
        user.AddToBasket("bglp");
        user.AddToBasket("bgle");
        user.AddToBasket("cofb");
        user.AddToBasket("cofc");
        user.AddToBasket("bglo");
        user.AddToBasket("bglp");
        user.AddToBasket("bgle");
        user.AddToBasket("cofb");
        user.AddToBasket("cofc");
        user.AddToBasket("cofb");
        user.AddToBasket("cofc");
        user.AddToBasket("bglo");
        user.AddToBasket("bglp");
        user.AddToBasket("bgle");
        user.AddToBasket("cofb");
        user.AddToBasket("cofc");
        user.AddToBasket("bglo");
        user.AddToBasket("bglp");
        user.AddToBasket("bgle");
        user.AddToBasket("cofb");
        user.AddToBasket("cofc");
        user.AddToBasket("cofb");
        user.AddToBasket("cofc");
        user.AddToBasket("cofb");
        user.AddToBasket("cofc");
        user.AddToBasket("cofb");


        bool added = user.AddToBasket("bgls");

        Console.WriteLine("ohno" + Basket.Capacity);
        Assert.That(!added);

    }


    //hmm but what if manager changes capacity to a lower number, after customers baskets are already full?
    [Test]
    public void ManagerChangeCapacityTest()
    {
        User manager = new User(manager: true);
        User customer = new User();

        manager.ChangeBasketCapacity(11);
        customer.ChangeBasketCapacity(20);

        Assert.That(Basket.Capacity , Is.EqualTo(11));
    }

    [Test]
    public void RemoveItemNotInBasketTest()
    {
        User user = new User();
        user.AddToBasket("cofl");

        bool removed = user.RemoveFromBasket("filb");

        Assert.That(!removed);
    }

    [TestCase(1.37f, "bglo", "bglp", "bgle")]
    [TestCase(0.98f, "bglo", "bgle")]
    [TestCase(1.73f, "bglo", "bglp", "bgle", "filb", "filb", "filx")]
    [TestCase(5.18f, "cofw", "cofc", "cofl", "cofl", "fils")]
    [TestCase(2.84f, "bgle", "bgle", "bgle", "bgle", "bgle", "bglp")]
    public void TotalCostTest(float expected, params string[] items)
    {
        User user = new User();
        
        foreach (string item in items)
        {
            user.AddToBasket(item);
        }
        Assert.That(user.GetTotalCost(), Is.EqualTo(expected));
    }

    [Test]
    public void ItemPriceTest()
    {
        User user = new User();

        Assert.That(user.GetItemPrice("bgle"), Is.EqualTo(0.49f));
    }

    [Test]
    public void OrderOnlyInventoryTest()
    {
        User user = new User();

        bool added = user.AddToBasket("pizzamizza woohoo yeee");

        Assert.That(!added);
    }
}

public class TestExtension
{
    [TestCase(2.49f, "bgle", "bgle", "bgle", "bgle", "bgle", "bgle")] //6 for 2.49
    [TestCase(3.99f, "bglo", "bglo", "bglo", "bglo", "bglo", "bglo", "bglo", "bglo", "bglo", "bglo", "bglo", "bglo")] //12 for 3.99
    [TestCase(3.37f, "bglp", "bglp", "bglp", "bglp", "bglp", "bglp", "bglo", "bglp")] //6 for 2.49 + one onion and one plain
    [TestCase(3.75f, "bglo", "bglp", "bgle", "cofb", "cofb", "cofb")] // 3 x Coffe & bagel for 1.25
    public void DiscountTest(float expected, params string[] items)
    {
        User manager = new User(manager: true);
        manager.ChangeBasketCapacity(15);
        foreach (string item in items)
        {
            manager.AddToBasket(item);
        }

        float cost = manager.GetTotalCost();

        Assert.That(cost, Is.EqualTo(expected));
    }

    [TestCase( "bglo", "bglp", "bgle")] //1,37
    [TestCase( "bglo", "bgle")] //0.98
    [TestCase( "bglo", "bglp", "bgle", "filb", "filb", "filx")] //1.73
    [TestCase( "cofw", "cofc", "cofl", "cofl", "fils")] //5.18
    [TestCase( "bgle", "bgle", "bgle", "bgle", "bgle", "bglp")] //2.84
    [TestCase( "bgle", "bgle", "bgle", "bgle", "bgle", "bgle")] //6 for 2.49
    [TestCase( "bglo", "bglo", "bglo", "bglo", "bglo", "bglo", "bglo", "bglo", "bglo", "bglo", "bglo", "bglo")] //12 for 3.99
    [TestCase( "bglp", "bglp", "bglp", "bglp", "bglp", "bglp", "bglo", "bglp")] //6 for 2.49 + one onion and one plain
    [TestCase( "bglo", "bglp", "bgle", "cofb", "cofb", "cofb")] //3.75
    [TestCase( "bglo", "bglo", "bglp", "bglp", "bglp", "bglp", "bglp", "bglp", "bglp", "bglp", "bglp", "bglp", "bglp", "bglp", "bgle", "bgle", "bgle", "cofb", "cofb", "cofb")] //total 8,72
    public void ReceiptCheck(params string[] items)
    {
        User manager = new User(manager: true);
        manager.ChangeBasketCapacity(25);
        foreach (string item in items)
        {
            manager.AddToBasket(item);
        }

        manager.GetReceipt();
    }
}