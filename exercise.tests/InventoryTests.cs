using exercise.main;

namespace exercise.tests;

[TestFixture]
public class InventoryTests
{
    Inventory inventory;
    [SetUp]
    public void Setup()
    {
        inventory = new Inventory();
    }

    [TestCase("BGLE", true)]
    [TestCase("COFC", true)]
    [TestCase("FILX", true)]
    [TestCase("NOTX", false)]
    public void InventoryItemExists(string sku, bool shoulReturn)
    {
        Assert.That(inventory.ItemExists(sku), Is.EqualTo(shoulReturn));
    }

    [TestCase("test", 0f)]
    [TestCase("BGLP", 0.39f)]
    [TestCase("COFC", 1.29f)]
    [TestCase("FILB", 0.12f)]
    public void InventoryGetPrice(string sku, float shouldReturn)
    {
        Assert.That(inventory.GetPrice(sku), Is.EqualTo(shouldReturn));
    }

    [TestCase("BGLO", "BGLO", 0.49f, "Bagle", "Onion")]
    [TestCase("BGLX", "BGLO", 0.49f, "Bagle", "Onion")]
    public void InventoryGetItem(string sku, string expectedSKU, float expectedPrice, string expectedName, string expectedVariant)
    {
        if (sku == "BGLO")
        {
            Assert.That(inventory.GetItem(sku), Is.Not.Null);
        }
        else
        {
            Assert.That(inventory.GetItem(sku), Is.Null);
        }
    }
}