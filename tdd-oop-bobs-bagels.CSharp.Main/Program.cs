// See https://aka.ms/new-console-template for more information
using csharp_tdd_oop_bobs_bagels_Csharp_Classes;

Inventory inventory = new Inventory();
Basket basket = new Basket();

bool running = true;

while (running)
{
    Console.Clear();
    Console.WriteLine("The Menu:");
    foreach (var item in inventory.InventoryList)
    {


        Console.WriteLine($"{item.SKU} {item.Variant} {item.Name}: {item.Price}");



    }
    Console.WriteLine("Your Basket:");
    foreach(var item in basket.ShoppingBasket)
    {
        Console.WriteLine($"{item.Variant} {item.Name}: {item.Price}");
    }
    
    Console.WriteLine($"Total :{basket.CalculateTotal()}");
    Console.WriteLine("Options:");
    Console.WriteLine("1. Enter an SKU to add to The basket");
    Console.WriteLine("2. Enter remove to remove an item from the basket");
    Console.WriteLine("3. Enter q to Quit");
    string input = Console.ReadLine();
    switch(input.ToUpper())
    {
        case "Q":
            running = false; break;
        case "REMOVE":
/*            removeItemFromBasket() ; break;
        default:
            addProduct(input)
                ; break;*/
    }

}





