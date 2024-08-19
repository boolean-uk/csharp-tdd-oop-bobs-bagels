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


    [Test]
    public void changeCapacityTest()
    {
        Basket basket = new Basket();
        Person manager = new Person("Flier", Role.MANAGER);

        basket.changeCapacity(4, manager);

        Assert.That(basket.MAX_BASKET_SIZE == 4);

        //someone who isnt the manager tries to change the basket properties
        Person notManager = new Person("Dennis", Role.CUSTOMER);
        basket.changeCapacity(3, notManager);
        Assert.That(basket.MAX_BASKET_SIZE == 4);

    }

    [Test]
    public void checkTotalTest()
    {
        Basket basket = new Basket();

        basket.addItem("Coffee", "Black");
        basket.addItem("Bagel", "Plain");
        basket.addItem("Filling", "Ham");

        double expected = 1.50;
        double result = basket.checkTotal();

        Assert.That(expected == result);

    }

    [Test]
    public void checkPriceForTypeTest()
    {
        Basket basket = new Basket();

        //check bagel price
        double expectedPrice1 = 0.39;
        double resultPrice1 = basket.checkPriceForType("Plain");
        Assert.That(expectedPrice1 == resultPrice1);

        //check filling price
        double expectedPrice2 = 0.12;
        double resultPrice2 = basket.checkPriceForType("Egg");
        Assert.That(expectedPrice2 == resultPrice2);

    }

}