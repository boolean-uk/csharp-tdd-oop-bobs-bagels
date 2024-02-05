// See https://aka.ms/new-console-template for more information
using exercise.main;

Console.WriteLine("Hello, World!");

Basket basket = new Basket();
Inventory inventory = new Inventory();
basket.ChangeCapacity(25);


basket.Add("BGLO");
basket.Add("BGLO");
basket.Add("BGLO");
basket.Add("BGLO");
basket.Add("BGLO");
basket.Add("BGLO");
basket.Add("COFB");





Receipt receipt = new Receipt(basket);
var itemAmounts = basket.GetItemAmounts();

foreach (var kvp in itemAmounts)
{
    Console.WriteLine($"{kvp.Key.Sku} - Quantity: {kvp.Value}");
}

Console.WriteLine(basket.GetTotalCost());
Console.WriteLine(basket.GetTotalCostWithoutDiscount());
receipt.PrintReceipt();
