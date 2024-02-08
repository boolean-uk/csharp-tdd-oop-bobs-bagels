using exercise.main;

Inventory inventory = new Inventory();
Basket basket = new Basket(inventory);
basket.ChangeCapacity(50);
basket.AddProduct("BGLO");
basket.AddProduct("BGLO");
for (int i = 0; i < 12; i++)
{
    basket.AddProduct("BGLP");
}
for (int i = 0; i < 6; i++)
{
    basket.AddProduct("BGLE");
}
basket.AddProduct("COFB");
basket.AddProduct("COFB");
basket.AddProduct("COFB");
Receipt receipt = new Receipt(basket);
receipt.PrintRecipt();