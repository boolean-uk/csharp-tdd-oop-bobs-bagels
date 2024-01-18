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

        Assert.That(_store.ActiveUser == _genericUserID);
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

}