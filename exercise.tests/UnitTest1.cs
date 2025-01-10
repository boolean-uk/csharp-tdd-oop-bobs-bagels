using exercise.main;

namespace exercise.tests;

public class Tests
{
    public Store store;
    [SetUp]
    public void Setup()
    {
        store = new Store(5, new List<Item> {
            new Bagel("BGLE", "Bagel", 0.49, "Everything"),
            new Bagel("BGLS", "Bagel", 0.49, "Sesame"),
            new Coffee("COFB", "Coffee", 0.99, "Black"),
            new Coffee("COFW", "Coffee", 1.19, "White"),
            new Coffee("COFC", "Coffee", 1.29, "Cappuccino"),
            new Coffee("COFL", "Coffee", 1.29, "Latte"),
            new Filling("FILB", "Filling", 0.12, "Bacon"),
            new Filling("FILE", "Filling", 0.12, "Egg"),
            new Filling("FILC", "Filling", 0.12, "Cheese"),
            new Filling("FILX", "Filling", 0.12, "Cream Cheese"),
            new Filling("FILS", "Filling", 0.12, "Smoked Salmon"),
            new Filling("FILH", "Filling", 0.12, "Ham")
        });
        store._customerList.Add(new Customer("Alice", store));
        store._customerList.Add(new Customer("John", store));

    }

    [TestCase("COFB")]
    public void CustomerOrderItemTest(string sku)
    {
        store._customerList[0].order(sku);
        Assert.That(store._customerList[0]._basket._items.Count.Equals(1));
        Assert.That(store._customerList[0]._basket._items[0].name.Equals("Coffee") && store._customerList[0]._basket._items[0].variant.Equals("Black"));
    }

    [TestCase("COFB")]
    public void CustomerDeleteItemTest(string sku)
    {
        store._customerList[0].order(sku);
        Assert.That(store._customerList[0]._basket._items.Count.Equals(1));
        store._customerList[0].DeleteItem(sku);
        Assert.That(store._customerList[0]._basket._items.Count.Equals(0));
    }

    [Test]
    public void CustomerOrderItemWithCapacityReachedTest()
    {
        store._customerList[0]._basket._items = new List<Item>
        {
            new Bagel("BGLO", "Bagel", 0.49, "Onion"),
            new Bagel("BGLE", "Bagel", 0.49, "Everything"),
            new Coffee("COFC", "Coffee", 0.49, "Capuccino"),
            new Filling("FILE", "Filling", 0.12, "Egg"),
            new Filling("FILC", "Filling", 0.12, "Cheese")
        };
        store._customerList[0].order("COFB");
        Assert.True(store._customerList[0]._basket._items.Count == 5);
    }

    [Test]
    public void SetCapacityAndDeleteOverflowingItemsTest()
    {
        store._customerList[0]._basket._items = new List<Item>
        {
            new Bagel("BGLO", "Bagel", 0.49, "Onion"),
            new Bagel("BGLE", "Bagel", 0.49, "Everything"),
            new Coffee("COFC", "Coffee", 0.49, "Capuccino"),
            new Filling("FILE", "Filling", 0.12, "Egg"),
            new Filling("FILC", "Filling", 0.12, "Cheese")
        };
        store.SetCapacity(3);
        Assert.True(store._customerList[0]._basket._items.Count == 3);
        Assert.True(store._customerList[0]._basket._items[2].variant.Equals("Capuccino"));
    }

    [Test]
    public void CalculateCostBeforeOrderTest()
    {
        store._customerList[0]._basket._items = new List<Item>
        {
            new Bagel("BGLO", "Bagel", 0.49, "Onion"),
            new Bagel("BGLE", "Bagel", 0.49, "Everything"),
            new Coffee("COFC", "Coffee", 0.49, "Capuccino"),
            new Filling("FILE", "Filling", 0.12, "Egg"),
            new Filling("FILC", "Filling", 0.12, "Cheese")
        };
        double totalCost = store._customerList[0]._basket.CalculateTotalCost();
        Assert.True(totalCost == 1.71);
    }
}