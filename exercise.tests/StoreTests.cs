using exercise.main;
using NUnit.Framework;
namespace exercise.tests;

[TestFixture]
public class StoreTests
{

    Store _store;
    string _bossUserID;
    string _genericUserID;

    [SetUp]
    public void Setup()
    {
        _store = new Store();
        _bossUserID = "boss@admin.bobsbagels.com";
        _genericUserID = "customer@genericmail.com";
        InitialSetUp();

    }

    private void InitialSetUp()
    {
        _store.CreateNewUser(_bossUserID);
        _store.CreateNewUser(_genericUserID);
        _store.CreateNewAddOn("FILB", "Bacon", 0.12m);
        _store.CreateNewAddOn("FILE", "Egg", 0.12m, 0.1m);
        _store.CreateNewAddOn("FILC", "Cheese", 0.12m);
        _store.CreateNewAddOn("FILX", "Cream Cheese", 0.12m);
        _store.CreateNewAddOn("FILS", "Smoked Salmon", 0.12m, 0.2m);
        _store.CreateNewAddOn("FILH", "Ham", 0.12m);
        _store.CreateNewBaseItem("BGLP", "Plain Bagel", 0.39m);
        _store.CreateNewBaseItem("BGLO", "Onion Bagel", 0.49m);
        _store.CreateNewBaseItem("BGLE", "Everything Bagel", 0.49m);
        _store.CreateNewBaseItem("BGLS", "Sesame Bagel", 0.49m);
        foreach (var item in _store.BaseItems)
        {
            item.AllowAddOns("FILB", "FILE", "FILC", "FILX", "FILS", "FILH");
        }
        _store.CreateNewBaseItem("COFB", "Black Coffee", 0.99m, 1.5m);
        _store.CreateNewBaseItem("COFW", "White Coffee", 1.19m, 1.5m);
        _store.CreateNewBaseItem("COFC", "Capucciono", 1.29m, 1.5m);
        _store.CreateNewBaseItem("COFL", "Caffè Latte", 1.29m, 1.5m);
        _store.Login(_genericUserID);
    }

    [Test]
    public void StoreSetUpTest()
    {
        Assert.That(_store.ActiveUserID == _genericUserID);
        Assert.That(_store.Users.Count == 2);
        Assert.Throws<UnauthorizedAccessException>(() => _store.CreateNewUser("user@test.com"));
        _store.Login(_bossUserID);
        Assert.DoesNotThrow(() => _store.CreateNewUser("user@test.com"));
        Assert.Throws<InvalidOperationException>(() => _store.CreateNewAddOn("BGLP", "Invalid filling", 0.12m));
        Assert.That(_store.BaseItems.Count > 0);
        Assert.That(_store.AddOns.Count > 0);
        Assert.That(_store.BaseItems[0].AvailableAddOns.Contains("FILE"));
    }

    [Test]
    public void StoreOrderBagelTest()
    {
        User user = _store.GetActiveUser();
        _store.AddToBasket("BGLP", 2);
        Assert.That(user.Basket.Count == 1);
        Assert.That(user.Basket[0].BaseItem.ItemID == "BGLP");
        Assert.That(user.Basket[0].Count == 2);
    }

    [Test]
    public void StoreRemoveOrderTest()
    {
        User user = _store.GetActiveUser();
        _store.AddToBasket("BGLP", 2);
        _store.RemoveFromBasket();
        Assert.That(user.Basket.Count == 0);
        _store.AddToBasket("BGLO", 2);
        _store.AddToBasket("BGLP", 1);
        _store.RemoveFromBasket();
        Assert.That(user.Basket.Count == 1);
        Assert.That(user.Basket[0].BaseItem.ItemID == "BGLO");
    }

    [Test]
    public void StoreBasketCapacityTest()
    {
        _store.Login(_bossUserID);
        _store.SetMaximumBasketCapacity(5m);
        _store.AddToBasket("BGLP", 4);
        Assert.DoesNotThrow(() => _store.AddToBasket("BGLP", 1));
        Assert.Throws<InvalidOperationException>(() => _store.AddToBasket("BGLP", 2));
    }

    [Test]
    public void StoreSetbasketCapacityTest()
    {
        _store.Login(_genericUserID);
        Assert.Throws<UnauthorizedAccessException>(() => _store.SetMaximumBasketCapacity(10m));
        _store.Login(_bossUserID);
        Assert.DoesNotThrow(() => _store.SetMaximumBasketCapacity(10m));
        _store.SetMaximumBasketCapacity(10m);
        Assert.Throws<InvalidOperationException>(() => _store.AddToBasket("BGLP", 11));
        _store.SetMaximumBasketCapacity(11);
        Assert.DoesNotThrow(() => _store.AddToBasket("BGLP", 11));
    }

    [Test]
    public void StoreInvalidRemoveTest()
    {
        Assert.Throws<InvalidOperationException>(() => _store.RemoveFromBasket());
        _store.AddToBasket("BGLP");
        Assert.DoesNotThrow(() => _store.RemoveFromBasket());
        _store.AddToBasket("BGLP");
        Assert.Throws<InvalidOperationException>(() => _store.RemoveFromBasket(1));
        _store.AddToBasket("BGLO");
        _store.AddToBasket("BGLP");
        _store.AddToBasket("BGLE");
        Assert.DoesNotThrow(() => _store.RemoveFromBasket(2));
        Assert.That(_store.GetActiveUser().Basket[2].BaseItem.ItemID == "BGLE");
    }

    [Test]
    public void BasketTotalCostTest()
    {
        decimal plainBagelPrice = _store.GetBaseItemByID("BGLP").Price;
        decimal everythingBagelPrice = _store.GetBaseItemByID("BGLE").Price;
        _store.AddToBasket("BGLP", 2);
        _store.AddToBasket("BGLE", 1);
        Assert.That(_store.BasketTotalCost() == 2 * plainBagelPrice + everythingBagelPrice);
        _store.RemoveFromBasket();
        Assert.That(_store.BasketTotalCost() == 2 * plainBagelPrice);
    }

}