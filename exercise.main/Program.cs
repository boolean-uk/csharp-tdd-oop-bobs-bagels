// See https://aka.ms/new-console-template for more information
using exercise.main;
Basket basket = new Basket();
Product prod = new Product("BGLO", 0.49d, "Bagel", "Onion", 3);
Product prod1 = new Product("BGLP", 0.39d, "Bagel", "Plain", 2);


basket.addProductToBasket(prod);
basket.addProductToBasket(prod1);

basket.WriteReceipt();



