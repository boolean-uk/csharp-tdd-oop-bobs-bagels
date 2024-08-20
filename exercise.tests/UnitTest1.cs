using exercise.main;
using System.Text;

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

        Assert.That(basket.SumOfItems == 10.43);
    }

    [Test]
    public void Test12DiscountOrder()
    {
        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();
        basket.ChangeCapacity(100);

        bool result1 = basket.Add("BGLP", 16);
        Assert.That(basket.SumOfItems == 5.55);
    }

    [Test]
    public void Test13CoffeeAndBagelDiscount()
    {
        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();
        basket.ChangeCapacity(2);
        bool result1 = basket.Add("BGLP", "COFB");
        Assert.IsTrue(result1);
        Assert.That(basket.SumOfItems == 1.25);
        Assert.That(basket.IsFull);
    }

    [Test]
    public void Test14AddingFillingToBagel()
    {
        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();
        basket.ChangeCapacity(2);
        bool result1 = basket.Add("BGLP", ["FILB", "FILE", "FILC"]);
        double price = 0.39 + 0.12 * 3;
        Assert.That(basket.SumOfItems == price);
        Assert.IsFalse(basket.IsFull);
    }

    [Test]
    public void Test15AddingCoffeeAndFillingToBagel()
    {
        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();
        basket.ChangeCapacity(2);
        bool result1 = basket.Add("BGLP", ["COFB", "FILB", "FILE", "FILC"]);
        double price = Math.Round(1.25 + 0.12 * 3, 2);
        Assert.That(basket.SumOfItems == price);
        Assert.IsTrue(basket.IsFull);
    }

    [Test]
    public void Test16AddingBagelToBagel()
    {
        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();
        basket.ChangeCapacity(2);
        bool result1 = basket.Add("BGLP", ["BGLO"]);
        Assert.IsFalse(result1);
    }

    [Test]
    public void Test17AddingSeveralCoffeesToBagel()
    {
        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();
        basket.ChangeCapacity(2);
        bool result1 = basket.Add("BGLP", ["COFB", "COFW"]);
        Assert.IsFalse(result1);
    }

    [Test]
    public void Test18UniqueIDForFillingBagel()
    {
        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();
        basket.ChangeCapacity(2);
        bool result1 = basket.Add("BGLP", ["FILE", "FILC"]);
        basket.Exists("BGLPFILEFILC");
        basket.Add("BGLP");
        Assert.IsTrue(basket.IsFull);
    }

    [Test]
    public void Test19AddingAnExtraCoffeeOrder()
    {
        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();
        basket.ChangeCapacity(4);
        bool result1 = basket.Add("BGLP", "COFB");
        bool result2 = basket.Add("BGLP", "COFB");
        Assert.IsTrue(result2);
        Assert.That(basket.SumOfItems == 2.5);

    }

    [Test]
    public void ReceiptPrinterTest()
    {
        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();
        basket.ChangeCapacity(100);

        bool result1 = basket.Add("BGLO", 2);
        bool result2 = basket.Add("BGLP", 12);
        bool result3 = basket.Add("BGLE", 6);
        bool result4 = basket.Add("COFB", 3);

        var sb = shop.ReceiptPrinter(basket);

        Assert.That(sb.ToString().Contains("Bob's Bagels"));
        Assert.That(sb.ToString().Contains("Onion Bagel"));
        Assert.That(sb.ToString().Contains("Plain Bagel"));
        Assert.That(sb.ToString().Contains("Everything Bagel"));
        Assert.That(sb.ToString().Contains("Coffee"));
        Assert.That(sb.ToString().Contains("for your order!"));
    }

    [Test]
    public void ReceiptDiscountTest()
    {
        BagelShop shop = new BagelShop();
        Basket basket = shop.GrabBasket();
        basket.ChangeCapacity(100);

        bool result1 = basket.Add("BGLO", 2);
        bool result2 = basket.Add("BGLP", 12);
        bool result3 = basket.Add("BGLE", 6);
        bool result4 = basket.Add("COFB", 3);

        var sb = shop.ReceiptPrinter(basket);

        Assert.That(sb.ToString().Contains("(-£"));
        Assert.That(sb.ToString().Contains("You saved a total of £"));
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