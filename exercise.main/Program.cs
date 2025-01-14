


using exercise.main;
using exercise.main.Discount;
using exercise.tests;

Inventory inventory = new Inventory();

DiscountManager discountManager = new DiscountManager(inventory);
CashRegister cashRegister = new CashRegister(inventory, discountManager);

Basket basket = new Basket(inventory, discountManager);


inventory.Add("BGLO", 	"Onion",          0.49f, 100);
inventory.Add("BGLP", 	"Plain",          0.39f, 100);
inventory.Add("BGLE", 	"Everything",     0.49f, 100);
inventory.Add("BGLS", 	"Sesame",         0.49f, 100);
inventory.Add("COFB", 	"Black",          0.99f, 100);
inventory.Add("COFW", 	"White",          1.19f, 100);
inventory.Add("COFC", 	"Capuccino",      1.29f, 100);
inventory.Add("COFL", 	"Latte",          1.29f, 100);
inventory.Add("FILB", 	"Bacon",          0.12f, 100);
inventory.Add("FILE", 	"Egg",            0.12f, 100);
inventory.Add("FILC", 	"Cheese",         0.12f, 100);
inventory.Add("FILX", 	"Cream Cheese",   0.12f, 100);
inventory.Add("FILS", 	"Smoked Salmon",  0.12f, 100);
inventory.Add("FILH",   "Ham",            0.12f, 100);


int nrOfBagelsForDiscount = 6;
float discountedPrice_6_for_2_49 = 2.49f;
var discountReq = new Dictionary<string, int> { { "BGLO", nrOfBagelsForDiscount } };
var d = new Discount_XforY(discountReq, discountedPrice_6_for_2_49, inventory);
discountManager.addDiscountType(d);

var discountReq_2 = new Dictionary<string, int> { { "BGLO", 1 }, { "COFB", 1 } };
var d2 = new Discount_XforY(discountReq_2, 1.25f, inventory);
discountManager.addDiscountType(d2);

var discountReq_3 = new Dictionary<string, int> { { "BGLP", 12 }};
var d3 = new Discount_XforY(discountReq_3, 3.99f, inventory);
discountManager.addDiscountType(d3);

var discountReq_4 = new Dictionary<string, int> { { "BGLE", 6 }};
var d4 = new Discount_XforY(discountReq_4, 2.49f, inventory);
discountManager.addDiscountType(d4);




var storeFrontExecutior = new StoreFrontExecutor(new TerminalStoreFront(inventory, basket, discountManager, cashRegister));

storeFrontExecutior.run();