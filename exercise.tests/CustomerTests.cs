using exercise.main.Items;
using exercise.main.Persons;

namespace exercise.tests;

public class CustomerTests
{
    [Test]
    public void AddItemToBasket()
    {
        // Setup
        Customer customer = new Customer();
        InventoryClass inventoryClass = new InventoryClass();

        // Execute
        Bagel bagel = inventoryClass.GetBagelBySkuID("BGLO");
        customer.AddItemToBasket(bagel);

        // Verify
        Assert.IsTrue(customer.Basket.ItemsInBasket.Contains(bagel));
    }

    [Test]
    public void AddItemToBasketWhenFull()
    {
        // Setup
        Customer customer = new Customer();
        InventoryClass inventoryClass = new InventoryClass();

        // Execute
        Bagel bagel = inventoryClass.GetBagelBySkuID("BGLO");
        customer.Basket.Capacity = 0;
        bool result = customer.AddItemToBasket(bagel);

        // Verify
        Assert.IsFalse(customer.Basket.ItemsInBasket.Contains(bagel) & result == false);
    }

    [Test]
    public void RemoveItemFromBasket()
    {
        // Setup
        Customer customer = new Customer();
        InventoryClass inventoryClass = new InventoryClass();

        // Execute
        Bagel bagel = inventoryClass.GetBagelBySkuID("BGLO");
        customer.AddItemToBasket(bagel);
        bool result = customer.RemoveItemFromBasket(bagel);

        // Verify
        Assert.IsTrue(!customer.Basket.ItemsInBasket.Contains(bagel) & result == true);
    }

    [Test]
    public void RemoveItemFromBasketWhenItemDoesNotExist()
    {
        // Setup
        Customer customer = new Customer();
        InventoryClass inventoryClass = new InventoryClass();

        // Execute
        Bagel bagel = inventoryClass.GetBagelBySkuID("BGLO");
        bool result = customer.RemoveItemFromBasket(bagel);

        // Verify
        Assert.IsTrue(!customer.Basket.ItemsInBasket.Contains(bagel) & result == false);
    }

    [Test]
    public void GetTotalSumOfBasket()
    {
        // Setup
        Customer customer = new Customer();
        InventoryClass inventoryClass = new InventoryClass();

        // Execute
        Bagel bagel = inventoryClass.GetBagelBySkuID("BGLO");
        Coffee coffee = inventoryClass.GetCoffeeBySkuID("COFB");

        customer.AddItemToBasket(bagel);
        customer.AddItemToBasket(coffee);

        double result = customer.GetTotalSumOfBasket();

        // Verify
        Assert.IsTrue(result == (bagel.Price + coffee.Price));
    }

    [Test]
    public void GetCostOfItem()
    {
        // Setup
        Customer customer = new Customer();
        InventoryClass inventoryClass = new InventoryClass();

        // Execute
        Bagel bagel = inventoryClass.GetBagelBySkuID("BGLO");

        double result = customer.GetCostOfItem(bagel);

        // Verify
        Assert.IsTrue(result == inventoryClass.GetBagelBySkuID("BGLO").Price);
    }

    [Test]
    public void AddFillingToBagel()
    {
        // Setup
        Customer customer = new Customer();
        InventoryClass inventoryClass = new InventoryClass();

        // Execute
        Bagel bagel = inventoryClass.GetBagelBySkuID("BGLO");
        Filling filling = inventoryClass.GetFillingBySkuID("FILX");

        customer.AddItemToBasket(bagel);

        bool result = customer.AddFillingToBagel(bagel, filling);

        // Verify
        Assert.IsTrue(result & bagel.Fillings.Contains(filling));
    }
}