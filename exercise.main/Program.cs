// See https://aka.ms/new-console-template for more information
using exercise.main.Items;
using exercise.main;



/*Inventory inventory = new Inventory();
Basket basket = new Basket();

Bagel bagel1 = new Bagel("Plain");
Bagel bagel2 = new Bagel("Onion");

//test1:
Product product1 = new Product(bagel1);
Product product2 = new Product(bagel1);
Product product3 = new Product(bagel1);
Product product4 = new Product(bagel1);
Product product5 = new Product(bagel1);
Product product6 = new Product(bagel1);
Product product7 = new Product(bagel2);
Product product8 = new Product(bagel2);

//test2:
Product product7 = new Product(bagel1);
Product product8 = new Product(bagel1);

//Test3:
Product product9 = new Product(bagel1);
Product product10 = new Product(bagel1);
Product product11 = new Product(bagel1);
Product product12 = new Product(bagel1);

//Test4:
Product product13 = new Product(bagel1);
Product product14 = new Product(bagel1);
Product product15 = new Product(bagel1);
Product product16 = new Product(bagel1);
Product product17 = new Product(bagel1);
Product product18 = new Product(bagel1);


basket.setNewCapacity(18);
basket.Add(product1);
basket.Add(product2);
basket.Add(product3);
basket.Add(product4);
basket.Add(product5);
basket.Add(product6);
basket.Add(product7);
basket.Add(product8);
basket.Add(product7);
basket.Add(product8);
basket.Add(product9);
basket.Add(product10);
basket.Add(product11);
basket.Add(product12);
basket.Add(product13);
basket.Add(product14);
basket.Add(product15);
basket.Add(product16);
basket.Add(product17);
basket.Add(product18);

double totalprice = basket.getTotalPrice();  // Shall returns 2.94 if no discount
int productCount = basket._basket.Count(product => product.name == "Bagel");

Console.WriteLine("The bagel = " + productCount);
Console.WriteLine($"The total price is {basket.getTotalPrice()}, and the discount is {basket.checkDisCount()}");
Console.WriteLine($"The original price is: {0.39 * 6}");*/

Inventory inventory = new Inventory();
Basket basket = new Basket();


Bagel bagel1 = new Bagel("Plain");
Bagel bagel2 = new Bagel("Onion");
Coffe coffe1 = new Coffe("Black");

//test1:
Product product1 = new Product(bagel1);
Product product2 = new Product(bagel1);
Product product3 = new Product(bagel1);
Product product4 = new Product(bagel1);
Product product5 = new Product(bagel1);
Product product6 = new Product(bagel1);
Product product7 = new Product(bagel2);
Product product8 = new Product(bagel2);
Product product9 = new Product(bagel2);
Product product10 = new Product(bagel2);
Product product11 = new Product(bagel2);
Product product12 = new Product(bagel2);
Product product13 = new Product(coffe1);

basket.setNewCapacity(18);
basket.Add(product1);
basket.Add(product2);
basket.Add(product3);
basket.Add(product4);
basket.Add(product5);
basket.Add(product6);
basket.Add(product7);
basket.Add(product8);
basket.Add(product7);
basket.Add(product8);
basket.Add(product9);
basket.Add(product10);
basket.Add(product11);
basket.Add(product12);
basket.Add(product13);


Receipt receipt = new Receipt(basket);

receipt.printReceipt();


Message message = new Message(basket);

message.SendReceipt(basket);