using exercise.main;

namespace exercise.tests;

public class Tests
{
    [Test]
    public void AddItemToBasket()
    {
        Basket basket = new Basket();
        Item bagel = new Item("BGLO", 0.49, "Bagel", "Onion");

        basket.Add(bagel);
        Assert.That(basket.items[0], Is.EqualTo(bagel));

    }
    [Test]
    public void RemoveItemFromBasket()
    {
        Basket basket = new Basket();
        List<Item> items = new List<Item>
        {
                new Item("BGLS", 0.49, "Bagel", "Sesame"),
                new Item("COFB", 0.99, "Coffee", "Black"),
                new Item("COFW", 1.19, "Coffee", "White"),
                new Item("COFC", 1.29, "Coffee", "Capuccino"),
                new Item("COFL", 1.29, "Coffee", "Latte"),
        };

        foreach (Item item in items)
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
        List<Item> items = new List<Item>
        {
                new Item("BGLS", 0.49, "Bagel", "Sesame"),
                new Item("COFB", 0.99, "Coffee", "Black"),
                new Item("COFW", 1.19, "Coffee", "White"),
                new Item("COFC", 1.29, "Coffee", "Capuccino"),
                new Item("COFL", 1.29, "Coffee", "Latte"),
        };

        foreach (Item item in items)
        {
            basket.Add(item);
        }

        Item testItem = new Item("FILE", 0.12, "Filling", "Egg");

        Assert.That(basket.Add(testItem), Is.EqualTo("Basket is full, item not added"));
    }


    [Test]
    public void MaxCapacityOfBasket()
    {
        var basket = new Basket();
        List<Item> items = new List<Item>
        {
                new Item("BGLS", 0.49, "Bagel", "Sesame"),
                new Item("COFB", 0.99, "Coffee", "Black"),
                new Item("COFW", 1.19, "Coffee", "White"),
                new Item("COFC", 1.29, "Coffee", "Capuccino"),
                new Item("COFL", 1.29, "Coffee", "Latte"),
        };

        foreach (Item item in items)
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
        List<Item> items = new List<Item>
        {
                new Item("BGLS", 0.49, "Bagel", "Sesame"),
                new Item("COFB", 0.99, "Coffee", "Black"),
                new Item("COFW", 1.19, "Coffee", "White"),
                new Item("COFC", 1.29, "Coffee", "Capuccino"),
                new Item("COFL", 1.29, "Coffee", "Latte"),
        };

        foreach (Item item in items)
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
        List<Item> items = new List<Item>
        {
                new Item("BGLS", 0.49, "Bagel", "Sesame"),
                new Item("COFB", 0.99, "Coffee", "Black"),
                new Item("COFW", 1.19, "Coffee", "White"),
                new Item("COFC", 1.29, "Coffee", "Capuccino"),
                new Item("COFL", 1.29, "Coffee", "Latte"),
        };

        foreach (Item item in items)
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
        List<Item> items = new List<Item>
        {
                new Item("BGLS", 0.49, "Bagel", "Sesame"),
                new Item("COFB", 0.99, "Coffee", "Black"),
                new Item("COFW", 1.19, "Coffee", "White"),
                new Item("COFC", 1.29, "Coffee", "Capuccino"),
                new Item("COFL", 1.29, "Coffee", "Latte"),
        };

        foreach (Item item in items)
        {
            basket.Add(item);
        }

        Item? BagelSesame = inv.GetItem("BGLS");
        Assert.That(BagelSesame?.Price, Is.EqualTo(0.49));
    }

    [Test]
    public void BagelWithFilling()
    {
        Inventory inv = new Inventory();
        var basket = new Basket();
        List<Item> items = new List<Item>
        {
                new Item("BGLS", 0.49, "Bagel", "Sesame"),
                new Item("COFB", 0.99, "Coffee", "Black"),
                new Item("COFW", 1.19, "Coffee", "White"),
                new Item("COFC", 1.29, "Coffee", "Capuccino"),
                new Item("COFL", 1.29, "Coffee", "Latte"),
        };

        foreach (Item item in items)
        {
            basket.Add(item);
        }

        Item? bagelSesame = inv.GetItem("BGLS");
        Item? eggFilling = inv.GetItem("FILE");

        double priceOfBagelWithFilling = (bagelSesame.Price + eggFilling.Price);

        bagelSesame.AddFilling(eggFilling);

        Assert.That(bagelSesame.Filling, Is.EqualTo(eggFilling));
        Assert.That(bagelSesame.Total(), Is.EqualTo(priceOfBagelWithFilling));
    }

    [Test]
    public void CheckFillingPrices()
    {
        Inventory inv = new Inventory();

        List<Item> itemFilling = inv.GetFillings();

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
        List<Item> items = new List<Item>
        {
                new Item("BGLS", 0.49, "Bagel", "Sesame"),
                new Item("COFB", 0.99, "Coffee", "Black"),
                new Item("COFW", 1.19, "Coffee", "White"),
        };

        foreach (Item item in items)
        {
            basket.Add(item);
        }

        Item invalidItem = new Item("KIUH", 0.38, "Fries", "Potato");
        basket.Add(invalidItem);
        Assert.That(basket.items.Count, Is.EqualTo(3));

    }

    [Test]
    public void CheckForAppliedDiscounts()
    {
        Inventory inv = new Inventory();
        var basket = new Basket();

        // two bagel onions
        basket.Add(new Item("BGLO", 0.49, "Bagel", "Onion"));
        basket.Add(new Item("BGLO", 0.49, "Bagel", "Onion"));


        // six bagel everything
        for (int i = 0; i < 5; i++)
        {
            basket.Add(new Item("BGLE", 0.49, "Bagel", "Everything"));
        }

        // twelve bagel plain
        for (int i = 0; i < 11; i++)
        {
            basket.Add(new Item("BGLP", 0.39, "Bagel", "Plain"));
        }

        // three coffee black
        basket.Add(new Item("COFB", 0.99, "Coffee", "Black"));
        basket.Add(new Item("COFB", 0.99, "Coffee", "Black"));
        basket.Add(new Item("COFB", 0.99, "Coffee", "Black"));


        basket.ApplyDiscount();
        /*
            2x BGLO  = 0.98
            12x BGLP = 3.99
            6x BGLE  = 2.49
            3x COF   = 2.97
                       ----
                      10.43
         */
        Assert.That(basket.Total(), Is.EqualTo(10.43));
    }


}