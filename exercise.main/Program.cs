using System;
using exercise.main;

class Program
{
    static void Main(string[] args)
    {

        var inventory = new Inventory();

        Basket basket = new Basket(5);

        basket.AddItems(inventory, "BGLO", 3);
        basket.AddItems(inventory, "COFB", 2);
        Console.WriteLine($"Basket: {basket.ShowBasket()}");
        Console.WriteLine($"Total Cost: {basket.GetTotalCost()}");
        Console.WriteLine(basket.AddItems(inventory, "COFB", 2));

        basket.ChangeCapacity(10);
        Console.WriteLine(basket.AddItems(inventory, "COFB", 2));
        Console.WriteLine(basket.AddItems(inventory, "COFB", 10));
        //Console.WriteLine($"Total Cost: {basket.GetTotalCost()}");
    }
}
