using exercise.main;

BobsBagelStore store = new BobsBagelStore();
Basket basket = new Basket(5);
Item item1 = new Item("BGLE", 0.39f, "Bagel", "Everything");
Item item2 = new Item("BGLS", 0.49f, "Bagel", "Sesame");
Item item3 = new Item("COFB", 0.99f, "Coffee", "Black");
Item item4 = new Item("FILX", 0.12f, "Filling", "Cream Cheese");

basket.AddItem(item1);
basket.AddItem(item2);
basket.AddItem(item3);
basket.AddItem(item3);
basket.AddItem(item4);

Receipt receipt = store.GenerateReceipt(basket);

receipt.PrintReceipt();

