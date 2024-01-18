using exercise.main;

namespace exercise.tests;

public class MenuTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void getItemTest()
    {
        Menu menu = new Menu();

        var result = menu.getItem("");
        var result1 = menu.getItem("BGLO");
        var result2 = menu.getItem("COFC");
        Assert.AreEqual(0.00, result.Item1);
        Assert.AreEqual(string.Empty, result.Item2);
        Assert.AreEqual(string.Empty, result.Item3);
        Assert.AreEqual(0.49, result1.Item1);
        Assert.AreEqual("Bagel", result1.Item2);
        Assert.AreEqual("Onion", result1.Item3);
        Assert.AreEqual(1.29, result2.Item1);
        Assert.AreEqual("Coffee", result2.Item2);
        Assert.AreEqual("Capuccino", result2.Item3);
    }
}