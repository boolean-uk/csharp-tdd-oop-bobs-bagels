using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace exercise.main
{
    public class Receipt
    {
        Person _person;

        public Receipt(Person person)
        {
            _person = person;
        }

        public Dictionary<string, double> prices => new Dictionary<string, double>()
             { {"Bacon", 0.12}, {"Egg", 0.12}, {"Cheese", 0.12}, {"Cream Cheese", 0.12}, {"Smoked Salmon", 0.12}, {"Ham", 0.12 } };


        public void PrintReceipt()
        {
            DateTime date = DateTime.Now;
            double total = 0;
            Console.WriteLine("    ~~~ Bob's Bagels ~~~");
            Console.WriteLine("\n");
            Console.WriteLine($"    {date:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine("\n");
            Console.WriteLine("----------------------------");
            Console.WriteLine("\n");

            Dictionary<string, int> itemCounts = new Dictionary<string, int>();
            Dictionary<string, string> idToRealName = new Dictionary<string, string>()
            {

                {"BGLO", "Onion Bagel" },
                {"BGLP", "Plain Bagel" },
                {"BGLE", "Everything Bagel" },
                {"BGLS", "Sesame Bagel" },
                {"COFB", "Black Coffee" },
                {"COFW", "White Coffee" },
                {"COFC", "Cappucino Coffee" },
                {"COFL", "Latte Coffee" },
                {"FILB", "Bacon" },
                {"FILE", "Egg" },
                {"FILC", "Cheese" },
                {"FILX", "Cream Cheese" },
                {"FILS", "Smoked Salmon" },
                {"FILH", "Ham" }
            };
            double discount = _person.DeductDiscount();
            total = _person.GetTotalCost();



            // looping through the basket to count amount of each item
            foreach (Item item in _person._basket)
            {

                if (itemCounts.ContainsKey(item.name))
                {
                    itemCounts[item.name]++;
                }
                else
                {
                    itemCounts.Add(item.name, 1);
                }
            }

            // calculating the cost amount of each individual item depending of the quantity of the item
            foreach (string itemCount in itemCounts.Keys)
            {

                int quantity = itemCounts[itemCount];
                double itemCost = 0;

                foreach (Item item in _person._basket)
                {
                    
                    if (item.name == itemCount)
                    {
                        
                        itemCost = item.prices[item.name];
                        
                        
                        break;
                    }
                }

                double totalCostForItem = itemCost * quantity;

                
                
               
                

                
                Console.WriteLine($"{idToRealName[itemCount],-18} {quantity,2}   £{totalCostForItem:F2}");
                
                //Check to see if the item is bagel
                bool isBagel = false;
                foreach (Item item in _person._basket)
                {
                    if (item.name == itemCount && item.GetType() == typeof(Bagel))
                    {
                        isBagel = true;
                        break;
                    }
                }

                // if it is a bagel I calculate the filling cost for each bagel
                if (isBagel)
                {
                    foreach (Item item in _person._basket)
                    {
                        if (item.name == itemCount && item.GetType() == typeof(Bagel))
                        {
                            Dictionary<string, int> fills = new Dictionary<string, int>();

                            foreach (Filling fill in item.bagelfillings)
                            {
                                string fillingName = idToRealName[fill.actualname];
                                if (fills.ContainsKey(fillingName))
                                {
                                    fills[fillingName]++;
                                }
                                else
                                {
                                    fills.Add(fillingName, 1);
                                }
                            }

                            foreach (string fill in fills.Keys)
                            {
                                Console.WriteLine($"{fill,-18} {fills[fill],2}   £{fills[fill] * prices[fill]:F2}");
                            }
                        }
                    
                }
                
                }
            


        }
            Console.WriteLine($"{"Discount",-18}{" ",2}   -£{discount:F2}");
            Console.WriteLine("\n----------------------------");
            Console.WriteLine($"Total                   £{total:F2}");
            Console.WriteLine($"\n You saved a total of £{discount:F2}");
            Console.WriteLine("      on this shop      ");
            Console.WriteLine("\n        Thank you");
            Console.WriteLine("      for your order!");
        }
    }
}
