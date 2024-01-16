using exercise.main.Foods;
using exercise.main.Variants;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void GetNameOfFoodItemsTest()
    {
        Bagel bagel = new(BagelVariant.Everything);
        Coffee coffee = new(CoffeeVariant.Black);
        Filling filling = new(FillingVariant.Bacon);

        Assert.That(bagel.Name, Is.EqualTo("Bagel"));
        Assert.That(coffee.Name, Is.EqualTo("Coffee"));
        Assert.That(filling.Name, Is.EqualTo("Filling"));
    }

    [Test]
    public void GetVariantOfFoodItemTest()
    {
        Bagel bagel = new(BagelVariant.Plain);
        Coffee coffee = new(CoffeeVariant.White);
        Filling filling = new(FillingVariant.Egg);

        Assert.That(bagel.Variant, Is.EqualTo(BagelVariant.Plain));
        Assert.That(coffee.Variant, Is.EqualTo(CoffeeVariant.White));
        Assert.That(filling.Variant, Is.EqualTo(FillingVariant.Egg));
    }

    [Test]
    public void SkuForFoodItemIsCorrect()
    {
        Bagel bagel = new(BagelVariant.Onion);
        Coffee coffee = new(CoffeeVariant.Capuccino);
        Filling filling = new(FillingVariant.Cream_Cheese);

        Assert.That(bagel.Sku, Is.EqualTo("BGLO"));
        Assert.That(coffee.Sku, Is.EqualTo("COFC"));
        Assert.That(filling.Sku, Is.EqualTo("FILX"));
    }
}