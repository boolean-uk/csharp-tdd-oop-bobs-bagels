// See https://aka.ms/new-console-template for more information
using exercise.main;




ProductList productList = new ProductList();
Basket basket = new Basket();
Discounts discounts = new Discounts(basket._basket);
ReceiptHelper rh = new ReceiptHelper(basket, discounts);


for (int i = 0; i < 19; i++)
{
    basket.AddItem("Bagel", "Onion");
}

basket.AddItem("Bagel", "Everything");
basket.AddItem("Bagel", "Everything");
basket.AddItem("Coffee", "Black");

//discounts.CalculateDiscount();

rh.printReceipt();
