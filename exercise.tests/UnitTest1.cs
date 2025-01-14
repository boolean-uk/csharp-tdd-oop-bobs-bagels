using exercise.main;
using exercise.main.Products;

namespace exercise.tests;

public class Tests
{
    [Test]
    public void AddItemToBasket()
    {
        Basket basket = new Basket();
        Bagel bagel = new Bagel("BGLO", 0.49, "Bagel", "Onion");

        basket.Add(bagel);
        Assert.That(basket.items[0], Is.EqualTo(bagel));

    }
    [Test]
    public void RemoveItemFromBasket()
    {
        Basket basket = new Basket();
        List<IProduct> items = new List<IProduct>
        {
                new Bagel("BGLS", 0.49, "Bagel", "Sesame"),
                new Coffee("COFB", 0.99, "Coffee", "Black"),
                new Coffee("COFW", 1.19, "Coffee", "White"),
                new Coffee("COFC", 1.29, "Coffee", "Capuccino"),
                new Coffee("COFL", 1.29, "Coffee", "Latte"),
        };

        foreach (IProduct item in items)
        {
            basket.Add(item);
        }

        Assert.That(basket.items.Count, Is.EqualTo(items.Count));
        var result = basket.Remove("BGLS");
        Assert.Multiple(() =>
        {
            Assert.That(basket.items, Has.Count.Not.EqualTo(items.Count));
            Assert.That(result, Is.EqualTo(items[0]));
        });
    }

    [Test]
    public void AddBeyondMaxCap()
    {
        var basket = new Basket();
        List<IProduct> items = new List<IProduct>
        {
                new Bagel("BGLS", 0.49, "Bagel", "Sesame"),
                new Coffee("COFB", 0.99, "Coffee", "Black"),
                new Coffee("COFW", 1.19, "Coffee", "White"),
                new Coffee("COFC", 1.29, "Coffee", "Capuccino"),
                new Coffee("COFL", 1.29, "Coffee", "Latte"),
        };
        foreach (IProduct item in items)
        {
            basket.Add(item);
        }

        Filling testItem = new Filling("FILE", 0.12, "Filling", "Egg");

        Assert.That(basket.Add(testItem), Is.EqualTo("Basket is full, item not added"));
    }


    [Test]
    public void MaxCapacityOfBasket()
    {
        var basket = new Basket();
        List<IProduct> items = new List<IProduct>
        {
                new Bagel("BGLS", 0.49, "Bagel", "Sesame"),
                new Coffee("COFB", 0.99, "Coffee", "Black"),
                new Coffee("COFW", 1.19, "Coffee", "White"),
                new Coffee("COFC", 1.29, "Coffee", "Capuccino"),
                new Coffee("COFL", 1.29, "Coffee", "Latte"),
        };
        foreach (IProduct item in items)
        {
            basket.Add(item);
        }

        var cap = basket.capacity;

        Assert.That(cap, Is.EqualTo(5));

    }

    [Test]
    public void ChangeMaxCapacityOfBasket()
    {
        var basket = new Basket();
        List<IProduct> items = new List<IProduct>
        {
                new Bagel("BGLS", 0.49, "Bagel", "Sesame"),
                new Coffee("COFB", 0.99, "Coffee", "Black"),
                new Coffee("COFW", 1.19, "Coffee", "White"),
                new Coffee("COFC", 1.29, "Coffee", "Capuccino"),
                new Coffee("COFL", 1.29, "Coffee", "Latte"),
        };
        foreach (IProduct item in items)
        {
            basket.Add(item);
        }

        Assert.That(basket.capacity, Is.EqualTo(5));
        basket.ChangeCap(7);
        Assert.That(basket.capacity, Is.EqualTo(7));
    }

    [Test]
    public void CheckTotalOfBasket()
    {
        var basket = new Basket();
        List<IProduct> items = new List<IProduct>
        {
                new Bagel("BGLS", 0.49, "Bagel", "Sesame"),
                new Coffee("COFB", 0.99, "Coffee", "Black"),
                new Coffee("COFW", 1.19, "Coffee", "White"),
                new Coffee("COFC", 1.29, "Coffee", "Capuccino"),
                new Coffee("COFL", 1.29, "Coffee", "Latte"),
        };
        foreach (IProduct item in items)
        {
            basket.Add(item);
        }

        double total = basket.Total();
        Assert.That(total, Is.EqualTo(5.25));
    }
    [Test]
    public void CheckPriceOfItem()
    {
        Inventory inv = new Inventory();
        var basket = new Basket();
        List<IProduct> items = new List<IProduct>
        {
                new Bagel("BGLS", 0.49, "Bagel", "Sesame"),
                new Coffee("COFB", 0.99, "Coffee", "Black"),
                new Coffee("COFW", 1.19, "Coffee", "White"),
                new Coffee("COFC", 1.29, "Coffee", "Capuccino"),
                new Coffee("COFL", 1.29, "Coffee", "Latte"),
        };
        foreach (IProduct item in items)
        {
            basket.Add(item);
        }

        IProduct? BagelSesame = inv.GetItem("BGLS");
        Assert.That(BagelSesame?.Price, Is.EqualTo(0.49));
    }

