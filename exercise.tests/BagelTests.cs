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
}