using exercise.main.Classes;

namespace exercise.tests.ClassesTests;

public class PersonTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [Category("Person.cs")]
    public void CreateDefaultPersonTest()
    {
        string name = "Ola";

        Person person = new(name);

        Assert.That(person.GetUUID, Is.Not.Null);
        Assert.That(person.GetUUID, Is.Not.Empty);

        Assert.That(person.GetName, Is.Not.Null);
        Assert.That(person.GetName, Is.Not.Empty);
        Assert.That(person.GetName, Is.EqualTo(name));

        Assert.That(person.GetRole, Is.Not.Null);
        Assert.That(person.GetRole, Is.Not.Empty);
        Assert.That(person.GetRole, Is.EqualTo("mop"));

        Assert.That(person.GetBasket, Is.Not.Null);
    }

    [Test]
    [Category("Person.cs")]
    public void CreatePersonWithRoleTest()
    {
        string name = "Ola";
        string role = "customer";

        Person person = new(name, role);

        Assert.That(person.GetUUID, Is.Not.Null);
        Assert.That(person.GetUUID, Is.Not.Empty);

        Assert.That(person.GetName, Is.Not.Null);
        Assert.That(person.GetName, Is.Not.Empty);
        Assert.That(person.GetName, Is.EqualTo(name));

        Assert.That(person.GetRole, Is.Not.Null);
        Assert.That(person.GetRole, Is.Not.Empty);
        Assert.That(person.GetRole, Is.EqualTo(role));

        Assert.That(person.GetBasket, Is.Not.Null);
    }

    [Test]
    [Category("Person.cs")]
    public void EmployeeAndManagerNoBasketTest()
    {
        string employeeName = "Ola";
        string employeeRole = "employee";

        Person employee = new(employeeName, employeeRole);

        Assert.That(employee.GetBasket, Is.Null);

        string managerName = "Per";
        string managerRole = "manager";

        Person manager = new(managerName, managerRole);

        Assert.That(manager.GetBasket, Is.Null);
    }
}
