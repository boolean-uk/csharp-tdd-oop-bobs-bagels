using exercise.core;

namespace exercise.tests;

public class DiscountTest
{
    DiscountContainer _discounts = LocalRepository.Default()._discounts;

    [Test]
    public void discounts()
    {
        var items = new List<StoreItem>();
        for (int i = 0; i < 6; i++)
        {
            items.Add(TestUtils.testBagels()[0]);
        }
        var discounted = _discounts.ApplyDiscounts(items);
        Assert.That(discounted.Count(), Is.EqualTo(1));
        Assert.That(discounted[0].GetPrice(), Is.EqualTo(2.49));

        items = new List<StoreItem>();
        for (int i = 0; i < 12; i++)
        {
            items.Add(TestUtils.testBagels()[0]);
        }
        discounted = _discounts.ApplyDiscounts(items);
        Assert.That(discounted.Count(), Is.EqualTo(1));
        Assert.That(discounted[0].GetPrice(), Is.EqualTo(3.99));

        items = new List<StoreItem>();
        items.Add(TestUtils.testBagels()[0]);
        items.Add(TestUtils.testItems()[0]);
        discounted = _discounts.ApplyDiscounts(items);
        Assert.That(discounted.Count(), Is.EqualTo(1));
        Assert.That(discounted[0].GetPrice(), Is.EqualTo(1.25));

        items = new List<StoreItem>();
        for (int i = 0; i < 18; i++)
        {
            items.Add(TestUtils.testBagels()[0]);
        }
        discounted = _discounts.ApplyDiscounts(items);
        Assert.That(discounted.Count(), Is.EqualTo(2));
        Assert.That(discounted.Select(dc => dc.GetPrice()).Sum(), Is.EqualTo(3.99 + 2.49));
    }

    [Test]
    public void GetSavedAmount()
    {
        var items = new List<StoreItem>();
        for (int i = 0; i < 6; i++)
        {
            items.Add(TestUtils.testBagels()[0]);
        }
        var discounted = _discounts.ApplyDiscounts(items)[0];
        if (discounted is DiscountBundle db)
        {
            Assert.That(db.GetSavedAmount(), Is.EqualTo(0.49 * 6 - 2.49).Within(0.0001));
        }

        items = new List<StoreItem>();
        for (int i = 0; i < 12; i++)
        {
            items.Add(TestUtils.testBagels()[0]);
        }
        discounted = _discounts.ApplyDiscounts(items)[0];
        if (discounted is DiscountBundle db2)
        {
            Assert.That(db2.GetSavedAmount(), Is.EqualTo(0.49 * 12 - 3.99).Within(0.0001));
        }
    }

    [Test]
    public void DontDiscountFilling()
    {
        var items = new List<StoreItem>();
        for (int i = 0; i < 6; i++)
        {
            var bagel = TestUtils.testBagels()[0];
            bagel.AddFilling(TestUtils.testFillings()[0]);
            items.Add(bagel);
        }
        var discounted = _discounts.ApplyDiscounts(items);
        Assert.That(discounted.Count(), Is.EqualTo(1));
        Assert.That(discounted[0].GetPrice(), Is.EqualTo(2.49 + 0.12 * 6));
    }
}
