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
        Item bagel = inventoryClass.GetItemBySkuID("BGLO");
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
        Item bagel = inventoryClass.GetItemBySkuID("BGLO");
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
        Item bagel = inventoryClass.GetItemBySkuID("BGLO");
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
        Item bagel = inventoryClass.GetItemBySkuID("BGLO");
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
        Item bagel = inventoryClass.GetItemBySkuID("BGLO");
        Item coffee = inventoryClass.GetItemBySkuID("COFB");

        customer.AddItemToBasket(bagel);
        customer.AddItemToBasket(coffee);

        double result = customer.GetTotalSumOfBasket();

        // Verify
        Assert.IsTrue(result == (bagel.Price + coffee.Price));
    }
}