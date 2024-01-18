using exercise.main;

namespace exercise.tests;

public class Tests
{

    [Test]
    public void ShouldSumItemsInBasket()
    {
        Item bagel = DefaultInventory.FindItemInInventoryBySKU("BGLO");
        Item coffee = DefaultInventory.FindItemInInventoryBySKU("COFB");
        Item filling = DefaultInventory.FindItemInInventoryBySKU("FILB");
        Basket basket = new Basket(3);
        basket.PutInBasket(bagel);
        basket.PutInBasket(coffee);
        basket.PutInBasket(filling);

        double sum = basket.SumTotal();
  
        // 0,49 + 0,99 + 0,12
        Assert.That(1.6d, Is.EqualTo(sum));
    }

    [Test]
    public void ShouldFindCostOfBagel()
    {
        Item bagel = DefaultInventory.FindItemInInventoryBySKU("BGLO");
        Item filling = DefaultInventory.FindItemInInventoryBySKU("FILB");
        Item coffee = DefaultInventory.FindItemInInventoryBySKU("COFB");
        Item secondFilling = DefaultInventory.FindItemInInventoryBySKU("FILE");
        List<Item> items = new List<Item>
        {
            bagel,filling, coffee, secondFilling
        };
        double sum = DefaultInventory.FindBagelCost(items);

        // 0,49 + 0,12 + 0,12
        Assert.That(0.73d, Is.EqualTo(sum));
    }
    [Test]
    public void ShouldFindCostOfOneFilling()
    {
        Item filling = DefaultInventory.FindItemInInventoryBySKU("FILB");
        double sum = DefaultInventory.FindFillingCost(filling);

        // 0,12
        Assert.That(0.12d, Is.EqualTo(sum));
    }
    [Test]
    public void ShouldRemoveItemFromBasket()
    {
        Item bagel = DefaultInventory.FindItemInInventoryBySKU("BGLO");
        Basket b = new Basket(5);
        b.PutInBasket(bagel);
        b.RemoveFromBasket(bagel);
        Assert.That(!b.items.Contains(bagel));
    }
    [Test]
    public void ShouldNotBePossibleToAddItemAfterBasketCapacityIsReached()
    {
        Item bagel = DefaultInventory.FindItemInInventoryBySKU("BGLO");
        Item filling = DefaultInventory.FindItemInInventoryBySKU("FILB");
        Basket b = new Basket(1);
        b.PutInBasket(bagel);
        string response = b.PutInBasket(filling);

        Assert.AreEqual("Basket is full", response);
    }
    [Test]
    public void ShouldNotBePossibleToAddItemNotInInventory()
    {
        Item nonExistingBagel = new Item("BGLI", 0.12, Name.Bagel, "Cheddar crisp");
        Basket b = new Basket(1);
        string response = b.PutInBasket(nonExistingBagel);

        Assert.AreEqual("Cheddar crisp is not in inventory", response);
    }
    [Test]
    public void CustomerShouldHaveABasket()
    {
        Item bagel = DefaultInventory.FindItemInInventoryBySKU("BGLO");
        Item filling = DefaultInventory.FindItemInInventoryBySKU("FILB");
        Customer c = new Customer();
        c.basket.PutInBasket(bagel);
        c.basket.PutInBasket(filling);

        Assert.That(c.basket.items.Contains(bagel) && c.basket.items.Contains(filling));
    }

}