namespace exercise.tests;

using exercise.main;

[TestFixture]
public class BasketTest
{

    [Test]
    public void TestAddBagelToBasket()
    {
        //setup
        Basket basket = new();

        //execute
        basket.AddBagel("someBagel");

        //verify
        Assert.That(basket.GetBagels().Count, Is.EqualTo(1));
        Assert.That(basket.GetBagels()[0], Is.EqualTo("someBagel"));
    }

    [Test]
    public void TestRemoveBagelFromBasket()
    {
        //setup
        Basket basket = new();
        basket.AddBagel("someBagel");

        //execute
        bool wasRemoved = basket.RemoveBagel("someBagel");

        //verify
        Assert.True(wasRemoved);
        Assert.That(basket.GetBagels(), Is.Empty);
    }

    [Test]
    public void TestIsFull()
    {
        //setup
        Basket basket = new(2);
        basket.AddBagel("someBagel");

        //execute
        bool shouldNotBeFull = basket.IsFull();
        basket.AddBagel("Some other bagel");
        bool shouldBeFull = basket.IsFull();

        //verify
        Assert.IsFalse(shouldNotBeFull);
        Assert.IsTrue(shouldBeFull);
    }

    [Test]
    public void TestChangeBasketCapacity()
    {
        //setup
        Basket basket = new(1);
        basket.AddBagel("Bagel1");

        //execute
        bool shouldBeFull = basket.IsFull();
        basket.ChangeBasketCapacity(3);
        bool shouldNotBeFull = basket.IsFull();

        //verify
        Assert.IsTrue(shouldBeFull);
        Assert.IsFalse(shouldNotBeFull);
    }
}