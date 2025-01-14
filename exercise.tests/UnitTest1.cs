using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using exercise.main;
using exercise.main.Discount;
using NUnit.Framework.Constraints;
using System.Reflection;

namespace exercise.tests;

public class Tests
{

    [Test]
    public void CreateBasket()
    {
        Inventory inventory = new Inventory();
        DiscountManager dm = new DiscountManager(inventory); 
        var p = new Basket(inventory, dm);
        Assert.Pass();
    }
    
    [Test]
    public void addProductToBasket()
    {
        Inventory inventory = new Inventory();
        DiscountManager dm = new DiscountManager(inventory);
        var b = new Basket(inventory, dm);

        inventory.Add("BGLO", "Onion", 0.49f, 100);
        inventory.Add("FILH", "Ham",      0.12f, 100);
        inventory.Add("FILC", "Cheese", 0.12f, 100);
        inventory.Add("FILE", "Egg", 0.12f, 100);

        b.addProduct("BGLO");
        b.addProduct("FILH");
        b.addProduct("FILC");
        b.addProduct("FILE");

        var productsInBasket = b.getAmountPerSku();
        Assert.That(productsInBasket.ContainsKey("BGLO"));
        Assert.That(productsInBasket.ContainsKey("FILH"));
        Assert.That(productsInBasket.ContainsKey("FILC"));
        Assert.That(productsInBasket.ContainsKey("FILE"));
        Assert.Pass();
    }
    [Test]
    public void basket_capacityLimitsAdding()
    {
        Inventory inventory = new Inventory();
        DiscountManager dm = new DiscountManager(inventory);
        var b = new Basket(inventory, dm, 3);

        inventory.Add("BGLO", "Onion", 0.49f, 100);
        inventory.Add("FILH", "Ham",      0.12f, 100);
        inventory.Add("FILC", "Cheese", 0.12f, 100);
        inventory.Add("FILE", "Egg", 0.12f, 100);

        b.addProduct("BGLO");
        b.addProduct("FILH");
        b.addProduct("FILC");
        b.addProduct("FILE"); // Should not be added

        var productsInBasket = b.getAmountPerSku();
        Assert.That(!productsInBasket.ContainsKey("FILE")); // Should not contain 
    }
    [Test]
    public void basket_changeCapacity_decrease()
    {
        Inventory inventory = new Inventory();
        DiscountManager dm = new DiscountManager(inventory);
        var b = new Basket(inventory, dm, 3);

        inventory.Add("BGLO", "Onion", 0.49f, 100);
        inventory.Add("FILH", "Ham",      0.12f, 100);
        inventory.Add("FILC", "Cheese", 0.12f, 100);
        inventory.Add("FILE", "Egg", 0.12f, 100);

        b.addProduct("BGLO");
        b.addProduct("FILH");
        b.addProduct("FILC");
        b.addProduct("FILE"); // Should not be added

        var productsInBasket = b.getAmountPerSku();
        Assert.That(!productsInBasket.ContainsKey("FILE")); // Should not contain 

        b.setCapacity(2); // Should remove FILC
        productsInBasket = b.getAmountPerSku();
        Assert.That(!productsInBasket.ContainsKey("FILC")); // Should not contain 

    }[Test]
    public void basket_changeCapacity_increase()
    {
        Inventory inventory = new Inventory();
        DiscountManager dm = new DiscountManager(inventory);
        var b = new Basket(inventory, dm, 3);

        inventory.Add("BGLO", "Onion", 0.49f, 100);
        inventory.Add("FILH", "Ham",      0.12f, 100);
        inventory.Add("FILC", "Cheese", 0.12f, 100);
        inventory.Add("FILE", "Egg", 0.12f, 100);

        b.addProduct("BGLO");
        b.addProduct("FILH");
        b.addProduct("FILC");
        b.addProduct("FILE"); // Should not be added

        var productsInBasket = b.getAmountPerSku();
        Assert.That(!productsInBasket.ContainsKey("FILE")); // Should not contain 

        b.setCapacity(4); // Should remove FILC
        b.addProduct("FILE"); // Should not be added
        productsInBasket = b.getAmountPerSku();
        Assert.That(productsInBasket.ContainsKey("FILE")); // Should contain 

    }
    
