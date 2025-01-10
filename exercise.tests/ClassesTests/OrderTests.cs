using exercise.main.Classes;
using exercise.main.Classes.Products;

namespace exercise.tests;

public class OrderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [Category("Order.cs")]
    public void CreateOrderTest()
    {
        Person person = new("Ola");
        BagelBasket basket = person.GetBasket();
        
        basket.AddBagel("bglo");
        basket.AddBagel("bglp");
        
        Order order = new Order(basket);

        Assert.IsNotNull(order);
        Assert.That(order.GetOrderTotal, Is.EqualTo(0.88M));
    }

    [Test]
    [Category("Order.cs")]
    public void CreateOrderWithFillingsTest()
    {
        Person person = new("Ola");
        BagelBasket basket = person.GetBasket();

        basket.AddBagel("bglo");
        basket.AddBagel("bglp");
        basket.AddBagel("bgle");
        basket.AddBagel("bgls");

        Bagel bagel = basket.GetBagels()[0];

        bagel.AddFilling("filb");
        bagel.AddFilling("file");
        bagel.AddFilling("filc");
        bagel.AddFilling("filx");
        bagel.AddFilling("fils");
        bagel.AddFilling("filh");

        Order order = new Order(basket);

        Assert.That(order.GetOrderTotal, Is.EqualTo(2.58M));
    }

    [Test]
    [Category("Order.cs")]
    public void ApplyDiscounts6BagelsTest()
    {
        Person person = new("Ola");
        BagelBasket basket = person.GetBasket();
        basket.ChangeCapacity(1000);

        basket.AddBagel("bglo");
        basket.AddBagel("bglo");
        basket.AddBagel("bglo");
        basket.AddBagel("bglo");
        basket.AddBagel("bglo");
        basket.AddBagel("bglo");

        Order order = new Order(basket);
        Assert.That(order.GetOrderTotal, Is.EqualTo(2.94M));

        order.ApplyDiscounts();

        Assert.That(order.GetOrderTotal, Is.EqualTo(2.49M));
    }

    [Test]
    [Category("Order.cs")]
    public void ApplyDiscounts12BagelsTest()
    {
        Person person = new("Ola");
        BagelBasket basket = person.GetBasket();
        basket.ChangeCapacity(1000);

        basket.AddBagel("bglo");
        basket.AddBagel("bglo");
        basket.AddBagel("bglo");
        basket.AddBagel("bglo");
        basket.AddBagel("bglo");
        basket.AddBagel("bglo");
        basket.AddBagel("bglo");
        basket.AddBagel("bglo");
        basket.AddBagel("bglo");
        basket.AddBagel("bglo");
        basket.AddBagel("bglo");
        basket.AddBagel("bglo");

        Order order = new Order(basket);
        Assert.That(order.GetOrderTotal, Is.EqualTo(5.88M));

        order.ApplyDiscounts();

        Assert.That(order.GetOrderTotal, Is.EqualTo(3.99M));
    }
}
