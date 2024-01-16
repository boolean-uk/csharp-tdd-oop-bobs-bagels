using exercise.main;

namespace exercise.tests;

public class Tests
{

    [Test]
    public void ShouldSumItemsInBasket()
    {
        Item bagel = DefaultInventory.FindItemBySKU("BGLO");
        Item coffee = DefaultInventory.FindItemBySKU("COFB");
        Item filling = DefaultInventory.FindItemBySKU("FILB");
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
        Item bagel = DefaultInventory.FindItemBySKU("BGLO");
        Item filling = DefaultInventory.FindItemBySKU("FILB");
        Item coffee = DefaultInventory.FindItemBySKU("COFB");
        Item secondFilling = DefaultInventory.FindItemBySKU("FILE");
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
        Item filling = DefaultInventory.FindItemBySKU("FILB");
        double sum = DefaultInventory.FindFillingCost(filling);

        // 0,12
        Assert.That(0.12d, Is.EqualTo(sum));
    }
    [Test]
    public void ShouldRemoveItemFromBasket()
    {
        Item bagel = DefaultInventory.FindItemBySKU("BGLO");
        Basket b = new Basket(5);
        b.PutInBasket(bagel);
        b.RemoveFromBasket(bagel);
        Assert.That(!b.items.Contains(bagel));
    }
    [Test]
    public void ShouldNotBePossibleToAddItemAfterBasketCapacityIsReached()
    {
        Item bagel = DefaultInventory.FindItemBySKU("BGLO");
        Item filling = DefaultInventory.FindItemBySKU("FILB");
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
        Item bagel = DefaultInventory.FindItemBySKU("BGLO");
        Item filling = DefaultInventory.FindItemBySKU("FILB");
        Customer c = new Customer();
        c.basket.PutInBasket(bagel);
        c.basket.PutInBasket(filling);

        Assert.That(c.basket.items.Contains(bagel) && c.basket.items.Contains(filling));
    }

}