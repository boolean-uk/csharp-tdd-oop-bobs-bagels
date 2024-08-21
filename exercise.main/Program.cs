using exercise.main;
using exercise.main.Items;
using exercise.main.Persons;

Customer customer = new Customer("customer", false);
ShopInventory shopInventory = new ShopInventory();
customer.Basket.Capacity = 50;

// 2 onion Bagel
Bagel onionBagel = shopInventory.GetBagelBySkuID("BGLO");

Filling creamCheeseFilling = shopInventory.GetFillingBySkuID("FILX");
customer.AddFillingToBagel(onionBagel, creamCheeseFilling);

customer.AddItemToBasket(onionBagel);
customer.AddItemToBasket(onionBagel);


// 12 Plain Bagel
Bagel plainBagel = shopInventory.GetBagelBySkuID("BGLP");
for (int i = 0; i < 12; i++)
{
    customer.AddItemToBasket(plainBagel);
}

// 6 Everything Bagel
Bagel everythingBagel = shopInventory.GetBagelBySkuID("BGLE");
for (int i = 0; i < 6; i++)
{
    customer.AddItemToBasket(everythingBagel);
}

// 3 Black Coffee
Coffee coffee = shopInventory.GetCoffeeBySkuID("COFB");
customer.AddItemToBasket(coffee);
customer.AddItemToBasket(coffee);
customer.AddItemToBasket(coffee);

string shopName = "Bob's Bagels";

Receipt receipt = new Receipt(customer.Basket.ItemsInBasket, shopName, customer.GetTotalSumOfBasket());

receipt.PrintReceipt();