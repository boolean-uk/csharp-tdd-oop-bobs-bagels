using exercise.main;

BobsBagelStore store = new BobsBagelStore();
Basket basket = new Basket(30);
Item item1 = new Item("BGLE", 0.39f, "Bagel", "Everything");
Item item2 = new Item("BGLP", 0.39f, "Bagel", "Plain");
Item item3 = new Item("COFB", 0.99f, "Coffee", "Black");
Item item4 = new Item("FILX", 0.12f, "Filling", "Cream Cheese");

for (int  i = 0; i < 7; i++)
{
    basket.AddItem(item1);
}

for (int i = 0; i < 15; i++)
{
    basket.AddItem(item2);
}

basket.AddItem(item3);
basket.AddItem(item3);
basket.AddItem(item4);

Receipt receipt = new Receipt(basket);

store.AddReceipt(basket, receipt);

receipt.PrintReceipt();


