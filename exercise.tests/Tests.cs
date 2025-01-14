using exercise.main.Classes;
using exercise.main.Enums;
using NUnit.Framework.Interfaces;

namespace exercise.tests;

public class Tests
{
    private Order _order;
    private Inventory _inventory;
    private Basket _basket;

    [SetUp]
    public void Setup()
    {
        _order = new Order();

        Product bagelOnion = new Product("BGLO", 0.49, ProductType.Bagel, "Onion");
        Product bagelPlain = new Product("BGLP", 0.39, ProductType.Bagel, "Plain");
        Product bagelEverything = new Product("BGLE", 0.49, ProductType.Bagel, "Everything");
        Product bagelSesame = new Product("BGLS", 0.49, ProductType.Bagel, "Sesame");

        Product coffeeBlack = new Product("COFB", 0.99, ProductType.Coffee, "Black");
        Product coffeeWhite = new Product("COFW", 1.19, ProductType.Coffee, "White");
        Product coffeeCapuccino = new Product("COFC", 1.29, ProductType.Coffee, "Capuccino");
        Product coffeeLatte = new Product("COFL", 1.29, ProductType.Coffee, "Latte");

        Product fillingBacon = new Product("FILB", 0.12, ProductType.Filling, "Bacon");
        Product fillingCheese = new Product("FILC", 0.12, ProductType.Filling, "Cheese");
        Product fillingCreamCheese = new Product("FILX", 0.12, ProductType.Filling, "Cream Cheese");
        Product fillingSalmon = new Product("FILS", 0.12, ProductType.Filling, "Smoked Salmon");
        Product fillingHam = new Product("FILH", 0.12, ProductType.Filling, "Ham");
        Product fillingEgg = new Product("FILE", 0.12, ProductType.Filling, "Egg");


        _inventory = new Inventory();
        _inventory.Add(bagelOnion, 100);
        _inventory.Add(bagelPlain, 100);
        _inventory.Add(bagelEverything, 100);
        _inventory.Add(fillingBacon, 50);
        _inventory.Add(fillingCheese, 50);
        _inventory.Add(coffeeBlack, 10);
        _inventory.Add(fillingEgg, 10);
        _inventory.Add(bagelSesame, 10);
        _inventory.Add(coffeeCapuccino, 10);
        _inventory.Add(coffeeLatte, 10);
        _inventory.Add(coffeeWhite, 10);
        _inventory.Add(fillingCreamCheese, 10);
        _inventory.Add(fillingHam, 10);
        _inventory.Add(fillingSalmon, 10);
        _inventory.Add(coffeeWhite, 10);

        Discount discount = new Discount();
        discount.AddQuantityDiscount("BGLO", 6, 0.45);
        discount.AddQuantityDiscount("BGLP", 6, 0.45);
        discount.AddQuantityDiscount("BGLE", 6, 0.45);
        discount.AddQuantityDiscount("BGLS", 6, 0.45);

        discount.AddQuantityDiscount("BGLO", 12, 1.89);
        discount.AddQuantityDiscount("BGLP", 12, 1.89);
        discount.AddQuantityDiscount("BGLE", 12, 1.89);
        discount.AddQuantityDiscount("BGLS", 12, 1.89);

        List<string> comboDiscount = new List<string>();
        comboDiscount.Add("BGLP");
        comboDiscount.Add("COFB");

        discount.AddComboDiscount(comboDiscount, 1.25);
        _basket = new Basket(discount);

        _basket.Add(bagelOnion, 13);
        _basket.Add(bagelPlain, 5);
        _basket.Add(bagelEverything, 6);
        _basket.Add(fillingEgg, 6);
        _basket.Add(fillingCheese, 5);
        _basket.Add(coffeeBlack, 5);

        List<BasketItem> items = _basket.GetItems();

        foreach (BasketItem item in items) 
        {
            OrderLine orderline = new OrderLine(item);
            _order.AddLine(orderline);
        }

    }

    [Test]
    public void TestAddBagel()
    {
        // arrange
        Product bagelGarlic = new Product("BGLG", 10, ProductType.Bagel, "Garlic");
        

        // act
        _basket.Add(bagelGarlic, 2);

        // assert
        Assert.That(_basket.GetItems().Count, Is.EqualTo(4));
    }

