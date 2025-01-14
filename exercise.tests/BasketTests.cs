using exercise.core;

namespace exercise.tests;

public class BasketTests
{
    private Basket _basket = new Basket { Capacity = 5 };

    [SetUp]
    public void Setup()
    {
        this._basket = new Basket { Capacity = 5 };
    }

    [Test]
    public void AddRemove()
    {
        var item = TestUtils.testBagels()[0];
        Assert.That(this._basket.GetItems().Count, Is.EqualTo(0));
        Assert.True(this._basket.AddItem(item));
        Assert.That(this._basket.GetItems().Count, Is.EqualTo(1));
        Assert.True(this._basket.RemoveItem(item));
        Assert.That(this._basket.GetItems().Count, Is.EqualTo(0));
    }

    [Test]
    public void UpdateCapacity()
    {
        Assert.True(this._basket.UpdateCapacity(1));
        Assert.That(this._basket.Capacity, Is.EqualTo(1));
        Assert.True(this._basket.UpdateCapacity(3));
        Assert.That(this._basket.Capacity, Is.EqualTo(3));
        Assert.True(this._basket.AddItem(TestUtils.testBagels()[0]));
        Assert.True(this._basket.AddItem(TestUtils.testBagels()[1]));
        Assert.False(this._basket.UpdateCapacity(1));
        Assert.That(this._basket.Capacity, Is.EqualTo(3));
    }

    [Test]
    public void TotalPrice()
    {
        // 0.49
        var filledBagel = TestUtils.testBagels()[0];
        // 0.12
        filledBagel.AddFilling(TestUtils.testFillings()[0]);
        // 0.99
        var coffee = TestUtils.testItems()[0];

        this._basket.AddItem(filledBagel);
        this._basket.AddItem((coffee));
        Assert.That(
            this._basket.GetTotalPrice(new DiscountContainer()),
            Is.EqualTo(0.49 + 0.12 + 0.99)
        );
    }

    [Test]
    public void purchase()
    {
        var filledBagel = TestUtils.testBagels()[0];
        filledBagel.AddFilling(TestUtils.testFillings()[0]);
        var coffee = TestUtils.testItems()[0];

        this._basket.AddItem(filledBagel);
        this._basket.AddItem((coffee));

        this._basket.Purchase(new DiscountContainer());
        Assert.That(this._basket.GetItems().Count, Is.EqualTo(0));
    }
}
