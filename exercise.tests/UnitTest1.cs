using System.Reflection.Metadata;
using exercise.main;

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

        bool added = user.AddToBasket("bgls");

        Assert.That(!added);

    }

    [Test]
    public void ManagerChangeCapacityTest()
    {
        User manager = new User(manager: true);
        User customer = new User();

        manager.ChangeBasketCapacity(10);
        customer.ChangeBasketCapacity(20);

        Assert.That(Basket.Capacity , Is.EqualTo(10));
    }

    [Test]
    public void RemoveItemNotInBasketTest()
    {
        User user = new User();
        user.AddToBasket("cofl");

        bool removed = user.RemoveFromBasket("filb");

        Assert.That(!removed);
    }

    [Test]
    public void TotalCostTest()
    {
        User user = new User();
        user.AddToBasket("bglo");
        user.AddToBasket("bglp");
        user.AddToBasket("cofb");

        Assert.That(user.GetTotalCost, Is.EqualTo(1.87f));
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