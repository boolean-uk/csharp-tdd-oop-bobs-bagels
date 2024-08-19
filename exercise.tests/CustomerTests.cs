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
        customer.Add(bagel);

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
        bool result = customer.Add(bagel);

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
        customer.Add(bagel);
        customer.Remove(bagel);

        // Verify
        Assert.IsFalse(customer.Basket.ItemsInBasket.Contains(bagel));
    }
}