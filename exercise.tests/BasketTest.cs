using exercise.main;

namespace exercise.tests;

[TestFixture]
public class BasketTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddTest()
    {
        //arrange
        Basket basket = new Basket();
        Item bagel = new Item("BGLO", 0.49, "Bagel", "Onion");
        Item coffee = new Item("COFC", 1.19, "Coffee", "Cappucino");
        Item filling = new Item("FILB", 0.12, "Filling", "Bacon");
        //act
        basket.AddItem(bagel);
        basket.AddItem(coffee);
        basket.AddItem(filling);
        //assert
        Assert.AreEqual(3, basket.myBasket.Count);
        Assert.IsTrue(basket.myBasket.Count <= basket.BasketSize);
    }
    [Test]
    public void RemoveTest()
    {
        //arrange
        Basket basket = new Basket();
        Item bagel = new Item("BGLO", 0.49, "Bagel", "Onion");
        Item coffee = new Item("COFC", 1.19, "Coffee", "Cappucino");
        Item filling = new Item("FILB", 0.12, "Filling", "Bacon");
        basket.AddItem(bagel);
        basket.AddItem(coffee);
        basket.AddItem(filling);
        //act
        basket.RemoveItem(coffee);
        basket.RemoveItem(filling);
        //assert
        Assert.AreEqual(1, basket.myBasket.Count);
        Assert.IsTrue(basket.myBasket.Count <= basket.BasketSize);
    }
    [Test]
    public void FullBasketTest()
    {
        //arrange
        Basket basket = new Basket();
        Item bagel = new Item("BGLO", 0.49, "Bagel", "Onion");
        Item bagel2 = new Item("BGLS", 0.49, "Bagel", "Sesame");
        Item coffee = new Item("COFC", 1.19, "Coffee", "Cappucino");
        Item filling = new Item("FILB", 0.12, "Filling", "Bacon");
        Item filling2 = new Item("FILE", 0.12, "Filling", "Egg");
        basket.AddItem(bagel);
        basket.AddItem(coffee);
        basket.AddItem(filling);
        basket.AddItem(bagel2);
        basket.AddItem(filling2);
        //act   
        bool isFull = basket.FullBasket(basket.myBasket);
        //assert
        Assert.IsTrue(isFull);
    }
    [Test]
    public void BasketCapacityTest()
    {
        //arrange
        Basket basket = new Basket();
        Item bagel = new Item("BGLO", 0.49, "Bagel", "Onion");
        Item bagel2 = new Item("BGLS", 0.49, "Bagel", "Sesame");
        Item coffee = new Item("COFC", 1.19, "Coffee", "Cappucino");
        Item filling = new Item("FILB", 0.12, "Filling", "Bacon");
        Item filling2 = new Item("FILE", 0.12, "Filling", "Egg");
        basket.AddItem(bagel);
        basket.AddItem(coffee);
        basket.AddItem(filling);
        basket.AddItem(bagel2);
        basket.AddItem(filling2);
        //act
        Item coffee2 = new Item("COFL", 1.19, "Coffee", "Latte");
        basket.BasketCapacity(6);
        basket.AddItem(coffee2);
        //assert
        Assert.AreEqual(6, basket.myBasket.Count);
        Assert.IsTrue(basket.myBasket.Count <= basket.BasketSize);
    }
    [Test]
    public void SchrodingersBagelTest()
    {
        //arrange
        Basket basket = new Basket();
        Item bagel = new Item("BGLO", 0.49, "Bagel", "Onion");
        Item bagel2 = new Item("BGLS", 0.49, "Bagel", "Sesame");
        Item coffee = new Item("COFC", 1.19, "Coffee", "Cappucino");
        Item filling = new Item("FILB", 0.12, "Filling", "Bacon");
        Item filling2 = new Item("FILE", 0.12, "Filling", "Egg");
        basket.AddItem(bagel);
        basket.AddItem(coffee);
        basket.AddItem(filling);
        basket.AddItem(bagel2);
        basket.AddItem(filling2);
        //act
        basket.RemoveItem(bagel2);
        bool exists1 = basket.SchrodingersItem(bagel);
        bool exists2 = basket.SchrodingersItem(bagel2);
        //assert
        Assert.IsTrue(exists1);
        Assert.IsFalse(exists2);
    }
}