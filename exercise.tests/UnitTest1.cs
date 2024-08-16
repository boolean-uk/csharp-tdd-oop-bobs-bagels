using exercise.main;

namespace exercise.tests;

public class Tests
{
    BagelShop shop = new BagelShop();

    [Test]
    public void Test1AddingBagel()
    {
        Basket basket = shop.grabBasket();
        Assert.IsNotNull(basket);

        bool result1 = basket.add("BGLO");
        Assert.IsTrue(result1);

        Product product = basket.Products[0];
        Assert.That(product.Sku.Equals("BGLO"));
    }

    [Test]
    public void Test2RemovingBagel()
    {
        Basket basket = shop.grabBasket();
        basket.add("BGLO");

        bool result1 = basket.remove("BGLO");
        Assert.IsTrue(result1);

        Assert.That(basket.Products.Count, Is.EqualTo(0));

        bool result2 = basket.remove("BGLO");
        Assert.IsFalse(result2);
    }

    [Test]
    public void Test3BasketFull()
    {
        Basket basket = shop.grabBasket();
        basket.add("BGLO");
        basket.add("BGLP");
        basket.add("BGLE");

        bool result = basket.IsFull;
        Assert.IsTrue(result);

        bool result2 = basket.add("BGLS");
        Assert.IsFalse(result2);
    }

    [Test]
    public void Test4ChangeCapacity()
    {
        Basket basket = shop.grabBasket();

        bool result1 = basket.changeCapacity(4);
        Assert.IsTrue(result1);

        basket.add("BGLO");
        basket.add("BGLP");
        basket.add("BGLE");

        bool result2 = basket.add("BGLS");
        Assert.IsTrue(result2);
    }

    [Test]
    public void Test5ItemNotInBasket()
    {
        Basket basket = shop.grabBasket();

        bool result1 = basket.remove("BGLO");
        Assert.IsFalse(result1);

        bool result2 = basket.exists("BGLO");
        Assert.IsFalse(result2);

        basket.add("BGLO");
        bool result3 = basket.exists("BGLO");
        Assert.IsTrue(result3);
    }

    [Test]
    public void Test6TotalCostOfItems()
    {
        Basket basket = shop.grabBasket();

        double sum = basket.SumOfItems;
        Assert.That(sum.Equals(0));

        basket.add("BGLO");
        basket.add("BGLP");
        basket.add("BGLE");

        double realSum = 0.49 + 0.39 + 0.49;

        double sum2 = basket.SumOfItems;
        Assert.That(sum2.Equals(realSum));
    }

    [Test]
    public void Test7CostOfABagel()
    {
        Basket basket = shop.grabBasket();

        double result1 = basket.costOfProduct("BGLO");
        Assert.That(result1.Equals(0.49));
        Assert.That(!result1.Equals(0.50));
        Assert.That(!result1.Equals(0.491));
    }

    [Test]
    public void Test8ChooseFillingsForBagel()
    {
        Basket basket = shop.grabBasket();

        basket.add("BGLO");
        basket.add("FILB");
        Assert.That(basket.Products[1].Sku.Equals("FILB"));
    }

    [Test]
    public void Test9CostOfFilling()
    {
        Basket basket = shop.grabBasket();

        double result1 = basket.costOfProduct("FILB");
        Assert.That(result1.Equals(0.12));
        Assert.That(!result1.Equals(0.50));
        Assert.That(!result1.Equals(0.122));
    }

    [Test]
    public void Test10StockOnlyOrdering()
    {
        Basket basket = shop.grabBasket();

        bool result1 = basket.add("BGLO");
        Assert.IsTrue(result1);

        bool result2 = basket.add("imnotabagel");
        Assert.IsFalse(result2);

        basket.changeCapacity(11);
        foreach (var i in Enumerable.Range(0, 9))
        {
            basket.add("BGLO");
        }
        // basket should not be full, but there should be no more products left, as
        // we only had 10 of each product to begin with
        bool result3 = basket.add("BGLO");
        Assert.IsFalse(result3);
    }

    [Test]
    public void InventoryTest()
    {
        List<string> bagels = ["BGLO", "BGLP", "BGLE", "BGLS"];
        List<string> coffee = ["COFB", "COFW", "COFC", "COFL"];
        List<string> fillings = ["FILB", "FILE", "FILC", "FILX", "FILS", "FILH"];

        Basket basket = shop.grabBasket();
        basket.changeCapacity(20);
        bagels.ForEach(bagel => {basket.add(bagel);});
        Assert.That(basket.Products.Count(), Is.EqualTo(4));
        coffee.ForEach(coff => { basket.add(coff); });
        Assert.That(basket.Products.Count(), Is.EqualTo(8));
        fillings.ForEach(filling => { basket.add(filling); });
        Assert.That(basket.Products.Count(), Is.EqualTo(14));
    }
}