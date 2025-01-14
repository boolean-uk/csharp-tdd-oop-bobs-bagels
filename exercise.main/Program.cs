// See https://aka.ms/new-console-template for more information

using exercise.main;
Basket basket = new Basket();
basket.AddProduct("BGLO");
basket.AddProduct("COFB");

basket.getVarPrice("Onion");
basket.getVarPrice("Black");
basket.PrintReceiptDiscount();
Console.WriteLine("Hello, World!");
