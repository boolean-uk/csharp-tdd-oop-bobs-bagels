namespace exercise.tests;
using exercise.main;
public class Tests
{


    [Test]
    public void addItemTest()
    {
        Inventory inventory = new Inventory();

        bool expected = true;

        bool result = inventory.isAvaiable("BGLO");

        Assert.That(expected ==  result);
        

        Assert.Pass();
    }
}