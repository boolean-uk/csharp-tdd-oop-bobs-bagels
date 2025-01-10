namespace exercise.tests;
using exercise.main;

public class Tests
{


    [Test]
    public void AddToBasket()
    {
        Person person = new Person() { _capacity = 10, role = "customer" };
        Bagel onionbagel = new Bagel("BGLO");
        person.AddItem(onionbagel);

        Assert.That(person.ItemExists(onionbagel), Is.True);
    }

    [Test]
    public void RemoveFromBasket()
    {
        Person person = new Person() { _capacity = 10, role = "Customer" };
        Bagel onionbagel = new Bagel("BGLO");
        person.AddItem(onionbagel);
        Assert.That(person.GetTotalItems(), Is.EqualTo(1));
        person.RemoveItem(onionbagel);
        Assert.That(person.GetTotalItems(), Is.EqualTo(0));
    }

    [Test]
    public void FullBasket()
    {
        Person person = new Person() { _capacity = 3, role = "customer" };
        Bagel onionbagel = new Bagel("BGLO");
        Bagel plainbagel = new Bagel("BGLP");
        Bagel everythingbagel = new Bagel("BGLE");
        person.AddItem(plainbagel);
        person.AddItem(onionbagel);
        person.AddItem(everythingbagel);
        Assert.That(person.IsFull(), Is.True);
    }

    [Test]
    public void ManagerChangeCapacity()
    {
        Person person = new Person() { _capacity = 10, role = "manager" };
        int capacity = person.GetCapacity();
        Assert.That(capacity == 10);
        person.ChangeCapacity(20);
        Assert.That(person.GetCapacity, Is.EqualTo(20));

    }

    [Test]
    public void CustomerChangeCapacity()
    {
        Person person = new Person() { _capacity = 10, role = "customer" };
        var message = Assert.Throws<Exception>(() => person.ChangeCapacity(20));

        Assert.That(message.Message, Is.EqualTo("You are not allowed to change the capacity, you are a customer"));
    }

    [Test]
    public void RemoveNonExistingItem()
    {
        Person person = new Person() { role = "customer" };
        Bagel bagel = new Bagel("BAGL");
        var message = Assert.Throws<Exception>(() => person.RemoveItem(bagel));

        Assert.That(message.Message, Is.EqualTo("Not in basket"));
    }

    [Test]
    public void GetTotalCost()
    {
        Person person = new Person() { role = "customer" };
        Bagel bagel = new Bagel("BGLO");
        Coffee coffee = new Coffee("COFW");
        Filling filling = new Filling("FILB");

        person.AddItem(bagel);
        person.AddItem(coffee);
        bagel.AddFilling(filling);

        Assert.That(person.GetTotalCost() > 0);
        Filling fill = new Filling("FILE");
        bagel.AddFilling(fill);
        double expected = 0.49 + 1.19 + 0.12 + 0.12;
        Assert.That(person.GetTotalCost(), Is.EqualTo(expected));
    }

    [Test]
    public void GetItemCost()
    {
        Person person = new Person() { role = "customer" };
        Bagel bagel = new Bagel("BGLO");
        Filling fill = new Filling("FILB");
        Filling fille = new Filling("FILE");
        bagel.AddFilling(fill);
        Coffee coff = new Coffee("COFB");
        person.AddItem(coff);
        person.AddItem(bagel);
        double cost = person.GetItemCost(bagel);
        Assert.That(cost, Is.EqualTo(0.61));
        double sec = person.GetItemCost(coff);
        Assert.That(sec, Is.EqualTo(0.99));

    }

    [Test]
    public void AddFilling()
    {
        Person person = new Person() { role = "customer" };
        Bagel bagel = new Bagel("BGLO");

        bagel.AddFilling(new Filling("FILB"));
        bagel.AddFilling(new Filling("FILE"));
        Assert.That(bagel.fillings.Count, Is.EqualTo(2));
    }

    [Test]
    public void GetFillingCost()
    {
        Person person = new Person() { role = "customer" };
        Filling fill = new Filling("FILB");
        double cost = person.GetFillingCost(fill);
        Assert.That(cost == 0.12);
    }

    [Test]
    public void NotInInventory()
    {
        Person person = new Person();
        Bagel bagel = new Bagel("KABOOM");
        var message = Assert.Throws<Exception>(() => person.AddItem(bagel));

        Assert.That(message.Message, Is.EqualTo("The item is not in inventory"));
        Coffee coff = new Coffee("COFB");
        person.AddItem(coff);
        Assert.That(person.ItemExists(coff), Is.True);
    }
}
