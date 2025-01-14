using exercise.main.Baskets;
using exercise.main.Products;

namespace exercise.tests.Baskets;

[TestFixture]
public class BasketTests
{
    private Basket _basket;
    private Bagel _bagel;
    private Coffee _coffee;

    [SetUp]
    public void SetUp()
    {
        _basket = new Basket(15);
        _bagel = new Bagel("BGLO", 0.45, "Bagel", "Onion");
        _coffee = new Coffee("COFB", 0.5, "Coffee", "Black");
    }

    [Test]
    public void AddItemNotFull()
    {
        _basket.AddItem(_bagel);

        Assert.That(_basket.Contains(_bagel), Is.True);
    }

    [Test]
    public void AddItemFull()
    {
        _basket.SetCapacity(1);
        _basket.AddItem(_bagel);

        Assert.Throws<BasketCapacityReachedException>(() => _basket.AddItem(_coffee));
    }

    [Test]
    public void ContainsTrueWhenProductInBasket()
    {
        _basket.AddItem(_bagel);

        Assert.That(_basket.Contains(_bagel), Is.True);
    }

    [Test]
    public void ContainsFalseWhenProductNotInBasket()
    {
        Assert.That(_basket.Contains(_bagel), Is.False);
    }

    [Test]
    public void GetTotalCost()
    {
        _basket.AddItem(_bagel);
        _basket.AddItem(_coffee);

        Assert.That(_basket.GetTotalCost(), Is.EqualTo(_bagel.Price + _coffee.Price));
    }

    [Test]
    public void IsFullTrueAtCapacity()
    {
        _basket.SetCapacity(1);
        _basket.AddItem(_bagel);

        Assert.That(_basket.IsFull(), Is.True);
    }

    [Test]
    public void IsFullFalseNotAtCapacity()
    {
        _basket.AddItem(_bagel);

        Assert.That(_basket.IsFull(), Is.False);
    }

    [Test]
    public void RemoveItem()
    {
        _basket.AddItem(_bagel);
        _basket.RemoveItem(_bagel);

        Assert.That(_basket.Contains(_bagel), Is.False);
    }

    [Test]
    public void RemoveItemThrowsWhenNotInBasket()
    {
        Assert.Throws<ItemNotInBasketException>(() => _basket.RemoveItem(_bagel));
    }

    [Test]
    public void RemoveItemsCapacityChange()
    {
        _basket.AddItem(_bagel);
        _basket.AddItem(_coffee);
        _basket.SetCapacity(1);

        Assert.That(_basket.BasketItems.Count, Is.EqualTo(1));
    }

    [Test]
    public void ClearItemsCapacityZero()
    {
        _basket.AddItem(_bagel);
        _basket.AddItem(_coffee);
        _basket.SetCapacity(0);

        Assert.That(_basket.BasketItems.Count, Is.EqualTo(0));
    }

    [Test]
    public void AllowMoreItemsCapacityIncreased()
    {
        _basket.SetCapacity(2);
        _basket.AddItem(_bagel);
        _basket.AddItem(_coffee);

        Assert.That(_basket.BasketItems.Count, Is.EqualTo(2));
    }
}

