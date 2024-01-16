using exercise.main;

namespace exercise.tests;

public class BobsBagelsTest
{

    private Basket basket;
    private Inventory inventory;

    [SetUp]
    public void Setup() {
        inventory = new Inventory();
        basket = new Basket(inventory);
    }

    [Test]
    public void TestAddToBasket_WhenSpaceExists_ShouldReturnTrue()
    {
        // Arrange
        Inventory inventory = new Inventory();
        basket = new Basket(inventory);

        // Act
        bool result = basket.AddToBasket("BGLO");

        // Assert
        Assert.IsTrue(result);
       
    }

    [Test]
    public void IsItemInStock_WhenItemExists_ShouldReturnTrue()
    {
        // Arrange
        string existingSku = "FILB";

        // Act
        bool result = inventory.IsItemInStock(existingSku);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsItemInStock_WhenItemDoesNotExist_ShouldReturnFalse()
    {
        // Arrange
        string nonExistingSku = "INVALIDSKU";

        // Act
        bool result = inventory.IsItemInStock(nonExistingSku);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void GetFillingCost_WhenValidFillingSku_ShouldReturnPrice()
    {
        // Arrange
        string validFillingSku = "FILB";

        // Act
        float result = inventory.GetFillingCost(validFillingSku);

        // Assert
        Assert.AreEqual(0.12f, result);
    }

    [Test]
    public void GetFillingCost_WhenInvalidFillingSku_ShouldThrowException()
    {
        // Arrange
        string invalidFillingSku = "INVALIDSKU";

        // Act & Assert
        Assert.Throws<Exception>(() => inventory.GetFillingCost(invalidFillingSku));
    }

    [Test]
    public void DisplayAllFillings_ShouldReturnListOfFillings()
    {
        // Act
        List<Tuple<string, float>> result = inventory.DisplayAllFillings();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsNotEmpty(result);
    }

    [Test]
    public void GetBagelCost_WhenValidBagelSku_ShouldReturnPrice()
    {
        // Arrange
        string validBagelSku = "BGLP";

        // Act
        float result = inventory.GetBagelCost(validBagelSku);

        // Assert
        Assert.AreEqual(0.39f, result);
    }

    [Test]
    public void GetBagelCost_WhenInvalidBagelSku_ShouldThrowException()
    {
        // Arrange
        string invalidBagelSku = "INVALIDSKU";

        // Act & Assert
        Assert.Throws<Exception>(() => inventory.GetBagelCost(invalidBagelSku));
    }
}