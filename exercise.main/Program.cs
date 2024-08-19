// See https://aka.ms/new-console-template for more information
using exercise.main;

Console.WriteLine("Hello, World!");
Inventory inventory = new Inventory();
Basket basket = new Basket();
Item expectedItem = new Item("BGLO", "Bagel", 0.49, "Onion");

basket.addItem("Bagel", "Onion");
Console.WriteLine(basket.yourBasket.First().ToString());
basket.removeItem("Onion");
Console.WriteLine(basket.yourBasket.Count());