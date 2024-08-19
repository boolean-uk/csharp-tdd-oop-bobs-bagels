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

        // Execute
        Bagel bagel = new Bagel { Sku = "BGLO", Price = 0.49d, Variant = "Onion" };
        customer.AddItemToBasket(bagel);

        // Verify
        Assert.IsTrue(customer.Basket.ItemsInBasket.Contains(bagel));
    }

    [Test]
    public void AddItemToBasketWhenFull()
    {
        // Setup
        Customer customer = new Customer();

        // Execute
        Bagel bagel = new Bagel { Sku = "BGLO", Price = 0.49d, Variant = "Onion" };
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

        // Execute
        Bagel bagel = new Bagel { Sku = "BGLO", Price = 0.49d, Variant = "Onion" };
        customer.AddItemToBasket(bagel);
        customer.RemoveItemFromBasket(bagel);

        // Verify
        Assert.IsFalse(customer.Basket.ItemsInBasket.Contains(bagel));
    }
}