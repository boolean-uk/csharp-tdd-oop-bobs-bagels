using exercise.main.Products;

namespace exercise.tests;

public class ProductTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test] 
    [TestCase(new string[] { "COFL" }, 1.29f)] // Coffee - Latte
    [TestCase(new string[] { "COFW" }, 1.19f)] // Coffee - Latte
    [TestCase(new string[] { "BGLO", "FILE" }, 0.61f)] // Bagel with onion, egg filling
    [TestCase(new string[] { "BGLO", "FILE", "FILS" }, 0.73f)] // Bagel with onion, egg and salmon filling
    [TestCase(new string[] { "ABCD" }, 0)] // Should be false
    [TestCase(new string[] { "ABCD", "EFGH" }, 0)] // Should be false
    public void ProductFactoryTest(string[] SKU, float expectedPrice)
    {
        // Arrange
        ProductFactory factory = new ProductFactory();

        // Act
        Product res = factory.GenerateProduct(SKU);

        // Assert
        Assert.That(res.GetSKUName(), Is.EqualTo(SKU[0]));
        Assert.That(res.GetPrice(), Is.EqualTo(expectedPrice)); // This also tests Inventory

    }

    [Test]
    [TestCase("FILB", 0.12f, true)]
    [TestCase("FILE", 0.12f, true)]
    [TestCase("FILC", 0.12f, true)]
    [TestCase("FILX", 0.12f, true)]
    [TestCase("FILS", 0.12f, true)]
    [TestCase("FILH", 0.12f, true)]
    [TestCase("FILZ", 0f, false)] // Invalid
    [TestCase("FILO", 0f, false)] // Invalid
    public void FillingValidityTest(string SKU, float expectedPrice, bool expectedValidity) 
    {
        // Arrange
        Filling fill = new Filling(SKU);

        // Act
        bool fillingValid = fill.IsValid(SKU);
        string name = fill.SKUName;

        // Assert 
        Assert.That(fillingValid, Is.EqualTo(expectedValidity));
        Assert.That(name, Is.EqualTo(SKU));
        Assert.That(expectedPrice, Is.EqualTo(fill.GetPrice())); // This also tests Inventory

    }

    [Test]
    [TestCase(new string[] { "BGLP", "FILC" }, 0.51f, true)]
    [TestCase(new string[] { "BGLP", "FILS" }, 0.51f, true)]
    [TestCase(new string[] { "BGLP", "FILH" }, 0.51f, true)]
    [TestCase(new string[] { "BGLP", "FILZ" }, 0.39f, false)]
    public void AddFillingTest(string[] SKU, float expectedPrice, bool expectedResult) 
    {
        // Arrange
        ProductFactory factory = new ProductFactory();
        Bagel bagel1 = (Bagel) factory.GenerateProduct(SKU);
        Bagel bagel2 = (Bagel)factory.GenerateProduct(SKU);

        // Act
        bool res = bagel1.AddFilling(new Filling(SKU[1]));

        // Assert
        Assert.That(bagel2.GetPrice(), Is.EqualTo(expectedPrice));
        Assert.That(res, Is.EqualTo(expectedResult));

    }
}