    [Test]
    public void BagelWithFilling()
    {
        Inventory inv = new Inventory();
        var basket = new Basket();
        List<IProduct> items = new List<IProduct>
        {
                new Bagel("BGLS", 0.49, "Bagel", "Sesame"),
                new Coffee("COFB", 0.99, "Coffee", "Black"),
                new Coffee("COFW", 1.19, "Coffee", "White"),
                new Coffee("COFC", 1.29, "Coffee", "Capuccino"),
                new Coffee("COFL", 1.29, "Coffee", "Latte"),
        };
        foreach (IProduct item in items)
        {
            basket.Add(item);
        }

        Bagel? bagelSesame = (Bagel?)inv.GetItem("BGLS");
        Filling? eggFilling = (Filling?)inv.GetItem("FILE");

        double priceOfBagelWithFilling = (bagelSesame.Price + eggFilling.Price);

        bagelSesame.AddFilling(eggFilling);

        Assert.That(bagelSesame.Filling, Is.EqualTo(eggFilling));
        Assert.That(bagelSesame.Total(), Is.EqualTo(priceOfBagelWithFilling));
    }

    [Test]
    public void CheckFillingPrices()
    {
        Inventory inv = new Inventory();

        List<IProduct> itemFilling = inv.GetFillings();

        foreach (var item in itemFilling)
        {
            Assert.That(item.Type, Is.EqualTo("Filling"));
        }
    }

    [Test]
    public void CheckValidItems()
    {
        Inventory inv = new Inventory();
        var basket = new Basket();
        List<IProduct> items = new List<IProduct>
        {
                new Bagel("BGLS", 0.49, "Bagel", "Sesame"),
                new Coffee("COFB", 0.99, "Coffee", "Black"),
                new Coffee("COFW", 1.19, "Coffee", "White"),
        };
        foreach (IProduct item in items)
        {
            basket.Add(item);
        }

        IProduct invalidItem = new Bagel("KIUH", 0.38, "Fries", "Potato");
        basket.Add(invalidItem);
        Assert.That(basket.items.Count, Is.EqualTo(3));

    }

    [Test]
    public void CheckForAppliedDiscounts()
    {
        Inventory inv = new Inventory();
        var basket = new Basket();
        basket.ChangeCap(50);

        // two bagel onions: 0.98
        basket.Add(new Bagel("BGLO", 0.49, "Bagel", "Onion"));
        basket.Add(new Bagel("BGLO", 0.49, "Bagel", "Onion"));


        // six bagel everything: 2.94 --> 2.49 discounted
        for (int i = 0; i < 6; i++)
        {
            basket.Add(new Bagel("BGLE", 0.49, "Bagel", "Everything"));
        }

        // twelve bagel plain: 5.88 --> 3.99
        for (int i = 0; i < 12; i++)
        {
            basket.Add(new Bagel("BGLS", 0.49, "Bagel", "Sesame"));
        }

        // three coffee black --> 2.97
        basket.Add(new Coffee("COFB", 0.99, "Coffee", "Black"));
        basket.Add(new Coffee("COFB", 0.99, "Coffee", "Black"));
        basket.Add(new Coffee("COFB", 0.99, "Coffee", "Black"));


        basket.ApplyDiscount();
        /*
            2x BGLO  = 0.98
            3x COF   = 2.97
            12x BGLP = 3.99
            6x BGLE  = 2.49
                       ----
                      10.43
            TOTAL BEFORE DISCOUNT: 12.77
         */

        Assert.That((decimal)basket.Total(), Is.EqualTo(10.43));
    }
    [Test]
    public void GetReceiptFromBasket()
    {
        Inventory inv = new Inventory();
        var basket = new Basket();

        List<IProduct> items = new List<IProduct>
    {
        new Bagel("BGLS", 0.49, "Bagel", "Sesame"),
        new Coffee("COFB", 0.99, "Coffee", "Black"),
        new Coffee("COFW", 1.19, "Coffee", "White"),
    };

        // Add initial items to the basket
        foreach (IProduct item in items)
        {
            basket.Add(item);
        }

        // Add 12 additional sesame bagels
        for (int i = 0; i < 12; i++)
        {
            basket.Add(new Bagel("BGLS", 0.49, "Bagel", "Sesame"));
        }

        // Generate and display the receipt
        string receipt = basket.GetReceipt();
        Assert.That(receipt, Is.Not.Empty);

    }



}