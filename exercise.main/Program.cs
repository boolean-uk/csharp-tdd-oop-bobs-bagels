// See https://aka.ms/new-console-template for more information


using exercise.main;

Inventory inventory = new Inventory();
Basket basket = new Basket();

//inventory.Products.ForEach(x => { Console.WriteLine(x.SKU); });

Product product1 = inventory.Products[0];
Product product2 = inventory.Products[1];
Product product3 = inventory.Products[2];
Product product4 = inventory.Products[3];
Product product5 = inventory.Products[4];
basket.Add(product1);
basket.Add(product2);
basket.Add(product2);
basket.Add(product2);
basket.Add(product4);
basket.Add(product5);
basket.Add(product5);
basket.Add(product5);


basket.PrintReceipt();
