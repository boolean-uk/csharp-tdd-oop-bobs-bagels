using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Shop
    {

        public Basket basket;
        public ProductList productList;
        public Shop()
        {
            basket = new Basket();
            productList = new ProductList();
        }

        public void intialize()
        {
            string choice = "m";
            Console.WriteLine("Hello, welcome to Bobs Bagels");
            Console.WriteLine("For Menu, type m");
            Console.WriteLine("To exit, type e");
            //choice = Console.ReadLine();

            if (choice == "e")
            {
                return;
            }

            if (choice == "m")
            {
                printMenu();

                Console.WriteLine("Options: ");
                Console.WriteLine("To order, type order");
                string secondChoice = Console.ReadLine();

                if (secondChoice == "order")
                {
                    bool ordercomplete = false;
                    while (!ordercomplete)
                    {
                        Console.WriteLine("What product would you like to order?");
                        string thirdChoice = Console.ReadLine();
                        if (thirdChoice == "Bagel")
                        {
                            Console.WriteLine("Variant of Bagel?");
                            string bagelType = Console.ReadLine();
                            basket.AddItem(thirdChoice, bagelType);

                        }
                        Console.WriteLine("Would you like to order more? y/n");
                        string fourthChoice = Console.ReadLine();

                        if (fourthChoice == "n")
                        {
                            ordercomplete = true;
                        }
                        else if (fourthChoice == "y")
                        {

                        }
                    }
                }


            }
        }

        public void printMenu()
        {

            foreach (var item in productList.products)
            {
                Console.WriteLine($"{item.Name} {item.Variant} {item.Price}");
            }
        }

    }
}
