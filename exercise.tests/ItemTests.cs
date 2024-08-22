using exercise.main;
using exercise.main.Items;
using exercise.main.Persons;

namespace exercise.tests;

public class ItemTests
{
    [Test]
    public void SixOnionBagelsSpecialOffer()
    {
        // Setup
        Customer customer = new Customer("customer", false);
        ShopInventory shopInventory = new ShopInventory();
        customer.Basket.Capacity = 10;

        // Execute
        Bagel onionBagel = shopInventory.GetBagelBySkuID("BGLO");
        
        for (int i = 0; i < 6; i++)
        {
            customer.AddItemToBasket(onionBagel);
        }

        // Verify
        Assert.IsTrue(onionBagel.Price == 2.49);

        //Customer customer = new Customer("customer", false);
        //ShopInventory shopInventory = new ShopInventory();
        //customer.Basket.Capacity = 23;

        //// 2 onion Bagel
        //Bagel onionBagel = shopInventory.GetBagelBySkuID("BGLO");
        //customer.AddItemToBasket(onionBagel);
        //customer.AddItemToBasket(onionBagel);

        //// 12 Plain Bagel
        //Bagel plainBagel = shopInventory.GetBagelBySkuID("BGLP");
        //for (int i = 0; i < 12; i++)
        //{
        //    customer.AddItemToBasket(plainBagel);
        //}

        //// 6 Everything Bagel
        //Bagel everythingBagel = shopInventory.GetBagelBySkuID("BGLE");
        //for (int i = 0; i < 6; i++)
        //{
        //    customer.AddItemToBasket(everythingBagel);
        //}

        //// 3 Black Coffee
        //Coffee coffee = shopInventory.GetCoffeeBySkuID("COFB");
        //customer.AddItemToBasket(coffee);
        //customer.AddItemToBasket(coffee);
        //customer.AddItemToBasket(coffee);

        //string shopName = "Bob's Bagels";

        //Receipt customerReceipt = customer.Checkout(shopName);

        //Assert.IsTrue(customerReceipt != null);
        //Assert.IsTrue(customerReceipt?.BoughtItems.Count() == 4);
        //Assert.IsTrue(customer.Basket.Capacity == 0);
        //Assert.IsTrue(onionBagel.Quantity == 2);
        //Assert.IsTrue(plainBagel.Quantity == 12);
        //Assert.IsTrue(everythingBagel.Quantity == 6);
        //Assert.IsTrue(coffee.Quantity == 3);
    }

    [Test]
    public void TwelveOnionBagelsSpecialOffer()
    {
        // Setup
        Customer customer = new Customer("customer", false);
        ShopInventory shopInventory = new ShopInventory();
        customer.Basket.Capacity = 50;

        // Execute
        Bagel onionBagel = shopInventory.GetBagelBySkuID("BGLO");

        for (int i = 0; i < 12; i++)
        {
            customer.AddItemToBasket(onionBagel);
        }

        // Verify
        Assert.IsTrue(onionBagel.Price == 2.49 * 2);
    }

    [Test]
    public void TwelveOnionBagelsSpecialOfferPlusOneOriginalPrice()
    {
        // Setup
        Customer customer = new Customer("customer", false);
        ShopInventory shopInventory = new ShopInventory();
        customer.Basket.Capacity = 50;

        // Execute
        Bagel onionBagel = shopInventory.GetBagelBySkuID("BGLO");

        for (int i = 0; i < 13; i++)
        {
            customer.AddItemToBasket(onionBagel);
        }

        // Verify
        Assert.IsTrue(onionBagel.Price == 5.47);
    }

    [Test]
    public void TwelvePlainBagelsSpecialOffer()
    {
        // Setup
        Customer customer = new Customer("customer", false);
        ShopInventory shopInventory = new ShopInventory();
        customer.Basket.Capacity = 50;

        // Execute
        Bagel plainBagel = shopInventory.GetBagelBySkuID("BGLP");

        for (int i = 0; i < 12; i++)
        {
            customer.AddItemToBasket(plainBagel);
        }

        // Verify
        Assert.IsTrue(plainBagel.Price == 3.99);
    }

    [Test]
    public void TwentyFourPlainBagelsSpecialOffer()
    {
        // Setup
        Customer customer = new Customer("customer", false);
        ShopInventory shopInventory = new ShopInventory();
        customer.Basket.Capacity = 50;

        // Execute
        Bagel plainBagel = shopInventory.GetBagelBySkuID("BGLP");

        for (int i = 0; i < 24; i++)
        {
            customer.AddItemToBasket(plainBagel);
        }

        // Verify
        Assert.IsTrue(plainBagel.Price == 3.99 * 2);
    }

    [Test]
    public void TwelvePlainBagelsPlusOneOriginalPrice()
    {
        // Setup
        Customer customer = new Customer("customer", false);
        ShopInventory shopInventory = new ShopInventory();
        customer.Basket.Capacity = 50;

        // Execute
        Bagel plainBagel = shopInventory.GetBagelBySkuID("BGLP");

        for (int i = 0; i < 13; i++)
        {
            customer.AddItemToBasket(plainBagel);
        }

        // Verify
        Assert.IsTrue(plainBagel.Price == 4.38);
    }

    [Test]
    public void MoneySavedFromSpecialOffer()
    {
        // Setup
        Customer customer = new Customer("customer", false);
        ShopInventory shopInventory = new ShopInventory();
        customer.Basket.Capacity = 50;

        // Execute
        Bagel plainBagel = shopInventory.GetBagelBySkuID("BGLP");

        for (int i = 0; i < 12; i++)
        {
            customer.AddItemToBasket(plainBagel);
        }

        // Verify
        Assert.IsTrue(plainBagel.MoneySaved == -0.69);
    }
}