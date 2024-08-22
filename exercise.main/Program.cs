
using exercise.main;
using exercise.main.Interfaces;
using exercise.main.Items;

// Originial BASKET (before refacotirng with interfaces and polymorphism)
/*
Inventory inventory = new Inventory();

inventory.getInventory().ForEach(x => Console.WriteLine(x.id + " " + x.price + " " + x.name + " " + x.variant));
Console.WriteLine("-------------------------------- \n");
Person person = new Person("Bob", Role.MANAGER);

Basket basket = new Basket();

Item wrongBagel = new Item("BGLW", 0.40, "Cake", "Wrong");
Item plainBagel = new Item("BGLP", 0.39, "Bagel", "Plain");
Item blackCoffe = new Item("COFB", 0.99, "Coffee", "Black");


basket.changeBasketCapacity(15, person.role);
// basket.addItem(plainBagel);   
//basket.removeBagelOrItem(plainBagel);

basket.addItem(plainBagel);
basket.addItem(blackCoffe);

basket.addItem(plainBagel);
basket.addItem(plainBagel);
basket.addItem(plainBagel);
basket.addItem(plainBagel);
basket.addItem(plainBagel);

basket.addItem(plainBagel);
basket.addItem(plainBagel);
basket.addItem(plainBagel);
basket.addItem(plainBagel);
basket.addItem(plainBagel);
basket.addItem(plainBagel);
basket.addItem(plainBagel);

// Console.WriteLine(basket.discount());

Console.WriteLine( "TOTALT:  " + basket.totalCost());

Console.WriteLine("\n");
// basket.Receipt();

Console.WriteLine($"\n New receipt \n");
basket.ReceiptWithDiscount();
*/

// ---------- NEW REFACTORED BASKET -----------------
Inventory2 inventory2 = new Inventory2();

inventory2.getInventory2().ForEach(x => Console.WriteLine(x.id + " " + x.price + " " + x.name + " " + x.variant));
Console.WriteLine("-------------------------------- \n");

Person person = new Person("Bob", Role.MANAGER);

Basket2 basket2 = new Basket2();

IItem bp = new Bagel() { id="BGLP", price=0.39, name="Bagel", variant="Plain" };

//Console.WriteLine(basket2.removeItem(bp));
Console.WriteLine(basket2.addItem(bp));

// Console.WriteLine(basket2.removeItem(bp));