    [Test]
    public void removeProductFromBasket()
    {
        Inventory inventory = new Inventory();
        DiscountManager dm = new DiscountManager(inventory);
        var b = new Basket(inventory, dm, 300);

        inventory.Add("BGLO", "Onion", 0.49f, 100);
        inventory.Add("BGLS", "Sesame", 0.49f, 100);
        inventory.Add("FILH", "Ham",      0.12f, 100);
        inventory.Add("FILC", "Cheese", 0.12f, 100);
        inventory.Add("FILE", "Egg", 0.12f, 100);

        b.addProduct("BGLO",30);
        b.addProduct("FILH",25);
        b.addProduct("BGLS", 25);
        b.addProduct("FILC",20);
        b.addProduct("FILE",10);

        Assert.That(b.removeProduct("FILC", 20) == true);
        Assert.That(b.removeProduct("BGLS", 5) == true);
        Assert.That(b.removeProduct("FILH", 100) == true);

        var productsInBasket = b.getAmountPerSku();
        Assert.That(productsInBasket["BGLO"] == 30);
        Assert.That(productsInBasket.ContainsKey("FILH") == false);
        Assert.That(productsInBasket["BGLS"] == 20);
        Assert.That(productsInBasket.ContainsKey("FILC") == false);
        Assert.That(productsInBasket["FILE"] == 10);

    }
    [Test]
    public void removeProductThatDoesNotExist_fromBasket()
    {
        Inventory inventory = new Inventory();
        DiscountManager dm = new DiscountManager(inventory);
        var b = new Basket(inventory, dm);

        inventory.Add("BGLO", "Onion", 0.49f, 100);
        inventory.Add("BGLS", "Sesame", 0.49f, 100);
        inventory.Add("FILH", "Ham",      0.12f, 100);
        inventory.Add("FILC", "Cheese", 0.12f, 100);
        inventory.Add("FILE", "Egg", 0.12f, 100);

        b.addProduct("BGLO",30);
        b.addProduct("FILH",25);
        b.addProduct("BGLS", 25);
        b.addProduct("FILC",20);

        Assert.That(b.removeProduct("FILE", 1) == false);

    }
    
