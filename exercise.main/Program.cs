using exercise.main;

Inventory inventory = new Inventory();
Basket basket = new Basket(inventory);
basket.ChangeCapacity(20);


for (int i = 0; i < 2; i++)
{
    basket.AddProduct("BGLO");
}
basket.AddFilling(0, "FILB");
basket.AddFilling(1, "FILE");
basket.AddFilling(1, "FILH");

Receipt receipt = new Receipt(basket);

var receiptText = receipt.PrintRecipt();
receipt.PrintReceiptToTerminal(receiptText);