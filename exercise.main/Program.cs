// See https://aka.ms/new-console-template for more information
using exercise.main;
using tdd_bobs_bagels.Main;

Console.WriteLine("Hello, World!");

Basket basket = new Basket(3);
Bagel bagel1 = new Bagel("BGLO", 0.49m, "Bagel", "Onion");
Bagel bagel2 = new Bagel("BGLP", 0.39m, "Bagel", "Plain");
basket.AddItem("Bagel");
basket.RemoveItem("Bagel");

foreach (var item in basket.Items)
{
    Console.WriteLine(item);
}
