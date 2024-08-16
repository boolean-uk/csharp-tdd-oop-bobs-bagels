// See https://aka.ms/new-console-template for more information


using exercise.main;

Inventory inventory = new Inventory();
Basket basket = new Basket();

//inventory.Products.ForEach(x => { Console.WriteLine(x.SKU); });

Product product1 = inventory.Products[0];

Console.WriteLine(product1.SKU);

