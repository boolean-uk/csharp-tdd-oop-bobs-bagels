using exercise.main;

BobsBagelStore store = new BobsBagelStore();
store.StockUpInventory();
store.ViewInventory();
Basket basket = new Basket(30);
Item item1 = new Item("BGLO", 0.49f, "Bagel", "Onion");
Item item2 = new Item("BGLP", 0.39f, "Bagel", "Plain");
Item item3 = new Item("COFB", 0.99f, "Coffee", "Black");
Item item4 = new Item("BGLE", 0.49f, "Bagel", "Everything");

basket.AddItem(item1);
basket.AddItem(item1);

for (int i = 0; i < 12; i++)
{
    basket.AddItem(item2);
}

for (int i = 0; i < 6; i++)
{
    basket.AddItem(item4);
}
basket.AddItem(item3);
basket.AddItem(item3);
basket.AddItem(item3);


Receipt receipt = new Receipt(basket);

store.AddReceipt(basket, receipt);

receipt.PrintReceipt();


