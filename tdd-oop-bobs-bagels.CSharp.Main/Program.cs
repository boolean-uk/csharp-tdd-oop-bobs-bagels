// See https://aka.ms/new-console-template for more information
using csharp_tdd_oop_bobs_bagels_Csharp_Classes;

Inventory inventory = new Inventory();

Console.WriteLine("Hello, Welcome to Bobs Bagels!");
Console.WriteLine(new string('-', 40));
Console.WriteLine("The Menu");

foreach (var item in inventory.InventoryList)
{
    
    
        Console.WriteLine($"{item.Variant} {item.Name}: €{item.Price}");
    
    

}

