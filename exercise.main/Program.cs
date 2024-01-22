using System;
using System.Collections.Generic;
using System.Linq;

namespace exercise.main
{
    class Program
    {
        static Basket basket = new Basket();

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
            Console.WriteLine("4. Change basket capacity");
            Console.WriteLine("5. Exit");

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
                    ChangeBasketCapacity();
                    return true;
                case "5":
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
                    basket.AddItem(products[choice - 1]);

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
            if (basket.GetBasketCount() == 0)
            {
                Console.WriteLine("Basket is empty.");
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Choose an item to remove from the basket:");
            for (int i = 0; i < basket.GetBasketCount(); i++)
            {
                Console.WriteLine($"{i + 1}. {basket.GetItem(i).Name} - {basket.GetItem(i).Variant} - ${basket.GetItem(i).Price}");
            }

            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= basket.GetBasketCount())
            {
                basket.RemoveItem(choice - 1);
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
            basket.ShowReceipt();
        }

        private static void ChangeBasketCapacity()
        {
            Console.Clear();
            Console.WriteLine("Enter the new basket capacity:");
            if (int.TryParse(Console.ReadLine(), out int newCapacity))
            {
                basket.ChangeBasketCapacity(newCapacity);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
