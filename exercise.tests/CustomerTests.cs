using exercise.main;
using exercise.main.Items;
using exercise.main.Persons;

namespace exercise.tests;

public class CustomerTests
{
    [Test]
    public void AddItemToBasket()
    {
        // Setup
        Customer customer = new Customer("customer", false);
        ShopInventory shopInventory = new ShopInventory();

        // Execute
        Bagel bagel = shopInventory.GetBagelBySkuID("BGLO");
        customer.AddItemToBasket(bagel);

        // Verify
        Assert.IsTrue(customer.Basket.ItemsInBasket.Contains(bagel));
    }

    [Test]
    public void AddItemToBasketWhenFull()
    {
        // Setup
        Customer customer = new Customer("customer", false);
        ShopInventory shopInventory = new ShopInventory();

        // Execute
        Bagel bagel = shopInventory.GetBagelBySkuID("BGLO");
        customer.Basket.Capacity = 0;

        bool result = customer.AddItemToBasket(bagel);

        // Verify
        Assert.IsFalse(customer.Basket.ItemsInBasket.Contains(bagel) & result == false);
    }

    [Test]
    public void RemoveItemFromBasket()
    {
        // Setup
        Customer customer = new Customer("customer", false);
        ShopInventory shopInventory = new ShopInventory();

        // Execute
        Bagel bagel = shopInventory.GetBagelBySkuID("BGLO");
        customer.AddItemToBasket(bagel);

        bool result = customer.RemoveItemFromBasket(bagel);

        // Verify
        Assert.IsTrue(!customer.Basket.ItemsInBasket.Contains(bagel) & result == true);
    }

    [Test]
    public void RemoveItemFromBasketWhenItemDoesNotExist()
    {
        // Setup
        Customer customer = new Customer("customer", false);
        ShopInventory shopInventory = new ShopInventory();

        // Execute
        Bagel bagel = shopInventory.GetBagelBySkuID("BGLO");

        bool result = customer.RemoveItemFromBasket(bagel);

        // Verify
        Assert.IsTrue(!customer.Basket.ItemsInBasket.Contains(bagel) & result == false);
    }

    [Test]
    public void GetTotalSumOfBasketWithoutBagelFillings()
    {
        // Setup
        Customer customer = new Customer("customer", false);
        ShopInventory shopInventory = new ShopInventory();

        // Execute
        Bagel bagel = shopInventory.GetBagelBySkuID("BGLO");
        Coffee coffee = shopInventory.GetCoffeeBySkuID("COFB");

        customer.AddItemToBasket(bagel);
        customer.AddItemToBasket(coffee);

        double result = customer.GetTotalSumOfBasket();

        // Verify
        Assert.IsTrue(result == (bagel.Price + coffee.Price));
    }

    [Test]
    public void GetTotalSumOfBasketWithBagelFillings()
    {
        // Setup
        Customer customer = new Customer("customer", false);
        ShopInventory shopInventory = new ShopInventory();

        // Execute
        Bagel bagel = shopInventory.GetBagelBySkuID("BGLO");
        Coffee coffee = shopInventory.GetCoffeeBySkuID("COFB");
        Filling filling = shopInventory.GetFillingBySkuID("FILX");
        Filling filling2 = shopInventory.GetFillingBySkuID("FILS");

        customer.AddItemToBasket(bagel);
        customer.AddItemToBasket(coffee);
        customer.AddFillingToBagel(bagel, filling);
        customer.AddFillingToBagel(bagel, filling2);

        double result = customer.GetTotalSumOfBasket();
        double expected = (bagel.Price + coffee.Price + filling.Price + filling2.Price);
        expected = Math.Round(expected, 2);

        // Verify
        Assert.IsTrue(result == expected);
    }

    [Test]
    public void GetCostOfItem()
    {
        // Setup
        Customer customer = new Customer("customer", false);
        ShopInventory shopInventory = new ShopInventory();

        // Execute
        Bagel bagel = shopInventory.GetBagelBySkuID("BGLO");

        double result = customer.GetCostOfItem(bagel);

        // Verify
        Assert.IsTrue(result == shopInventory.GetBagelBySkuID("BGLO").Price);
    }

    [Test]
    public void AddFillingToBagel()
    {
        // Setup
        Customer customer = new Customer("customer", false);
        ShopInventory shopInventory = new ShopInventory();

        // Execute
        Bagel bagel = shopInventory.GetBagelBySkuID("BGLO");
        Filling filling = shopInventory.GetFillingBySkuID("FILX");

        customer.AddItemToBasket(bagel);

        bool result = customer.AddFillingToBagel(bagel, filling);

        // Verify
        Assert.IsTrue(result & bagel.Fillings.Contains(filling));
    }

    [Test]
    public void GetReceipt()
    {
        Customer customer = new Customer("customer", false);
        ShopInventory shopInventory = new ShopInventory();

        // 2 onion Bagel
        Bagel onionBagel = shopInventory.GetBagelBySkuID("BGLO");
        customer.AddItemToBasket(onionBagel);
        customer.AddItemToBasket(onionBagel);

        // 12 Plain Bagel
        Bagel plainBagel = shopInventory.GetBagelBySkuID("BGLP");
        for (int i = 0; i < 12; i++)
        {
            customer.AddItemToBasket(plainBagel);
        }
        
        // 6 Everything Bagel
        Bagel everythingBagel = shopInventory.GetBagelBySkuID("BGLE");
        for (int i = 0; i < 6; i++)
        {
            customer.AddItemToBasket(everythingBagel);
        }

        // 3 Black Coffee
        Coffee coffee = shopInventory.GetCoffeeBySkuID("COFB");
        customer.AddItemToBasket(coffee);
        customer.AddItemToBasket(coffee);
        customer.AddItemToBasket(coffee);

        string shopName = "Bob's Bagels";

        Receipt customerReceipt = customer.GetReceipt(shopName);

        Assert.Fail();

        //Assert.IsTrue(customerReceipt != null);
        //Assert.IsTrue(customerReceipt != null);
        //Assert.IsTrue(customerReceipt != null);
    }
}