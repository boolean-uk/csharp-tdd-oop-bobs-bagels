using exercise.main.Classes;
using exercise.main.Classes.Products;

namespace exercise.tests.ClassesTests;

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
        Inventory inventory = new Inventory();
        Person person = new("Ola");
        Basket basket = person.GetBasket();
        
        basket.AddProduct("bglo", inventory);
        basket.AddProduct("bglp", inventory);
        
        Order order = new Order(basket, inventory);

        Assert.IsNotNull(order);
        Assert.That(order.GetOrderTotal, Is.EqualTo(0.88M));
    }

    [Test]
    [Category("Order.cs")]
    public void CreateOrderWithFillingsTest()
    {
        Inventory inventory = new Inventory();
        Person person = new("Ola");
        Basket basket = person.GetBasket();

        basket.AddProduct("bglo", inventory);
        basket.AddProduct("bglp", inventory);
        basket.AddProduct("bgle", inventory);
        basket.AddProduct("bgls", inventory);

        Bagel bagel = (Bagel) basket.GetProducts()[0];

        bagel.AddFilling("filb", inventory);
        bagel.AddFilling("file", inventory);
        bagel.AddFilling("filc", inventory);
        bagel.AddFilling("filx", inventory);
        bagel.AddFilling("fils", inventory);
        bagel.AddFilling("filh", inventory);

        Order order = new Order(basket, inventory);

        Assert.That(order.GetOrderTotal, Is.EqualTo(2.58M));
    }

    [Test]
    [Category("Order.cs")]
    public void ApplyDiscounts6BagelsTest()
    {
        Inventory inventory = new Inventory();
        Person person = new("Ola");
        Basket basket = person.GetBasket();
        basket.ChangeCapacity(1000);

        basket.AddProduct("bglo", inventory);
        basket.AddProduct("bglo", inventory);
        basket.AddProduct("bglo", inventory);
        basket.AddProduct("bglo", inventory);
        basket.AddProduct("bglo", inventory);
        basket.AddProduct("bglo", inventory);

        Order order = new Order(basket, inventory);
        Assert.That(order.GetOrderTotal, Is.EqualTo(2.94M));

        order.ApplyDiscounts(basket, inventory);

        Assert.That(order.GetOrderTotal, Is.EqualTo(2.49M));
    }

    [Test]
    [Category("Order.cs")]
    public void ApplyDiscounts12BagelsTest()
    {
        Inventory inventory = new Inventory();
        Person person = new("Ola");
        Basket basket = person.GetBasket();
        basket.ChangeCapacity(1000);

        basket.AddProduct("bglo", inventory);
        basket.AddProduct("bglo", inventory);
        basket.AddProduct("bglo", inventory);
        basket.AddProduct("bglo", inventory);
        basket.AddProduct("bglo", inventory);
        basket.AddProduct("bglo", inventory);
        basket.AddProduct("bglo", inventory);
        basket.AddProduct("bglo", inventory);
        basket.AddProduct("bglo", inventory);
        basket.AddProduct("bglo", inventory);
        basket.AddProduct("bglo", inventory);
        basket.AddProduct("bglo", inventory);

        Order order = new Order(basket, inventory);
        Assert.That(order.GetOrderTotal, Is.EqualTo(5.88M));

        order.ApplyDiscounts(basket, inventory);

        Assert.That(order.GetOrderTotal, Is.EqualTo(3.99M));
    }

    [Test]
    [Category("Order.cs")]
    public void DiscountTest1()
    {
        Inventory inventory = new Inventory();
        Person person = new("Ola");
        Basket basket = person.GetBasket();
        
        basket.AddProduct("BGLO", inventory);
        basket.AddProduct("BGLO", inventory);

        Order order = new Order(basket, inventory);
        Assert.That(order.GetOrderTotal, Is.EqualTo(0.98M));

        order.ApplyDiscounts(basket, inventory);

        Assert.That(order.GetOrderTotal, Is.EqualTo(0.98M));
    }

    [Test]
    [Category("Order.cs")]
    public void DiscountTest2()
    {
        Inventory inventory = new Inventory();
        Person person = new("Ola");
        Basket basket = person.GetBasket();
        basket.ChangeCapacity(12);

        for (int i = 0; i < 12; i++)
        {
            basket.AddProduct("BGLP", inventory);
        }

        Order order = new Order(basket, inventory);
        Assert.That(order.GetOrderTotal, Is.EqualTo(4.68M));

        order.ApplyDiscounts(basket, inventory);

        Assert.That(order.GetOrderTotal, Is.EqualTo(3.99M));
    }

    [Test]
    [Category("Order.cs")]
    public void DiscountTest3()
    {
        Inventory inventory = new Inventory();
        Person person = new("Ola");
        Basket basket = person.GetBasket();
        basket.ChangeCapacity(12);

        for (int i = 0; i < 6; i++)
        {
            basket.AddProduct("BGLE", inventory);
        }

        Order order = new Order(basket, inventory);
        Assert.That(order.GetOrderTotal, Is.EqualTo(2.94M));

        order.ApplyDiscounts(basket, inventory);

        Assert.That(order.GetOrderTotal, Is.EqualTo(2.49M));
    }

    [Test]
    [Category("Order.cs")]
    public void DiscountTest4()
    {
        Inventory inventory = new Inventory();
        Person person = new("Ola");
        Basket basket = person.GetBasket();
        basket.ChangeCapacity(16);

        for (int i = 0; i < 16; i++)
        {
            basket.AddProduct("BGLP", inventory);
        }

        Order order = new Order(basket, inventory);
        Assert.That(order.GetOrderTotal, Is.EqualTo(6.24M));

        order.ApplyDiscounts(basket, inventory);

        Assert.That(order.GetOrderTotal, Is.EqualTo(5.55M));
    }
}
