// See https://aka.ms/new-console-template for more information
using exercise.main.Inventory;

Console.WriteLine("Hello, World!");

Basket basket = new Basket(4);

Item _bagel = new Bagel("BGLE", 0.49, exercise.main.Inventory.Type.Bagel, "Everything");
Item _coffee = new Item("COFB", 0.99, exercise.main.Inventory.Type.Coffee, "Black");
Item _filling = new Filling("FILE", 0.12, exercise.main.Inventory.Type.Filling, "Egg");

basket.AddItem(_bagel);
basket.AddItem(_coffee);
basket.AddItem(_filling);
basket.AddItem(_filling);

basket.WriteReceipt();