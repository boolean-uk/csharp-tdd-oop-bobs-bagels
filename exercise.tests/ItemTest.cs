using exercise.main.Items;

namespace exercise.tests;

public class ItemTest
{

    [TestCase("Black", .99f)]
    public void TestCoffee(string variant, float price)
    {
        Item item = new Coffee(variant, price);
        Assert.That(item.Id, Is.EqualTo("COF" + variant.ToUpper().First()));
        Assert.That(item.Name, Is.EqualTo("Coffee"));
        Assert.That(item.Variant, Is.EqualTo(variant));
        Assert.That(item.Price, Is.EqualTo(price));
    }


    [TestCase("Bacon", .12f)]
    public void TestFilling(string variant, float price)
    {
        Item item = new Filling(variant, price);
        Assert.That(item.Id, Is.EqualTo("FIL" + variant.ToUpper().First()));
        Assert.That(item.Name, Is.EqualTo("Filling"));
        Assert.That(item.Variant, Is.EqualTo(variant));
        Assert.That(item.Price, Is.EqualTo(price));
    }

    [TestCase("Onion", .49f, 3)]
    [TestCase("Everything", .49f, 0)]
    public void TestBagel(string variant, float price, int fillingCount)
    {
        Bagel bagel = new Bagel(variant, price);

        for (int i = 0; i < fillingCount; i++)
        {
            Item filling = new Filling("Cheese", .12f);
            bagel.AddFilling(filling);
            Assert.That(bagel.Fillings, Has.Some.EqualTo(filling));
        }
        Assert.That(bagel.Id, Is.EqualTo($"BGL{variant.ToUpper().First()}" + (bagel.Fillings.Count > 0 ? $", {string.Join(", ", bagel.Fillings.Select(a => a.Id))}" : "")));
        Assert.That(bagel.Name, Is.EqualTo("Bagel"));
        Assert.That(bagel.Variant, Is.EqualTo(variant));
        Assert.That(bagel.Price, Is.EqualTo(price + .12 * fillingCount).Within(0.0001f));
    }
}