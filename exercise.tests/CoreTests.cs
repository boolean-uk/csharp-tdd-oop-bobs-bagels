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
        basket.addItem("Bagel", "Onion");
        //for checking that a non existant item doesnt get added to the basket
        bool expected = false;
        bool result1 = basket.addItem("Bagel", "Leverpostei");

        //for checking that something doesnt get added to a full basket
        basket.addItem("Bagel", "Sesame");
        basket.addItem("Bagel", "Sesame");
        bool result2 = basket.addItem("Bagel", "Plain");

        Assert.That(basket.yourBasket.First().id == expectedItem.id);
        Assert.That(result1 == expected);
        Assert.That(result2 == expected);

    }

    [Test]

    public void removeItemTest()
    {
        Basket basket = new Basket();
        basket.removeItem("Onion");


        Assert.That(basket.yourBasket.Count == 0);

    }
}