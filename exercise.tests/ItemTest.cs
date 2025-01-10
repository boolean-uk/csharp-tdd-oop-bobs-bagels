using exercise.main.Items;

namespace exercise.tests;

public class ItemTest
{

    [TestCase("BGLO", "Bagel", "Onion", .49f)]
    public void TestItem(string id, string name, string variant, float price)
    {
        Item item = new(id, name, variant, price);
        Assert.That(item.Id, Is.EqualTo(id));
        Assert.That(item.Name, Is.EqualTo(name));
        Assert.That(item.Variant, Is.EqualTo(variant));
        Assert.That(item.Price, Is.EqualTo(price));
    }

    [TestCase("BGLO", "Bagel", "Onion", .49f)]
    public void TestBagel(string id, string name, string variant, float price)
    {
        Bagel bagel = new Bagel(id, name, variant, price);
        Item filling = new("FILC", "Filling", "Cheese", .12f);
        bagel.AddFilling(filling);
        Assert.That(bagel.Id, Is.EqualTo(id));
        Assert.That(bagel.Name, Is.EqualTo(name));
        Assert.That(bagel.Variant, Is.EqualTo(variant));
        Assert.That(bagel.Price, Is.EqualTo(price + filling.Price));
    }
}