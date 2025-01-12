using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using exercise.main;
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

        //for (var i = 0; i < 6; i++)
        for (var i = 0; i < 24; i++)
        {
            p.addProduct(b);
        }
        p.addProduct(h);
        p.addProduct(c);
        p.addProduct(l);
        p.addProduct(l);


        //var d = new Discount_XforY<Bagel>();
        var discountReq = new Dictionary<string, int> { { "BGLO" ,  6} };
        var d = new Discount_XforY(discountReq, 2.49f);

        

        //Func<int, int> lambda = x => {
        //    return x;
        //};

        //Action lambda =( ) => {
        //    return 3;
        //};

        //d.defineCondition(lambda);

        DiscountManager dm = new DiscountManager();

        dm.addDiscountType(d);


        //Order o = dm.calculateDiscount(p);
        dm.calculateDiscount(p);



        Assert.Pass();
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