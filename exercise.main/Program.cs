// See https://aka.ms/new-console-template for more information
using BobsBagels.main;


var inventory = new Inventory();
var shopper = new Shopper();
var manager = new Manager();
manager.ChangeCapacity(16);


// act

var BGLP = inventory.SearchInventory("BGLP");
shopper.Basket.Add(BGLP, 16);
shopper.PrintReceipt();