    [Test]
    public void getTotalFromBasket()
    {
        Inventory inventory = new Inventory();
        DiscountManager dm = new DiscountManager(inventory);
        var b = new Basket(inventory, dm);

        inventory.Add("BGLO", "Onion", 0.49f, 100);
        inventory.Add("BGLS", "Sesame", 0.49f, 100);
        inventory.Add("FILH", "Ham",      0.12f, 100);
        inventory.Add("FILC", "Cheese", 0.12f, 100);
        inventory.Add("FILE", "Egg", 0.12f, 100);

        b.addProduct("BGLO",1);
        b.addProduct("FILH",1);
        b.addProduct("FILC",1);

        
        Assert.That(b.getTotal() == 0.49f + 0.12f + 0.12f);

    }
    [Test]
    public void addToBasket_itemWithZeroInStock()
    {
        Inventory inventory = new Inventory();
        DiscountManager dm = new DiscountManager(inventory);
        var b = new Basket(inventory, dm);

        inventory.Add("BGLO", "Onion", 0.49f, 0);
        inventory.Add("BGLS", "Sesame", 0.49f, 100);
        inventory.Add("FILH", "Ham",      0.12f, 100);
        inventory.Add("FILC", "Cheese", 0.12f, 100);
        inventory.Add("FILE", "Egg", 0.12f, 100);

        b.addProduct("BGLO",1);

        var prods = b.getProducts();

        Assert.That(prods.Count == 0);
    }
    [Test]
    public void addToBasket_ItemDoesNotExistInInventory()
    {
        Inventory inventory = new Inventory();
        DiscountManager dm = new DiscountManager(inventory);
        var b = new Basket(inventory, dm);

        inventory.Add("BGLO", "Onion", 0.49f, 0);
        inventory.Add("BGLS", "Sesame", 0.49f, 100);
        inventory.Add("FILH", "Ham",      0.12f, 100);
        inventory.Add("FILC", "Cheese", 0.12f, 100);
        inventory.Add("FILE", "Egg", 0.12f, 100);

        b.addProduct("COFB",1);

        var prods = b.getProducts();

        Assert.That(prods.Count == 0);
    }
    [Test]
    public void createDiscountType()
    {
        Inventory inventory = new Inventory();
        DiscountManager dm = new DiscountManager(inventory);
        var p = new Basket(inventory, dm, 50);

        inventory.Add("BGLO", "Onion", 0.49f, 50);
        inventory.Add("COFB", "Black", 0.99f, 100);
        inventory.Add("FILH", "Ham", 0.12f, 50);
        inventory.Add("FILC", "Cheese", 0.12f, 50);
        inventory.Add("FILE", "Egg", 0.12f,  50);

        // Create Discount deal, 6 BGLOO, for 2.49f 
        int nrOfBagelsForDiscount = 6;
        float discountedPrice_6_for_2_49 = 2.49f;
        var discountReq = new Dictionary<string, int> { { "BGLO" , nrOfBagelsForDiscount } };
        var d = new Discount_XforY(discountReq, discountedPrice_6_for_2_49, inventory);

        // Add deal to DiscountManager
        //DiscountManager dm = new DiscountManager(inventory);
        dm.addDiscountType(d);

        // Add non-discounted Products, calculate the total
        float totalPrice = 0.0f;
        

        p.addProduct("COFB");
        totalPrice += inventory.getPrice("COFB");
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

        totalPrice += MathF.Floor((float)nrOf_OnionBagels / nrOfBagelsForDiscount) * discountedPrice_6_for_2_49;
        
        // calculate Rest 
        totalPrice += ((float)nrOf_OnionBagels % nrOfBagelsForDiscount) * discountedPrice_6_for_2_49;


        //Order o = dm.calculateDiscount(p);
        var orderDataDict = dm.calculateTotalWithDiscount(p);

        var returnedTotal= orderDataDict.Values.Sum(x => x.total_price);

        Assert.That(totalPrice, Is.EqualTo(returnedTotal));

    }
    [Test]
    public void multipleDiscountsAreAppliedCorrectly_onlyBuyOneDeal()
    {
        Inventory inventory = new Inventory();
        DiscountManager dm = new DiscountManager(inventory);
        var p = new Basket(inventory, dm, 50);

        inventory.Add("BGLO", "Onion", 0.49f, 50);
        inventory.Add("COFB", "Black", 0.99f, 100);
        inventory.Add("FILH", "Ham", 0.12f, 50);
        inventory.Add("FILC", "Cheese", 0.12f, 50);
        inventory.Add("FILE", "Egg", 0.12f,  50);

        // Create Discount deal, 6 BGLOO, for 2.49f 
        int nrOfBagelsForDiscount = 6;
        float discountedPrice_6_for_2_49 = 2.49f;
        var discountReq = new Dictionary<string, int> { { "BGLO" , nrOfBagelsForDiscount } };
        var d = new Discount_XforY(discountReq, discountedPrice_6_for_2_49, inventory);

        var discountReq_2 = new Dictionary<string, int> { { "BGLO", 1 }, { "COFB", 1 } };
        var d2 = new Discount_XforY(discountReq_2, 1.25f, inventory);

        var discountReq_3 = new Dictionary<string, int> { { "BGLP", 12 } };
        var d3 = new Discount_XforY(discountReq_3, 3.99f, inventory);

        var discountReq_4 = new Dictionary<string, int> { { "BGLE", 6 } };
        var d4 = new Discount_XforY(discountReq_4, 2.49f, inventory);

        // Add deal to DiscountManager
        //DiscountManager dm = new DiscountManager(inventory);
        dm.addDiscountType(d);
        dm.addDiscountType(d2);
        dm.addDiscountType(d3);
        dm.addDiscountType(d4);

        // Add non-discounted Products, calculate the total
        float totalPrice = 0.0f;
        

        // Add discounted Products, calculate sum based on the discount
        int nrOf_OnionBagels = 24;
        p.addProduct("BGLO", nrOf_OnionBagels);

        totalPrice += MathF.Floor((float)nrOf_OnionBagels / nrOfBagelsForDiscount) * discountedPrice_6_for_2_49;
        
        // calculate Rest 
        totalPrice += ((float)nrOf_OnionBagels % nrOfBagelsForDiscount) * discountedPrice_6_for_2_49;


        //Order o = dm.calculateDiscount(p);
        var orderDataDict = dm.calculateTotalWithDiscount(p);

        var returnedTotal= orderDataDict.Values.Sum(x => x.total_price);

        Assert.That(totalPrice, Is.EqualTo(returnedTotal));

    }
    [Test]
    public void multipleDiscountsAreAppliedCorrectly_buyDealAndOther()
    {
        Inventory inventory = new Inventory();
        DiscountManager dm = new DiscountManager(inventory);
        var p = new Basket(inventory, dm, 50);

        inventory.Add("BGLO", "Onion", 0.49f, 50);
        inventory.Add("COFB", "Black", 0.99f, 100);
        inventory.Add("FILH", "Ham", 0.12f, 50);
        inventory.Add("FILC", "Cheese", 0.12f, 50);
        inventory.Add("FILE", "Egg", 0.12f,  50);

        // Create Discount deal, 6 BGLOO, for 2.49f 
        int nrOfBagelsForDiscount = 6;
        float discountedPrice_6_for_2_49 = 2.49f;
        var discountReq = new Dictionary<string, int> { { "BGLO" , nrOfBagelsForDiscount } };
        var d = new Discount_XforY(discountReq, discountedPrice_6_for_2_49, inventory);

        var discountReq_2 = new Dictionary<string, int> { { "BGLO", 1 }, { "COFB", 1 } };
        var d2 = new Discount_XforY(discountReq_2, 1.25f, inventory);

        var discountReq_3 = new Dictionary<string, int> { { "BGLP", 12 } };
        var d3 = new Discount_XforY(discountReq_3, 3.99f, inventory);

        var discountReq_4 = new Dictionary<string, int> { { "BGLE", 6 } };
        var d4 = new Discount_XforY(discountReq_4, 2.49f, inventory);

        // Add deal to DiscountManager
        //DiscountManager dm = new DiscountManager(inventory);
        dm.addDiscountType(d);
        dm.addDiscountType(d2);
        dm.addDiscountType(d3);
        dm.addDiscountType(d4);

        // Add non-discounted Products, calculate the total
        float totalPrice = 0.0f;


        //p.addProduct("COFB");
        //totalPrice += inventory.getPrice("COFB");
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

        totalPrice += MathF.Floor((float)nrOf_OnionBagels / nrOfBagelsForDiscount) * discountedPrice_6_for_2_49;
        
        // calculate Rest 
        totalPrice += ((float)nrOf_OnionBagels % nrOfBagelsForDiscount) * discountedPrice_6_for_2_49;


        //Order o = dm.calculateDiscount(p);
        var orderDataDict = dm.calculateTotalWithDiscount(p);

        var returnedTotal= orderDataDict.Values.Sum(x => x.total_price);

        Assert.That(totalPrice, Is.EqualTo(returnedTotal));

    }

