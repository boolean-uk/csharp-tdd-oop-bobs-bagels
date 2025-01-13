using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using exercise.main;
using NUnit.Framework.Constraints;
namespace exercise.tests;

public class Tests
{

    [Test]
    public void CreateBasket()
    {
        Inventory inventory = new Inventory();
        var p = new Basket(inventory);
        Assert.Pass();
    }
    
    [Test]
    public void addProductToBasket()
    {
        Inventory inventory = new Inventory();
        var p = new Basket(inventory);

        inventory.Add("BGLO", "Onion", 0.49f, 100);
        inventory.Add("FILH", "Ham",      0.12f, 100);
        inventory.Add("FILC", "Cheese", 0.12f, 100);
        inventory.Add("FILE", "Egg", 0.12f, 100);

        //var b = new Product("BGLO", "Onion", 0.49f);
        //var h = new Product("FILH", "Ham",      0.12f);
        //var c = new Product("FILC", "Cheese", 0.12f);
        //var l = new Product("FILE", "Egg",      0.12f);

        //p.addProduct(b);
        //p.addProduct(h);
        //p.addProduct(c);
        //p.addProduct(l);
        p.addProduct("BGLO");
        p.addProduct("FILH");
        p.addProduct("FILC");
        p.addProduct("FILE");
        Assert.Pass();
    }
    [Test]
    public void createDiscountType()
    {
        Inventory inventory = new Inventory();
        var p = new Basket(inventory);

        
        //var b = new Product("BGLO", "Onion", 0.49f);
        //var h = new Product("FILH", "Ham", 0.12f);
        //var c = new Product("FILC", "Cheese", 0.12f);
        //var l = new Product("FILE", "Egg", 0.12f);

        //inventory.Add(b,50);
        //inventory.Add(h,50);
        //inventory.Add(c,50);
        //inventory.Add(l,50);
        inventory.Add("BGLO", "Onion", 0.49f, 50);
        inventory.Add("FILH", "Ham", 0.12f, 50);
        inventory.Add("FILC", "Cheese", 0.12f, 50);
        inventory.Add("FILE", "Egg", 0.12f,  50);

        // Create Discount deal, 6 BGLOO, for 2.49f 
        int nrOfBagelsForDiscount = 6;
        float discountedPrice_6_for_2_49 = 2.49f;
        var discountReq = new Dictionary<string, int> { { "BGLO" , nrOfBagelsForDiscount } };
        var d = new Discount_XforY(discountReq, discountedPrice_6_for_2_49, inventory);

        // Add deal to DiscountManager
        DiscountManager dm = new DiscountManager(inventory);
        dm.addDiscountType(d);

        // Add non-discounted Products, calculate the total
        float totalPrice = 0.0f;
        

        p.addProduct("FILH");
        totalPrice += inventory.getPrice("FILH");
        p.addProduct("FILC");
        totalPrice += inventory.getPrice("FILC");
        p.addProduct("FILE");
        totalPrice += inventory.getPrice("FILE");
        p.addProduct("FILE");
        totalPrice += inventory.getPrice("FILE");

        // Add discounted Products, calculate sum based on the discount
        int nrOf_OnionBagels = 24;
        p.addProduct("BGLO", nrOf_OnionBagels);
        //for (var i = 0; i < nrOf_OnionBagels; i++)
        //{
        //    //p.addProduct(b);
        //    p.addProduct("BGLO");
        //}

        totalPrice += MathF.Floor((float)nrOf_OnionBagels / nrOfBagelsForDiscount) * discountedPrice_6_for_2_49;
        
        // calculate Rest 
        totalPrice += ((float)nrOf_OnionBagels % nrOfBagelsForDiscount) * discountedPrice_6_for_2_49;


        //Order o = dm.calculateDiscount(p);
        var orderDataDict = dm.calculateDiscount(p);

        var returnedTotal= orderDataDict.Values.Sum(x => x.total_price);

        Assert.That(totalPrice, Is.EqualTo(returnedTotal));

    }
    [Test]
    public void createInventory()
    {

        Inventory inventory = new Inventory();
        Assert.Pass();

    }
    [Test]
    public void inventory_add()
    {

        Inventory inventory = new Inventory();
        inventory.Add("BGLO", "Onion", 0.49f, 10);

        Assert.That(inventory.getStock("BGLO"), Is.EqualTo(10));
        Assert.That(inventory.getName("BGLO"), Is.EqualTo("Onion"));
        Assert.That(inventory.getPrice("BGLO"), Is.EqualTo(0.49f));

    }

        //[TestCase("Onion", 2.5f)]
        //public void CreateProduct(string productName, float productPrice)
        //{
        //    var p = new Product<Bagel>(productName, productPrice);
        //    Assert.Pass();
        //}

        //[TestCase("Bread", 2.5f)]
        //public void CreateProduct_withSubProducts(string productName, float productPrice, params Tuple<string, float>[]  subProducts)
        //{

        //    var products = new List<BaseProduct>()
        //    {
        //        new Product<Filling>("Ham", 0.5f),
        //        new Product<Filling>("Cheese", 0.5f),
        //        new Product<Filling>("Lettuce", 0.5f),
        //    };

        //    var p = new Product<Bagel>(productName, productPrice, products);


        //    Assert.Pass();
        //}

        //[TestCase("Bread", 2.5f)]
        //public void CreateProduct_withSubProducts_getPrice(string productName, float productPrice)
        //{

        //    var products = new List<BaseProduct>()
        //    {
        //        new Product<Filling>("Ham", 0.5f),
        //        new Product<Filling>("Cheese", 0.5f),
        //        new Product<Filling>("Lettuce", 0.5f),
        //    };

        //    var expectedCost = products.Sum(p => p.CombinedPrice) + productPrice;

        //    var p = new Product<Bagel>(productName, productPrice, products);


        //    Assert.That( p.CombinedPrice == expectedCost);
        //}
    }