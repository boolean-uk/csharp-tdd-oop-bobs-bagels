using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Sources;
using System.Xml.Linq;
using exercise.main;
using exercise.main.Products;
using NUnit.Framework;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }
    [Test]
    public void addProductToBasket()
    {
        Basket basket = new Basket();
        Inventory inventory = new Inventory();
        InventoryProduct bagel = basket.Inventory.OnionBagel;

        basket.AddProduct(bagel);
        List<InventoryProduct> Result = basket.ListOfProducts;

        Assert.That(Result.Count >= 1);
    }
    [Test]
    public void removeProductFromBasket()
    {

        Basket basket = new Basket();
        Bagel bagel = (Bagel)basket.Inventory.PlainBagel;

        basket.AddProduct(bagel);
        basket.AddProduct(bagel);
        basket.AddProduct(bagel);
        Assert.That(basket.ListOfProducts.Count == 3);

        basket.RemoveProduct(bagel);

        Assert.That(basket.ListOfProducts.Count < 3);

    }

    [Test]
    public void addingProductBeyondCapacity()
    {
        Coffee coffee = new Coffee("COFL");
        Coffee BlackCoffee = new Coffee("COFB");
        Basket basket = new Basket();
        for (int i = 0; i <= basket.Capacity; i++)
        {
            basket.AddProduct(coffee);
        }

        Assert.That(basket.ListOfProducts.Count == basket.Capacity);

        bool Result = basket.AddProduct(BlackCoffee);

        Assert.That(basket.ListOfProducts.Count == basket.Capacity && Result == false);
        Assert.That(basket.ListOfProducts.Contains(BlackCoffee) == false, Is.EqualTo(basket.ListOfProducts.Count <= basket.Capacity));

    }

    [TestCase("admin", 32)]
    [TestCase("customer", 12)]
    [TestCase("", 2)]
    [TestCase("admin", 5)]
    [TestCase("customer", 5)]

    public void changeCapacity(string adminLevel, int newCapacity)
    {
        Basket basket = new Basket();
        Person person = new Person(adminLevel);

        int oldCapacity = basket.Capacity;
        if (newCapacity != oldCapacity)
        {
            int Result = basket.changeCapacity(person, newCapacity);

            Assert.That(oldCapacity != Result, Is.EqualTo(person.AdminLevel == "admin"));
            Assert.That(oldCapacity != Result, Is.EqualTo(basket.Capacity == newCapacity));
        }
    }

    [Test]
    public void removeNotExistingProduct()
    {
        Basket basket = new Basket();
        Bagel bagel = new Bagel("BGLP");
        Coffee coffee = new Coffee("COFB");


        basket.AddProduct(bagel);
        Assert.That(basket.ListOfProducts, Is.Not.Empty);

        bool Result = basket.RemoveProduct(bagel);
        bool Result2 = basket.RemoveProduct(coffee);

        Assert.That(Result == true && Result2 == false);

    }

    [Test]

    [TestCase("BGLO", "COFW", "COFC")]
    [TestCase("BGLS", "COFW", "COFC")]
    [TestCase("BGLS", "COFL", "COFW")]

    public void getTotalCost(string A, string B, string C)
    {
        Basket basket = new Basket();

        //SKU = { "BGLO", "BGLP", "BGLE", "BGLS", "COFB", "COFW", "COFC", "COFL", "FILB", "FILE", "FILC", "FILX", "FILS", "FILH" };
        InventoryProduct product1 = new Bagel(A);
        InventoryProduct product2 = new Coffee(B);
        InventoryProduct product3 = new Coffee(C);

        basket.AddProduct(product3); basket.AddProduct(product1); basket.AddProduct(product2);

        double Result = basket.GetTotal();
        double sum = Math.Round(product1.Price + product2.Price + product3.Price, 2);

        Assert.That(Result, Is.EqualTo(sum));

    }

    [TestCase("BGLO")]
    [TestCase("BGLP")]
    [TestCase("BGLE")]
    [TestCase("BGLS")]

    public void getPriceOfSingleItem(string A)
    {
        //SKU Bagels= { "BGLO", "BGLP", "BGLE", "BGLS"}
        InventoryProduct product = new Bagel(A);

        double Result = product.Price;
        Basket basket = new Basket();
        basket.AddProduct(product);
        double fromBasket = basket.ListOfProducts[0].Price;
        Assert.That(Result > 0);
        Assert.That(fromBasket > 0);
    }

    [Test]

    public void addFillingForBagel()
    {
        //SKU Bagels= { "BGLO", "BGLP", "BGLE", "BGLS"}
        //SKU Fillings = { "FILB", "FILE", "FILC", "FILX", "FILS", "FILH" };
        Bagel product = new Bagel("BGLO");
        Basket basket = new Basket();
        Inventory inventory = new Inventory();
        Filling Bacon = (Filling)inventory.Bacon;
        basket.AddProduct(product);
        bool Result = product.AddFilling(Bacon);

        Assert.That(product.Fillings.Count > 0, Is.EqualTo(Result));
        Assert.IsTrue(product.Fillings.Count > 0);

    }
    [Test]
    public void getCostOfFilling()
    {

        //SKU Fillings = { "FILB", "FILE", "FILC", "FILX", "FILS", "FILH" };
        Filling filling = new Filling("FILB");
        double Result = filling.Price;

        Assert.That(Result > 0, Is.EqualTo(filling.Price == 0.12));
    }

    [TestCase("AAAA")]
    [TestCase("FILE")]
    [TestCase("BGLO")]
    public void checkInventory(string A)
    {
        Inventory inventory = new Inventory();
        InventoryProduct Bagel = new Bagel(A);
        Basket Basket = new Basket();

        bool Result = inventory.checkInventory(Bagel);


        Assert.That(Result == true, Is.EqualTo(Basket.AddProduct(Bagel) == true));

    }



}