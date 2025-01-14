namespace exercise.tests;

using System.Diagnostics;
using System.Security.Cryptography;
using exercise.main;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework.Interfaces;

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
        Person customer = new Person() { _capacity = 10, role = "customer" };
        int capacity = customer.GetCapacity();
        Assert.That(capacity == 10);
        person.ChangeCapacity(customer, 20);
        Assert.That(customer.GetCapacity, Is.EqualTo(20));

    }

    [Test]
    public void CustomerChangeCapacity()
    {
        Person person = new Person() { _capacity = 10, role = "customer" };
        var message = Assert.Throws<Exception>(() => person.ChangeCapacity(person, 20));

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
        Coffee coffee = new Coffee("COFB");
        Filling filling = new Filling("FILB");
        bagel.AddFilling(filling);
        Filling fill = new Filling("FILE");
        bagel.AddFilling(fill);
        person.AddItem(bagel);
        person.AddItem(coffee);
        
       
        double expected = 1.25 + 0.12 + 0.12;
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


    [Test]
    public void CoffeeBagelDiscount()
    {
        Person person = new Person();
        Bagel bagel = new Bagel("BGLO");
        Filling fill = new Filling("FILB");
        bagel.AddFilling(fill);
        person.AddItem(bagel);
        Coffee c = new Coffee("COFB");
        person.AddItem(c);
        double initcost = 0.49 + 0.12 + 0.99;
        double calc = 0.49 + 0.99 - 1.25;
        double num = initcost - calc;
        double newcost = person.GetTotalCost();
        
        Assert.That(newcost == num);
    }



    [Test]
    public void SixBagelsDiscount()
    {
        Person newPerson = new Person();
        Bagel bg1 = new Bagel("BGLO");
        Bagel bg2 = new Bagel("BGLO");
        
        Bagel bg3 = new Bagel("BGLO");
        Bagel bg4 = new Bagel("BGLO");
        Bagel bg5 = new Bagel("BGLO");
        Bagel bg6 = new Bagel("BGLO");
        newPerson.AddItem(bg1);
        newPerson.AddItem(bg2);
        newPerson.AddItem(bg3);
        newPerson.AddItem(bg4);
        newPerson.AddItem(bg5);
        newPerson.AddItem(bg6);
        double totalCost = newPerson.GetTotalCost();
        
        Assert.That(totalCost > 2.48 && totalCost < 2.5); // annoying wont accept 2.49
        
    }

    [Test]
    public void TwelveBagelsDiscount()
    {
        Person newPerson = new Person() { role = "manager" };
        Person customer = new Person() { role = "customer" };
        newPerson.ChangeCapacity(customer ,15);
        Bagel bg1 = new Bagel("BGLE");
        Bagel bg2 = new Bagel("BGLE");

        Bagel bg3 = new Bagel("BGLE");
        Bagel bg4 = new Bagel("BGLE");
        Bagel bg5 = new Bagel("BGLE");
        Bagel bg6 = new Bagel("BGLE");
        Bagel bg12 = new Bagel("BGLE");
        Bagel bg23= new Bagel("BGLE");

        Bagel bg34 = new Bagel("BGLE");
        Bagel bg45 = new Bagel("BGLE");
        Bagel bg56 = new Bagel("BGLE");
        Bagel bg67 = new Bagel("BGLE");
        Filling fill = new Filling("FILX");
        Filling fill1 = new Filling("FILX");


        bg67.AddFilling(fill);
        bg67.AddFilling(fill1);
        customer.AddItem(bg1);
        customer.AddItem(bg2);
        customer.AddItem(bg3);
        customer.AddItem(bg4);
        customer.AddItem(bg5);
        customer.AddItem(bg6);
        customer.AddItem(bg67);
        customer.AddItem(bg12);
        customer.AddItem(bg23);
        customer.AddItem(bg34);
        customer.AddItem(bg45);
        customer.AddItem(bg56);


        double totalCost = customer.GetTotalCost();
        Assert.That(totalCost > 4.22 && totalCost < 4.24);
    }

    [Test]
    public void BothDiscounts()
    {

        
        Person person = new Person() { role = "customer" };
        Bagel bagel = new Bagel("BGLO");
        Coffee coffee = new Coffee("COFB");

        Bagel bagel1 = new Bagel("BGLP");
        Bagel bagel2 = new Bagel("BGLP");
        Bagel bagel3 = new Bagel("BGLP");
        Bagel bagel4 = new Bagel("BGLP");
        Bagel bagel5 = new Bagel("BGLP");
        Bagel bagel6 = new Bagel("BGLP");

        double expectedCost = (0.39 * 6) + 0.49 + 0.99;
        double diff = 0.49 + 0.99 - 1.25;
        double actual = expectedCost - diff;
        person.AddItem(bagel);
        person.AddItem(bagel1);
        person.AddItem(bagel2);
        person.AddItem(bagel3);
        person.AddItem(bagel4);
        person.AddItem(bagel5);
        person.AddItem(bagel6);
        person.AddItem(coffee);

        //In this store you only receive one discount on purschase - the cheapest discount for the store
        Assert.That(person.GetTotalCost() > 3.58 && person.GetTotalCost() < 3.6);

    }

    [Test]
    public void BothDiscountsPlusFill()
    {
        Person person = new Person() { role = "customer" };
        Bagel bagel = new Bagel("BGLO");
        Coffee coffee = new Coffee("COFB");

        Bagel bagel1 = new Bagel("BGLP");
        Bagel bagel2 = new Bagel("BGLP");
        Bagel bagel3 = new Bagel("BGLP");
        Bagel bagel4 = new Bagel("BGLP");
        Bagel bagel5 = new Bagel("BGLP");
        Bagel bagel6 = new Bagel("BGLP");
        Filling fill = new Filling("FILX");
        bagel.AddFilling(fill); 
        double expectedCost = (0.39 * 6) + 0.49 + 0.99;
        double diff = 0.49 + 0.99 - 1.25;
        double actual = expectedCost - diff;
        person.AddItem(bagel);
        person.AddItem(bagel1);
        person.AddItem(bagel2);
        person.AddItem(bagel3);
        person.AddItem(bagel4);
        person.AddItem(bagel5);
        person.AddItem(bagel6);
        person.AddItem(coffee);
        Assert.That(person.GetTotalCost() > 3.70 && person.GetTotalCost() < 3.72);

    }
}
