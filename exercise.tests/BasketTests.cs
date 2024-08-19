using exercise.main;


namespace exercise.tests;

public class BasketTests
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void TestAddItem()
    {
        Basket basket = new Basket(5);

        bool addedBagel1 = basket.AddItem("BGLO");
        bool addedBagel2 = basket.AddItem("BINGO");
        Assert.That(addedBagel1, Is.True);
        Assert.That(addedBagel2, Is.False);
        Assert.That(basket.Items.Count(), Is.EqualTo(1));
        Assert.That(basket.Items[0].Sku == "BGLO");
    }

    [Test]
    public void TestRemoveItem()
    {
        
        Basket basket = new Basket(5);

        basket.AddItem("BGLO");
        basket.AddItem("COFB");
        basket.AddItem("FILB");

        bool removedBagel = basket.RemoveItem(basket.Items[0]);

        Assert.That(removedBagel, Is.EqualTo(true));
        Assert.That(basket.Items.Count() == 2);
        
    }

    [Test]
    public void TestFindItem()
    {
        Basket basket = new Basket(5);
        Assert.That(basket.FindItem("blabla").Count(), Is.EqualTo(0));

        basket.AddItem("BGLO");
        basket.AddItem("COFB");
        basket.AddItem("FILB");

        List<Item> foundItems = basket.FindItem("BGLO");

        Assert.That(foundItems[0].Sku == "BGLO", Is.EqualTo(true));
        Assert.That(foundItems.Count(), Is.EqualTo(1));

        basket.AddItem("BGLO");
        List<Item> foundItems2 = basket.FindItem("BGLO");
        Assert.That(foundItems2.Count(), Is.EqualTo(2));


    }

    [Test]
    public void TestExtendBasket()
    {
        
        Basket basket = new Basket(3);

        Assert.That(basket.ExtendBasket(-10) == false);
        Assert.That(basket.ExtendBasket(0) == false);

        Item bagel1 = new Bagel("BGLO", 0.49d, "Bagel", "Onion");
        Item bagel2 = new Bagel("BGLP", 0.39d, "Bagel", "Plain");
        Item coffee1 = new Coffee("COFW", 1.19d, "Coffee", "White");
        Item coffee2 = new Coffee("COFB", 0.99d, "Coffee", "Black");

        Item coffee3 = new Coffee("COFB", 0.99d, "Coffee", "Black");

        basket.AddItem("BGLO");
        basket.AddItem("BGLP");
        basket.AddItem("COFW");
        basket.AddItem("COFB");

        int bagelCount = basket.Items.Count();
        Assert.That(basket.ExtendBasket(bagelCount - 1) == false);

        // Checks that capacity cannot be set to the same as it was
        Assert.That(basket.ExtendBasket(basket.Capacity) == false);

        // Checks that new bagels can be added after extending capacity
        basket.ExtendBasket(6);
        Assert.That(basket.AddItem("BGLO") == true);
        
    }


    [Test]
    public void TestCheckBasketCost()
    {

        
        Basket basket = new Basket(5);

        basket.AddItem("BGLO");

        Bagel b = (Bagel)basket.Items[0];
        b.AddFilling("FILB");

        basket.AddItem("BGLP");
        basket.AddItem("COFW");
        basket.AddItem("COFB");

        double cost = basket.CheckBasketCost();

        Assert.That(Math.Round(cost, 2), Is.EqualTo(3.18d));
        
    }

    [TestCase(4,1, 2, 2.96d)] // 4 Bagels - 1 Coffee - 2 Fillings
    [TestCase(6,1, 2, 3.72d)] // 6 Bagels - 1 Coffee - 2 Fillings
    [TestCase(12,0, 0, 3.99d)] // 12 Bagels - 0 Coffee - 0 Fillings
    [TestCase(18,0, 0, 6.48d)] // 18 Bagels - 0 Coffee - 0 Fillings
    [TestCase(19,0, 0, 6.97d)] // 19 Bagels - 0 Coffee - 0 Fillings
    [TestCase(19,0, 1, 7.73d)] // 19 Bagels - 1 Coffee - 0 Fillings
    public void TestCheckBasketCostDiscounted(int bagelamount, int coffeeamount, int fillingamount, double expected)
    {
        Basket basket = new Basket(10);
        for(int i = 0; i < bagelamount; i++)
        {
            basket.AddItem("BGLO");
        }
        Bagel b = (Bagel)basket.Items[0];

        for (int i = 0; i < fillingamount; i++)
        {
            b.AddFilling("FILB");
        }

        for(int i = 0; i < coffeeamount; i++)
        {
            basket.AddItem("COFB");
        }


        Assert.That(basket.CheckBasketCostDiscounted(), Is.EqualTo(expected));
    }
}