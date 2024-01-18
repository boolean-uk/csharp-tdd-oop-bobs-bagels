// See https://aka.ms/new-console-template for more information

using exercise.main;

Basket basket = new Basket(5);
Bagel bagel = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
Bagel bagel2 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
Bagel bagel3 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");
Bagel bagel4 = new Bagel("BGLO", 0.49m, ProductType.bagel, "Onion");

Coffee coffee = new Coffee("COFB", 0.99m, ProductType.coffee, "Black");

basket.AddToBasket(bagel);
basket.AddToBasket(bagel2);
basket.AddToBasket(bagel3);
basket.AddToBasket(bagel4);
basket.AddToBasket(coffee);

Reciept reciept = new Reciept(basket);

reciept.PrintReciept();