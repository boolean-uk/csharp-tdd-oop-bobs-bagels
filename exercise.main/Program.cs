
using exercise.main;

Basket basket = new Basket();
basket.AddItem("Onion");
basket.AddItem("Onion");
basket.AddItem("Black");


string printedReceipt = basket.PrintReceipt;
Console.WriteLine(printedReceipt);



// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
