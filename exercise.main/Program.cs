// See https://aka.ms/new-console-template for more information
using exercise.main;

Console.WriteLine("Hello, World!");

IInventory inventory = new WholeInventory();
Basket b = new Basket(inventory);

b.ChangeCapacity(30);

Bagel rbb = (Bagel)inventory.getInventory()["BGLO"];
b.AddItem(rbb);


Bagel bagel = (Bagel)inventory.getInventory()["BGLE"];
Bagel bagel2 = (Bagel)inventory.getInventory()["BGLE"];
Bagel bagel3 = (Bagel)inventory.getInventory()["BGLE"];
Bagel bagel4 = (Bagel)inventory.getInventory()["BGLE"];
Bagel bagel5 = (Bagel)inventory.getInventory()["BGLE"];
Bagel bagel6 = (Bagel)inventory.getInventory()["BGLE"];

b.AddItem(bagel);
b.AddItem(bagel2);
b.AddItem(bagel3);
b.AddItem(bagel4);
b.AddItem(bagel5);
b.AddItem(bagel6);


b.BundleOrder("b6", new List<Item> { bagel, bagel2, bagel3, bagel4, bagel5, bagel6 });

Bagel b1 = (Bagel)inventory.getInventory()["BGLO"];
Bagel b2 = (Bagel)inventory.getInventory()["BGLO"];
Bagel b3 = (Bagel)inventory.getInventory()["BGLO"];
Bagel b4 = (Bagel)inventory.getInventory()["BGLO"];
Bagel b5 = (Bagel)inventory.getInventory()["BGLO"]; 
Bagel b6 = (Bagel)inventory.getInventory()["BGLO"];
Bagel b7 = (Bagel)inventory.getInventory()["BGLO"];
Bagel b8 = (Bagel)inventory.getInventory()["BGLO"];
Bagel b9 = (Bagel)inventory.getInventory()["BGLO"];
Bagel b10 = (Bagel)inventory.getInventory()["BGLO"];
Bagel b11 = (Bagel)inventory.getInventory()["BGLO"];
Bagel b12 = (Bagel)inventory.getInventory()["BGLO"];

b.AddItem(b1);
b.AddItem(b2);
b.AddItem(b3);
b.AddItem(b4);
b.AddItem(b5);
b.AddItem(b6);
b.AddItem(b7);
b.AddItem(b8);
b.AddItem(b9);
b.AddItem(b10);
b.AddItem(b11);
b.AddItem(b12);

b.BundleOrder("b12", new List<Item> { b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12 });

Bagel bc1 = (Bagel)inventory.getInventory()["BGLO"];
Coffee bc2 = (Coffee)inventory.getInventory()["COFB"];

b.AddItem(bc1);
b.AddItem(bc2);

b.BundleOrder("bac", new List<Item> { bc1, bc2 });

b.PrintReceipt();

/**
Bagel bagel7 = (Bagel)inventory.getInventory()["BGLE"];
Bagel bagel8 = (Bagel)inventory.getInventory()["BGLE"];
Bagel bagel9 = (Bagel)inventory.getInventory()["BGLE"];
Bagel bagel10 = (Bagel)inventory.getInventory()["BGLE"];
Bagel bagel11 = (Bagel)inventory.getInventory()["BGLE"];
Bagel bagel12 = (Bagel)inventory.getInventory()["BGLE"];
Bagel bagel13 = (Bagel)inventory.getInventory()["BGLE"];
Bagel bagel14 = (Bagel)inventory.getInventory()["BGLE"];
Bagel bagel15 = (Bagel)inventory.getInventory()["BGLE"];
Bagel bagel16 = (Bagel)inventory.getInventory()["BGLE"];
Bagel bagel17 = (Bagel)inventory.getInventory()["BGLE"];
Bagel bagel18 = (Bagel)inventory.getInventory()["BGLE"];
**/
