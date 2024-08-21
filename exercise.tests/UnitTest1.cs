using System.Data;

namespace exercise.tests;

public class Tests
{
    private BobsBagel bb;
    private Basket basket;
    private Item fillerItem;
    private Item testItem;
    private Filling testFilling;
    private Item item1;
    [SetUp]
    public void Setup()
    {
        bb = new BobsBagel(20);
        basket = bb.NewBasket();
        fillerItem = Inventory.inventory[0];
        
        testItem = new Bagel("Cfe", 1.3f, "Coffee");
        testFilling = new Filling("HAM", 0.12f, "Ham");
        item1 = Inventory.inventory[1];
    }

    [TestCase(true, 29, 30)]
    [TestCase(false, 30, 30)]
    public void AddItemTest(bool expResult, int basketCount, int basketCapacity)
    {
        basket = new Basket(basketCapacity);
        for(int i = 0; i < basketCount; i++)
        {
            basket.AddItem(fillerItem);
        }

        bool result = basket.AddItem(item1);
        Assert.That(result, Is.EqualTo(expResult));

        Assert.That(basket.AddItem(testItem), Is.EqualTo(false));
    }


    [Test]
    public void RemoveItemTest()
    {
        bool resultadd = basket.AddItem(item1);
        basket.RemoveItem(item1);
        bool resultremove = (basket.Items.Count == 0);

        Assert.That(resultadd, Is.EqualTo(resultremove));
    }

    /*
    [TestCase(12)]
    [TestCase(1)]
    [TestCase(122)]
    public void ChangeCapacityTest(int newCapacity)
    {
        int oldCapacity = basket.Capacity;
        basket.ChangeCapasity(newCapacity);
        Assert.That(oldCapacity != newCapacity);
        Assert.That(basket.Capacity, Is.EqualTo(newCapacity));
    }*/


    [TestCase(0.49f, 1.3f)]
    public void GetItemCostTest(float fillerCost, float testCost)
    {
        Assert.That(testItem.GetItemCost(), Is.EqualTo(testCost));
        Assert.That(fillerItem.GetItemCost(), Is.EqualTo(fillerCost));
    }


    [TestCase(0.88f)]
    public void GetCostTest(float expCost)
    {
        basket.AddItem(item1);
        basket.AddItem(fillerItem);
        float cost = basket.GetCost();
        Assert.That(expCost, Is.EqualTo(cost));
    }


    [Test]
    public void AddFillingTest()
    {
        Bagel item = (Bagel)testItem;
        bool result = item.AddFilling(testFilling);
        Assert.That(item.Fillings.Contains(testFilling), Is.EqualTo(false));

        result = item.AddFilling((Filling)Inventory.inventory[11]);
        Assert.That(item.Fillings.Contains((Filling)Inventory.inventory[11]), Is.EqualTo(true));
    }

    [Test]
    public void RemoveFillingTest()
    {
        Bagel item = (Bagel)testItem;
        bool result = item.AddFilling(testFilling);
        Assert.That(item.Fillings.Contains(testFilling), Is.EqualTo(false));
        result = item.RemoveFilling(testFilling);
        Assert.That(result, Is.EqualTo(false));
        result = item.AddFilling((Filling)Inventory.inventory[11]);
        Assert.That(item.Fillings.Contains((Filling)Inventory.inventory[11]), Is.EqualTo(true));
        result = item.RemoveFilling((Filling)Inventory.inventory[11]);
        Assert.That(!item.Fillings.Contains((Filling)Inventory.inventory[11]));
    }

    [TestCase(12)]
    [TestCase(1)]
    [TestCase(122)]
    public void ChangeBasketCapacityTest(int newCapacity)
    {
        int oldCapacity = bb.BasketCapasity;
        Assert.That(newCapacity != oldCapacity);
        bb.ChangeBasketCapasity(newCapacity);
        Basket bskt = bb.NewBasket();
        int bsktCapacity = bskt.Capacity;
        Assert.That(bsktCapacity == newCapacity);

    }

    [Test]
    public void CheckOutTest()
    {
        for (int i = 0; i < 18; i++) 
        {
            basket.AddItem(item1);
        }
        Bagel bagel = (Bagel)Inventory.inventory[3];
        bagel.AddFilling((Filling)Inventory.inventory[11]);
        basket.AddItem(bagel);

        float sum = CheckOut.checkOut(basket);
        //Console.WriteLine(basket.Items.Count);
        Assert.That(sum, Is.EqualTo((float)Math.Round(3.99f + 2.49f + 0.12f + 0.49f, 2)));
    }
}