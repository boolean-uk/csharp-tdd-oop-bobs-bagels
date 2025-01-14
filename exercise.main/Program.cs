// See https://aka.ms/new-console-template for more information
using exercise.core;

IRepository repo = LocalRepository.Default();
Store store = new Store(repo);
User bob = new User { UserId = "bob", priv = Privilege.Admin };
store.AddUser(bob);
store.setActiveUser(bob);
store.ModifyCartCapacity(bob, 10);

for (int i = 0; i < 8; i++)
{
    var bagel = LocalRepository.Default().getRegisteredItems()[0];
    if (bagel is Bagel bg)
    {
        var filling = LocalRepository.Default().getRegisteredItems()[9];
        if (filling is BagelFilling f)
        {
            bg.AddFilling(f);
        }
    }
    store.AddToCart(bagel);
}

var r = store.Checkout();
System.Console.WriteLine(r?.GetReceiptText());
