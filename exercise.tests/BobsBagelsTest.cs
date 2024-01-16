using exercise.main;
using System.Reflection;

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

    private List<Item> GetBasketItems()
    {
        // Use reflection to access the private basket list
        var field = typeof(Basket).GetField("basket", BindingFlags.NonPublic | BindingFlags.Instance);
        return (List<Item>)field.GetValue(basket);
    }


    //! Class Basket tests
    [Test]
    public void TestAddToBasket_WhenSpaceExistsAndNoExtraFilling_ShouldReturnTrue()
    {
         // Act
        bool result = basket.AddToBasket("BGLO");

        // Assert
        Assert.IsTrue(result);
       
    }


    [Test]
    public void AddToBasket_WhenNotFullAndValidBagel_ShouldAddBagelToBasket()
    {
        // Arrange
        string bagelSku = "BGLP";

        // Act
        bool result = basket.AddToBasket(bagelSku);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(1, basket.GetListCount());
        Assert.AreEqual(bagelSku, GetBasketItems()[0].Sku);
    }

    [Test]
    public void AddToBasket_WhenNotFullAndValidBagelWithExtraFillings_ShouldAddBagelWithFillingsToBasket()
    {
        // Arrange
        string bagelSku = "BGLP";
        string extraFillings = "FILB FILC";

        // Act
        bool result = basket.AddToBasket(bagelSku, extraFillings);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(1, basket.GetListCount());
        Assert.AreEqual(bagelSku, GetBasketItems()[0].Sku);
        CollectionAssert.AreEqual(new List<Tuple<string, float>> { Tuple.Create("Bacon", 0.12f), Tuple.Create("Cheese", 0.12f) }, GetBasketItems()[0].Fillings);
    }

    [Test]
    public void AddToBasket_WhenBasketIsFull_ShouldThrowException()
    {
        basket.ChangeBasketCapacity(4);
        // Arrange
        string bagelSku = "BGLP";
        
        // Fill the basket to capacity
        for (int i = 0; i < basket.GetCapacity(); i++)
        {
            basket.AddToBasket(bagelSku);
        }

        // Try adding on extra
        basket.AddToBasket(bagelSku);

        // Act & Assert
        Assert.Throws<Exception>(() => basket.AddToBasket(bagelSku));
    }

    [Test]
    public void AddToBasket_WhenInvalidBagelSku_ShouldThrowException()
    {
        // Arrange
        string invalidBagelSku = "INVALID";

        // Act & Assert
        Assert.Throws<Exception>(() => basket.AddToBasket(invalidBagelSku));
    }

    [Test]
    public void AddToBasket_WhenInvalidFillingSku_ShouldThrowException()
    {
        // Arrange
        string bagelSku = "BGLP";
        string invalidFillingSku = "INVALID";

        // Act & Assert
        Assert.Throws<Exception>(() => basket.AddToBasket(bagelSku, invalidFillingSku));
    }


    //! Class Inventory Tests
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
        decimal result = inventory.GetFillingCost(validFillingSku);

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
        List<Tuple<string, decimal>> result = inventory.DisplayAllFillings();

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
        decimal result = inventory.GetBagelCost(validBagelSku);

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