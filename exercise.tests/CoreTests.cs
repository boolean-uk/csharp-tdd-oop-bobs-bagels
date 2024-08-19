

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
        var user = new Shopper();
        var bagel = inventory.SearchInventory("BGLP");

        var result = user.Basket.Add(bagel);

        Assert.That(result, Is.True);

    }
    [Test]
    public void AddingManyOfItem()
    {
        var inventory = new Inventory();
        var user = new Shopper();
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
            Assert.That(user.Basket.Items[bagel], Is.EqualTo(4));
            Assert.That(user.Basket.Count, Is.EqualTo(4));
        });
    }

    //As a customer,
    //So I can shake things up a bit,
    //I'd like to be able to choose fillings for my bagel
    [Test]
    public void AddFilledBagelWithCoffee()
    {
        var inventory = new Inventory();
        var user = new Shopper();
        var bagel = (Bagel)inventory.SearchInventory("BGLP");
        var filling = (Filling)inventory.SearchInventory("FILX");
        var coffee = inventory.SearchInventory("COFB");

        var fillingResult = bagel.AddFilling(filling);
        var bagelResult= user.Basket.Add(bagel);
        var coffeeResult = user.Basket.Add(coffee);
        var quantity = user.Basket.Count;
        Assert.Multiple(() =>
        {
            Assert.That(bagelResult, Is.True);
            Assert.That(fillingResult, Is.True);
            Assert.That(coffeeResult, Is.True);
            Assert.That(quantity, Is.EqualTo(3));
        });
    }

    //As a member of the public,
    //So that I can not overfill my small bagel basket
    //I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
    [Test]
    public void AddingOverCapacity()
    {
        var inventory = new Inventory();
        var user = new Shopper();
        var bagel = (Bagel) inventory.SearchInventory("BGLP");
        var filling = (Filling)inventory.SearchInventory("FILX");
        var everythingBagel = (Bagel) inventory.SearchInventory("BGLE");
        var salmonFilling = (Filling)inventory.SearchInventory("FILS");
        var coffee = inventory.SearchInventory("COFB");

        var fillingResult = bagel.AddFilling(filling);
        var bagelResult = user.Basket.Add(bagel);
        var coffeeResult = user.Basket.Add(coffee);
        var salmonFillingResult = everythingBagel.AddFilling(salmonFilling);
        var everythingBagelResult = user.Basket.Add(everythingBagel);
        var containsBagel = user.Basket.Items.ContainsKey(everythingBagel);
        var containsFilling = user.Basket.Items.ContainsKey(salmonFilling);



        Assert.Multiple(() =>
        {
            Assert.That(bagelResult, Is.True);
            Assert.That(fillingResult, Is.True);
            Assert.That(coffeeResult, Is.True);
            Assert.That(salmonFillingResult, Is.True);
            // Filling increases quantity
            Assert.That(everythingBagelResult, Is.False);
            Assert.That(containsBagel, Is.False);
            Assert.That(containsFilling, Is.False);
        });
    }


    //As a member of the public,
    //So I can change my order,
    //I'd like to remove a bagel from my basket.
    [Test]
    public void RemovingSingleItem() 
    {
        var inventory = new Inventory();
        var user = new Shopper();
        var bagel = inventory.SearchInventory("BGLP");

        user.Basket.Add(bagel);
        var result = user.Basket.Remove(bagel);

        Assert.That(result, Is.True);
    }

    [Test]
    public void RemovingFromEmptyBasket()
    {
        var inventory = new Inventory();
        var user = new Shopper();
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
        var user = new Shopper();
        var bagel = inventory.SearchInventory("BGLP");
        var filling = inventory.SearchInventory("FILX");

        user.Basket.Add(bagel);
        var result =  user.Basket.Remove(filling);

        Assert.That(result, Is.False);
    }
    [Test]
    public void RemovingBagelShouldRemoveFilling()
    {
        var inventory = new Inventory();
        var user = new Shopper();
        var bagel = (Bagel)inventory.SearchInventory("BGLP");
        var filling = (Filling)inventory.SearchInventory("FILX");

        bagel.AddFilling(filling);
        user.Basket.Add(bagel);
        var result = user.Basket.Remove(bagel);

        Assert.Multiple(() =>
        {
            Assert.That(user.Basket.Count, Is.EqualTo(0));
            Assert.That(result, Is.True);
        });
    }

    //As a Bob's Bagels manager,
    //So that I can expand my business,
    //I’d like to change the capacity of baskets.
    [Test]
    public void ManagerChangeCapacity() 
    {
        var manager = new Manager();
        var shopper = new Shopper();

        var change = manager.ChangeCapacity(3);
        var result = shopper.Basket.Capacity;

        Assert.Multiple(() =>
        { 
            Assert.That(result, Is.EqualTo(3));
            Assert.That(change, Is.True);
        }
        );
    }

    //As a customer,
    //So I know what the damage will be,
    //I'd like to know the cost of a bagel before I add it to my basket.

    [Test]
    public void CalculateSimpleBagel()
    {
        var inventory = new Inventory();
        var bagel = inventory.SearchInventory("BGLP");

        var price = bagel.Price;

        Assert.That(price, Is.EqualTo(0.39f));
    }

    [Test]
    public void CalculateMaxFilledBagel()
    {
        var inventory = new Inventory();
        Bagel bagel = (Bagel) inventory.SearchInventory("BGLE");
        var filling1 = (Filling)inventory.SearchInventory("FILX");
        var filling2 = (Filling)inventory.SearchInventory("FILS");
        var filling3 = (Filling)inventory.SearchInventory("FILE");

        bagel.AddFilling(filling1);
        bagel.AddFilling(filling2);
        bagel.AddFilling(filling3);
        var price = bagel.Price;

        Assert.That(price, Is.EqualTo(0.49f+ 0.12f*3));
    }

    //As a customer,
    //So I know how much money I need,
    //I'd like to know the total cost of items in my basket.
    [Test]
    public void CalculateTotal() 
    {
        
        var inventory = new Inventory();
        var shopper = new Shopper();
        Bagel bagel = (Bagel)inventory.SearchInventory("BGLE");
        var filling1 = (Filling)inventory.SearchInventory("FILX");
        var filling2 = (Filling)inventory.SearchInventory("FILS");
        var filling3 = (Filling)inventory.SearchInventory("FILE");

        bagel.AddFilling(filling1);
        bagel.AddFilling(filling2);
        bagel.AddFilling(filling3);
        shopper.Basket.Add(bagel);
        var price = shopper.Basket.Total();

        Assert.That(price, Is.EqualTo(0.49f + 0.12f * 3));

    }

    [Test]
    public void CalculateEmptyBasket()
    {

        var inventory = new Inventory();
        var shopper = new Shopper();

        var price = shopper.Basket.Total();

        Assert.That(price, Is.EqualTo(0));
    }

    //As a customer,
    //So I don't over-spend,
    //I'd like to know the cost of each filling before I add it to my bagel order.
    [Test]
    public void FillingPrice()
    {
        var inventory = new Inventory();

        var filling1 = (Filling)inventory.SearchInventory("FILX");
        var filling2 = (Filling)inventory.SearchInventory("FILS");
        var filling3 = (Filling)inventory.SearchInventory("FILE");

        Assert.Multiple(() =>
        {
            Assert.That(filling1.Price, Is.EqualTo(0.12f));
            Assert.That(filling2.Price, Is.EqualTo(0.12f));
            Assert.That(filling3.Price, Is.EqualTo(0.12f));

        });

    }

}