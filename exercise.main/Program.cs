// See https://aka.ms/new-console-template for more information
using exercise.main;

Console.WriteLine("Hello, World!");


Basket basket = new Basket();

Item bagel = new Bagel("Plain");
basket.Add(bagel);

for (int i = 0; i < 100; i++)
    basket.Add(new Coffee("Latte"));

bagel.AddFilling(new Filling("Egg"));
bagel.AddFilling(new Filling("Bacon"));

Receipt receipt = new Receipt();

receipt.AddAll(basket.items);

receipt.PrintReceipt(basket.items);