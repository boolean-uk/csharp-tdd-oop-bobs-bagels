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
        Bagel bagel = new(BagelType.Sesame);

        //execute
        basket.AddBagel(bagel);

        //verify
        Assert.That(basket.GetBagels().Count, Is.EqualTo(1));
        Assert.That(basket.GetBagels()[0], Is.EqualTo(bagel));
    }

    [Test]
    public void TestRemoveBagelFromBasket()
    {
        //setup
        Basket basket = new();
        Bagel bagel = new(BagelType.Sesame);
        basket.AddBagel(bagel);

        //execute
        bool wasRemoved = basket.RemoveItem(bagel);

        //verify
        Assert.True(wasRemoved);
        Assert.That(basket.GetBagels(), Is.Empty);
    }

    [Test]
    public void TestIsFull()
    {
        //setup
        Basket basket = new(2);
        Bagel bagel = new(BagelType.Sesame);
        basket.AddBagel(bagel);

        //execute
        bool shouldNotBeFull = basket.IsFull();
        Bagel bagel2 = new(BagelType.Onion);
        basket.AddBagel(bagel2);
        bool shouldBeFull = basket.IsFull();

        //verify
        Assert.Multiple(() =>
        {
            Assert.That(shouldNotBeFull, Is.False);
            Assert.That(shouldBeFull, Is.True);
        });
    }

    [Test]
    public void TestChangeBasketCapacity()
    {
        //setup
        Basket basket = new(1);
        Bagel bagel = new(BagelType.Sesame);

        //execute
        bool shouldBeFull = basket.IsFull();
        basket.ChangeBasketCapacity(3);
        bool shouldNotBeFull = basket.IsFull();

        //verify
        Assert.Multiple(() =>
        {
            Assert.That(shouldBeFull, Is.True);
            Assert.That(shouldNotBeFull, Is.False);
        });
    }

    [Test]
    public void TestDoesItemExist()
    {
        //setup
        Basket basket = new(5);
        Bagel bagel = new(BagelType.Sesame);
        basket.AddBagel(bagel);

        //execute
        Bagel bagel2 = new(BagelType.Plain);
        bool shouldExist = basket.DoesItemExist(bagel);
        bool shouldNotExist = basket.DoesItemExist(bagel2);

        //verify
        Assert.Multiple(() =>
        {
            Assert.That(shouldExist, Is.True);
            Assert.That(shouldNotExist, Is.False);
        });
    }

    [Test]
    public void GetTotalItemCost()
    {
        //setup
        Basket basket = new(5);
        Bagel bagel = new(BagelType.Sesame);
        basket.AddBagel(bagel);

        //execute
        double totalPrice = basket.GetBasketCost();

        //verify
        Assert.That(totalPrice, Is.EqualTo(0.49));
    }
}