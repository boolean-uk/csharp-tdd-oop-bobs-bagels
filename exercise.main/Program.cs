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
Product product6 = inventory.Products[5];
Product product7 = inventory.Products[6];
Product product8 = inventory.Products[7];
Product product9 = inventory.Products[8];


/*
//discount test
basket.Add(product1); //onion bagel * 6
basket.Add(product1);
basket.Add(product1);
basket.Add(product1);
basket.Add(product1);
basket.Add(product1);
basket.Add(product2); //plain bagel
basket.Add(product2); 
basket.Add(product2); 
basket.Add(product2); 
basket.Add(product2); 
basket.Add(product2); 
basket.Add(product3); //Everything bagel
basket.Add(product5); // coffee black
basket.Add(product8); // coffee latte
*/

//example order 2 from github
/*
basket.Add(product2);
basket.Add(product2);
basket.Add(product2);
basket.Add(product2);
basket.Add(product2);
basket.Add(product2);
basket.Add(product2);
*/

//test 2
//basket.Add(product1); //onion bagel * 6
//basket.Add(product1);
//basket.Add(product1);
//basket.Add(product1);
//basket.Add(product1);
//basket.Add(product1);
//basket.Add(product2); //plain bagel * 6
//basket.Add(product2);
//basket.Add(product2);
//basket.Add(product2);
//basket.Add(product2);
//basket.Add(product2);
//basket.Add(product3); //Everything bagel
//basket.Add(product5); // coffee black
//basket.Add(product8); // coffee latte

basket.Add(product1); //onion bagel * 6
basket.Add(product1);
basket.Add(product1);
basket.Add(product1);
basket.Add(product1);
basket.Add(product1);
basket.Add(product4); //Sesame bagel * 6
basket.Add(product4);
basket.Add(product4);
basket.Add(product4);
basket.Add(product4);
basket.Add(product4);
basket.Add(product2); //Plain bagel
basket.Add(product5); // coffee black
basket.Add(product8); // coffee latte





basket.GetTotalCost();

//receipt broken cus of discount! Fix
string receipt = basket.PrintReceipt();
Console.WriteLine(receipt);
