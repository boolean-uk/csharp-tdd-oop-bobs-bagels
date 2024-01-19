using System.Linq;
using System.Security.Cryptography.X509Certificates;
using exercise.main.Inventory;



namespace exercise.tests;

public class Tests
{


    [Test]

    public void FirstTest()
    {
        Basket basket = new Basket(20);
        Item bagel = BobsInventory.Inventory.Where(bagel._SKU = "BGLP");

        basket.AddItem(bagel);


    }
}