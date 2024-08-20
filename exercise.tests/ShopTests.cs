using exercise.main;
using exercise.main.Items;
using exercise.main.Persons;

namespace exercise.tests;

public class ShopTests
{
    [Test]
    public void ChangeBasketCapacity()
    {
        // Setup
        ShopInventory shopInventory = new ShopInventory();
        Shop shop = new Shop("Bob's Bagels", shopInventory);

        // Execute
        Manager manager = (Manager)shop.Persons.First(person => person.GetType() == typeof(Manager));
        Customer customer = (Customer)shop.Persons.First(person => person.GetType() == typeof(Customer));

        shop.ChangeBasketCapacity(manager, 2);

        // Verify
        Assert.IsTrue(customer.Basket.Capacity == 2);
    }

    [Test]
    public void GetShopInventory()
    {
        ShopInventory shopInventory = new ShopInventory();
        Shop shop = new Shop("Bob's Bagels", shopInventory);

        Assert.That(shop.ShopInventory.Inventory, Is.EqualTo(shopInventory.Inventory));
    }
}