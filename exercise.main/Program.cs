// See https://aka.ms/new-console-template for more information
using exercise.main.Classes;

Console.WriteLine("Hello, World!");
Store _store = new();
Basket _basket = new(15);

Bagel _bagel, _plain;
Item _coffee, _latte;
Filling _filling;

_store.Baskets.Add(_basket);

_bagel = new Bagel("BGLE", 0.49, Name.Bagel, "Everything");
_plain = new Bagel("BGLP", 0.39, Name.Bagel, "Plain");
_coffee = new Item("COFB", 0.99, Name.Coffee, "Black");
_latte = new Item("COFL", 1.29, Name.Coffee, "Latte");
_filling = new Filling("FILE", 0.12, Name.Filling, "Egg");

Basket _lastBasket() { return _store.Baskets.Last(); }
Item _lastItem() { return _lastBasket().Items.Last(); }

_lastBasket().Items.AddRange(Enumerable.Repeat(_plain, 12));
double price = _lastBasket().DiscountedCost();
Console.WriteLine(price);