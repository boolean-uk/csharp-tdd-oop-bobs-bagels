using System.Diagnostics.Tracing;
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
        float expectedDiscount = 2.49F;
        Shop shop = new Shop();
        Customer customer = new Customer();
        Basket basket = customer.GetBasket();
        Iproduct bagel = new Bagel("bagel ", "BGLO", 0.49F, "Onion");
        Iproduct filling = new Filling("Filling", "FILC", 0.12F, "Cheese");
        List<Iproduct> discountedItems = new List<Iproduct>();

        for (int i = 0; i < 6; i++) 
        {
            discountedItems.Add(bagel);
   
        }
        basket.AddBagel(bagel);
        Coupon coupon = new Coupon(discountedItems,2.49F);
        shop.AddToInventory(bagel, 2);
        shop.AddToInventory(filling, 5);

        basket.AddCoupon(coupon);
        float total= basket.Discount();
        Assert.That(total, Is.EqualTo(bagel.GetPrice())); 
    }
    [Test]
    public void Discount2()
    {
        float expectedDiscount = 2.49F;
        Shop shop = new Shop();
        Customer customer = new Customer();
        Basket basket = customer.GetBasket();
        Iproduct bagel = new Bagel("bagel ", "BGLO", 0.49F, "Onion");
        Iproduct filling = new Filling("Filling", "FILC", 0.12F, "Cheese");
        List<Iproduct> discountedItems = new List<Iproduct>();

        for (int i = 0; i < 6; i++)
        {
            discountedItems.Add(bagel);
            basket.AddBagel(bagel);
        }
 
        Coupon coupon = new Coupon(discountedItems, 2.49F);
        shop.AddToInventory(bagel, 6);
        shop.AddToInventory(filling, 5);
        basket.AddBagel(bagel);//7 bagels, 6 is dicounted + 1 not discounted
        basket.AddCoupon(coupon);
        float total = basket.Discount();
        Assert.That(total, Is.EqualTo(expectedDiscount ));

    }
    [Test]
    public void PrintReceipts()
    {
        Iperson customer = new Customer();
        Basket basket = customer.GetBasket();
        Iproduct bagel = new Bagel("bagel ", "BGL", 6.9F, "Onion");
        Iproduct bagel2 = new Bagel("bagel ", "BGL", 6.9F, "Onion");
        Iproduct bagel3 = new Bagel("bagel ", "BGL", 6.9F, "Onion");
        basket.AddBagel(bagel);
        basket.AddBagel(bagel2);
        basket.AddBagel(bagel3);
        basket.PrintReceipt();
    }
}