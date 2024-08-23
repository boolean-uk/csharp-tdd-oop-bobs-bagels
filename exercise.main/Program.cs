// See https://aka.ms/new-console-template for more information
using exercise.main;
using System.Linq;

Basket basket = new Basket();
basket.Cap = 20;

Inventory.FillingStock = 20;
Inventory.BagelStock = 20;
Inventory.CoffeeStock = 20;

List<Item> preselection = basket.MakeNew();
List<Filling> fillings = new List<Filling>();
Filling filling1 = ChosenItem.ChooseFillings("FILE", 0.12, "Filling", "Egg");
fillings.Add(filling1);
Bagel bagel1 = ChosenItem.MakeBagel("BGLE", 0.49, "Bagel", "Everything", "");
bagel1 = ChosenItem.AddFillings(bagel1, fillings);
Coffee cup1 = new Coffee("COFB", 0.99, "Coffee", "Black");
Coffee cup2 = new Coffee("COFB", 0.99, "Coffee", "Black");
Coffee cup3 = new Coffee("COFB", 0.99, "Coffee", "Black");

Bagel bagel2 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
List<Item> preselection2 = basket.MakeNew();
preselection2.Add(bagel2);

preselection.Add(cup1);
preselection.Add(cup2);
preselection.Add(cup3);
preselection.Add(bagel1);

preselection.Add(filling1);

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

Console.WriteLine(basket.PrintBasket());



