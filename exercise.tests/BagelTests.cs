using exercise.main;

namespace exercise.tests;

public class Tests
{
    [TestCase("Fail", "BGLO")]
    public void AddBagelTest(string fail, string bagel)
    {
        //arrange
        Manager manager = new Manager();
        Customer customer = new Customer(manager, 3.50f);
        bool expectedFailure = false;

        //act
        bool result = customer.Add(manager, fail);

        //assert
        Assert.That(result, Is.EqualTo(expectedFailure));

        //arrange
        bool expectedSuccess = true;

        //act
        result = customer.Add(manager, bagel);

        //assert
        Assert.That(result, Is.EqualTo(expectedSuccess));
    }

    [TestCase("BGLO")]
    public void RemoveBagelTest(string bagel)
    {
        //arrange
        Manager manager = new Manager();
        Customer customer = new Customer(manager, 3.50f);
        bool expectedFailure = false;

        //act
        bool result = customer.Remove(manager, bagel);

        //assert
        Assert.That(result, Is.EqualTo(expectedFailure));

        //arrange
        customer.Add(manager, bagel);
        bool expectedSuccess = true;

        //act
        result = customer.Remove(manager, bagel);

        //assert
        Assert.That(result, Is.EqualTo(expectedSuccess));
    }

    [TestCase("BGLO", "BGLP", "BGLE")]
    public void OverfillTest(string product1, string product2, string product3)
    {
        //arrange
        Manager manager = new Manager();
        Customer customer = new Customer(manager, 3.50f);
        bool expectedSuccess = true;
        customer.Add(manager, product1);
        customer.Add(manager, product2);

        //act
        bool result = customer.Add(manager, product3);

        //assert
        Assert.That(result, Is.EqualTo(expectedSuccess));

        //arrange
        bool expectedFailure = false;

        //act
        result = customer.Add(manager, product3);

        //assert
        Assert.That(result, Is.EqualTo(expectedFailure));
    }

    [TestCase("COFB", "COFW")]
    public void CapacityChangeTest(string product1, string product2)
    {
        //arrange
        Manager manager = new Manager();
        int newSize = 1;
        manager.ChangeBasketSize(newSize);
        Customer customer = new Customer(manager, 3.50f);
        bool expectedFailure = false;
        customer.Add(manager, product1);

        //act
        bool result = customer.Add(manager, product2);

        bool changeToNegative = manager.ChangeBasketSize(-1);

        //assert
        Assert.That(result, Is.EqualTo(expectedFailure));
        Assert.That(changeToNegative, Is.EqualTo(expectedFailure));
    }

    [TestCase("BGLS")]
    public void RemoveNothingTest(string product)
    {
        //arrange
        Manager manager = new Manager();
        Customer customer = new Customer(manager, 3.50f);
        bool expectedFailure = false;

        //act
        bool result = customer.Remove(manager, product);

        //assert
        Assert.That(result, Is.EqualTo(expectedFailure));

        //arrange
        customer.Add(manager, product);
        bool expectedSuccess = true;

        //act
        result = customer.Remove(manager, product);

        //assert
        Assert.That(result, Is.EqualTo(expectedSuccess));
    }

    [TestCase("COFL", "COFW", "BGLE", 2.97f)]
    [TestCase("BGLO", "BGLP", "BGLS", 1.37f)]
    [TestCase("COFB", "COFB", "COFB", 2.97f)]
    public void TotalCostTest(string product1, string product2, string product3, float sum)
    {
        //arrange
        Manager manager = new Manager();
        Customer customer = new Customer(manager, 3.50f);
        customer.Add(manager, product1);
        customer.Add(manager, product2);
        customer.Add(manager, product3);

        //act
        float totalSum = customer.TotalCost();

        //assert
        Assert.That(totalSum, Is.EqualTo(sum));
    }
}