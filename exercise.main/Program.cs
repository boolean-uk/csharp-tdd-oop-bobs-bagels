// See https://aka.ms/new-console-template for more information
using exercise.main.Classes;
using exercise.main.Enums;

Order _order;
Inventory _inventory;
Basket _basket;


_order = new Order();

Product bagelOnion = new Product("BGLO", 0.49, ProductType.Bagel, "Onion");
Product bagelPlain = new Product("BGLP", 0.39, ProductType.Bagel, "Plain");
Product bagelEverything = new Product("BGLE", 0.49, ProductType.Bagel, "Everything");
Product bagelSesame = new Product("BGLS", 0.49, ProductType.Bagel, "Sesame");

Product coffeeBlack = new Product("COFB", 0.99, ProductType.Coffee, "Black");
Product coffeeWhite = new Product("COFW", 1.19, ProductType.Coffee, "White");
Product coffeeCapuccino = new Product("COFC", 1.29, ProductType.Coffee, "Capuccino");
Product coffeeLatte = new Product("COFL", 1.29, ProductType.Coffee, "Latte");

Product fillingBacon = new Product("FILB", 0.12, ProductType.Filling, "Bacon");
Product fillingCheese = new Product("FILC", 0.12, ProductType.Filling, "Cheese");
Product fillingCreamCheese = new Product("FILX", 0.12, ProductType.Filling, "Cream Cheese");
Product fillingSalmon = new Product("FILS", 0.12, ProductType.Filling, "Smoked Salmon");
Product fillingHam = new Product("FILH", 0.12, ProductType.Filling, "Ham");
Product fillingEgg = new Product("FILE", 0.12, ProductType.Filling, "Egg");


_inventory = new Inventory();
_inventory.Add(bagelOnion, 100);
_inventory.Add(bagelPlain, 100);
_inventory.Add(bagelEverything, 100);
_inventory.Add(fillingBacon, 50);
_inventory.Add(fillingCheese, 50);
_inventory.Add(coffeeBlack, 10);
_inventory.Add(fillingEgg, 10);
_inventory.Add(bagelSesame, 10);
_inventory.Add(coffeeCapuccino, 10);
_inventory.Add(coffeeLatte, 10);
_inventory.Add(coffeeWhite, 10);
_inventory.Add(fillingCreamCheese, 10);
_inventory.Add(fillingHam, 10);
_inventory.Add(fillingSalmon, 10);
_inventory.Add(coffeeWhite, 10);

Discount discount = new Discount();
discount.AddQuantityDiscount("BGLO", 6, 0.45);
discount.AddQuantityDiscount("BGLP", 6, 0.45);
discount.AddQuantityDiscount("BGLE", 6, 0.45);
discount.AddQuantityDiscount("BGLS", 6, 0.45);

discount.AddQuantityDiscount("BGLO", 12, 1.89);
discount.AddQuantityDiscount("BGLP", 12, 1.89);
discount.AddQuantityDiscount("BGLE", 12, 1.89);
discount.AddQuantityDiscount("BGLS", 12, 1.89);

List<string> comboDiscount = new List<string>();
comboDiscount.Add("BGLP");
comboDiscount.Add("COFB");

discount.AddComboDiscount(comboDiscount, 1.25);
_basket = new Basket(discount);

_basket.Add(bagelOnion, 13);
_basket.Add(bagelPlain, 5);
_basket.Add(bagelEverything, 6);
_basket.Add(fillingEgg, 6);
_basket.Add(fillingCheese, 5);
_basket.Add(coffeeBlack, 5);

List<BasketItem> items = _basket.GetItems();

foreach (BasketItem item in items)
{
    OrderLine orderline = new OrderLine(item);
    _order.AddLine(orderline);
}

_basket.SubmitOrder();
