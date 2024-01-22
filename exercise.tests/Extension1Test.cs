using NUnit.Framework;
using exercise.main;
using System.Linq;
using static exercise.main.Basket;
using static exercise.main.BasketManager;
using static exercise.main.OrderCostManager;
using static exercise.main.Inventory;

namespace exercise.tests;

[TestFixture]
public class Extension1Tests
{
    private Basket basket;
    private Inventory inventory;
    private Order order;
    private OrderCostManager costManager;

    [SetUp]
    public void Setup()
    {
        basket = new Basket();
        inventory = new Inventory();
        order = new Order();
        costManager = new OrderCostManager();
    }

    [Test]
    public void Add()
    {
        string sku = "BGLO";
        int id = basket.Add(sku);
        Assert.That(id, Is.Not.EqualTo(0));
        Assert.IsTrue(basket.CustomerOrder.Products.Any(b => b.ID == id));
    }

    [Test]
    public void AddMissingSKU()
    {
        string sku = "INVALID_SKU";
        int id = basket.Add(sku);
        Assert.That(id, Is.EqualTo(0));
    }

    [Test]
    public void AddBasketIsFull()
    {
        basket.ChangeCapacity(0);
        string sku = "BGLO";

        var exception = Assert.Throws<Exception>(() => basket.Add(sku));
        Assert.That(exception.Message, Is.EqualTo("Product was not added to basket, because basket is full."));
    }

    [Test]
    public void Remove()
    {
        string sku = "BGLO";
        int id = basket.Add(sku);
        basket.Remove(id);
        Assert.IsFalse(basket.CustomerOrder.Products.Any(b => b.ID == id));
    }

    [Test]
    public void RemoveMissingID()
    {
        var exception = Assert.Throws<Exception>(() => basket.Remove(999));
        Assert.That(exception.Message, Is.EqualTo("No product with specified ID."));
    }

    [Test]
    public void ChangeCapacity()
    {
        int newCapacity = 10;
        basket.ChangeCapacity(newCapacity);
        Assert.That(basket.Capacity, Is.EqualTo(newCapacity));
    }

    [Test]
    public void TotalCost()
    {
        basket.Add("BGLO");
        basket.Add("BGLP");

        double expectedTotalCost = 0.49 + 0.39;

        double totalCost = basket.Cost();
        Assert.That(totalCost, Is.EqualTo(expectedTotalCost));
    }

    [Test]
    public void ProductCost()
    {
        string sku = "BGLO";
        double cost = basket.MenyItemCost(sku);
        Assert.That(cost, Is.EqualTo(inventory.GetItem(sku).Price));
    }

    [Test]
    public void ProductCostMissingSKU()
    {
        string sku = "INVALID_SKU";
        var exception = Assert.Throws<Exception>(() => basket.MenyItemCost(sku));
        Assert.That(exception.Message, Is.EqualTo("No item with the specified SKU."));
    }

    [Test]
    public void AddFillingMissingID()
    {
        var exception = Assert.Throws<Exception>(() => basket.AddFilling(999, "FILH"));
        Assert.That(exception.Message, Is.EqualTo("No bagel with the specified ID."));
    }

    [Test]
    public void AddFillingMissingSKU()
    {
        int id = basket.Add("BGLO");
        var exception = Assert.Throws<Exception>(() => basket.AddFilling(id, "INVALID_SKU"));
        Assert.That(exception.Message, Is.EqualTo("No bagel with the specified SKU."));
    }

    [Test]
    public void GetDiscountsOnionDiscount()
    {
        OrderCostManager costManager = new OrderCostManager();
        var order = new Order();

        InventoryItem onionVariant = inventory.GetItem("BGLO");

        for (int i = 0; i < 6; i++)
        {
            order.Add(new Bagel(onionVariant));
        }

        var discounts = costManager.GetDiscounts(order);

        Assert.That(discounts.Count, Is.EqualTo(1));
        Assert.That(discounts[0].Name, Is.EqualTo("Onion"));
        Assert.That(discounts[0].Price, Is.EqualTo(2.49));
    }

