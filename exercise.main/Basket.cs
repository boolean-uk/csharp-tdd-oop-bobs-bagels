using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {

        private List<Item> BasketList;
        public int BasketCapacity = 10;
        
        public Basket(int capacity)
        {
            BasketCapacity = capacity;
            BasketList = new List<Item>(); 
        }

        public string AddItem(Item item)

        {
            if (BasketList.Count >= BasketCapacity) 
            {
                return "Cannot add the item because the basket is full";

            }
            else
                BasketList.Add(item);
            return "The item was successfully added";
        }

        public bool RemoveItem(Item item)
        {
            if (BasketList.Contains(item))
            {
                BasketList.Remove(item);
                return true;
            }
            else
            { 
                return false;
            }
        }

        public int ChangeCapacityForBaskets(int NewCapacity)
        {
            if (NewCapacity != BasketCapacity)
            {
                BasketCapacity = NewCapacity;
               

            }
            return BasketCapacity;

        }

        public decimal CalculateTotalPriceWithDiscount()
        {
            decimal totalPrice = 0M;
            Dictionary<string, int> itemCounts = new Dictionary<string, int>();

            // Item count
            foreach (Item item in BasketList)
            {
                if (itemCounts.ContainsKey(item.Sku))
                    itemCounts[item.Sku] += 1;
                else
                    itemCounts[item.Sku] = 1;
            }

            // This is getting pretty ugly, im sorry...
            Dictionary<string, int> remainingBagels = new Dictionary<string, int>();
            foreach (var skuCount in itemCounts)
            {
                string sku = skuCount.Key;
                int count = skuCount.Value;

                // Discount for Onion and Everything Bagels
                if (sku == "BGLO")
                {
                    int discountSets = count / 6;
                    int remainder = count % 6;
                    totalPrice += discountSets * 2.49M + remainder * 0.49M;

                    // Storing remaining bagels for pairing
                    remainingBagels[sku] = remainder;
                }

                else if (sku == "BGLE")
                {
                    int discountSets = count / 6;
                    int remainder = count % 6;
                    totalPrice += discountSets * 2.49M + remainder * 0.49M;

                    // Store the remaining bagels for pairing with coffee
                    remainingBagels[sku] = remainder;
                }

                // Discount logic for Plain Bagels
                else if (sku == "BGLP")
                {
                    int discountSets = count / 12;
                    int remainder = count % 12;
                    totalPrice += discountSets * 3.99M + remainder * 0.39M;

                    // Store the remaining bagels for pairing
                    remainingBagels[sku] = remainder;
                }
                else if (sku == "BGLS")
                {
                    remainingBagels[sku] = count;
                }
            }
            // Black coffee and bagel pairing for discount
            if (itemCounts.ContainsKey("COFB"))
            {
                int coffeeCount = itemCounts["COFB"];
                int totalRemainingBagels = remainingBagels.Values.Sum();
                int availablePairs = Math.Min(totalRemainingBagels, coffeeCount); //The smallest number of the two will dictate how many pairs


                // Apply discount for the eligible pairs
                totalPrice += availablePairs * 1.25M;
                int bagelsToPair = availablePairs;


                foreach (var sku in remainingBagels.Keys.ToList())
                {
                    if (bagelsToPair <= 0)
                        break;

                    int remainingCount = remainingBagels[sku];

                    if (remainingCount > 0)
                    {
                        int bagelsUsed = Math.Min(remainingCount, bagelsToPair);
                        decimal bagelPrice = BasketList.First(item => item.Sku == sku).Price;
                        remainingBagels[sku] -= bagelsUsed;
                        bagelsToPair = bagelsToPair - bagelsUsed;
                        totalPrice -= bagelPrice;
                    }
                }

                // Calculate remaining coffee that is not paired
                int remainingCoffee = coffeeCount - availablePairs;
                totalPrice += remainingCoffee * 0.99M;

            }

            // Remaining items without discounts
            foreach (var skuCount in itemCounts)
            {
                string sku = skuCount.Key;
                int count = skuCount.Value;

                if (sku != "BGLO" && sku != "BGLE" && sku != "BGLP" && sku != "COFB")
                {
                    totalPrice += count * BasketList.First(item => item.Sku == sku).Price;

                }
            }

            return totalPrice;

        }
            

        public string CanRemoveItemFromBasket(Item item)
        {

            if (BasketList.Contains(item))
            {
                return "Item can be removed";

            }
            else
            {
                return "Item is not in the basket, and therefore can`t be removed";
            
            }

            }

        public decimal BagelCost(Item item)

        {
            if (item.Name == "Bagel")
            
            {
                return item.Price;

            }

            else
            {
                throw new ArgumentException("The item is not a bagel.");
            }

        }

        public decimal CheckFillingPrice(Item item)
        {
            if (item.Name == "Filling")

            {
                return item.Price;
            }
            else
            {
                throw new ArgumentException("The item is not a filling");
            }

        }

        public bool CheckIfInInventory(string sku)
        {
            foreach (Item item in Inventory.inventoryList)
            {
                if (item.Sku == sku)
                {
                    return true;
                }

            }
            return false;
        }

        // Support-method to get whats in the basket and calculate discount price for 

        public int CountItemsBySku(string sku)
        {
            return BasketList.Count(item => item.Sku == sku);
        }

        public void GenerateReceipt()
        {
            // Print the header of the receipt
            Console.WriteLine("~~~ Bob's Bagels ~~~");
            Console.WriteLine();
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            decimal totalCost = 0M;
            decimal totalDiscount = 0M;

            // Loop through each item in the basket
            Dictionary<string, int> itemCounts = new Dictionary<string, int>();
            foreach (Item item in BasketList)
            {
                if (itemCounts.ContainsKey(item.Sku))
                    itemCounts[item.Sku]+=1;
                else
                    itemCounts[item.Sku] = 1;
            }

            // Print each item and its cost
            foreach (var skuCount in itemCounts)
            {
                string sku = skuCount.Key;
                int count = skuCount.Value;
                decimal price = BasketList.First(item => item.Sku == sku).Price;

                if (sku == "BGLO")
                {
                    int discountSets = count / 6;
                    int remainder = count % 6;
                    decimal cost = discountSets * 2.49M + remainder * 0.49M;
                    Console.WriteLine($"Onion Bagel         {count}   £{cost:F2}");
                    totalCost += cost;
                    totalDiscount += discountSets * 0.69M;
                }

                else if (sku == "BGLE")
                {
                    int discountSets = count / 6;
                    int remainder = count % 6;
                    decimal cost = discountSets * 2.49M + remainder * 0.49M;
                    Console.WriteLine($"Everything Bagel    {count}   £{cost:F2}");
                
                    totalCost += cost;
                    totalDiscount += discountSets * 0.69M;
                }

                else if (sku == "BGLP")
                {
                    int discountSets = count / 12; // Division without rest
                    int remainder = count % 12; //Modulo to calculate remainder
                    decimal cost = discountSets * 3.99M + remainder * 0.39M;
                    Console.WriteLine($"Plain Bagel         {count}   £{cost:F2}");

                    totalCost += cost;
                    totalDiscount += discountSets * 0.69M;
                }
                else if (sku == "COFB")
                {
                    int bagelCount = CountItemsBySku("BGLO") + CountItemsBySku("BGLE") + CountItemsBySku("BGLP");
                    int coffeeCount = count;
                    int eligiblePairs = Math.Min(bagelCount, coffeeCount);
                    decimal cost = eligiblePairs * 1.25M + (coffeeCount - eligiblePairs) * 0.99M;
                    Console.WriteLine($"Coffee              {count}   £{cost:F2}");
                    totalCost += cost;
                }
                else
                {
                    decimal cost = count * price;
                    Console.WriteLine($"{sku}                {count}   £{cost:F2}");
                    totalCost += cost;
                }
            }

            Console.WriteLine("----------------------------");
            Console.WriteLine($"Total                £{totalCost:F2}");
            Console.WriteLine();
            Console.WriteLine($"You saved a total of £{totalDiscount:F2}");
            Console.WriteLine("       on this shop");
            Console.WriteLine();
            Console.WriteLine("        Thank you");
            Console.WriteLine("      for your order!");
        }

        public void PrintBasketList()
        {
            // Iterate through each item in BasketList and print it
            foreach (var item in BasketList)
            {
                Console.WriteLine(item.Sku);
            }
        }




    }
}
