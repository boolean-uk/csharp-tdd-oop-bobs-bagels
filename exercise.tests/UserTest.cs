using exercise.core;

namespace exercise.tests;

public class UserTest
{
    private User _user = new User { UserId = "bob", priv = Privilege.User };
    private User _admin = new User { UserId = "ben", priv = Privilege.Admin };

    [SetUp]
    public void Setup()
    {
        _user = new User { UserId = "bob", priv = Privilege.User };
        _admin = new User { UserId = "ben", priv = Privilege.Admin };
    }

    [Test]
    public void ModifyCartCapacity()
    {
        this._user.ModifyCartCapacity(_admin, 5);
        Assert.That(this._user.BasketCapacity, Is.EqualTo(5));
        this._user.ModifyCartCapacity(_admin, 2);
        Assert.That(this._user.BasketCapacity, Is.EqualTo(2));
        this._user.AddItemToCart(TestUtils.testItems()[0]);
        this._user.AddItemToCart(TestUtils.testItems()[1]);
        Assert.False(this._user.ModifyCartCapacity(_admin, 1));
    }

    [Test]
    public void AddGetRemoveItem()
    {
        this._user.ModifyCartCapacity(_admin, 5);
        Assert.That(this._user.GetBasketItems(), Is.Empty);
        this._user.AddItemToCart(TestUtils.testItems()[0]);
        Assert.That(this._user.GetBasketItems().Count, Is.EqualTo(1));
        this._user.AddItemToCart(TestUtils.testItems()[1]);
        Assert.That(this._user.GetBasketItems().Count, Is.EqualTo(2));
        this._user.RemoveItemFromCart(this._user.GetBasketItems().ElementAt(1));
        Assert.That(this._user.GetBasketItems().Count, Is.EqualTo(1));
        this._user.RemoveItemFromCart(this._user.GetBasketItems().ElementAt(0));
        Assert.That(this._user.GetBasketItems().Count, Is.EqualTo(0));
    }

    [Test]
    public void AddToFullCart()
    {
        this._user.ModifyCartCapacity(_admin, 1);
        this._user.AddItemToCart(TestUtils.testItems()[0]);
        Assert.False(this._user.AddItemToCart(TestUtils.testItems()[1]));
        Assert.That(this._user.GetBasketItems().Count, Is.EqualTo(1));
    }

    [Test]
    public void GetCartPrice()
    {
        this._user.ModifyCartCapacity(_admin, 5);
        Assert.That(this._user.GetCartPrice(new DiscountContainer()), Is.EqualTo(0.0));
        // 0.99
        this._user.AddItemToCart(TestUtils.testItems()[0]);
        Assert.That(this._user.GetCartPrice(new DiscountContainer()), Is.EqualTo(0.99));
        // 0.49
        var bagel = TestUtils.testBagels()[0];
        // 0.12
        bagel.AddFilling(TestUtils.testFillings()[0]);
        this._user.AddItemToCart(bagel);
        Assert.That(
            this._user.GetCartPrice(new DiscountContainer()),
            Is.EqualTo(0.99 + 0.49 + 0.12)
        );
    }

    [Test]
    public void BuyCart()
    {
        this._user.ModifyCartCapacity(_admin, 5);
        this._user.AddItemToCart(TestUtils.testItems()[0]);
        Assert.That(this._user.GetBasketItems().Count, Is.EqualTo(1));
        var rc = this._user.BuyCart(new DiscountContainer());
        Assert.That(rc, Is.Not.Null);
        Assert.That(this._user.GetBasketItems().Count, Is.EqualTo(0));
    }
}
