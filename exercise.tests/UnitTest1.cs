namespace exercise.tests;
using exercise.main;

public class Tests
{
  
    [Test]
    public void Test1()
    {
        Basket basket = new Basket();
        bool addTest = basket.addItem("BGLO");

        Assert.IsTrue(addTest);

    }
    [Test]
    public void Test2()
    {
        Basket basket = new Basket();
        basket.addItem("BGLO");
        bool remTest = basket.removeItem(0);
        Assert.IsTrue(remTest);
    }
    [Test]
    public void Test3()
    {
        Basket basket = new Basket();
        basket.addItem("BGLO");
        basket.changeMaxCap(1);
        bool addTest = basket.addItem("BGLP");
        
        Assert.IsFalse(addTest);
    }
    [Test]
    public void Test4()
    {
        Basket basket = new Basket();
        bool remTest = basket.removeItem(0);
        Assert.IsFalse (remTest);
    }
    [Test]
    public void Test5()
    {
        Basket basket = new Basket();
        basket.addItem("BGLO");
        Assert.IsTrue(basket.totalCost() == 0.49f);
    }
    [Test]
    public void Test6()
    {
        Basket basket = new Basket();
        Assert.IsTrue(basket.itemPrice("BGLO") == 0.49f);

    }
    [Test]
    public void Test7()
    {
        Basket basket = new Basket();
        basket.addItem("BGLO");
        basket.addItem("BGLP");
        Assert.IsTrue(basket.totalCost() == 0.88f);
    }
    [Test]
    public void Test8()
    {
        Basket basket = new Basket();
        basket.addItem("BGLO");
        bool addFillTest = basket.addFilling(0, "FILB");
        Assert.IsTrue(addFillTest);

    }
    [Test]
    public void Test9()
    {
        Basket basket = new Basket();
        bool addTest = basket.addItem("ABCF");
        Assert.IsFalse(addTest);
    }
    [Test]
    public void Test10()
    {
        Basket basket = new Basket();
        List<string> listTest = basket.listFillings();

        Assert.IsTrue(listTest[0] == "Bacon,0.12");
        Assert.IsTrue(listTest[1] == "Egg,0.12");
        Assert.IsTrue(listTest[2] == "Cheese,0.12");
        Assert.IsTrue(listTest[3] == "Cream Cheese,0.12");
        Assert.IsTrue(listTest[4] == "Smoked Salmon,0.12");
        Assert.IsTrue(listTest[5] == "Ham,0.12");

    }


}