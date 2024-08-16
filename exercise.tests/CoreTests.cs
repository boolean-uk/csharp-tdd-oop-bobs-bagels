

using BobsBagels.main;

namespace BobsBagels.tests;

public class CoreTests {

    //As a member of the public,
    //So I can order a bagel before work,
    //I'd like to add a specific type of bagel to my basket.
    // And also
    //As the manager,
    //So we don't get any weird requests,
    //I want customers to only be able to order things that we stock in our inventory.
    [Test]
    public void AddSingleBagel()
    {
        var inventory = new Inventory();
        var user = new User("Customer");
        var bagel = inventory.SearchInventory("BGLP");

        var result = user.Basket.Add(bagel);

        Assert.That(result, Is.True);

    }
    [Test]
    public void AddingManyOfItem()
    {
        var inventory = new Inventory();
        var user = new User("Customer");
        var bagel = inventory.SearchInventory("BGLP");

        var result1 = user.Basket.Add(bagel);
        var result2 = user.Basket.Add(bagel);
        var result3 = user.Basket.Add(bagel);
        var result4 = user.Basket.Add(bagel);
        Assert.Multiple(() =>
        {
            Assert.That(result1, Is.True);
            Assert.That(result2, Is.True);
            Assert.That(result3, Is.True);
            Assert.That(result4, Is.True);
            Assert.That(user.Basket.Items[bagel] == 4);
        });
    }

    //As a customer,
    //So I can shake things up a bit,
    //I'd like to be able to choose fillings for my bagel
    [Test]
    public void AddSeveralItems()
    {
        var inventory = new Inventory();
        var user = new User("Customer");
        var bagel = inventory.SearchInventory("BGLP");
        var filling = inventory.SearchInventory("FILX");
        var coffee = inventory.SearchInventory("COFB");

        var bagelResult= user.Basket.Add(bagel);
        var fillingResult = user.Basket.Add(filling);
        var coffeeResult = user.Basket.Add(coffee);
        Assert.Multiple(() =>
        {
            Assert.That(bagelResult, Is.True);
            Assert.That(fillingResult, Is.True);
            Assert.That(coffeeResult, Is.True);
        });
    }

    //As a member of the public,
    //So that I can not overfill my small bagel basket
    //I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
    [Test]
    public void AddingOverCapacity()
    {
        var inventory = new Inventory();
        var user = new User("Customer");
        var bagel = inventory.SearchInventory("BGLP");
        var filling = inventory.SearchInventory("FILX");
        var everythingBagel = inventory.SearchInventory("BGLE");
        var salmonFilling = inventory.SearchInventory("FILS");
        var coffee = inventory.SearchInventory("COFB");

        var bagelResult = user.Basket.Add(bagel);
        var fillingResult = user.Basket.Add(filling);
        var coffeeResult = user.Basket.Add(coffee);
        var everythingBagelResult = user.Basket.Add(everythingBagel);
        var salmonFillingResult = user.Basket.Add(salmonFilling);
        Assert.Multiple(() =>
        {
            Assert.That(bagelResult, Is.True);
            Assert.That(fillingResult, Is.True);
            Assert.That(coffeeResult, Is.True);
            Assert.That(everythingBagelResult, Is.True);
            Assert.That(salmonFillingResult, Is.False);
        });
    }


    //As a member of the public,
    //So I can change my order,
    //I'd like to remove a bagel from my basket.
    [Test]
    public void RemovingSingleItem() 
    {
        var inventory = new Inventory();
        var user = new User("Customer");
        var bagel = inventory.SearchInventory("BGLP");

        user.Basket.Add(bagel);
        var result = user.Basket.Remove(bagel);

        Assert.That(result, Is.True);
    }

    [Test]
    public void RemovingFromEmptyBasket()
    {
        var inventory = new Inventory();
        var user = new User("Customer");
        var bagel = inventory.SearchInventory("BGLP");

        var result = user.Basket.Remove(bagel);

        Assert.That(result, Is.False);
    }

    //As a member of the public
    //So that I can maintain my sanity
    //I'd like to know if I try to remove an item that doesn't exist in my basket.

    [Test]
    public void RemovingWrongItem()
    {
        var inventory = new Inventory();
        var user = new User("Customer");
        var bagel = inventory.SearchInventory("BGLP");
        var filling = inventory.SearchInventory("FILX");

        user.Basket.Add(bagel);
        var result = user.Basket.Remove(filling);

        Assert.That(result, Is.False);
    }

    //As a Bob's Bagels manager,
    //So that I can expand my business,
    //I’d like to change the capacity of baskets.



    //As a customer,
    //So I know how much money I need,
    //I'd like to know the total cost of items in my basket.



    //As a customer,
    //So I know what the damage will be,
    //I'd like to know the cost of a bagel before I add it to my basket.



    //As a customer,
    //So I don't over-spend,
    //I'd like to know the cost of each filling before I add it to my bagel order.
}