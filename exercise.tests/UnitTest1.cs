using exercise.main;
using exercise.main.Products;

namespace exercise.tests;

public class Tests
{

    private Basket _basket;
    private Store _store;

    [SetUp]
    public void Setup()
    {
        _store = new Store();
        _basket = new Basket(_store.Inventory);
        _basket.Capacity = 1;

    }

    [Test]
    public void AddItemToBasket()
    {

        Product onionBagel1 = _store.Inventory.Products["BGLO"];
        Basket basket = new Basket(_store.Inventory);
        basket.AddItem(onionBagel1);
        

        Assert.That(onionBagel1, Is.Not.Null);
        Assert.That(onionBagel1.SKU, Is.EqualTo("BGLO"));

    }

    [Test]
    public void RemoveItemFromBasket()
    {
        Product onionBagel1 = _store.Inventory.Products["BGLO"];
        _basket.AddItem(onionBagel1);

        Assert.That(_basket.BasketOrder, Has.Count.EqualTo(1));

        _basket.RemoveItem(onionBagel1);
        Assert.That(_basket.BasketOrder, Is.Empty);

    }
 
    [Test]
    public void CheckBasketFull()
    {
        _basket.AddItem(_store.Inventory.Products["BGLO"]);
        var result = _basket.AddItem(_store.Inventory.Products["BGLO"]);

        Assert.That(result, Is.EqualTo("Basket is full. Item was not added to basket."));

    }
    
    [Test]
    public void ChangeBasketCapacity()
    {
        _basket.Capacity = 2;
        Assert.That(_basket.Capacity, Is.EqualTo(2));

        _basket.Capacity = 3;
        Assert.That(_basket.Capacity, Is.EqualTo(3));
    }

    [Test]
    public void RemoveItemNotInBasket()
    {
        Product firstProduct = _store.Inventory.Products.First().Value;
        var result = _basket.RemoveItem(firstProduct);

        Assert.That(result, Is.EqualTo("Item does not exist in basket"));
    }

    [Test]
    public void CheckTotalCost()
    {
        Basket basket = new Basket(_store.Inventory);
        basket.Capacity = 3;
        basket.AddItem(_store.Inventory.Products["BGLO"]);
        Assert.That(basket.TotalCost(), Is.EqualTo(0.49));
        basket.AddItem(_store.Inventory.Products["BGLP"]);
        Assert.That(basket.TotalCost(), Is.EqualTo(0.49 + 0.39));
        basket.AddItem(_store.Inventory.Products["BGLS"]);
        Assert.That(basket.TotalCost(), Is.EqualTo(0.49 + 0.39 + 0.49));
    }


    [Test]
    public void CheckPriceOfBagel()
    {

        Basket basket = new Basket(_store.Inventory);
        var onionBagel1 = _store.Inventory.Products["BGLO"];
        var price = onionBagel1.Price;

        Assert.That(price, Is.EqualTo(0.49));

    }

    [Test]
    public void AddFillingToBagel()
    {
        Basket basket = new Basket(_store.Inventory);
        var onionBagel1 = _store.Inventory.Products["BGLO"] as Bagel;
        var onionBagel2 = _store.Inventory.Products["BGLO"] as Bagel;
        var ham1 = _store.Inventory.Products["FILH"] as Filling;
        onionBagel1.AddFilling(ham1);
        basket.AddItem(onionBagel1);

        Assert.That(onionBagel1.PriceWithFillings, Is.EqualTo(0.49 + 0.12));

    }

    [Test]
    public void CheckFillingPrice()
    {
        var ham1 = _store.Inventory.Products["FILH"];

        Assert.That(ham1.Price, Is.EqualTo(0.12));
    }

    [Test]
    public void CheckOnlyOrderFromInventory()
    {
        Basket basket = new Basket(_store.Inventory);
        var newProduct = new Bagel("NEW", 99, Bagel.BagelVariant.Everything);
        var result = basket.AddItem(newProduct);

        Assert.That(result, Is.EqualTo("Item is not in the inventory. Item was not added to basket."));
    }
}