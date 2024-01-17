using exercise.main.Classes;

namespace exercise.tests;

public class Tests
{
    //Stock _stock = new();

    Store _store = new();
    Basket _basket = new(10);

    Bagel _bagel;
    Item _coffee;
    Filling _filling;


    [SetUp]
    public void SetUp()
    {
        _store.Baskets.Add(_basket);

        _bagel = new Bagel ("BGLE", 0.49, Name.Bagel, "Everything");
        _coffee = new Item ("COFB", 0.99, Name.Coffee, "Black");
        _filling = new Filling("FILE", 0.12, Name.Filling, "Egg");

    }

    private Basket _lastBasket() { return _store.Baskets.Last(); }
    private Item _lastItem() { return _lastBasket().Items.Last(); }


    [Test]
    public void AddBagel() //using the basket class
    {
        _lastBasket().Add(_bagel);
        Assert.That(_lastItem(), Is.EqualTo(_bagel));
    }

    [Test]
    public void AddCoffee() //using the store and stock classes
    {
        _store.AddItem(_basket, "COFB");
        Assert.That(_lastItem().Variant, Is.EqualTo(_coffee.Variant));
    }

    [Test]
    public void AddFilling()
    {
        _lastBasket().Add(_bagel);
        _lastItem().AddFilling(_filling);
        Assert.That(_lastItem().GetFilling().Last(), Is.EqualTo(_filling));
    }

    [Test]
    public void RemoveBagel()
    {
        _lastBasket().Items.Clear();
        _lastBasket().Add(_bagel);
        _lastBasket().Remove("BGLE");
        Assert.That(_lastBasket().Items.Count, Is.EqualTo(0));
    }

    [Test]
    public void RemoveFilling()
    {
        _lastBasket().Add(_bagel);
        _lastItem().AddFilling(_filling);
        _lastItem().RemoveFilling("FILE");
        Assert.That(_lastItem().GetFilling().Count, Is.EqualTo(0));
    }



    [Test]
    public void SetCapacities()
    {
        _store.SetCapacity(5);
        Assert.That(_lastBasket().Capacity, Is.EqualTo(5));
    }

    [Test]
    public void BasketCost()
    {
        _lastBasket().Add(_bagel);
        _lastBasket().Add(_coffee);
        Assert.That(_lastBasket().Cost(), Is.EqualTo(1.48));
    }

    [Test]
    public void PriceCheck()
    {
        Assert.That(_store.Price(Name.Coffee), Is.EqualTo("COFB Black 0.99\nCOFW White 1.19\nCOFC Cappuccino 1.29\nCOFL Latte 1.29\n"));
    }

    

}