// See https://aka.ms/new-console-template for more information

using exercise.main;

Basket basket = new Basket();

string product1 = "BGLO";
string product2 = "BGLP";
string product3 = "BGLE";
string product4 = "COFB";
double totalPrice = 10.43;

basket.AddMultible(product1, 2);
basket.AddMultible(product2, 12);
basket.AddMultible(product3, 6);
basket.AddMultible(product4, 3);

Reciept reciept = new Reciept(basket.basket, totalPrice);

reciept.PrintReciept();
