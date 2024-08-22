using exercise.main;

Basket basket =  new Basket();

basket.changecapacity(5);

Item item1 = new Item("BGLO", 0.49, "Bagel", "Onion");
Item item2 = new Item("BGLP", 0.39, "Bagel", "Plain");
Item item3 = new Item("BGLE", 0.49, "Bagel", "Everything");

Console.WriteLine(basket.addItem(item1));
Console.WriteLine(basket.addItem(item2));
Console.WriteLine(basket.addItem(item3));

//string receipt = basket.printreceipt();
//Console.WriteLine(receipt);
