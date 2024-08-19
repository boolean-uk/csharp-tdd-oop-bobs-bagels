using exercise.main;

namespace exercise.tests;

public class Tests
{
    [Test]
    public void Test1AddingBagel()
    {
        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();
        Assert.IsNotNull(basket);

        bool result1 = basket.Add("BGLO");
        Assert.IsTrue(result1);

        Product product = basket.Products[0].Product;
        Assert.That(product.Sku.Equals("BGLO"));
    }

    [Test]
    public void Test2RemovingBagel()
    {
        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();
        basket.Add("BGLO");

        bool result1 = basket.Remove("BGLO");
        Assert.IsTrue(result1);

        Assert.That(basket.Products.Count, Is.EqualTo(0));

        bool result2 = basket.Remove("BGLO");
        Assert.IsFalse(result2);
    }

    [Test]
    public void Test3BasketFull()
    {
        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();
        basket.Add("BGLO");
        basket.Add("BGLP");
        basket.Add("BGLE");

        bool result = basket.IsFull;
        Assert.IsTrue(result);

        bool result2 = basket.Add("BGLS");
        Assert.IsFalse(result2);
    }

    [Test]
    public void Test4ChangeCapacity()
    {
        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();

        bool result1 = basket.ChangeCapacity(4);
        Assert.IsTrue(result1);

        basket.Add("BGLO");
        basket.Add("BGLP");
        basket.Add("BGLE");

        bool result2 = basket.Add("BGLS");
        Assert.IsTrue(result2);
    }

    [Test]
    public void Test5ItemNotInBasket()
    {
        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();

        bool result1 = basket.Remove("BGLO");
        Assert.IsFalse(result1);

        bool result2 = basket.Exists("BGLO");
        Assert.IsFalse(result2);

        basket.Add("BGLO");
        bool result3 = basket.Exists("BGLO");
        Assert.IsTrue(result3);
    }

    [Test]
    public void Test6TotalCostOfItems()
    {
        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();

        double sum = basket.SumOfItems;
        Assert.That(sum.Equals(0));

        basket.Add("BGLO");
        basket.Add("BGLP");
        basket.Add("BGLE");

        double realSum = 0.49 + 0.39 + 0.49;

        double sum2 = basket.SumOfItems;
        Assert.That(sum2.Equals(realSum));
    }

    [Test]
    public void Test7CostOfABagel()
    {
        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();

        double result1 = basket.CostOfProduct("BGLO");
        Assert.That(result1.Equals(0.49));
        Assert.That(!result1.Equals(0.50));
        Assert.That(!result1.Equals(0.491));
    }

    [Test]
    public void Test8ChooseFillingsForBagel()
    {
        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();

        basket.Add("BGLO");
        basket.Add("FILB");
        Assert.That(basket.Products[1].Product.Sku.Equals("FILB"));
    }

    [Test]
    public void Test9CostOfFilling()
    {
        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();

        double result1 = basket.CostOfProduct("FILB");
        Assert.That(result1.Equals(0.12));
        Assert.That(!result1.Equals(0.50));
        Assert.That(!result1.Equals(0.122));
    }

    [Test]
    public void Test10StockOnlyOrdering()
    {
        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();

        bool result1 = basket.Add("BGLO");
        Assert.IsTrue(result1);

        bool result2 = basket.Add("imnotabagel");
        Assert.IsFalse(result2);

        basket.ChangeCapacity(150);
        foreach (var i in Enumerable.Range(0, 99))
        {
            basket.Add("BGLO");
        }
        // basket should not be full, but there should be no more products left, as
        // we only had 100 of each product to begin with
        Assert.IsFalse(basket.IsFull);
        bool result3 = basket.Add("BGLO");
        Assert.IsFalse(result3);
    }

    [Test]
    public void Test11DiscountOrder()
    {
        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();
        basket.ChangeCapacity(100);

        bool result1 = basket.Add("BGLO", 2);
        bool result2 = basket.Add("BGLP", 12);
        bool result3 = basket.Add("BGLE", 6);
        bool result4 = basket.Add("COFB", 3);

        Assert.IsTrue(result1);
        Assert.IsTrue(result2);
        Assert.IsTrue(result3);
        Assert.IsTrue(result4);
    }

    [Test]
    public void InventoryTest()
    {
        List<string> bagels = ["BGLO", "BGLP", "BGLE", "BGLS"];
        List<string> coffee = ["COFB", "COFW", "COFC", "COFL"];
        List<string> fillings = ["FILB", "FILE", "FILC", "FILX", "FILS", "FILH"];

        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();
        basket.ChangeCapacity(20);
        bagels.ForEach(bagel => {basket.Add(bagel);});
        Assert.That(basket.Products.Count(), Is.EqualTo(4));
        coffee.ForEach(coff => { basket.Add(coff); });
        Assert.That(basket.Products.Count(), Is.EqualTo(8));
        fillings.ForEach(filling => { basket.Add(filling); });
        Assert.That(basket.Products.Count(), Is.EqualTo(14));
    }
}