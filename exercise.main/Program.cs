// See https://aka.ms/new-console-template for more information


using exercise.main;


Inventory inventory = new Inventory();
Basket basket = new Basket();
Item item1 = inventory.GetItembySku("BGLO");
Item item2 = inventory.GetItembySku("BGLP");
Item item3 = inventory.GetItembySku("BGLE");

basket.addItem(item1);
string sku = "BGLO";
Console.WriteLine(item1.Name);
Console.WriteLine(item2.Name);
Console.WriteLine(item3.Name);

Console.WriteLine(basket.getBagelPrice(sku));


