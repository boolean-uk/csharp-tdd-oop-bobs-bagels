using basket.main;

namespace basket.tests;


public class TestsBasket
{
    private Basket _basket;
    private List<string> _bagelsInBasket;

    [SetUp]
    public void Setup()
    {
        // for each test a new Basket() will be created
        _basket = new Basket(5);
        _bagelsInBasket = new List<string>();
        // bagel is added to each test.
        _basket.AddBagelToBasket("Spelt Bagel");
        _basket.AddBagelToBasket("Sesame salmon Bagel");
        _basket.AddBagelToBasket("Whole wheat Bagel");
        _basket.AddBagelToBasket("Avocado Bagel");
        _basket.AddBagelToBasket("Hummus Bagel");
    }


    [Test]
    public void TestAddBagelToBasket()
    {
        // setup is done in global setup
        // execute the actual function to test
        bool addedBagel = _basket.AddBagelToBasket("Vegan Bagel");
        //int itemsInBasket = _bagelsInBasket.Count;  
        // Assert test, whether execution is successful ( -> check if results / outputs are ok)
        Assert.That(addedBagel, Is.True);
        Assert.That(_basket, Is.Not.Null);
        // try to see that basket contains 2 items now

    }

}