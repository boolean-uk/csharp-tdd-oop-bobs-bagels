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
        var p = new Basket();
        Assert.Pass();
    }
    
    [Test]
    public void addProductToBasket()
    {
        var p = new Basket();

        var b = new Product<Bagel>  ("BGLO", "Onion", 0.49f);
        var h = new Product<Filling>("FILH", "Ham",      0.12f);
        var c = new Product<Filling>("FILC", "Cheese", 0.12f);
        var l = new Product<Filling>("FILE", "Egg",      0.12f);

        p.addProduct(b);
        p.addProduct(h);
        p.addProduct(c);
        p.addProduct(l);
        Assert.Pass();
    }
    [Test]
    public void createDiscountType()
    {
        var p = new Basket();

        
        var b = new Product<Bagel>("BGLO", "Onion", 0.49f);
        var h = new Product<Filling>("FILH", "Ham", 0.12f);
        var c = new Product<Filling>("FILC", "Cheese", 0.12f);
        var l = new Product<Filling>("FILE", "Egg", 0.12f);

        Inventory inventory = new Inventory();
        inventory.Add(b,50);
        inventory.Add(h,50);
        inventory.Add(c,50);
        inventory.Add(l,50);

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
        

        p.addProduct(h);
        totalPrice += h.ProductPrice;
        p.addProduct(c);
        totalPrice += c.ProductPrice;
        p.addProduct(l);
        totalPrice += l.ProductPrice;
        p.addProduct(l);
        totalPrice += l.ProductPrice;

        // Add discounted Products, calculate sum based on the discount
        int nrOf_OnionBagels = 24;
        for (var i = 0; i < nrOf_OnionBagels; i++)
        {
            p.addProduct(b);
        }

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