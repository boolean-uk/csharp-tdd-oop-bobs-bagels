// See https://aka.ms/new-console-template for more information
using exercise.main;
using tdd_bobs_bagels.Main;


/*
Basket basket = new Basket(3);
Bagel bagel1 = new Bagel("BGLO", 0.49m, "Bagel", "Onion");
Bagel bagel2 = new Bagel("BGLP", 0.39m, "Bagel", "Plain");
//basket.AddItem();
//basket.RemoveItem("Bagel");
Inventory inv = new Inventory();
inv.AddItem(bagel1);
Console.WriteLine(inv);
Console.WriteLine(basket.Items);
foreach (var item in basket.Items)
{
    Console.WriteLine(item);
}
*/

Inventory store = new Inventory();
Basket basket = new Basket();
store.AddBasket(basket);
store.IncreaseCapacity(20);
Product bagel;


for (int i = 0; i < 2; i++)
{
    bagel = new Bagel("BGLO");
    basket.Add(bagel);
}

for (int i = 0; i < 12; i++)
{
    bagel = new Bagel("BGLP");
    basket.Add(bagel);
}

for (int i = 0; i < 6; i++)
{
    bagel = new Bagel("BGLE");
    basket.Add(bagel);
}

Product coffee;
for (int i = 0; i < 3; i++)
{
    coffee = new Coffee("COFB");
    basket.Add(coffee);
}

Receipt receipt = new Receipt(basket);
receipt.PrintReceipt();
