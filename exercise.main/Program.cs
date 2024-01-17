// See https://aka.ms/new-console-template for more information
using exercise.main;

BobsBagels store = new BobsBagels();
Basket basket = new Basket();
store.AddBasket(basket);
store.IncreaseCapacity(20);
Bagel bagel;


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

Coffee coffee;
for (int i = 0; i < 3; i++)
{
    coffee = new Coffee("COFB");
    basket.Add(coffee);
}

Receipt receipt = new Receipt(basket);
receipt.PrintReceipt();
