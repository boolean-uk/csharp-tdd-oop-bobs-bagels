// See https://aka.ms/new-console-template for more information
using exercise.main;

Console.WriteLine("Hello, World!");

Basket basket = new Basket();
Inventory inventory = new Inventory();

basket.Add("BGLP");
basket.Add("BGLP");
basket.Add("BGLP");
basket.Add("BGLP");
basket.Add("BGLP");
basket.Add("BGLP");
basket.Add("BGLO");
basket.Add("BGLO");




var itemAmounts = basket.GetItemAmounts();

foreach (var kvp in itemAmounts)
{
    Console.WriteLine($"{kvp.Key.Sku} - Quantity: {kvp.Value}");
}

Console.WriteLine(basket.GetTotalCost());

