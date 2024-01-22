using exercise.main;
using static exercise.main.BasketManager;
using static exercise.main.Inventory;

class Program
{
    static void Main(string[] args)
    {
        // Initialize the inventory and basket manager
        Inventory inventory = new Inventory();
        Order order = new Order();

        // Add items to the order
        InventoryItem onionVariant = inventory.GetItem("BGLO");
        InventoryItem everythingVariant = inventory.GetItem("BGLE");
        InventoryItem blackCoffee = inventory.GetItem("COFB");

        // Adding 2 Onion Bagels
        for (int i = 0; i < 2; i++)
        {
            order.Add(new Bagel(onionVariant));
        }

        // Adding 12 Plain Bagels
        for (int i = 0; i < 8; i++)
        {
            order.Add(new Bagel(everythingVariant));
        }

        for (int i = 0; i < 3; i++)
        {
            order.Add(new Bagel(blackCoffee));
        }

        // Create and display the receipt
        ReceiptManager receiptManager = new ReceiptManager();
        receiptManager.DisplayReceipt(order);
    }
}
