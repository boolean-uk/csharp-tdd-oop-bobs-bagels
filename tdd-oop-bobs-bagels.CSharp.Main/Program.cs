// See https://aka.ms/new-console-template for more information
using csharp_tdd_oop_bobs_bagels_Csharp_Classes;

Inventory inventory = new Inventory();
Basket basket = new Basket();

bool running = true;

while (running)
{
    Console.Clear();
    Console.WriteLine(new string('~', 40));
    Console.WriteLine("The Menu:");
    Console.WriteLine(new string('~', 40));
    foreach (var item in inventory.InventoryList)
    {
        Console.WriteLine($"{item.SKU} {item.Variant} {item.Name}: {item.Price}");
    }
    Console.WriteLine(" ");
    Console.WriteLine("Current Discounts:");
    Console.WriteLine("12 Plain Bagels For 3.99!! ");
    Console.WriteLine("Onion and Everything Bagels: 6 for the price of 2.49!!!");
    Console.WriteLine("What is a Coffee without a bagel?? 1 Coffee and 1 Bagel for 1.25");
    Console.WriteLine(" ");



    Console.WriteLine(new string('~', 40));
    Console.WriteLine("Your Basket:");
    Console.WriteLine(new string('~', 40));
    foreach (var item in basket.ShoppingBasket)
    {
        Console.WriteLine($"{item.Id}.  {item.Variant} {item.Name}: {item.Price}  ({item.Amount})" );
        foreach(var filling in item.Extras) { Console.WriteLine($"      {filling.Variant}"); }
    }
    
    
    Console.WriteLine(new string('-', 40));

    decimal total = basket.CalculateTotal();
    Console.WriteLine($"Total :{total}");
    Console.WriteLine(new string('-', 40));

    Console.WriteLine("Options:");
    Console.WriteLine("1. Enter an SKU to add to The basket");
    Console.WriteLine("2. Enter remove to remove an item from the basket");
    Console.WriteLine("3. Enter q to Quit");
    Console.WriteLine("3. Enter Pay to get an reciept");
    string input = Console.ReadLine();
    switch(input.ToUpper())
    {
        case "Q":
            running = false; break;
        case "REMOVE":
            RemoveProduct() ; 
            break;
        case "PAY":
            PrintReceipt(total) ; 
            break; 
        default:
            AddProduct(input)
                ; break;
    }

}

void AddProduct(string input)

    {
    Console.Clear();
    ShopItem inputToShopitem = basket.SkuToShopItem(input);
    if (inputToShopitem.SKU == "") 
    {
        Console.WriteLine("Item does not exist");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    } else
    {
        Console.WriteLine($"{inputToShopitem.Variant} {inputToShopitem.Name} {inputToShopitem.Price}");
        Console.WriteLine("How many would you like?");
        int amount = int.Parse(Console.ReadLine());
        ;
        if (basket.AddItemToBasket(inputToShopitem, amount))
        {
            Console.WriteLine("Would you like to add a filling?");
            foreach (var item in inventory.InventoryList)
            {
                if (item.Name == "Filling")
                {
                    Console.WriteLine($"{item.SKU} {item.Variant} {item.Name}: {item.Price}");
                }
            }
            Console.WriteLine("Enter the SKU to add an filling");
            Console.WriteLine("Else press (N) to return to main menu");
            string yesno = Console.ReadLine();
            switch (input.ToUpper())
            {
               case "N":
                    break;
                default:
                    basket.AddFilling(inputToShopitem, yesno)
                        ; break;
            }
        }
        else 
        {
            Console.WriteLine("Basket is Full!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

    }
    
    
    
}



void RemoveProduct()
{
    Console.Clear() ;
    Console.WriteLine("Your Basket:");
    foreach (var item in basket.ShoppingBasket)
    {
        Console.WriteLine($"{item.Id}.  {item.Variant} {item.Name}: {item.Price}  ({item.Amount})");
    }

    Console.WriteLine("Enter the id of the item to be removed");
    string itemId = Console.ReadLine();
    basket.RemoveItemFromBasket(int.Parse(itemId));
}


void PrintReceipt(decimal total)
{
    
    Console.Clear();
    Console.WriteLine("~~~Bob's Bagels~~~");
    Console.WriteLine("");
    Console.WriteLine($"{DateTime.Now}");
    Console.WriteLine("");
    Console.WriteLine("----------------------------");
    Console.WriteLine("");
    foreach(var item in basket.ShoppingBasket)
    { 
        Console.WriteLine($"{item.Variant} {item.Name} {item.Amount} £{item.Costs} ");
        if (item.Discount != 0) 
        { 
            Console.WriteLine($"(-£{item.Discount})"); 
        }
    }

    Console.WriteLine("");
    Console.WriteLine("----------------------------");
    Console.WriteLine($"Total   £{total}");
    Console.WriteLine("");
    Console.WriteLine("Thank you for your order!");
    Console.ReadKey();
}
