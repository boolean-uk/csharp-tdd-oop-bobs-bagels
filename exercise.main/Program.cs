// See https://aka.ms/new-console-template for more information
using exercise.main;

Bagel bagel = new Bagel("BGLO", 0.49, "Bagel", "Onion");
Coffee coffee = new Coffee("COFB", 0.99, "Coffee", "Black");
Filling filling = new Filling("FILB", 0.12, "Filling", "Bacon");
Bagel bagel1 = new Bagel("BGLP", 0.39, "Bagel", "Plain");
Basket basket = new Basket(4);
basket.AddItem(bagel);
basket.AddItem(coffee);
basket.AddItem(filling);
basket.AddItem(bagel1);

Receipt.PrintReciept(basket);
