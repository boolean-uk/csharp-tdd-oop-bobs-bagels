namespace exercise.tests;
using exercise.main;
public class Tests
{


    [Test]
    public void findItemByNameTest()
    {
        Inventory inventory = new Inventory();

        Item expected = new Item("BGLO", "Bagel", 0.49, "Onion");
        Item result = inventory.findItemByName("Onion");

        Assert.That(expected.id == result.id);
    }

    [Test]
    public void addItemTest()
    {
        Inventory inventory = new Inventory();
        Basket basket = new Basket();
        Item expectedItem = new Item("BGLO", "Bagel", 0.49, "Onion");
        List<Item> items = [expectedItem];

        basket.addItem("Bagel", "Onion");

        Assert.That(basket.yourBasket.First().id == expectedItem.id);

    }
}