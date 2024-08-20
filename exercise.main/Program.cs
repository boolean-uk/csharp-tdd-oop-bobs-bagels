// See https://aka.ms/new-console-template for more information
using exercise.main;
using System.Linq;

Basket basket = new Basket();
basket.Cap = 20;

Inventory.FillingStock = 10;
Inventory.BagelStock = 10;
Inventory.CoffeeStock = 10;

List<Item> selection1 = basket.MakeNew();

Bagel bagel1 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");

Filling filling1 = ChosenItem.ChooseFillings("FILE", 0.12, "Filling", "Egg");
Filling filling2 = ChosenItem.ChooseFillings("FILB", 0.12, "Filling", "Bacon");

basket.fillings.Add(filling1);
basket.fillings.Add(filling2);
bagel1 = ChosenItem.AddFillings(bagel1, basket.fillings);

basket.AddToSelection(selection1, bagel1);
basket.AddToSelection(selection1, filling1);
basket.AddToSelection(selection1, filling2);

basket.AddToBasket(0, selection1);

List<Item> selection2 = basket.MakeNew();

Bagel bagel2 = ChosenItem.MakeBagel("BGLE", 0.49, "Bagel", "Everything", "");

basket.AddToSelection(selection2 , bagel2);
basket.AddToBasket(1, selection2);

Console.WriteLine(basket.PrintBasket());
