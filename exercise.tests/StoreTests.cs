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
        _store.AddUser(_bossUserID);
        _store.Login(_bossUserID);
        _store.AddUser(_genericUserID);
        _store.Login(_genericUserID);
        _store.AddAddOn("FILB", "Bacon", 0.12m);
        _store.AddAddOn("FILE", "Egg", 0.12m, 0.1m);
        _store.AddAddOn("FILC", "Cheese", 0.12m);
        _store.AddAddOn("FILX", "Cream Cheese", 0.12m);
        _store.AddAddOn("FILS", "Smoked Salmon", 0.12m, 0.2m);
        _store.AddAddOn("FILH", "Ham", 0.12m);
        _store.AddBaseItem("BGLP", "Plain Bagel", 0.39m);
        _store.AddBaseItem("BGLO", "Onion Bagel", 0.49m);
        _store.AddBaseItem("BGLE", "Everything Bagel", 0.49m);
        _store.AddBaseItem("BGLS", "Sesame Bagel", 0.49m);
        foreach (var item in _store.BaseItems)
        {
            item.AllowAddOns("FILB", "FILE", "FILC", "FILX", "FILS", "FILH");
        }
        _store.AddBaseItem("COFB", "Black Coffee", 0.99m, 1.5m);
        _store.AddBaseItem("COFW", "White Coffee", 1.19m, 1.5m);
        _store.AddBaseItem("COFC", "Capucciono", 1.29m, 1.5m);
        _store.AddBaseItem("COFL", "Caffè Latte", 1.29m, 1.5m);
    }

    [Test]
    public void StoreSetUpTest()
    {

        Assert.That(_store.ActiveUser == _genericUserID);
        Assert.That(_store.Users.Count == 2);
        Assert.Throws<UnauthorizedAccessException>(() => _store.AddUser("user@test.com"));
        _store.Login(_bossUserID);
        Assert.DoesNotThrow(() => _store.AddUser("user@test.com"));
        Assert.That(_store.BaseItems.Count > 0);
        Assert.That(_store.AddOns.Count > 0);
    }

}