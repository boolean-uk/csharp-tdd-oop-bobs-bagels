using exercise.main;

namespace exercise.tests;

public class Tests
{
    private Basket _basket;
    private Product _product;
    private string _stringProduct;

    [SetUp]
    public void Setup()
    {
        _basket = new Basket();
        _stringProduct = "Onion";
        _product = new Product("Bagel", 0.39d, "Plain");
    }

    [Test]
    public void AddProductTest()
    {
        _basket.AddProduct(_stringProduct);

        Assert.That(_basket.GetItems().Count, Is.EqualTo(1));
    }
    [Test]
    public void RemoveProductTest()
    {
        string onionBagel = "Onion";
        _basket.AddProduct(onionBagel);
        _basket.RemoveProduct(onionBagel);

        Assert.That(_basket.GetItems().Count, Is.EqualTo(0));
    }

    [Test]
    public void AddProductOverencumberedTest()
    {
        _basket.ChangeCapacity(1);
        string cheeseBagel = "Cheese";
        string everythingBagel = "Everything";
        _basket.AddProduct(cheeseBagel);
        string encumbered = _basket.AddProduct(everythingBagel);

        Assert.That(encumbered, Is.EqualTo("Nope. Overencumbered."));
    }

    [Test]
    public void RemoveNonexistingstringTest()
    {
        string cheeseBagel = "Cheese";
        string eggBagel = "Egg";
        _basket.AddProduct(cheeseBagel);
        string nonexistent = _basket.RemoveProduct(eggBagel);

        Assert.That(nonexistent, Is.EqualTo("No such product to remove."));
    }

    [Test]
    public void AddProductToProductTest()
    {
        string onion = "Onion";
        _product.AddSubProduct(onion);

        List<Product> products = _product.GetSubProducts();

        Assert.That(products.Count, Is.EqualTo(1));
    }

    [Test]
    public void PriceTest()
    {
        double expectedPrice = 0.39d;
        double actualPrice = _product.Price;
        
        Assert.That(actualPrice, Is.EqualTo(expectedPrice));
    }

    [Test]
    public void TotalPriceTest()
    {
        string productString1 = "Plain";
        string productString2 = "Plain";

        _basket.AddProduct(productString1);
        _basket.AddProduct(productString2);

        Product plainBacon = _basket.GetItems().First();
        plainBacon.AddSubProduct("Bacon");

        double expectedPrice = 0.39d + 0.39d + 0.12d;

        double actualPrice = _basket.TotalPrice();

        Assert.That(actualPrice, Is.EqualTo(expectedPrice));

    }

    [Test]
    public void TryToAddNotAvailbaleProduct()
    {
        
        // Arrange
        
        string stringNotAvailable = "Not available"; 

        // Act
        var result = _basket.AddProduct(stringNotAvailable);

        // Assert
        Assert.That(result, Is.EqualTo("Warning: The product is not available."));
    }

    [Test]
    public void CalculateDozenDiscountTest()
    {
        //arrange
        for(int i = 0; i < 12; i++) 
        {
            _basket.AddProduct("Onion");
            Product onionBacon = _basket.GetItems().Last();
            onionBacon.AddSubProduct("Bacon");
        }

        _basket.AddProduct("Plain");
        Product plainSalmon2 = _basket.GetItems().Last();
        plainSalmon2.AddSubProduct("Smoked Salmon");

        //act
        double expectedDiscount = (12 * 0.49d) - 3.99d;
        double actualDicount = _basket.CalculateDiscount();
        double tolerance = 0.01; // This is for two decimal places


        Assert.That(actualDicount, Is.EqualTo(expectedDiscount).Within(tolerance));
    }
    [Test]
    public void CalculateHalfDozenDiscountTest()
    {
        //arrange
        for(int i = 0; i < 12; i++) 
        {
            _basket.AddProduct("Onion");
            Product onionBacon = _basket.GetItems().Last();
            onionBacon.AddSubProduct("Bacon");
        }

        for (int i = 0; i < 6; i++)
        {
            _basket.AddProduct("Plain");
            Product plainSalmon = _basket.GetItems().Last();
            plainSalmon.AddSubProduct("Smoked Salmon");
        }

        _basket.AddProduct("Plain");
        Product plainSalmon2 = _basket.GetItems().Last();
        plainSalmon2.AddSubProduct("Smoked Salmon");

        //act
        double expectedDiscount = ((12 * 0.49d) - 3.99d)+((6*0.39)-2.49);
        double actualDicount = _basket.CalculateDiscount();
        double tolerance = 0.01; // This is for two decimal places


        Assert.That(actualDicount, Is.EqualTo(expectedDiscount).Within(tolerance));
    }

    [Test]
    public void CalculateCoffeeDiscountTest()
    {
        //arrange

        _basket.AddProduct("Plain");
        Product plainSalmon2 = _basket.GetItems().Last();
        plainSalmon2.AddSubProduct("Smoked Salmon");

        _basket.AddProduct("Onion");
        Product onionBacon = _basket.GetItems().Last();
        onionBacon.AddSubProduct("Bacon");

        _basket.AddProduct("Black");
        _basket.AddProduct("White");
        _basket.AddProduct("Cappuccino");

        

        //act
        double expectedDiscount = (1.29 + 1.19d) + (0.49d + 0.39d) - (1.25d*2);
        double actualDicount = _basket.CalculateDiscount();
        double tolerance = 0.01; // This is for two decimal places


        Assert.That(actualDicount, Is.EqualTo(expectedDiscount).Within(tolerance));
    }



}