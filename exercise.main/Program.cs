// See https://aka.ms/new-console-template for more information
using exercise.main;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Threading.Tasks;
using System;


Bagel bagel = new Bagel("BGLO", 0.49, "Bagel", "Onion");
Bagel bagel2 = new Bagel("BGLO", 0.49, "Bagel", "Onion");
Bagel bagel3 = new Bagel("BGLO", 0.49, "Bagel", "Onion");
Bagel bagel4 = new Bagel("BGLO", 0.49, "Bagel", "Onion");
Bagel bagel5 = new Bagel("BGLO", 0.49, "Bagel", "Onion");
Bagel bagel6 = new Bagel("BGLO", 0.49, "Bagel", "Onion");
Coffee coffee = new Coffee("COFB", 0.99, "Coffee", "Black");
Filling filling = new Filling("FILB", 0.12, "Filling", "Bacon");
Bagel bagel1 = new Bagel("BGLP", 0.39, "Bagel", "Plain");
Basket basket = new Basket(20);
bagel.AddFilling("Bacon");
bagel.AddFilling("Bacon");
bagel.AddFilling("Bacon");
bagel2.AddFilling("Bacon");
bagel2.AddFilling("Bacon");
bagel2.AddFilling("Bacon");
basket.AddItem(bagel);
basket.AddItem(bagel2);
basket.AddItem(bagel3);
basket.AddItem(bagel4);
basket.AddItem(bagel5);
basket.AddItem(bagel6);
basket.AddItem(coffee);
basket.AddItem(filling);
basket.AddItem(bagel1);

Receipt receipt = new Receipt(basket);
receipt.PrintReceipt();