    [Test]
    public void GetDiscountsCoffeeAndBagelDiscount()
    {
        Order order = new Order();

        InventoryItem onionVariant = inventory.GetItem("BGLO");
        InventoryItem coffeeVariant = inventory.GetItem("COFB");

        order.Add(new Bagel(onionVariant));
        order.Add(new Coffee(coffeeVariant));

        List<Discount>? discounts = costManager.GetDiscounts(order);

        Assert.That(discounts.Any(d => d.Name == "Coffee & Bagel" && d.Quantity == 1), Is.True);
    }

    [Test]
    public void GetDiscountsTwoOverlappingDiscounts()
    {
        Order order = new Order();

        InventoryItem onionVariant = inventory.GetItem("BGLO");
        InventoryItem coffeeVariant = inventory.GetItem("COFB");

        for (int i = 0; i < 7; i++)
        {
            order.Add(new Bagel(onionVariant));
        }

        order.Add(new Coffee(coffeeVariant));

        List<Discount>? discounts = costManager.GetDiscounts(order);

        Assert.That(discounts.Count, Is.EqualTo(2));
        // Check for the bulk bagel discount
        Assert.That(discounts.Any(d => d.Name == "Onion" && d.Quantity == 6), Is.True);
        // Check for the Coffee & Bagel discount
        Assert.That(discounts.Any(d => d.Name == "Coffee & Bagel" && d.Quantity == 1), Is.True);
    }

    [Test]
    public void CostNoDiscounts()
    {
        InventoryItem onionVariant = inventory.GetItem("BGLO");

        order.Add(new Bagel(onionVariant)); 

        double expectedCost = 0.49;
        double actualCost = costManager.Cost(order);

        Assert.That(actualCost, Is.EqualTo(expectedCost));
    }

    [Test]
    public void CostOnionDiscount()
    {
        InventoryItem onionVariant = inventory.GetItem("BGLO");

        for (int i = 0; i < 6; i++)
        {
            order.Add(new Bagel(onionVariant));
        }

        double expectedCost = 2.49;
        double actualCost = costManager.Cost(order);

        Assert.That(actualCost, Is.EqualTo(expectedCost));
    }

    [Test]
    public void CostCoffeeAndBagelDiscount()
    {
        InventoryItem onionVariant = inventory.GetItem("BGLO");
        InventoryItem coffeeVariant = inventory.GetItem("COFB");

        order.Add(new Bagel(onionVariant));
        order.Add(new Coffee(coffeeVariant));

        // Diagnostic check for discounts
        var discounts = costManager.GetDiscounts(order);
        Assert.IsTrue(discounts.Any(d => d.Name == "Coffee & Bagel" && d.Quantity == 1), "Coffee & Bagel discount not applied");

        double expectedCost =  1.25;
        double actualCost = costManager.Cost(order);

        Assert.That(actualCost, Is.EqualTo(expectedCost));
    }

    [Test]
    public void CostMultipleDiscounts()
    {
        InventoryItem onionVariant = inventory.GetItem("BGLO");
        InventoryItem plainVariant = inventory.GetItem("BGLP");
        InventoryItem coffeeVariant = inventory.GetItem("COFB");

        for (int i = 0; i < 6; i++)
        {
            order.Add(new Bagel(onionVariant)); // Bulk discount for Onion
        }

        order.Add(new Bagel(plainVariant)); // No discount
        order.Add(new Coffee(coffeeVariant)); // Part of Coffee & Bagel discount

        double expectedCost = Math.Round(2.49 + 0.39 + 1.25, 2); // Round to 2 decimal places
        double actualCost = Math.Round(costManager.Cost(order), 2); // Round to 2 decimal places

        Assert.That(actualCost, Is.EqualTo(expectedCost));
    }
}
