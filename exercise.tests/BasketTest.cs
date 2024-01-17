namespace exercise.tests;

using exercise.main;

[TestFixture]
public class BasketTest
{

    [Test]
    public void TestAddBagelToBasket()
    {
        //setup
        Basket basket = new();
        Bagel bagel = new(BagelType.Sesame);

        //execute
        basket.AddItem(bagel);

        //verify
        Assert.That(basket.GetBagels().Count, Is.EqualTo(1));
        Assert.That(basket.GetBagels()[0], Is.EqualTo(bagel));
    }

    [Test]
    public void TestRemoveBagelFromBasket()
    {
        //setup
        Basket basket = new();
        Bagel bagel = new(BagelType.Sesame);
        basket.AddItem(bagel);

        //execute
        bool wasRemoved = basket.RemoveItem(bagel);

        //verify
        Assert.True(wasRemoved);
        Assert.That(basket.GetBagels(), Is.Empty);
    }

    [Test]
    public void TestIsFull()
    {
        //setup
        Basket basket = new(2);
        Bagel bagel = new(BagelType.Sesame);
        basket.AddItem(bagel);

        //execute
        bool shouldNotBeFull = basket.IsFull();
        Bagel bagel2 = new(BagelType.Onion);
        basket.AddItem(bagel2);
        bool shouldBeFull = basket.IsFull();

        //verify
        Assert.Multiple(() =>
        {
            Assert.That(shouldNotBeFull, Is.False);
            Assert.That(shouldBeFull, Is.True);
        });
    }

    [Test]
    public void TestChangeBasketCapacity()
    {
        //setup
        Basket basket = new(1);
        Bagel bagel = new(BagelType.Sesame);
        basket.AddItem(bagel);

        //execute
        bool shouldBeFull = basket.IsFull();
        basket.ChangeBasketCapacity(3);
        bool shouldNotBeFull = basket.IsFull();

        //verify
        Assert.Multiple(() =>
        {
            Assert.That(shouldBeFull, Is.True);
            Assert.That(shouldNotBeFull, Is.False);
        });
    }

    [Test]
    public void TestDoesItemExist()
    {
        //setup
        Basket basket = new(5);
        Bagel bagel = new(BagelType.Sesame);
        basket.AddItem(bagel);

        //execute
        Bagel bagel2 = new(BagelType.Plain);
        bool shouldExist = basket.DoesItemExist(bagel);
        bool shouldNotExist = basket.DoesItemExist(bagel2);

        //verify
        Assert.Multiple(() =>
        {
            Assert.That(shouldExist, Is.True);
            Assert.That(shouldNotExist, Is.False);
        });
    }

    [Test]
    public void TestGetTotalItemCost()
    {
        //setup
        Basket basket = new(5);
        Bagel bagel = new(BagelType.Sesame);
        basket.AddItem(bagel);

        //execute
        double totalPrice = basket.GetBasketCost();

        //verify
        Assert.That(totalPrice, Is.EqualTo(0.49));
    }

    [Test]
    public void TestDiscountApplies()
    {
        //setup
        Basket basket = new(10);
        Bagel bagel = new(BagelType.Sesame);
        Bagel bagel2 = new(BagelType.Plain);
        Bagel bagel3 = new(BagelType.Onion);
        Bagel bagel4 = new(BagelType.Everything);
        Bagel bagel5 = new(BagelType.Sesame);
        Bagel bagel6 = new(BagelType.Plain);
        Bagel bagelWithFilling = new(BagelType.Plain);
        Filling filling = new(FillingType.CreamCheese);
        bagelWithFilling.AddFilling(filling);
        basket.AddItems([bagel, bagel2, bagel3, bagel4, bagel5, bagel6]);

        Basket basket2 = new(5);
        Coffee coffee = new(CoffeeType.Capuccino);
        basket2.AddItems([coffee, bagel]);

        //execute
        double price = basket.GetDiscountBasketCost();
        basket.RemoveItem(bagel);
        basket.AddItem(bagelWithFilling);
        double priceFilling = basket.GetDiscountBasketCost();
        basket.RemoveItem(bagelWithFilling);
        double pricingNoDiscount = basket.GetDiscountBasketCost();
        double coffeeCombo = basket2.GetDiscountBasketCost();

        //verify
        Assert.That(price, Is.EqualTo(2.49));
        Assert.That(priceFilling, Is.EqualTo(2.49 + filling.GetPrice()));
        double sumLast = bagel2.GetPrice() + bagel3.GetPrice() + bagel4.GetPrice() + bagel5.GetPrice() + bagel6.GetPrice();
        Assert.That(pricingNoDiscount, Is.EqualTo(sumLast));

        Assert.That(coffeeCombo, Is.EqualTo(1.25));
    }

    [Test]
    public void TestReceipt()
    {
        //setup
        Basket basket = new(10);
        Bagel bagel = new(BagelType.Sesame);
        Bagel bagel2 = new(BagelType.Plain);
        Bagel bagel3 = new(BagelType.Onion);
        Bagel bagel4 = new(BagelType.Everything);
        Bagel bagel5 = new(BagelType.Sesame);
        Bagel bagel6 = new(BagelType.Plain);
        Bagel bagelWithFilling = new(BagelType.Plain);
        Coffee coffee = new(CoffeeType.Capuccino);
        Filling filling = new(FillingType.CreamCheese);
        bagelWithFilling.AddFilling(filling);
        basket.AddItems([bagel, bagel2, bagel3, bagel4, bagel5, bagel6, bagelWithFilling, coffee]);

        basket.CreateReceipt();

        Assert.True(true);
    }
}