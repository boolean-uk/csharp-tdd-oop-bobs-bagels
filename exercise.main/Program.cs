// See https://aka.ms/new-console-template for more information
using exercise.main;

Inventory inventory = new Inventory();
Basket basket = new Basket();
basket.AddItem("COFW");

for(int i = 0; i < 7; i++)
{
    basket.AddItem("BGLO");
}
basket.AddItem("FILE");
Receipt receipt = new Receipt(basket, DateTime.UtcNow);
receipt.PrintReceipt();