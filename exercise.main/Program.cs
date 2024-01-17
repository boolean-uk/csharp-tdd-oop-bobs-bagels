// See https://aka.ms/new-console-template for more information

using exercise.main;

Basket basket = new Basket();

basket.ChangeCapacity(1000);
Bagel everything = new Bagel(BagelType.Everything);
basket.Add(everything);
everything.Add(new Filling(FillingType.CreamedCheese));
Bagel onion = new Bagel(BagelType.Onion);
basket.Add(onion);
onion.Add(new Filling(FillingType.CreamedCheese));
basket.Add(new Bagel(BagelType.Sesame));
basket.Add(new Coffee(CoffeeType.Latte));
basket.Add(new Coffee(CoffeeType.Black));
basket.Add(new Coffee(CoffeeType.Latte));
basket.Add(new Coffee(CoffeeType.Black));
for ( int i = 0; i < 100; i++)
{
    basket.Add(new Bagel(BagelType.Plain));
}

basket.WriteReceipt();