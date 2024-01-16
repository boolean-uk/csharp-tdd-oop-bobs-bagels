using exercise.main;

Basket basket = new Basket(3);
Item expected = new Item(0.49f, "Bagel", "Everything");
Item result = basket.addItem("BGLE");
Console.WriteLine("");