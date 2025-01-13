// See https:
//aka.ms/new-console-template for more information
using exercise.main;

Console.WriteLine("Welcome to Bob's Bagels! \n----------------------------- \nWhat would you like to do?");


Store bobsBagel = new Store();

Basket basket = new Basket(bobsBagel.Inventory);
basket.Capacity = 20;
basket.AddItem(bobsBagel.Inventory.Products["BGLO"]);
basket.AddItem(bobsBagel.Inventory.Products["BGLO"]);
basket.AddItem(bobsBagel.Inventory.Products["BGLO"]);
basket.AddItem(bobsBagel.Inventory.Products["BGLO"]);
basket.AddItem(bobsBagel.Inventory.Products["BGLO"]);
basket.AddItem(bobsBagel.Inventory.Products["BGLO"]);
basket.AddItem(bobsBagel.Inventory.Products["BGLO"]);
basket.AddItem(bobsBagel.Inventory.Products["BGLO"]);

for(int i = 0; i < 13; i++)
{
    basket.AddItem(bobsBagel.Inventory.Products["BGLP"]);
}

basket.TotalCost();
basket.ApplyDiscount();
//var exit = false;


//while (!exit)

//{
// Ask the user to choose an option.
//Console.WriteLine("Choose an option from the following list:");
//Console.WriteLine("\t1 - Order");
//Console.WriteLine("\t2 - Check out");
//Console.WriteLine("\t3 - View/Change order");
//Console.WriteLine("\t4 - Leave");
//Console.Write("Your option? ");

//switch (Console.ReadLine())
//{
//    case "1":
//        Console.WriteLine("What would you like to order?");
//        Console.ReadKey();
//        break;
//    case "2":
//        Console.WriteLine("Test");
//        Console.ReadKey();
//        break;
//    case "3":
//        Console.WriteLine("Test2");
//        Console.ReadKey();
//        break;
//    case "4":
//        Console.WriteLine("Test3");
//        exit = true;
//        break;
//}



//}
