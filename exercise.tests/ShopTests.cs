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
    public void AddShopManager()
    {
        ShopInventory shopInventory = new ShopInventory();
        Shop shop = new Shop("Bob's Bagels", shopInventory);

        shop.AddShopManager("John the Second Bob's Bagels Manager");

        bool newManagerIsInList = false;

        foreach (var person in shop.GetShopManagers())
        {
            if (person.Name == "John the Second Bob's Bagels Manager")
            {
                newManagerIsInList = true;
            }
        }

        Assert.IsTrue(newManagerIsInList);
    }

    [Test]
    public void AddShopCustomer()
    {
        ShopInventory shopInventory = new ShopInventory();
        Shop shop = new Shop("Bob's Bagels", shopInventory);

        shop.AddShopCustomer("John the Second Bob's Bagels Customer");

        bool newCustomerIsInList = false;

        foreach (var person in shop.GetShopCustomers())
        {
            if (person.Name == "John the Second Bob's Bagels Customer")
            {
                newCustomerIsInList = true;
            }
        }

        Assert.IsTrue(newCustomerIsInList);
    }

    [Test]
    public void GetShopManagers()
    {
        ShopInventory shopInventory = new ShopInventory();
        Shop shop = new Shop("Bob's Bagels", shopInventory);

        bool listOnlyContainsManagers = true;

        foreach (var person in shop.GetShopManagers())
        {
            if (person.GetType() == typeof(Customer))
            {
                listOnlyContainsManagers = false;
                break;
            }
        }

        Assert.IsTrue(listOnlyContainsManagers & shop.GetShopManagers() != null);
    }

    [Test]
    public void GetShopCustomers()
    {
        ShopInventory shopInventory = new ShopInventory();
        Shop shop = new Shop("Bob's Bagels", shopInventory);

        bool listOnlyContainsCustomers = true;

        foreach (var person in shop.GetShopCustomers())
        {
            if (person.GetType() == typeof(Manager))
            {
                listOnlyContainsCustomers = false;
                break;
            }
        }

        Assert.IsTrue(listOnlyContainsCustomers & shop.GetShopCustomers != null);
    }

    [Test]
    public void GetShopInventory()
    {
        ShopInventory shopInventory = new ShopInventory();
        Shop shop = new Shop("Bob's Bagels", shopInventory);

        Assert.That(shop.ShopInventory.Inventory, Is.EqualTo(shopInventory.Inventory));
    }
}