    [Test]
    public void TestAddDuplicateBagels()
    {
        // arrange
        Product bagelGarlic = new Product("BGLG", 10, ProductType.Bagel, "Garlic");


        // act
        _basket.Add(bagelGarlic, 2);
        _basket.Add(bagelGarlic, 3);

        // assert
        Assert.That(_basket.GetItems().Count, Is.EqualTo(4));
        Assert.That(_basket.GetItemBySKU("BGLG").Amount, Is.EqualTo(5));
    }

    [Test]
    public void TestRemoveBagel()
    {
        // arrange


        // act
        _basket.Remove("BGLO");

        // assert
        Assert.That(_basket.GetItems().Count, Is.EqualTo(2));
    }

    [Test]
    public void TestChangeCapacity()
    {
        // arrange


        // act
        _basket.Capacity = 20;

        // assert
        Assert.That(_basket.Capacity, Is.EqualTo(20));
    }

    [Test]
    public void TestBasketFull()
    {
        // arrange
        Product bagelGarlic = new Product("BGLG", 10, ProductType.Bagel, "Garlic");


        // act
        _basket.Capacity = 3;
        bool added = _basket.Add(bagelGarlic, 2);

        // assert
        Assert.That(added, Is.False);
    }

    [Test]
    public void TestCheckIfProductExistsInBasket()
    {
        // arrange
        Product bagelGarlic = new Product("BGLG", 10, ProductType.Bagel, "Garlic");

        // act
        bool exists = _basket.CheckIfProductExistsInBasket(bagelGarlic);

        // assert
        Assert.That(exists, Is.False);
    }

    [Test]
    public void TestCheckTotalCostOfItemsInBasket()
    {
        // arrange


        // act
        double totalCost = _basket.GetTotal();

        // assert
        Assert.That(totalCost, Is.EqualTo(30));
    }
    [Test]
    public void TestCheckCostOfBagel()
    {
        // arrange
        Product bagelGarlic = new Product("BGLG", 10, ProductType.Bagel, "Garlic");

        // act
        double cost = bagelGarlic.Price;

        // assert
        Assert.That(cost, Is.EqualTo(10));
    }

    [Test]
    public void TestCheckStockOfProduct()
    {
        // arrange
        int amount = _inventory.GetStock("BGLO");

        // act


        // assert
        Assert.That(amount, Is.EqualTo(100));
    }

    [Test]
    public void TestAddAndRemoveStock()
    {
        // arrange
        Product bagelGarlic = new Product("BGLG", 10, ProductType.Bagel, "Garlic");
        Product bagelPlain = new Product("BGLP", 10, ProductType.Bagel, "Plain");

        // act
        _inventory.Remove("BGLO", 10);
        _inventory.Add(bagelGarlic, 10);
        _inventory.Add(bagelPlain, 10);

        int bgloAmount = _inventory.GetStock("BGLO");
        int bglgAmount = _inventory.GetStock("BGLG");
        int bglpAmount = _inventory.GetStock("BGLP");

        // assert
        Assert.That(bgloAmount, Is.EqualTo(90));
        Assert.That(bglgAmount, Is.EqualTo(10));
        Assert.That(bglpAmount, Is.EqualTo(110));
    }

    [Test]
    public void TestReceipt()
    {
        // arrange


        // act
        _basket.ApplyDiscounts();
        Console.WriteLine(_basket.ToString());

        // assert
        Console.WriteLine(_basket.Receipt());
    }

    [Test]
    public void TestDiscount()
    {
        // arrange


        // act
        double discounts = _basket.ApplyDiscounts();


        // assert
        Assert.That(discounts, Is.EqualTo(2.34));
    }

    [Test]
    public void TestCheckCostOfEachFilling()
    {
        // arrange

        // act
        Dictionary<string, double> fillings = _inventory.Products
    .Where(x => x.Value.Type.Equals(ProductType.Filling))
    .ToDictionary(x => x.Key, x => x.Value.Price);


        // assert
        Assert.That(fillings["FILB"], Is.EqualTo(5));
        Assert.That(fillings["FILC"], Is.EqualTo(6));
    }
}