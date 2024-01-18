// See https://aka.ms/new-console-template for more information
using exercise.main.items;
using exercise.main;

Basket basket = new Basket();
basket.Capacity = 1000;
for (int i = 0; i < 37; i++)
{
    basket.Add(new Bagel(BagelVariant.Onion));
}
Bagel bagel = new Bagel(BagelVariant.Plain);
bagel.AddFilling(new Filling(FillingVariant.Bacon));
bagel.AddFilling(new Filling(FillingVariant.Ham));
bagel.AddFilling(new Filling(FillingVariant.Cheese));
basket.Add(bagel);
basket.Add(new Bagel(BagelVariant.Sesame));
basket.Add(new Bagel(BagelVariant.Sesame));
basket.Add(new Bagel(BagelVariant.Sesame));
basket.Add(new Bagel(BagelVariant.Everything));
basket.Add(new Coffee(CoffeeVariant.Capuccino));
for (int i = 0; i < 7; i++)
{
    basket.Add(new Coffee(CoffeeVariant.Latte));
}
Console.Write(basket.GetReceipt());
