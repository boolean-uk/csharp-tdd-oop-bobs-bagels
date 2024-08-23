// See https://aka.ms/new-console-template for more information
using exercise.main;
using System.Linq;

Basket basket = new Basket();
basket.Cap = 20;

Inventory.FillingStock = 20;
Inventory.BagelStock = 20;
Inventory.CoffeeStock = 20;

List<Item> preselection = basket.MakeNew();
Bagel bagel1 = ChosenItem.MakeBagel("BGLE", 0.49, "Bagel", "Everything", "");

Bagel bagel2 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
List<Item> preselection2 = basket.MakeNew();
preselection2.Add(bagel2);

preselection.Add(bagel1);


basket.AddToBasket(1, preselection);
basket.AddToBasket(2, preselection);
basket.AddToBasket(3, preselection);
basket.AddToBasket(4, preselection);
basket.AddToBasket(5, preselection);
basket.AddToBasket(6, preselection);

basket.AddToBasket(13, preselection2);

Console.WriteLine(basket.PrintBasket());



