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

Bagel bagel3 = ChosenItem.MakeBagel("BGLP", 0.49, "Bagel", "Plain", "");

List<Item> preselection2 = basket.MakeNew();
preselection2.Add(bagel2);

preselection.Add(bagel1);

List<Item> preselection3 = basket.MakeNew();

preselection3.Add(bagel3);



basket.AddToBasket(1, preselection);
basket.AddToBasket(2, preselection);
basket.AddToBasket(3, preselection);
basket.AddToBasket(4, preselection);
basket.AddToBasket(5, preselection);
basket.AddToBasket(6, preselection);
basket.AddToBasket(7, preselection);
basket.AddToBasket(8, preselection);
basket.AddToBasket(9, preselection);
basket.AddToBasket(10, preselection);
basket.AddToBasket(11, preselection);
basket.AddToBasket(12, preselection);

basket.AddToBasket(13, preselection2);
basket.AddToBasket(14, preselection2);
basket.AddToBasket(15, preselection2);
basket.AddToBasket(16, preselection2);
basket.AddToBasket(17, preselection2);
basket.AddToBasket(18, preselection2);

basket.AddToBasket(19, preselection3);
basket.AddToBasket(20, preselection3);


Console.WriteLine(basket.PrintBasket());



