using exercise.main;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddTest()
    {

        ProductList productList = new ProductList();
        Basket basket = new Basket();
        basket.AddItem("Coffee", "Black");
        basket.AddItem("Bagel", "Onion");


        Assert.That(basket._basket.First().Name.Equals("Coffee"));
        Assert.That(basket._basket.First().Variant.Equals("Black"));
        Assert.That(basket._basket.First().Price.Equals(0.99));
        Assert.That(basket._basket.First().SKU.Equals("COFB"));



    }

    [Test]
    public void RemoveTest()
    {

        ProductList productList = new ProductList();
        Basket basket = new Basket();

        basket.AddItem("Bagel", "Onion");
        basket.AddItem("Coffee", "Black");
        basket.AddItem("Bagel", "Everything");
        basket.RemoveItem("Bagel", "Everything");

        Product x = productList.products.Find(x => x.SKU.Equals("BGLE"));
        Assert.That(!basket._basket.Contains(x));

        Assert.That(basket._basket.First().Name.Equals("Bagel"));
        Assert.That(basket._basket.First().Variant.Equals("Onion"));
        Assert.That(basket._basket.First().Price.Equals(0.49));
        Assert.That(basket._basket.First().SKU.Equals("BGLO"));



    }


    [Test]
    public void CapacityTest()
    {

        ProductList productList = new ProductList();
        Basket basket = new Basket();

        basket.AddItem("Bagel", "Onion");
        basket.AddItem("Coffee", "Black");
        basket.AddItem("Bagel", "Everything");
        basket.RemoveItem("Bagel", "Everything");

        Assert.That(basket.CheckCapacity(1));


    }

    [Test]
    public void ChangeCapacityTest()
    {

        ProductList productList = new ProductList();
        Basket basket = new Basket();

        basket.AddItem("Bagel", "Onion");
        basket.AddItem("Coffee", "Black");
        basket.AddItem("Bagel", "Everything");
        basket.RemoveItem("Bagel", "Everything");
        basket.changeCapacity(15);
        Assert.That(basket.CheckCapacity(10));


    }

    [Test]
    public void CheckForItemTest()
    {

        ProductList productList = new ProductList();
        Basket basket = new Basket();

        basket.AddItem("Bagel", "Onion");
        basket.AddItem("Coffee", "Black");
        basket.AddItem("Bagel", "Everything");
        basket.RemoveItem("Bagel", "Everything");

        Assert.That(basket.checkForItem("Bagel", "Onion") == true);
        Assert.That(basket.checkForItem("Bagel", "Everything") == false);


    }


    [Test]
    public void SumItemTest()
    {

        ProductList productList = new ProductList();
        Basket basket = new Basket();

        basket.AddItem("Bagel", "Onion");
        basket.AddItem("Coffee", "Black");
        basket.AddItem("Bagel", "Everything");

        basket.CalculateSum();

        Assert.That(basket.CalculateSum() == (0.49 + 0.49 + 0.99), Is.True);

    }


    [Test]
    public void priceTest()
    {

        ProductList productList = new ProductList();
        Basket basket = new Basket();

        basket.AddItem("Bagel", "Onion");
        basket.AddItem("Coffee", "Black");
        basket.AddItem("Bagel", "Everything");

        basket.CalculateSum();

        Assert.That(basket.findPrice("Coffee", "Black") == (0.99), Is.True);

    }

    [Test]
    public void AddFillingTest()
    {

        ProductList productList = new ProductList();
        Basket basket = new Basket();

        basket.AddItem("Bagel", "Onion");
        basket.AddItem("Coffee", "Black");
        basket.AddItem("Bagel", "Everything");
        basket.AddFilling("Bacon");
        Assert.That(basket.checkForItem("Filling", "Bacon") == true);

    }



    [Test]
    public void DiscountTest()
    {

        ProductList productList = new ProductList();
        Basket basket = new Basket();
        Discounts discounts = new Discounts(basket._basket);

        for (int i = 0; i < 12; i++)
        {
            basket.AddItem("Bagel", "Onion");
        }

        basket.AddItem("Bagel", "Everything");
        basket.AddItem("Coffee", "White");



        discounts.CalculateDiscount();

        Assert.That(discounts.CalculateDiscount(), Is.EqualTo(3.99 + 1.25));

    }

    [Test]
    public void DiscountTest2()
    {

        ProductList productList = new ProductList();
        Basket basket = new Basket();
        Discounts discounts = new Discounts(basket._basket);

       
        for (int i = 0; i < 18; i++)
        {
            basket.AddItem("Bagel", "Onion");
        }

        basket.AddItem("Bagel", "Everything");
        basket.AddItem("Bagel", "Everything");
        basket.AddItem("Coffee", "Black");

        discounts.CalculateDiscount();
        //3.99 + 1.25
        Assert.That(discounts.CalculateDiscount(), Is.EqualTo(3.99 + 2.49 + 1.25 + 0.49));

    }




}
