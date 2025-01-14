using exercise.main;
using NUnit.Framework;

namespace exercise.tests;

public class DiscountTest
{
    [Test]
    public void TestSkuToList()
    {
        Dictionary<string, int> skuCount = new Dictionary<string, int>
        {
            {"BGLO", 3}, {"COFB", 2}
        };

        Discount d = new Discount(skuCount, 5, 5);

        List<string> SKUList = d.ToList();

        List<string> expected = new List<string>
        {
            "BGLO", "BGLO", "BGLO", "COFB", "COFB"
        };

        Assert.That(SKUList, Is.EquivalentTo(expected));

    }
}
