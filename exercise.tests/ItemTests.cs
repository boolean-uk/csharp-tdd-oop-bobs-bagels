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
        Assert.IsTrue(plainBagel.MoneySaved == 0.69);
    }
}