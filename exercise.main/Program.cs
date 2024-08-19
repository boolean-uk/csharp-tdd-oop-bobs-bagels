// See https://aka.ms/new-console-template for more information


using exercise.main;


Inventory inventory = new Inventory();
Basket basket = new Basket();
Item item1 = inventory.GetItembySku("BGLO");
Item item2 = inventory.GetItembySku("BGLP");
Item item3 = inventory.GetItembySku("BGLE");

Console.WriteLine(item1.Name);
Console.WriteLine(item2.Name);
Console.WriteLine(item3.Name);



basket.addItem(item1);
basket.addItem(item2);
basket.addItem(item3);

Console.WriteLine(basket.Item.Count());
