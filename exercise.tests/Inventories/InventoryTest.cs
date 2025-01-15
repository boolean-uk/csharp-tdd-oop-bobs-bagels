using exercise.main.Baskets;
using exercise.main.Inventories;
using exercise.main.Products;

namespace exercise.tests.Inventories;

[TestFixture]
public class InventoryTest
{
    private Inventory _inventory;

    [SetUp]
    public void SetUp()
    {
        _inventory = Inventory.Instance;  
    }

    [TestCase("BGLO", 0.49, "Bagel", "Onion", typeof(Bagel))]
    [TestCase("BGLP", 0.39, "Bagel", "Plain", typeof(Bagel))]
    [TestCase("BGLE", 0.49, "Bagel", "Everything", typeof(Bagel))]
    [TestCase("BGLS", 0.49, "Bagel", "Sesame", typeof(Bagel))]
    [TestCase("COFB", 0.99, "Coffee", "Black", typeof(Coffee))]
    [TestCase("COFW", 1.19, "Coffee", "White", typeof(Coffee))]
    [TestCase("COFC", 1.29, "Coffee", "Capuccino", typeof(Coffee))]
    [TestCase("COFL", 1.29, "Coffee", "Latte", typeof(Coffee))]
    [TestCase("FILB", 0.12, "Filling", "Bacon", typeof(Filling))]
    [TestCase("FILE", 0.12, "Filling", "Egg", typeof(Filling))]
    [TestCase("FILC", 0.12, "Filling", "Cheese", typeof(Filling))]
    [TestCase("FILX", 0.12, "Filling", "Cream Cheese", typeof(Filling))]
    [TestCase("FILS", 0.12, "Filling", "Smoked Salmon", typeof(Filling))]
    [TestCase("FILH", 0.12, "Filling", "Ham", typeof(Filling))]
    public void IsInStockTestAndPopulate(string sku, double price, string name, string variant, Type productType)
    {
        Assert.That(_inventory.IsInStock((Product) Activator.CreateInstance(productType, sku, price, name, variant)), Is.EqualTo(true));

        Assert.That(_inventory.IsInStock(new Bagel("asd", 0.1, "asd", "asd")), Is.EqualTo(false));
    }

    [TestCase("COFL", 1.29, "Coffee", "Latte", typeof(Coffee))]
    [TestCase("FILB", 0.12, "Filling", "Bacon", typeof(Filling))]
    [TestCase("FILE", 0.12, "Filling", "Egg", typeof(Filling))]
    [TestCase("FILC", 0.12, "Filling", "Cheese", typeof(Filling))]
    public void CheckGetPrice(string sku, double price, string name, string variant, Type productType) 
    {

        Assert.That(_inventory.GetPrice((Product)Activator.CreateInstance(productType, sku, price, name, variant)), Is.EqualTo(price));
    }

    public void CheckGetPriceInvalidItem() 
    {
        Assert.That(_inventory.GetPrice(new Bagel("asd", 0.1, "asd", "asd")), Is.EqualTo(-1d));
    }
    

}