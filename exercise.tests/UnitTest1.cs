using exercise.main;
namespace exercise.tests;


public class Tests
{


    [Test]
    public void AddToBasket()
    {

        Basket basket = new Basket();
        Iproduct bagel = new Bagel("bagel ", "BGL", 6.9F, "Onion");
        basket.AddBagel(bagel);
        Assert.That(basket.Items.Count(), Is.EqualTo(1));
    }
    [Test]
    public void RemoveBagel()
    {
        Basket basket = new Basket();
        Iproduct bagel = new Bagel("bagel ", "BGL", 6.9F, "Onion");
        basket.AddBagel(bagel);
        basket.AddBagel(bagel);
        basket.RemoveBagel(bagel);
        basket.RemoveBagel(bagel);
        Assert.That(basket.Items.Count(), Is.EqualTo(0));
    }
    [Test]
    public void IsFull()
    {
        Basket basket = new Basket();
        Iproduct bagel = new Bagel("bagel ", "BGL", 6.9F, "Onion");
        basket.AddBagel(bagel);
        basket.AddBagel(bagel);
        Assert.That(basket.IsFull(), Is.EqualTo(false));
    }

    [Test]
    public void ChangeBasketCapacity()
    {
        Iperson manager = new Manager();
        manager.ChangeBasketCapacity(5);
        Iproduct bagel = new Bagel("bagel ", "BGL", 6.9F, "Onion");
        for (int i = 0; i < 6; i++)
        {
            manager.GetBasket().AddBagel(bagel);
        }
        Assert.That(manager.GetBasket().IsFull(), Is.EqualTo(true));

    }
    [Test]
    public void ItemNotPresent()
    {
        Iperson customer = new Customer();
        Iproduct bagel = new Bagel("bagel ", "BGL", 6.9F, "Onion");
        Assert.Throws<ArgumentException>(() => customer.GetBasket().RemoveBagel(bagel));
    }
    [Test]
    public void GetTotalCost()
    {
        Iperson customer = new Customer();
        Basket basket = customer.GetBasket();
        Iproduct bagel = new Bagel("bagel ", "BGL", 6.9F, "Onion");
        basket.AddBagel(bagel);
        float totalCost = basket.GetTotalCost();
        Assert.That(totalCost, Is.EqualTo(6.9F));

    }
    [Test]
    public void GetCost()
    {
        Iproduct bagel = new Bagel("bagel ", "BGL", 6.9F, "Onion");
        Assert.That(bagel.GetPrice(), Is.EqualTo(6.9F));
    }
    [Test]
    public void AddFilling()
    {
        Iproduct bagel = new Bagel("bagel ", "BGL", 6.9F, "Onion");
        Iproduct filling = new Filling("Filling", "FILC", 0.12F, "Cheese");
        bagel.AddFilling(filling);
        Assert.That(bagel.GetFillings().ElementAt(0), Is.EqualTo(filling));
    }
    [Test]
    public void AvaiableItems()
    { 
        Shop shop = new Shop();
        Iproduct bagel = new Bagel("bagel ", "BGL", 6.9F, "Onion");
        Iproduct filling = new Filling("Filling", "FILC", 0.12F, "Cheese");
        shop.AddToInventory(bagel, 2);
        shop.AddToInventory(filling, 5);
        List<Iproduct> inventory = shop.AvaiableItems();
        Assert.That(inventory.Count(), Is.EqualTo(7));
    }
    [Test]
    public void Discount()
    {
        Shop shop = new Shop();
        Customer customer = new Customer();
        Basket basket = customer.GetBasket();
        Iproduct bagel = new Bagel("bagel ", "BGLO", 6.9F, "Onion");
        Iproduct filling = new Filling("Filling", "FILC", 0.12F, "Cheese");
        List<Iproduct> couponItems = new List<Iproduct>();
        for (int i = 0; i < 6; i++) 
        {
            couponItems.Add(bagel);
        }
        Coupon coupon = new Coupon(couponItems,2.49F);
        shop.AddToInventory(bagel, 2);
        shop.AddToInventory(filling, 5);
        basket.AddBagel(bagel);
        basket.AddCoupon(coupon);
        float total= basket.Discount();
        Assert.That(total, Is.EqualTo(2.49F));

    }
    [Test]
    public void PrintReceipts()
    {
        return;
    }
}