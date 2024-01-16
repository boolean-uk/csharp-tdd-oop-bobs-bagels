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
        Bagel bagel = new();
        Coffee coffee = new();
        Filling filling = new();

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
}