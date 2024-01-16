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

    //! from google
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
        bool result = basket.AddToBasket("BGLO");
        Assert.IsTrue(result);
       
    }


    [Test]
    public void AddToBasket_WhenNotFullAndValidBagel_ShouldAddBagelToBasket()
    {
        bool result = basket.AddToBasket("BGLP");
        Assert.IsTrue(result);
        Assert.AreEqual(1, basket.GetListCount());
        Assert.AreEqual("BGLP", GetBasketItems()[0].Sku);
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
        CollectionAssert.AreEqual(new List<Tuple<string, decimal>> { Tuple.Create("Bacon", 0.12m), Tuple.Create("Cheese", 0.12m) }, GetBasketItems()[0].Fillings);
    }

    [Test]
    public void AddToBasket_WhenBasketIsFull_ShouldThrowException()
    {
        basket.ChangeBasketCapacity(4);

        string bagelSku = "BGLP";

        // Fill the basket to capacity
        for (int i = 0; i < basket.GetCapacity(); i++)
        {
            basket.AddToBasket(bagelSku);
        }
        basket.AddToBasket(bagelSku);
        // Act & Assert
        Assert.Throws<Exception>(() => basket.AddToBasket(bagelSku));
    }

    [Test]
    public void AddToBasket_WhenInvalidBagelSku_ShouldThrowException()
    {
        Assert.Throws<Exception>(() => basket.AddToBasket("INVALID"));
    }

    [Test]
    public void AddToBasket_WhenInvalidFillingSku_ShouldThrowException()
    {
        string bagelSku = "BGLP";
        string invalidFillingSku = "INVALID";


        Assert.Throws<Exception>(() => basket.AddToBasket(bagelSku, invalidFillingSku));
    }

    [Test]
    public void RemoveFromBasket_WhenItemExists_ShouldReturnTrue()
    {
        Assert.Pass();
    }

    [Test]
    public void RemoveFromBasket_WhenItemDoesNotExsists_ShouldReturnFalse()
    {
        Assert.Pass();
    }

    [Test]
    public void ChangeBasketCapacity_ValidCapacity()
    {
        basket.ChangeBasketCapacity(4);

        Assert.AreEqual(4, basket.GetCapacity());
    }

    [Test]
    public void ChangeBasketCapacity_InValidCapacity_ShouldReturnException()
    {
        Assert.Throws<Exception>(() => basket.ChangeBasketCapacity(-1));
    }


    //! Class Inventory Tests
    [Test]
    public void IsItemInStock_WhenItemExists_ShouldReturnTrue()
    {
        bool result = inventory.IsItemInStock("FILB");
        Assert.IsTrue(result);
    }

    [Test]
    public void IsItemInStock_WhenItemDoesNotExist_ShouldReturnFalse()
    {
        bool result = inventory.IsItemInStock("INVALIDSKU");
        Assert.IsFalse(result);
    }

    [Test]
    public void GetFillingCost_WhenValidFillingSku_ShouldReturnPrice()
    {
        decimal result = inventory.GetFillingCost("FILB");

        // Assert
        Assert.AreEqual(0.12f, result);
    }

    [Test]
    public void GetFillingCost_WhenInvalidFillingSku_ShouldThrowException()
    {
        Assert.Throws<Exception>(() => inventory.GetFillingCost("INVALIDSKU"));
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
        decimal result = inventory.GetBagelCost("BGLP");
        Assert.AreEqual(0.39f, result);
    }

    [Test]
    public void GetBagelCost_WhenInvalidBagelSku_ShouldThrowException()
    {
        Assert.Throws<Exception>(() => inventory.GetBagelCost("INVALIDSKU"));
    }

    
}