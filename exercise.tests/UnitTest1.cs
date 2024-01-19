namespace exercise.tests;
using exercise.main;

[TestFixture]
public class Tests
{

    [Test]
    public void AddTest()
    {
        Basket basket = new Basket();
        Inventory inventory = new Inventory();
        Product bagel = inventory.Products[0];

        
        basket.Add(bagel);

        
        Assert.AreEqual(1, basket.Items.Count);
        Assert.IsTrue(basket.Items.ContainsKey(bagel.SKU));
    }


    [Test]
    public void RemoveTest()
    {
        Basket basket = new Basket();
        Inventory inventory = new Inventory();
        Product bagel = inventory.Products[0];
        Product coffee = inventory.Products[1];

        basket.Add(coffee);
        basket.Add(bagel);

        basket.Remove(bagel.SKU);
        basket.Remove(coffee.SKU);
        Assert.That(basket.Items.Count, Is.EqualTo(0));
    }
    [Test]
    public void Testfull()
    {

        Basket basket = new Basket();
        Inventory inventory = new Inventory();
        Product bagel = inventory.Products[0];
        Product bagel2 = inventory.Products[1];
        Product bagel3 = inventory.Products[2];
      
        Assert.Throws<Exception>(() =>
        {
            basket.Add(bagel);
            basket.Add(bagel2);
            basket.Add(bagel2);
            basket.Add(bagel2);
            basket.Add(bagel2);
            basket.Add(bagel3);
            basket.Add(bagel3);
            basket.Add(bagel3);
            basket.Add(bagel3);
            basket.Add(bagel3);
            basket.Add(bagel3);
            basket.Add(bagel3);
            basket.Add(bagel3);
            basket.Add(bagel3);
            basket.Add(bagel3);
            basket.Add(bagel3);
            basket.Add(bagel3);
            basket.Add(bagel3);
            basket.Add(bagel3);
            basket.Add(bagel3);
            basket.Add(bagel3);

        });
    }
    [Test]
    public void TestRemoveError()
    {
        Basket basket = new Basket();
        Inventory inventory = new Inventory();
        Product coffee = inventory.Products[2];

       
        Assert.Throws<Exception>(() => basket.Remove(coffee.SKU));
    }
        [Test]
    public void IncreaseCapacityTest()
    {
        Basket basket = new Basket();
        Inventory inventory = new Inventory();
        Product bagel = inventory.Products[0];
        Product coffee = inventory.Products[2];
        Product bagel2 = inventory.Products[1];

        basket.Add(bagel);
        basket.Add(bagel2);
        basket.Add(bagel2);
        basket.Add(bagel2);
        basket.Add(bagel2);
        basket.Add(bagel2);
        basket.Add(bagel2);
        basket.Add(bagel2);
        basket.Add(bagel2);
        basket.Add(bagel2);
        basket.Add(bagel2);
        basket.Add(bagel2);
        basket.Add(bagel2);
        basket.Add(bagel2);
        basket.Add(bagel2);

        int initialItemCount = basket.Items.Count;  

        basket.IncreaseCapacity();
        basket.Add(coffee);

        Assert.That(basket.Items.Count, Is.EqualTo(initialItemCount + 1));

    }
    [Test]
    public void GetTotalCostTest_CustomOrder()
    {
        Inventory inventory = new Inventory();
        Basket basket = new Basket();

        for (int i = 0; i < 2; i++)
        {
            basket.Add(inventory.Products.First(p => p.SKU == "BGLO"));
        }

        for (int i = 0; i < 12; i++)
        {
            basket.Add(inventory.Products.First(p => p.SKU == "BGLP"));
        }


        for (int i = 0; i < 6; i++)
        {
            basket.Add(inventory.Products.First(p => p.SKU == "BGLE"));
        }

        for (int i = 0; i < 3; i++)
        {
            basket.Add(inventory.Products.First(p => p.SKU == "COFB"));
        }

        
        decimal totalCost = basket.GetTotalCost(inventory);

       
        Assert.AreEqual(11.21m, totalCost);
    }
}