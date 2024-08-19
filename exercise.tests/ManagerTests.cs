using exercise.main.Persons;

namespace exercise.tests;

public class ManagerTests
{
    [Test]
    public void SetBasketCapacity()
    {   // Setup
        Customer customer = new Customer();
        Manager manager = new Manager();

        // Execute
        manager.ChangeBasketCapacity(2);
        int customerBasketCapacity = customer.Basket.Capacity;

        // Verify
        Assert.IsTrue(manager.Basket.Capacity == customerBasketCapacity);
    }
}