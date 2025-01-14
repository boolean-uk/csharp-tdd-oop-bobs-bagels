// See https:
//aka.ms/new-console-template for more information
using exercise.main;

Console.WriteLine("Welcome to Bob's Bagels! \n----------------------------- \n");


Store bobsBagel = new Store();

Basket basket = new Basket(bobsBagel.Inventory);
basket.Capacity = 25;
basket.AddItem(bobsBagel.Inventory.Products["BGLO"]);
basket.AddItem(bobsBagel.Inventory.Products["BGLO"]);
basket.AddItem(bobsBagel.Inventory.Products["BGLO"]);
basket.AddItem(bobsBagel.Inventory.Products["BGLO"]);
basket.AddItem(bobsBagel.Inventory.Products["BGLO"]);
basket.AddItem(bobsBagel.Inventory.Products["BGLO"]);

for(int i = 0; i < 12; i++)
{
    basket.AddItem(bobsBagel.Inventory.Products["BGLP"]);
}

basket.AddItem(bobsBagel.Inventory.Products["FILH"]);
Receipt receipt = new Receipt(basket);

receipt.PrintReceipt();

