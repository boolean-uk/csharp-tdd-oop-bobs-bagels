using System;
using exercise.main;

class Program
{
    static void Main(string[] args)
    {

        var inventory = new Inventory();

        inventory.PrintInventories();
        Basket basket = new Basket(100);

        //basket.AddItems(inventory, "BGLO", 3);
        //basket.AddItems(inventory, "COFB", 2);
        Console.WriteLine($"Basket: {basket.ShowBasket()}");
        Console.WriteLine($"Total Cost: {basket.GetTotalCost()}");

        basket.RemoveItems(inventory, "BGLO", 1);
        Console.WriteLine($"Basket after removal: {basket.ShowBasket()}");
    }
}
