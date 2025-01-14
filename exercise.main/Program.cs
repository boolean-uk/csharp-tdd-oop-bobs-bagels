// See https://aka.ms/new-console-template for more information
using exercise.main;

Console.WriteLine("Hello, World!");

Basket basket = new Basket();
basket.changeCapacity(100);
basket.AddItem("BGLO");
basket.AddItem("BGLO");
       
basket.AddItem("BGLP");
basket.AddItem("BGLP");
basket.AddItem("BGLP");
basket.AddItem("BGLP");
basket.AddItem("BGLP");
basket.AddItem("BGLP");
basket.AddItem("BGLP");
basket.AddItem("BGLP");
basket.AddItem("BGLP");
basket.AddItem("BGLP");
basket.AddItem("BGLP");
basket.AddItem("BGLP");
       
basket.AddItem("BGLE");
basket.AddItem("BGLE");
basket.AddItem("BGLE");
basket.AddItem("BGLE");
basket.AddItem("BGLE");
basket.AddItem("BGLE");
       
basket.AddItem("COFB");
basket.AddItem("COFB");
basket.AddItem("COFB");

Console.WriteLine(basket.PrintReceipt());

