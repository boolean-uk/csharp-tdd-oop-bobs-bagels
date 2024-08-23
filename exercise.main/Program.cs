using exercise.main;

Basket basket =  new Basket();

basket.changecapacity(10);

Item item1 = new Item("BGLO", 0.49, "Bagel", "Onion");
Item item2 = new Item("BGLO", 0.49, "Bagel", "Onion");
Item item3 = new Item("BGLP", 0.39, "Bagel", "Plain");
Item item4 = new Item("BGLE", 0.49, "Bagel", "Everything");

basket.addItem(item1);
basket.addItem(item2);
basket.addItem(item3);
basket.addItem(item4);

string receipt = basket.printreceipt();
Console.WriteLine(receipt);