    [Test]
    public void discountManager_pickTheOneDealAvailable()
    {
        Inventory inventory = new Inventory();
        DiscountManager dm = new DiscountManager(inventory);
        var b = new Basket(inventory, dm, 100);

        inventory.Add("BGLO", "Onion", 0.49f, 50);
        inventory.Add("COFB", "Black", 0.99f, 100);
        inventory.Add("FILH", "Ham", 0.12f, 50);
        inventory.Add("FILC", "Cheese", 0.12f, 50);
        inventory.Add("FILE", "Egg", 0.12f,  50);

        // Create Discount deal, 6 BGLOO, for 2.49f 
        int nrOfBagelsForDiscount = 6;
        float discountedPrice_6_for_2_49 = 2.49f;
        var discountReq = new Dictionary<string, int> { { "BGLO" , nrOfBagelsForDiscount } };
        var d = new Discount_XforY(discountReq, discountedPrice_6_for_2_49, inventory);

        var discountReq_2 = new Dictionary<string, int> { { "BGLO", 1 }, { "COFB", 1 } };
        var d2 = new Discount_XforY(discountReq_2, 1.25f, inventory);

        var discountReq_3 = new Dictionary<string, int> { { "BGLP", 12 } };
        var d3 = new Discount_XforY(discountReq_3, 3.99f, inventory);

        var discountReq_4 = new Dictionary<string, int> { { "BGLE", 6 } };
        var d4 = new Discount_XforY(discountReq_4, 2.49f, inventory);

        // Add deal to DiscountManager
        //DiscountManager dm = new DiscountManager(inventory);
        dm.addDiscountType(d);
        dm.addDiscountType(d2);
        dm.addDiscountType(d3);
        dm.addDiscountType(d4);

        // Add non-discounted Products, calculate the total
        float totalPrice = 0.0f;
        

        // Add discounted Products, calculate sum based on the discount
        int nrOf_OnionBagels = 6;
        b.addProduct("BGLO", nrOf_OnionBagels);

        totalPrice += MathF.Floor((float)nrOf_OnionBagels / nrOfBagelsForDiscount) * discountedPrice_6_for_2_49;
        
        // calculate Rest 
        totalPrice += ((float)nrOf_OnionBagels % nrOfBagelsForDiscount) * discountedPrice_6_for_2_49;

        // Expect to pick 6 bagels for 2.49, over coffe+bagel for 1.25

        Type dm_type = dm.GetType();
        
        MethodInfo possibleDiscounts_method = dm_type.GetMethod("getPossibleDiscounts", BindingFlags.NonPublic | BindingFlags.Instance);
        MethodInfo pickBestDeals_method = dm_type.GetMethod("pickBestDeals", BindingFlags.NonPublic | BindingFlags.Instance);
        
        var possibleDiscounts = possibleDiscounts_method.Invoke(dm, [b]);

        List<DiscountedProductCount> bestDeals = pickBestDeals_method.Invoke(dm, [possibleDiscounts, b]) as List<DiscountedProductCount>;

        Assert.That(bestDeals.Count == 1);


    }
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(24)]
    public void discountManagerPicksBestDeals(int nrOfCoffeeToAdd)
    {
        Inventory inventory = new Inventory();
        DiscountManager dm = new DiscountManager(inventory);
        var b = new Basket(inventory, dm, 100);

        inventory.Add("BGLO", "Onion", 0.49f, 50);
        inventory.Add("COFB", "Black", 0.99f, 100);
        inventory.Add("FILH", "Ham", 0.12f, 50);
        inventory.Add("FILC", "Cheese", 0.12f, 50);
        inventory.Add("FILE", "Egg", 0.12f,  50);

        // Create Discount deal, 6 BGLOO, for 2.49f 
        int nrOfBagelsForDiscount = 6;
        float discountedPrice_6_for_2_49 = 2.49f;
        var discountReq = new Dictionary<string, int> { { "BGLO" , nrOfBagelsForDiscount } };
        var d = new Discount_XforY(discountReq, discountedPrice_6_for_2_49, inventory);

        var discountReq_2 = new Dictionary<string, int> { { "BGLO", 1 }, { "COFB", 1 } };
        var d2 = new Discount_XforY(discountReq_2, 1.25f, inventory);

        var discountReq_3 = new Dictionary<string, int> { { "BGLP", 12 } };
        var d3 = new Discount_XforY(discountReq_3, 3.99f, inventory);

        var discountReq_4 = new Dictionary<string, int> { { "BGLE", 6 } };
        var d4 = new Discount_XforY(discountReq_4, 2.49f, inventory);

        // Add deal to DiscountManager
        //DiscountManager dm = new DiscountManager(inventory);
        dm.addDiscountType(d);
        dm.addDiscountType(d2);
        dm.addDiscountType(d3);
        dm.addDiscountType(d4);

        // Add non-discounted Products, calculate the total
        float totalPrice = 0.0f;
        
        if (nrOfCoffeeToAdd != 0)
        {
            b.addProduct("COFB", nrOfCoffeeToAdd);
            totalPrice += inventory.getPrice("COFB");
        }
        b.addProduct("FILH");
        totalPrice += inventory.getPrice("FILH");
        b.addProduct("FILC");
        totalPrice += inventory.getPrice("FILC");
        b.addProduct("FILE");
        totalPrice += inventory.getPrice("FILE");
        b.addProduct("FILE");
        totalPrice += inventory.getPrice("FILE");

        // Add discounted Products, calculate sum based on the discount
        int nrOf_OnionBagels = 24;
        b.addProduct("BGLO", nrOf_OnionBagels);

        totalPrice += MathF.Floor((float)nrOf_OnionBagels / nrOfBagelsForDiscount) * discountedPrice_6_for_2_49;
        
        // calculate Rest 
        totalPrice += ((float)nrOf_OnionBagels % nrOfBagelsForDiscount) * discountedPrice_6_for_2_49;

        // Expect to pick 6 bagels for 2.49, over coffe+bagel for 1.25

        Type dm_type = dm.GetType();
        
        MethodInfo possibleDiscounts_method = dm_type.GetMethod("getPossibleDiscounts", BindingFlags.NonPublic | BindingFlags.Instance);
        MethodInfo pickBestDeals_method = dm_type.GetMethod("pickBestDeals", BindingFlags.NonPublic | BindingFlags.Instance);
        
        var possibleDiscounts = possibleDiscounts_method.Invoke(dm, [b]);

        List<DiscountedProductCount> bestDeals = pickBestDeals_method.Invoke(dm, [possibleDiscounts, b]) as List<DiscountedProductCount>;

        Assert.That(bestDeals.Count == 1);
        Assert.That(bestDeals[0].discount == d);



    }
    [Test]
    public void createInventory()
    {

        Inventory inventory = new Inventory();
        Assert.Pass();

    }
    [Test]
    public void createTerminalStoreFront()
    {

        Inventory inventory = new Inventory();
        DiscountManager dm = new DiscountManager(inventory);
        Basket basket = new Basket(inventory, dm);
        DiscountManager discountManager = new DiscountManager(inventory);
        CashRegister cashRegister = new CashRegister(inventory,discountManager);

        inventory.Add("BGLO", "Onion", 0.49f, 100);
        inventory.Add("BGLS", "Sesame", 0.49f, 100);
        inventory.Add("FILH", "Ham", 0.12f, 100);
        inventory.Add("FILC", "Cheese", 0.12f, 100);
        inventory.Add("FILE", "Egg", 0.12f, 100);


        var storeFrontExecutior = new StoreFrontExecutor(new TerminalStoreFront(inventory, basket, discountManager, cashRegister));

        //storeFrontExecutior.run(); // Will get stuck,... not part of the test 

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
    [Test]
    public void create_cashRegister()
    {
        Inventory inventory = new Inventory();
        DiscountManager dm = new DiscountManager(inventory);
        CashRegister cashRegister = new CashRegister(inventory,dm);

        Assert.Pass();
    }
    [Test]
    public void cashRegister_registerBasket()
    {

        Inventory inventory = new Inventory();
        DiscountManager dm = new DiscountManager(inventory);
        var b = new Basket(inventory, dm, 100);
        var cashReg = new CashRegister(inventory, dm);

        inventory.Add("BGLO", "Onion", 0.49f, 50);
        inventory.Add("COFB", "Black", 0.99f, 100);
        inventory.Add("FILH", "Ham", 0.12f, 50);
        inventory.Add("FILC", "Cheese", 0.12f, 50);
        inventory.Add("FILE", "Egg", 0.12f, 50);

        // Create Discount deal, 6 BGLOO, for 2.49f 
        int nrOfBagelsForDiscount = 6;
        float discountedPrice_6_for_2_49 = 2.49f;
        var discountReq = new Dictionary<string, int> { { "BGLO", nrOfBagelsForDiscount } };
        var d = new Discount_XforY(discountReq, discountedPrice_6_for_2_49, inventory);

        var discountReq_2 = new Dictionary<string, int> { { "BGLO", 1 }, { "COFB", 1 } };
        var d2 = new Discount_XforY(discountReq_2, 1.25f, inventory);

        var discountReq_3 = new Dictionary<string, int> { { "BGLP", 12 } };
        var d3 = new Discount_XforY(discountReq_3, 3.99f, inventory);

        var discountReq_4 = new Dictionary<string, int> { { "BGLE", 6 } };
        var d4 = new Discount_XforY(discountReq_4, 2.49f, inventory);

        // Add deal to DiscountManager
        dm.addDiscountType(d);
        dm.addDiscountType(d2);
        dm.addDiscountType(d3);
        dm.addDiscountType(d4);

        // Add non-discounted Products, calculate the total
        float totalPrice = 0.0f;
        b.addProduct("BGLO");
        totalPrice += inventory.getPrice("BGLO");
        b.addProduct("FILH");
        totalPrice += inventory.getPrice("FILH");
        b.addProduct("FILC");
        totalPrice += inventory.getPrice("FILC");
        b.addProduct("FILE");
        totalPrice += inventory.getPrice("FILE");
        b.addProduct("FILE");
        totalPrice += inventory.getPrice("FILE");



        cashReg.registerBasket(b);

        Type cashRegType = cashReg.GetType();

        FieldInfo currentOrder_field = cashRegType.GetField("currentOrder", BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo currentBasket_field = cashRegType.GetField("currentBasket", BindingFlags.NonPublic | BindingFlags.Instance);
        Order registered_order = (Order)currentOrder_field.GetValue(cashReg);
        Basket registered_basket = (Basket)currentBasket_field.GetValue(cashReg);

        Assert.That(registered_order != null);
        Assert.That(registered_basket != null);

    }
    
    [Test]
    public void cashRegister_registerBasket_thenPaySuccessfully()
    {

        Inventory inventory = new Inventory();
        DiscountManager dm = new DiscountManager(inventory);
        var b = new Basket(inventory, dm, 100);
        var cashReg = new CashRegister(inventory, dm);

        inventory.Add("BGLO", "Onion", 0.49f, 100);
        inventory.Add("BGLP", "Plain", 0.39f, 100);
        inventory.Add("BGLE", "Everything", 0.49f, 100);
        inventory.Add("BGLS", "Sesame", 0.49f, 100);
        inventory.Add("COFB", "Black", 0.99f, 100);
        inventory.Add("COFW", "White", 1.19f, 100);
        inventory.Add("COFC", "Capuccino", 1.29f, 100);
        inventory.Add("COFL", "Latte", 1.29f, 100);
        inventory.Add("FILB", "Bacon", 0.12f, 100);
        inventory.Add("FILE", "Egg", 0.12f, 100);
        inventory.Add("FILC", "Cheese", 0.12f, 100);
        inventory.Add("FILX", "Cream Cheese", 0.12f, 100);
        inventory.Add("FILS", "Smoked Salmon", 0.12f, 100);
        inventory.Add("FILH", "Ham", 0.12f, 100);

        // Create Discount deal, 6 BGLOO, for 2.49f 
        int nrOfBagelsForDiscount = 6;
        float discountedPrice_6_for_2_49 = 2.49f;
        var discountReq = new Dictionary<string, int> { { "BGLO", nrOfBagelsForDiscount } };
        var d = new Discount_XforY(discountReq, discountedPrice_6_for_2_49, inventory);

        var discountReq_2 = new Dictionary<string, int> { { "BGLO", 1 }, { "COFB", 1 } };
        var d2 = new Discount_XforY(discountReq_2, 1.25f, inventory);

        var discountReq_3 = new Dictionary<string, int> { { "BGLP", 12 } };
        var d3 = new Discount_XforY(discountReq_3, 3.99f, inventory);

        var discountReq_4 = new Dictionary<string, int> { { "BGLE", 6 } };
        var d4 = new Discount_XforY(discountReq_4, 2.49f, inventory);

        // Add deal to DiscountManager
        dm.addDiscountType(d);
        dm.addDiscountType(d2);
        dm.addDiscountType(d3);
        dm.addDiscountType(d4);

        // Add non-discounted Products, calculate the total
        float totalPrice = 0.0f;
        b.addProduct("BGLS",3);
        b.addProduct("BGLP",25);
        b.addProduct("BGLO",6);
        b.addProduct("BGLE",12);
        b.addProduct("cofb",2);
        totalPrice += inventory.getPrice("BGLO");
        b.addProduct("FILH");
        totalPrice += inventory.getPrice("FILH");
        b.addProduct("FILC");
        totalPrice += inventory.getPrice("FILC");
        b.addProduct("FILE");
        totalPrice += inventory.getPrice("FILE");
        b.addProduct("FILE");
        totalPrice += inventory.getPrice("FILE");



        cashReg.registerBasket(b);

        string reciept = cashReg.finalizePurchase(true);

        Assert.That(reciept.Length != 0);
        Assert.That(reciept != "You failed paying for your bagels...");



        Type cashRegType = cashReg.GetType();

        FieldInfo currentOrder_field = cashRegType.GetField("currentOrder", BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo currentBasket_field = cashRegType.GetField("currentBasket", BindingFlags.NonPublic | BindingFlags.Instance);
        Order registered_order = (Order)currentOrder_field.GetValue(cashReg);
        Basket registered_basket = (Basket)currentBasket_field.GetValue(cashReg);

        Assert.That(registered_order == null);
        Assert.That(registered_basket == null);


    }
    [Test]
    public void cashRegister_registerBasket_thenPayFailure()
    {

        Inventory inventory = new Inventory();
        DiscountManager dm = new DiscountManager(inventory);
        var b = new Basket(inventory, dm, 100);
        var cashReg = new CashRegister(inventory, dm);

        inventory.Add("BGLO", "Onion", 0.49f, 100);
        inventory.Add("BGLP", "Plain", 0.39f, 100);
        inventory.Add("BGLE", "Everything", 0.49f, 100);
        inventory.Add("BGLS", "Sesame", 0.49f, 100);
        inventory.Add("COFB", "Black", 0.99f, 100);
        inventory.Add("COFW", "White", 1.19f, 100);
        inventory.Add("COFC", "Capuccino", 1.29f, 100);
        inventory.Add("COFL", "Latte", 1.29f, 100);
        inventory.Add("FILB", "Bacon", 0.12f, 100);
        inventory.Add("FILE", "Egg", 0.12f, 100);
        inventory.Add("FILC", "Cheese", 0.12f, 100);
        inventory.Add("FILX", "Cream Cheese", 0.12f, 100);
        inventory.Add("FILS", "Smoked Salmon", 0.12f, 100);
        inventory.Add("FILH", "Ham", 0.12f, 100);

        // Create Discount deal, 6 BGLOO, for 2.49f 
        int nrOfBagelsForDiscount = 6;
        float discountedPrice_6_for_2_49 = 2.49f;
        var discountReq = new Dictionary<string, int> { { "BGLO", nrOfBagelsForDiscount } };
        var d = new Discount_XforY(discountReq, discountedPrice_6_for_2_49, inventory);

        var discountReq_2 = new Dictionary<string, int> { { "BGLO", 1 }, { "COFB", 1 } };
        var d2 = new Discount_XforY(discountReq_2, 1.25f, inventory);

        var discountReq_3 = new Dictionary<string, int> { { "BGLP", 12 } };
        var d3 = new Discount_XforY(discountReq_3, 3.99f, inventory);

        var discountReq_4 = new Dictionary<string, int> { { "BGLE", 6 } };
        var d4 = new Discount_XforY(discountReq_4, 2.49f, inventory);

        // Add deal to DiscountManager
        dm.addDiscountType(d);
        dm.addDiscountType(d2);
        dm.addDiscountType(d3);
        dm.addDiscountType(d4);

        // Add non-discounted Products, calculate the total
        float totalPrice = 0.0f;
        b.addProduct("BGLO");
        totalPrice += inventory.getPrice("BGLO");
        b.addProduct("FILH");
        totalPrice += inventory.getPrice("FILH");
        b.addProduct("FILC");
        totalPrice += inventory.getPrice("FILC");
        b.addProduct("FILE");
        totalPrice += inventory.getPrice("FILE");
        b.addProduct("FILE");
        totalPrice += inventory.getPrice("FILE");



        cashReg.registerBasket(b);

        string reciept = cashReg.finalizePurchase(false);

        Assert.That(reciept.Length != 0);
        Assert.That(reciept == "You failed paying for your bagels...");



        Type cashRegType = cashReg.GetType();

        FieldInfo currentOrder_field = cashRegType.GetField("currentOrder", BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo currentBasket_field = cashRegType.GetField("currentBasket", BindingFlags.NonPublic | BindingFlags.Instance);
        Order registered_order = (Order)currentOrder_field.GetValue(cashReg);
        Basket registered_basket = (Basket)currentBasket_field.GetValue(cashReg);

        Assert.That(registered_order == null);
        Assert.That(registered_basket == null);


    }


}