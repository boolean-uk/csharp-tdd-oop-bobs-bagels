// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using exercise.main;

Console.WriteLine("- - - Welcome to Bob's Bagels! - - -");
Console.WriteLine("Actions:\n v: View basket \n m: See menu\n a: Add [ID] to basket\n r: Remove from basket\n f: Add filling\n rf: remove filling\n ms: Set new basket size\n e: Exit\n");

Basket basket = new Basket() { Items = new List<Item>(), MaxSize = 10 };

string action = Console.ReadLine();

while (action != "e")
{
    Console.WriteLine("Actions:\n v: View basket \n m: See menu\n a: Add [ID] to basket\n r: Remove from basket\n f: Add filling\n rf: remove filling\n ms: Set new basket size\n e: Exit\n");

    switch (action)
    {
        case "m":
            Console.WriteLine("\nID   NAME   VARIANT  PRICE");
            Basket.StockItems.ForEach(i => Console.WriteLine(i.getItemToString()));
            break;

        case "v":
            Console.WriteLine("\nID   NAME   VARIANT  PRICE");
            basket.Items.ForEach(i => Console.WriteLine(i.getItemToString()));
            Console.WriteLine("Fillings: ");
            try { basket.Items.ForEach(i => i.getFillings().ForEach(j => Console.WriteLine(j.getFillingToString()))); }
            catch(Exception ex) { }   

            Console.WriteLine($"_______________________\nTotal cost: £{basket.getTotalCost()}");
            break;

        case "a":
            Console.WriteLine("What [ID] would you like to add to basket? (eg. BGLO)\n b: Back\n");
            string addItemId = Console.ReadLine();
            while (addItemId != "b") 
            {
                try 
                {
                    basket.addToBasket(addItemId);
                    Console.WriteLine("Added to basket!\n");
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                
                addItemId = Console.ReadLine();
            }
            break;

        case "r":
            Console.WriteLine("What [ID] would you like to remove from basket? (eg. BGLO)\n b: Back\n");
            string removeItemId = Console.ReadLine();
            while (removeItemId != "b")
            {
                try 
                { 
                    basket.removeFromBasket(removeItemId);
                    Console.WriteLine("Removed from basket!\n");
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }

                removeItemId = Console.ReadLine();
            }
            break;

        case "f":
            if (!basket.Items.Any(i => i.Name == "Bagel"))
            { 
                Console.WriteLine("No bagel in basket");
                break;
            }
            Console.WriteLine("What bagel [ORDER] would you like yo add filling to? (eg. 1)\n");
            Console.WriteLine("\nORDER ID   NAME   VARIANT  PRICE");
            basket.Items.ForEach(i => Console.WriteLine($"{basket.Items.IndexOf(i)}: {i.getItemToString()}"));

            string order = Console.ReadLine();
            int orderNr = 0;
            if (Int32.TryParse(order, out orderNr) && (basket.Items.Count >= orderNr || orderNr >= 0))
            {
                Console.WriteLine("What filling would you like to add? (eg. FILE)\n b: Back\n");
                string fill = Console.ReadLine();
                while (fill != "b")
                {
                    try
                    {
                        basket.Items[orderNr].addFilling(fill);
                        Console.WriteLine("Added to filling to bagel!\n");
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }

                    fill = Console.ReadLine();
                }
                break;
            }
            else { Console.WriteLine("Invalid order. ") ; }
            break;


        case "rf":
            if (!basket.Items.Any(i => i.getFillings().Count > 0))
            {
                Console.WriteLine("No fillings to remove");
                break;
            }
            Console.WriteLine("What bagel [ORDER] would you like remove filling from? (eg. 1)\n");
            Console.WriteLine("\nORDER ID   NAME   VARIANT  PRICE");
            basket.Items.ForEach(i => Console.WriteLine($"{basket.Items.IndexOf(i)}: {i.getItemToString()}"));

            string orderF = Console.ReadLine();
            int orderNrF = 0;
            if (Int32.TryParse(orderF, out orderNrF) && (basket.Items.Count >= orderNrF || orderNrF >= 0))
            {
                Console.WriteLine("What filling would you like to remove? (eg. FILE)\n b: Back\n");
                string fill = Console.ReadLine();
                while (fill != "b")
                {
                    try
                    {
                        basket.Items[orderNrF].removeFilling(fill);
                        Console.WriteLine("Removed filling from bagel!\n");
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }

                    fill = Console.ReadLine();
                }
                break;
            }
            else { Console.WriteLine("Invalid order."); }
            break;

        case "ms":
            Console.WriteLine("Manager mode activated\n Set new size of basket: ");
            string newStr = Console.ReadLine();

            int newSize = 0;
            if (Int32.TryParse(newStr, out newSize))
            {
                basket.MaxSize = newSize;
                Console.WriteLine($"New basket size set to {newStr}");
            }
            else { Console.WriteLine("Invalid size."); }
            break;

        default:
            break;
    }
    action = Console.ReadLine();
}
Console.WriteLine("Goodbye!");
