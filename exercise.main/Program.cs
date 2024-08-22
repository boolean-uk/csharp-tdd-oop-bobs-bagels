// See https://aka.ms/new-console-template for more information
using exercise.main;
using System.Linq;

Basket basket = new Basket();
basket.Cap = 20;

Inventory.FillingStock = 20;
Inventory.BagelStock = 20;
Inventory.CoffeeStock = 20;


List<Item> preselection3 = basket.MakeNew();
Bagel bagel3 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
preselection3.Add(bagel3);
List<Item> selectedItems3 = basket.AddToSelection(preselection3);
basket.AddToBasket(3, selectedItems3);

List<Item> preselection4 = basket.MakeNew();
Bagel bagel4 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
preselection4.Add(bagel4);
List<Item> selectedItems4 = basket.AddToSelection(preselection4);
basket.AddToBasket(4, selectedItems4);

List<Item> preselection5 = basket.MakeNew();
Bagel bagel5 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
preselection5.Add(bagel5);
List<Item> selectedItems5 = basket.AddToSelection(preselection5);
basket.AddToBasket(5, selectedItems5);

List<Item> preselection6 = basket.MakeNew();
Bagel bagel6 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
preselection6.Add(bagel6);
List<Item> selectedItems6 = basket.AddToSelection(preselection6);
basket.AddToBasket(6, selectedItems6);

List<Item> preselection7 = basket.MakeNew();
Bagel bagel7 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
preselection7.Add(bagel7);
List<Item> selectedItems7 = basket.AddToSelection(preselection7);
basket.AddToBasket(7, selectedItems7);

List<Item> preselection8 = basket.MakeNew();
Bagel bagel8 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
preselection8.Add(bagel8);
List<Item> selectedItems8 = basket.AddToSelection(preselection8);
basket.AddToBasket(8, selectedItems8);

//List<Item> preselection9 = basket.MakeNew();
//Bagel bagel9 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
//preselection9.Add(bagel9);
//List<Item> selectedItems9 = basket.AddToSelection(preselection9);
//basket.AddToBasket(9, selectedItems9);

//List<Item> preselection10 = basket.MakeNew();
//Bagel bagel10 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
//preselection10.Add(bagel10);
//List<Item> selectedItems10 = basket.AddToSelection(preselection10);
//basket.AddToBasket(10, selectedItems10);

//List<Item> preselection11 = basket.MakeNew();
//Bagel bagel11 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
//preselection11.Add(bagel11);
//List<Item> selectedItems11 = basket.AddToSelection(preselection11);
//basket.AddToBasket(11, selectedItems11);

//List<Item> preselection12 = basket.MakeNew();
//Bagel bagel12 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
//preselection12.Add(bagel12);
//List<Item> selectedItems12 = basket.AddToSelection(preselection12);
//basket.AddToBasket(12, selectedItems12);

//List<Item> preselection13 = basket.MakeNew();
//Bagel bagel13 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
//preselection13.Add(bagel13);
//List<Item> selectedItems13 = basket.AddToSelection(preselection13);
//basket.AddToBasket(13, selectedItems13);

//List<Item> preselection14 = basket.MakeNew();
//Bagel bagel14 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
//preselection14.Add(bagel14);
//List<Item> selectedItems14 = basket.AddToSelection(preselection14);
//basket.AddToBasket(14, selectedItems14);

//List<Item> preselection15 = basket.MakeNew();
//Bagel bagel15 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
//preselection15.Add(bagel15);
//List<Item> selectedItems15 = basket.AddToSelection(preselection15);
//basket.AddToBasket(15, selectedItems15);

//List<Item> preselection16 = basket.MakeNew();
//Bagel bagel16 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
//preselection16.Add(bagel16);
//List<Item> selectedItems16 = basket.AddToSelection(preselection16);
//basket.AddToBasket(16, selectedItems16);

//List<Item> preselection17 = basket.MakeNew();
//Bagel bagel17 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
//preselection17.Add(bagel17);
//List<Item> selectedItems17 = basket.AddToSelection(preselection17);
//basket.AddToBasket(17, selectedItems17);

//List<Item> preselection18 = basket.MakeNew();
//Bagel bagel18 = ChosenItem.MakeBagel("BGLO", 0.49, "Bagel", "Onion", "");
////preselection18.Add(bagel18);
////List<Item> selectedItems18 = basket.AddToSelection(preselection18);
////basket.AddToBasket(18, selectedItems18);

//Filling filling1 = ChosenItem.ChooseFillings("FILE", 0.12, "Filling", "Egg");
//List<Filling> thesefillings = new List<Filling>();
//thesefillings.Add(filling1);
//bagel18 = ChosenItem.AddFillings(bagel18, thesefillings);
//preselection18.Add(bagel18);
//preselection18.Add(filling1);
//List<Item> selectedItems18 = basket.AddToSelection(preselection18);
//basket.AddToBasket(18, selectedItems18);



Console.WriteLine(basket.PrintBasket());



