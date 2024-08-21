using exercise.main;
using Microsoft.VisualBasic;
using System.Reflection.Emit;

namespace exercise.tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    //1. As a member of the public, So I can order a bagel before work, I'd like to add a specific type of bagel to my basket.
    //8. As a customer, So I can shake things up a bit, I'd like to be able to choose fillings for my bagel.

    [Test]
    public void AddItemToBasketTest()
    {
        string variant = "Onion";
        bool expected = true;
        Basket basket = new Basket();

        bool HasBeenAdded = basket.AddItem(variant);

        Assert.That(HasBeenAdded, Is.EqualTo(expected));

    }

    //2. As a member of the public, So I can change my order, I'd like to remove a bagel from my basket.

    [Test]
    public void RemoveItemFromBasketTest()
    {
        string variant1 = "Onion";
        string variant2 = "Black";
        bool expected = true;
        Basket basket = new Basket();
        basket.AddItem(variant1);
        basket.AddItem(variant2);

        bool hasBeenRemoved = basket.RemoveItem(variant1);

        Assert.That(hasBeenRemoved, Is.EqualTo(expected));

    }

    //3. As a member of the public, So that I can not overfill my small bagel basket, I'd like to know when my basket is full when I try adding an item beyond my basket capacity.
    
    [Test]
    public void BasketIsFullTest()
    {
        string variant1 = "Onion";
        string variant2 = "Black";
        string variant3 = "Egg";

        Basket basket = new Basket();
        basket.BasketCapacity = 2;
        basket.AddItem(variant1);
        basket.AddItem(variant2);
        basket.AddItem(variant3);

        bool IsBasketFull = basket.IsBasketFull;

        Assert.That(IsBasketFull, Is.True);
    }


    //4. As a Bob's Bagel manager, So that I can expand my business, I'd like to change the capacity of baskets.
    
    [Test]
    public void CanChangeCapacityTest()
    {
        bool manager = true;
        Basket basket = new Basket();

        bool CanChangeCap = basket.ChangeCapacity(5, manager);

        Assert.That(CanChangeCap, Is.True);

    }


    //5. As a member of the public, So that I can maintain my sanity, I'd like to know if I try to remove an item that doesn't exist in my basket.
    
    [Test]
    public void ItemIsNotInBasketTest()
    {
        bool expected = false;
        Basket basket = new Basket();

        bool isInBasket = basket.RemoveItem("Black");

        Assert.That(isInBasket, Is.EqualTo(expected));
    }
    

    //6. As a customer, So I know how much money I need, I'd like to know the total cost of items in my basket.
    
    [Test]
    public void TotalCostofBasketTest()
    {
        double expectedTotal = 0.49 + 0.99 + 0.12;
        Basket basket = new Basket();
        basket.AddItem("Onion");
        basket.AddItem("Black");
        basket.AddItem("Egg");

        double actualTotal = basket.TotalCost;

        Assert.That(actualTotal, Is.EqualTo(expectedTotal));


    }

    //7. As a customer, So I know what the damage will be, I'd like to know the cost of a bagel before I add it to my basket.
    //9. As a customer, So I don't over-spend, I'd like to know the cost of each filling before I add it to my bagel order.
    
    [Test]
    public void GetCostofItemTest()
    {
        double expectedCost = 0.12;
        BobsInventory inventory = new BobsInventory();

        inventory.ItemVariant = "Egg";
        double actualCost = inventory.GetCostofItem;

        Assert.That(actualCost, Is.EqualTo(expectedCost));
        
    }

    //10. As a manager, So we don't get any weird requests, I want customer to only be able to order things that we stock in our inventory.
    
    [Test]
    public void CanOnlyOrderFromInventoryTest()
    {
        Basket basket = new Basket();

        //Try to order item in stock
        bool isInInventory = basket.AddItem("Egg");

        Assert.That(isInInventory, Is.True);

        //Try to order item not in stock
        bool isInInventory2 = basket.AddItem("bolle");

        Assert.That(isInInventory2, Is.False);

    }

    //extension 2 Receipts
    //11. As a customer, So that I can track my spendings, I'd like to receive a receipt of my order.
    [Test]
    public void PrintReceiptTest()
    {
        Basket basket = new Basket();
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Black");


        string printedReceipt = basket.PrintReceipt;

        Assert.That(printedReceipt, Does.Contain("Onion Bagel"));
    }

    //extension 1 Discounts
    [Test]
    public void Get6BagelDiscountTest()
    {
        Basket basket = new Basket();
        basket.BasketCapacity = 6;
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");

        double totalWithDiscount = basket.GetSpecialOffer();

        Assert.That(totalWithDiscount, Is.EqualTo(2.49));

    }

    [Test]
    public void Get12BagelDiscountTest()
    {
        Basket basket = new Basket();
        basket.BasketCapacity = 12;
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");

        double totalWithDiscount = basket.GetSpecialOffer();

        Assert.That(totalWithDiscount, Is.EqualTo(3.99));
    }

    [Test]
    public void GetCoffeeAndBagelDiscountTest()
    {
        Basket basket = new Basket();
        basket.AddItem("Black");
        basket.AddItem("Plain");

        double totalWithDiscount = basket.GetSpecialOffer();

        Assert.That(totalWithDiscount, Is.EqualTo(1.25));

    }

    [Test]
    public void GetAllDiscountsTest()
    {
        Basket basket = new Basket();
        basket.BasketCapacity = 30;
        basket.AddItem("Black");
        basket.AddItem("Plain");

        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");

        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        basket.AddItem("Onion");
        
        double discount = basket.GetSpecialOffer();

        Assert.That(discount, Is.EqualTo(2.49 + 3.99 + 1.25));

    }
}