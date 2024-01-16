using exercise.main;

class Program
{
    static List<Product> basket = new List<Product>();
    static void Main(string[] args)
    {
        Inventory inventory = new Inventory();
        bool showMenu = true;
        while (showMenu)
        {
            showMenu = MainMenu(inventory);
        }
    }

    private static bool MainMenu(Inventory inventory)
    {
        Console.Clear();
        Console.WriteLine("Welcome to Bob's Bagels - Best bagels in town!");
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Add item to basket");
        Console.WriteLine("2. Remove item from basket");
        Console.WriteLine("3. Show total price of basket");
        Console.WriteLine("4. Exit");

        switch (Console.ReadLine())
        {
            case "1":
                AddItemToBasket(inventory.Products);
                return true;
            case "2":
                RemoveItemFromBasket();
                return true;
            case "3":
                ShowReceipt();
                return true;
            case "4":
                return false;
            default:
                return true;

        }
    }

    private static void AddItemToBasket(List<Product> products)
    {
        Console.Clear();
        Console.WriteLine("Choose a product:");

        bool addingItems = true;       

        while (addingItems)
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name} - {products[i].Variant} - ${products[i].Price}");
            }

            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= products.Count)
            {
                basket.Add(products[choice - 1]);
                Console.WriteLine($"{products[choice - 1].Name} was added to the basket!");

                Console.WriteLine("Do you want to add another item? (Y/N)");
                string response = Console.ReadLine().Trim().ToUpper();

                if (response != "Y")
                {
                    addingItems = false;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }

        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    private static void RemoveItemFromBasket()
    {
        Console.Clear();
        if (basket.Count == 0)
        {
            Console.WriteLine("Basket is empty.");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Choose an item to remove from the basket:");
        for (int i = 0; i < basket.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {basket[i].Name} - {basket[i].Variant} - ${basket[i].Price}");
        }

        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= basket.Count)
        {
            Product removedItem = basket[choice - 1];
            basket.RemoveAt(choice - 1);
            Console.WriteLine($"{removedItem.Name} removed from the basket!");
        }
        else
        {
            Console.WriteLine("Invalid choice. Please try again.");
        }

        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    private static void ShowReceipt()
    {
        Console.Clear();

        if (basket.Count == 0)
        {
            Console.WriteLine("Basket is empty. Total price: $0.00");
        }
        else
        {
            Console.WriteLine("Items in the basket:");
            for (int i = 0; i < basket.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {basket[i].Name} - {basket[i].Variant} - ${basket[i].Price}");
            }

            double total = basket.Sum(item => item.Price);
            Console.WriteLine($"Total price: ${total}");
        }

        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

}