// See https://aka.ms/new-console-template for more information
using workshop.main;

class Receipt
{
    static void Main()
    {
        Inventory inventory = new Inventory();
        OrderManager orderManager = new OrderManager();

        // Create a sample order with quantities
        Dictionary<string, int> orderItems = new Dictionary<string, int>
        {
            { "BGLO", 2 },
            { "BGLP", 16 },
            { "BGLE", 6 },
            { "COF", 3 }
            // Add other items as needed
        };

        // Display the order summary
        orderManager.DisplayOrderSummary(orderItems, inventory);
    }
}


