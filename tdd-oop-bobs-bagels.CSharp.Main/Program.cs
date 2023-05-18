using tdd_oop_bobs_bagels.CSharp.Source;

BobsBagelsApp bobsBagelsApp = new BobsBagelsApp();
bool running = true;

while (running)
{
    Console.Clear();
    // display stock
    Console.WriteLine("Menu:");
    foreach (InventoryItem i in bobsBagelsApp.stock)
    {
        Console.WriteLine($"{i.SKU} {i.Name} {i.Variant} {i.Price}");
    }
    //display basket
    Console.WriteLine("Basket:");
    foreach (InventoryItem i in bobsBagelsApp.basket)
    {
        Console.WriteLine($"{i.SKU} {i.Name} {i.Variant} {i.Price}");
    }
    Console.WriteLine(bobsBagelsApp.TotalCostBasket());

    Console.WriteLine("Enter a SKU to add a product\n1 to delete a product \nQ to quit");
    string input = Console.ReadLine();
    switch (input.ToUpper())
    {
        case "1":   
            deleteItemFromBasket();
            break;
        case "Q":
        case "q":
            running = false; 
            break;
        default:
            bobsBagelsApp.AddProduct(input);
            break;
    }
    
}

void deleteItemFromBasket()
{
    Console.Clear();
    int itemnumber = 1;
    foreach (InventoryItem i in bobsBagelsApp.basket)
    {
        Console.WriteLine($"{itemnumber} {i.SKU} {i.Name} {i.Variant} {i.Price}");
        itemnumber++;
    }
    Console.WriteLine("Enter number to delete item.");
    string numberToDelete = Console.ReadLine();
    bobsBagelsApp.RemoveProductByNumber(int.Parse(numberToDelete) -1);
}