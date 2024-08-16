using exercise.main;

namespace exercise.tests;

public class Tests
{
    [TestCase("Fail", "BGLO")]
    public void AddBagel(string fail, string bagel)
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
}