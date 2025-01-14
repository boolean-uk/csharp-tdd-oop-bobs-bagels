using exercise.core;

namespace exercise.tests;

public class ReceiptTest
{
    Basket _basket = new Basket { Capacity = 10 };

    [SetUp]
    public void SetUp()
    {
        this._basket = new Basket { Capacity = 10 };
    }

    [Test]
    public void MoreItemsLongerString()
    {
        List<StoreItem> items = new List<StoreItem>();
        for (int i = 0; i < 5; i++)
        {
            items.Add(TestUtils.testItems()[0]);
        }
        var r1 = new Receipt(items);

        items = new List<StoreItem>();
        for (int i = 0; i < 9; i++)
        {
            items.Add(TestUtils.testItems()[0]);
        }
        var r2 = new Receipt(items);
        var r1Length = r1.GetReceiptText().Count(c => c.Equals('\n'));
        var r2Length = r2.GetReceiptText().Count(c => c.Equals('\n'));
        Assert.That(r1Length, Is.LessThan(r2Length));
    }
}
