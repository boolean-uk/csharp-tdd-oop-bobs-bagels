using exercise.main;

string yourTwilioAccountSID = "";
string yourTwilioAuthToken = "";
string yourPhoneNumber = "";
BobsBagelStore store = new BobsBagelStore();
string orderMessage = string.Empty;

store.StockUpInventory();
store.ViewInventory();
Console.ReadLine();

store.MakeOrder(CreateOrderExample1());
Console.ReadLine();

store.MakeOrder(CreateOrderExample2());
Console.ReadLine();

orderMessage += store.PrintOrderHistory();

SmsController sms = new SmsController(yourTwilioAccountSID, yourTwilioAuthToken);
sms.SendMessage(orderMessage, yourPhoneNumber);


Receipt CreateOrderExample1()
{
    Basket basket1 = new Basket(30);
    Item item11 = new Item("BGLO", 0.49f, "Bagel", "Onion");
    Item item12 = new Item("BGLP", 0.39f, "Bagel", "Plain");
    Item item13 = new Item("COFB", 0.99f, "Coffee", "Black");
    Item item14 = new Item("BGLE", 0.49f, "Bagel", "Everything");

    basket1.AddItem(item11);
    basket1.AddItem(item11);

    for (int i = 0; i < 12; i++)
    {
        basket1.AddItem(item12);
    }

    for (int i = 0; i < 6; i++)
    {
        basket1.AddItem(item14);
    }
    basket1.AddItem(item13);
    basket1.AddItem(item13);
    basket1.AddItem(item13);

    Receipt receipt1 = new Receipt(basket1);
    store.AddReceipt(basket1, receipt1);
    return receipt1;
}

Receipt CreateOrderExample2()
{
    Basket basket2 = new Basket(30);
    Item item21 = new Item("BGLO", 0.49f, "Bagel", "Onion");
    Item item22 = new Item("BGLP", 0.39f, "Bagel", "Plain");
    Item item23 = new Item("COFB", 0.99f, "Coffee", "Black");
    Item item24 = new Item("BGLE", 0.49f, "Bagel", "Everything");

    basket2.AddItem(item21);
    basket2.AddItem(item21);

    for (int i = 0; i < 4; i++)
    {
        basket2.AddItem(item22);
    }

    for (int i = 0; i < 10; i++)
    {
        basket2.AddItem(item24);
    }
    basket2.AddItem(item23);
    basket2.AddItem(item23);

    Receipt receipt2 = new Receipt(basket2);
    store.AddReceipt(basket2, receipt2);
    return receipt2;
}