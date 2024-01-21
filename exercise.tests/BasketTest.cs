using exercise.main;

namespace exercise.tests;

[TestFixture]
public class BasketTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test] // Core exercise
    public void AddTest() // User story 1
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
        Assert.That(basket.myBasket.Count, Is.EqualTo(3));
        Assert.IsTrue(basket.myBasket.Count <= basket.BasketSize);
    }
    [Test]
    public void RemoveTest() // User story 2
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
        Assert.That(basket.myBasket.Count, Is.EqualTo(1));
        Assert.IsTrue(basket.myBasket.Count <= basket.BasketSize);
    }
    [Test]
    public void FullBasketTest() // User story 3
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
    public void BasketCapacityTest() // User story 4
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
        Assert.That(basket.myBasket.Count, Is.EqualTo(6));
        Assert.IsTrue(basket.myBasket.Count <= basket.BasketSize);
    }
    [Test]
    public void SchrodingersBagelTest() // User story 5
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
    [Test]
    public void TotalTest() // User story 6
    {
        //arrange
        Basket basket = new Basket();
        Item bagel = new Item("BGLO", 0.49, "Bagel", "Onion");
        Item bagel2 = new Item("BGLS", 0.49, "Bagel", "Sesame");
        Item coffee = new Item("COFC", 1.19, "Coffee", "Cappucino");
        Item filling = new Item("FILB", 0.12, "Filling", "Bacon");
        Item filling2 = new Item("FILE", 0.12, "Filling", "Egg");
        basket.AddItem(bagel);
        basket.AddItem(bagel2);
        basket.AddItem(coffee);
        basket.AddItem(filling);
        basket.AddItem(filling2);
        //act
        double sum = basket.Total(basket.myBasket);
        //assert
        //0.49 + 0.49 + 1.19 + 0.12 + 0.12 = 2.41
        Assert.That(sum, Is.EqualTo(2.41d));
    }
    [Test]
    public void PriceTest() // User story 7 & 9
    {
        // using the same test for user story 7 and 9 since they are both
        // about returning a Price from string Name on select Item

        //arrange
        Basket basket = new Basket();

        //act
        double price1 = basket.Price("Everything");
        double price2 = basket.Price("Latte");
        double price3 = basket.Price("Cheese");
        //assert
        Assert.That(price1, Is.EqualTo(0.49));
        Assert.That(price2, Is.EqualTo(1.29));
        Assert.That(price3, Is.EqualTo(0.12));
    }
    [Test]
    public void ChangeFillingTest() // User story 8
    {
        //arrange
        Basket basket = new Basket();
        Item bagel = new Item("BGLO", 0.49, "Bagel", "Onion");
        Item bagel2 = new Item("BGLS", 0.49, "Bagel", "Sesame");
        Item coffee = new Item("COFC", 1.19, "Coffee", "Cappucino");
        Item filling = new Item("FILB", 0.12, "Filling", "Bacon");
        Item filling2 = new Item("FILE", 0.12, "Filling", "Egg");
        basket.AddItem(bagel);
        basket.AddItem(bagel2);
        basket.AddItem(coffee);
        basket.AddItem(filling);
        //act
        basket.RemoveItem(filling);
        Item newfilling = basket.ChangeFilling(filling, "FILE", 0.12, "Filling", "Egg");
        basket.AddItem(newfilling);
        //assert
        Assert.That(newfilling.Product, Is.EqualTo(filling2.Product));
    }
    [Test]
    public void inInventoryTest() // User story 10
    {
        //arrange
        Basket basket = new Basket();
        Item bagel = new Item("BGLO", 0.49, "Bagel", "Onion");
        Item bagel2 = new Item("BGLS", 0.49, "Bagel", "Sesame");
        Item coffee = new Item("COFC", 1.19, "Coffee", "Capuccino");
        Item filling = new Item("FILB", 0.12, "Filling", "Bacon");
        Item filling2 = new Item("FILE", 0.12, "Filling", "Egg");
        //act
        bool bagelStocked = basket.InInventory(bagel, basket.inventory);
        bool bagel2Stocked = basket.InInventory(bagel2, basket.inventory);
        bool coffeeStocked = basket.InInventory(coffee, basket.inventory);
        bool fillingStocked = basket.InInventory(filling, basket.inventory);
        bool filling2Stocked = basket.InInventory(filling2, basket.inventory);
        //assert
        Assert.IsTrue(bagelStocked);
        Assert.IsTrue(bagel2Stocked);
        Assert.IsTrue(coffeeStocked); 
        Assert.IsTrue(fillingStocked);
        Assert.IsTrue(filling2Stocked);
    }
    [Test]
    public void ReceiptTest() // Extension 2
    {
        //arrange
        Basket basket = new Basket();
        Item bagel = new Item("BGLO", 0.49, "Bagel", "Onion");
        Item bagel2 = new Item("BGLS", 0.49, "Bagel", "Sesame");
        Item coffee = new Item("COFC", 1.19, "Coffee", "Capuccino");
        Item filling = new Item("FILB", 0.12, "Filling", "Bacon");
        Item filling2 = new Item("FILE", 0.12, "Filling", "Egg");
        basket.AddItem(bagel);
        basket.AddItem(bagel2);
        basket.AddItem(coffee);
        basket.AddItem(filling);
        basket.AddItem(filling2);
        //act
        double receiptSum = basket.Receipt(basket.myBasket);
        //assert
        Assert.AreEqual(2.41, receiptSum); // total sum on receipt should be €2.41
    }
}