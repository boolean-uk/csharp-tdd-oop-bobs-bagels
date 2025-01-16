using System;
using exercise.main;

class Program
{
    static void Main(string[] args)
    {

        var inventory = new Inventory();

        Basket basket = new Basket(30);

        basket.AddItems(inventory, "BGLO", 6);
        basket.AddItems(inventory, "BGLP", 12);
        basket.AddItems(inventory, "BGLE", 6);
        basket.AddItems(inventory, "COFB", 1);
        Console.WriteLine($"Basket: {basket.ShowBasket()}");
    }
}
