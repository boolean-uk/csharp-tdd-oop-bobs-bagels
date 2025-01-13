// See https://aka.ms/new-console-template for more information
using exercise.main.Communication;
using exercise.main.Models;

Console.WriteLine("Hello, World!");


Basket basket = new Basket(30);

Bagel bagel1 = new Bagel("BGLO");
Bagel bagel2 = new Bagel("BGLO");
Bagel bagel3 = new Bagel("BGLE");
Coffee coffee1 = new Coffee("COFB");
Coffee coffee2 = new Coffee("COFB");

Filling filling1 = new Filling("FILS");
Filling filling2 = new Filling("FILH");
bagel1.AddFilling(filling1);
bagel2.AddFilling(filling2);
basket.Add(bagel1);
basket.Add(bagel2);
basket.Add(bagel3);
basket.Add(coffee1);
basket.Add(coffee2);

Receipt receipt = new Receipt(basket);

decimal totalprice = basket.GetPriceWithDiscounts();


ICommunicator communicator = new ConsoleCommunicator();
communicator.Send(receipt.FullReceipt());


