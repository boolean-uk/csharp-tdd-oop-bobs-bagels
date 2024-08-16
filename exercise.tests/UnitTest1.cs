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
        Assert.Pass();
    }

}