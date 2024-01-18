using exercise.main;

Customer c = new Customer();
Item plain = DefaultInventory.FindItemInInventoryBySKU("BGLP");
Item everything = DefaultInventory.FindItemInInventoryBySKU("BGLE");
Item coffee = DefaultInventory.FindItemInInventoryBySKU("COFB");
for (int i = 0; i < 26; i++)
{
    c.basket.PutInBasket(plain);
}
c.basket.PutInBasket(coffee);
c.basket.PutInBasket(everything);


Receipt r = new Receipt("Bob s bagels", c);
r.PrintReceipt();

