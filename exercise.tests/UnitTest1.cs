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
    public void InventoryTest()
    {
        List<string> bagels = ["BGLO", "BGLP", "BGLE", "BGLS"];
        List<string> coffee = ["COFB", "COFW", "COFC", "COFL"];
        List<string> fillings = ["FILB", "FILE", "FILC", "FILX", "FILS", "FILH"];

        Basket basket = shop.grabBasket();
        bagels.ForEach(bagel => {basket.add(bagel);});
        Assert.That(basket.Products.Count(), Is.EqualTo(4));
        coffee.ForEach(coff => { basket.add(coff); });
        Assert.That(basket.Products.Count(), Is.EqualTo(8));
        fillings.ForEach(filling => { basket.add(filling); });
        Assert.That(basket.Products.Count(), Is.EqualTo(14));
    }
}