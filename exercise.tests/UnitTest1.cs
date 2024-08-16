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
}