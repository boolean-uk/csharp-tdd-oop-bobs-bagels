
//SetUp
using exercise.main;

Basket basket = new Basket();
basket.Capacity = 10;
basket.IsPurchased = true;
InventoryProducts bagelOnion = new InventoryProducts("BGLO", 0.49d, "Bagel", "Onion");
InventoryProducts bagelSesame = new InventoryProducts("BGLS", 0.49d, "Bagel", "Sesame");
InventoryProducts coffeeWhite = new InventoryProducts("COFW", 1.19d, "Coffee", "White");
InventoryProducts fillingSalmon = new InventoryProducts("FILS", 0.12d, "Filling","Smoked Salmon");
basket.Items.Add(bagelOnion);
basket.Items.Add(coffeeWhite);
basket.Items.Add(fillingSalmon);
basket.Items.Add(bagelOnion);
basket.Items.Add(bagelOnion);
for(int i = 0; i < 12; i++)
{
    basket.Items.Add(bagelSesame);

}


//Execute

Receipt receipt = basket.CreateReceipt();

Console.WriteLine(receipt.ReceiptToString());




















// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
