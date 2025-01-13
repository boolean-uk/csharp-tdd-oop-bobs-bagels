using exercise.main;
using NUnit.Framework;

namespace exercise.tests;

public class ShopTest
{
    [Test]
    public void TestAddItemAddsForAllPersons()
    {
        Shop s = new Shop();
        Person customer = new Person("Customer");
        Person manager = new Person("Manager");

        ActionMessage cAdd = s.AddItem("BGLO", customer);
        ActionMessage mAdd = s.AddItem("BGLO", manager);

        
        Assert.IsTrue(cAdd.Success && mAdd.Success);
        Assert.IsTrue(s.GetCart(customer).Count == 1);
        Assert.IsTrue(s.GetCart(manager).Count == 1);


    }

    [Test]
    public void TestRemoveItemRmovesForAllCustomers()
    {
        Shop s = new Shop();
        Person customer = new Person("Customer");
        Person manager = new Person("Manager");

        ActionMessage cAdd = s.AddItem("BGLO", customer);
        ActionMessage cRemove = s.RemoveItem("BGLO", customer);
        ActionMessage mAdd = s.AddItem("BGLO", manager);
        ActionMessage mRemove = s.RemoveItem("BGLO", manager);

        Assert.IsTrue(cAdd.Success && mAdd.Success);
        Assert.IsTrue(cRemove.Success && mRemove.Success);
        Assert.IsTrue(s.GetCart(customer).Count == 0);
        Assert.IsTrue(s.GetCart(manager).Count == 0);
    }

    [TestCase("Manager", 29, true)]
    [TestCase("Customer", 100, false)]
    public void TestCartCapacityCanOnlyBeChangedByManager(string role, int newCapacity, bool expected)
    {
        Shop s = new Shop();
        Person p = new Person(role);
        s.ChangeCartCapacity(newCapacity, p);
        int currentCartCapacity = s.GetCartCapacity();
        Assert.That(currentCartCapacity == newCapacity, Is.EqualTo(expected));
    }

    [Test]
    public void TestAllRolesCanGetCartCost()
    {
        Shop s = new Shop();
        Person customer = new Person("Customer");
        Person manager = new Person("Manager");

        s.AddItem("BGLO", customer);
        s.AddItem("COFB", customer);

        s.AddItem("BGLO", manager);
        s.AddItem("COFB", manager);

        double customerCost = s.GetCartCost(customer);
        double managerCost = s.GetCartCost(manager);

        Assert.IsTrue(customerCost == 0.49+0.99);
        Assert.IsTrue(managerCost == 0.49+0.99);
    }



}
