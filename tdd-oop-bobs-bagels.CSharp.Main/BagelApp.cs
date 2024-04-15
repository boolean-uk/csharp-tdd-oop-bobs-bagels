using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using tdd_oop_bobs_bagels.CSharp.Main;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class BagelApp
    {
        private bool running = true;
        public Basket basket = new Basket();
        public BagelApp()
        {
            while (running)
            { 
                Welcome();
                Console.WriteLine("Enter your choice...");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "m":
                    case "M":
                        Console.Clear();
                        Console.WriteLine("Getting Menu");
                        SeeMenu();
                        break;
                    case "q":
                    case "Q":
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        Stop();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Try again..");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                }
            }
        }
        
        private void SeeMenu()
        {
            while (running)
            {
                Console.Clear();
                Console.WriteLine("             Bob's Bagels Menu             ");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
                Console.WriteLine(" ID | Price | Item      ");
                DisplayMenu();
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                DiscountMenu();
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("To add an item, type its ID and press Enter");
                Console.WriteLine("To add a special bagel offer, type its ID followed by D (e.g. B2D)");
                Console.WriteLine("To remove B1, type B1R and press Enter");
                Console.WriteLine("P: Place completed order");
                Console.WriteLine("Q: Quit");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
                Console.WriteLine(basket.ViewBasket());
                Console.WriteLine("Your choice:");
                string input = Console.ReadLine();

                //choices: 
                //add item to basket -> basket add method
                //view basket
                //view cost
                //quit
                switch (input)
                {
                    case "B1D": //6 onion bagels
                        for (int i=0; i<6; i++)
                        {
                            basket.AddItem("B1");
                        }
                        Console.Clear();
                        break;
                    case "B2D": //12 plain bagels
                        for (int i = 0; i<12; i++)
                        {
                            basket.AddItem("B2");
                        }
                        Console.Clear();
                        break;
                    case "B3D": //6 everything bagels
                        for (int i = 0; i<6; i++)
                        {
                            basket.AddItem("B3");
                        }
                        Console.Clear();
                        break;
                    case "B1":
                    case "B2":
                    case "B3":
                    case "B4":
                    case "C1":
                    case "C2":
                    case "C3":
                    case "C4":
                    case "F1":
                    case "F2":
                    case "F3":
                    case "F4":
                    case "F5":
                    case "F6":
                        basket.AddItem(input);
                        //Thread.Sleep(1500);
                        Console.Clear();
                        break;
                    case "B1R":
                    case "B2R":
                    case "B3R":
                    case "B4R":
                    case "C1R":
                    case "C2R":
                    case "C3R":
                    case "C4R":
                    case "F1R":
                    case "F2R":
                    case "F3R":
                    case "F4R":
                    case "F5R":
                    case "F6R":
                        basket.RemoveItem(input);
                        Console.Clear();
                        break;
                    case "P":
                    case "p":
                        Console.Clear();
                        Console.WriteLine("Processing payment");
                        Thread.Sleep(1500);
                        Console.Clear();
                        Console.WriteLine(basket.GetReceipt());
                        Console.WriteLine("\nPress Enter to Exit");
                        string exit = Console.ReadLine();
                        switch (exit) { default: Stop(); break; }
                        break;
                    case "007":
                        Console.Clear();
                        Console.WriteLine("Hello Manager");
                        ManagerAccess(input);
                        Console.Clear();
                        break;
                    case "q":
                    case "Q":
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        Stop();
                        break;
                    default:
                        Console.WriteLine("Not a valid entry");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                }
            }
        }

        private void Welcome()
        {
            Console.WriteLine(" Welcome to Bobs Bagels! ");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("M: View our Menu");
            Console.WriteLine("Q: Quit");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
        }

        private void DisplayMenu()
        {
            Inventory BobsInventory = new Inventory();
            BobsInventory.SetInventory();
            StringBuilder menu = new StringBuilder();

            //Console.Clear();
            //Console.WriteLine("             Bob's Bagels Menu             ");
            //Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            //Console.WriteLine(" ID | Price | Item      ");
            foreach (Item i in BobsInventory.Stock)
            {
                menu.AppendLine($" {i.ID} |  {i.Price} | {i.Variant} {i.Name}");
            }
            
            Console.WriteLine(menu.ToString());
            //Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }

        private void DiscountMenu()
        {
            StringBuilder discountmenu = new StringBuilder();
            discountmenu.AppendLine("Special Offers:");
            discountmenu.AppendLine("Onion Bagel: 6 for 2.49");
            discountmenu.AppendLine("Plain Bagel: 12 for 3.99");
            discountmenu.AppendLine("Everything Bagel: 6 for 2.49");
            discountmenu.AppendLine("Black Coffee & Bagel for 1.25");
            Console.WriteLine(discountmenu.ToString());
        }

        private void ManagerAccess(string managerCode)
        {
            string inputNewMax = Console.ReadLine();
            int NewMax = Int32.Parse(inputNewMax);
            basket.EditMaximum(managerCode, NewMax);
            Console.WriteLine($"New Capacity: {NewMax}");
        }


        private void Stop()
        {
            running = false;
        }
    }
}

