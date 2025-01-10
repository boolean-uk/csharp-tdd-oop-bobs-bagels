using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace exercise.main
{
    public class Bagel
    {

        public int capacity { get; set; } 

        public List<Inventory> BasketList;

        List<Inventory> InventoryList;

        public Bagel()
        {
            this.BasketList = new List<Inventory>();
            this.InventoryList = new List<Inventory>();
            this.capacity = 30;
            InitializeInventory();
        }
         public void InitializeInventory()
        {
            this.InventoryList.Add(new Inventory("BGLO", 0.49, "Bagel", "Onion"));
            this.InventoryList.Add(new Inventory("BGLP", 0.39, "Bagel", "Plain"));
            this.InventoryList.Add(new Inventory("BGLE", 0.49, "Bagel", "Everything"));
            this.InventoryList.Add(new Inventory("BGLS", 0.49, "Bagel", "Sesame"));
            this.InventoryList.Add(new Inventory("COFB", 0.99, "Coffee", "Black"));
            this.InventoryList.Add(new Inventory("COFW", 1.19, "Coffee", "White"));
            this.InventoryList.Add(new Inventory("COFC", 1.29, "Coffee", "Capuccino"));
            this.InventoryList.Add(new Inventory("COFL", 1.29, "Coffee", "Latte"));
            this.InventoryList.Add(new Inventory("FILB", 0.12, "Filling", "Bacon"));
            this.InventoryList.Add(new Inventory("FILE", 0.12, "Filling", "Egg"));
            this.InventoryList.Add(new Inventory("FILC", 0.12, "Filling", "Cheese"));
            this.InventoryList.Add(new Inventory("FILX", 0.12, "Filling", "Cream Cheese"));
            this.InventoryList.Add(new Inventory("FILS", 0.12, "Filling", "Smoked Salmon"));
            this.InventoryList.Add(new Inventory("FILH", 0.12, "Filling", "Ham"));
        }

        public string AddBagel(string SKU)
        {
            Inventory? item = InventoryList.Find(x => x.SKU == SKU);
            if (item != null)
            {
                if (BasketList.Count < capacity)
                {
                    BasketList.Add(item);
                    return "Bagel added to basket";
                }
                else
                {
                    return "Basket is full";
                }
            }
            else
            {
                return "Bagel not found";
            }
        }

        public string RemoveBagel(string SKU)
        {
            Inventory? item = InventoryList.Find(x => x.SKU == SKU);
            if (item != null)
            {
                if (BasketList.Contains(item))
                {
                    BasketList.Remove(item);
                    return "Bagel removed from basket";
                }
                else
                {
                    return "Bagel not in basket";
                }
            }
            else
            {
                return "Bagel not found";
            }
        }
        
        public int ChangeCap(int cap)
        {
            this.capacity = cap;

            return cap;
        }
        public bool BasketFull()
        {
            if (BasketList.Count <= capacity)
            {
                Console.WriteLine("Basket is full");
                return true;
            }
            Console.WriteLine("Basket has space");
            return false;
        }

        public double totalCost()
        {
            double totalCost = 0;
            int countOnion = 0;
            int countPlain = 0;
            int countEverything = 0;
            int count = 0;
            int countCoffe = 0;
            bool coffeeBagel = false;
            double totalSaved = 0.0;

            for (int i = 0; i < BasketList.Count; i++)
            {
                if (BasketList[i].SKU.Equals("BGLO"))
                {
                    countOnion++;
                    count++;
                }
                else if (BasketList[i].SKU.Equals("BGLP"))
                {
                    countPlain++;
                    count++;
                }
                else if (BasketList[i].SKU.Equals("BGLE"))
                {
                    countEverything++;
                    count++;
                }
                else if (BasketList[i].SKU.Equals("COFB"))
                {
                    coffeeBagel = true;
                    count++;
                    countCoffe++;
                }
                totalCost += BasketList[i].Price;
            }
            if (countOnion >= 6)
            {
                int discountGroupsOnion = countOnion / 6;
                totalCost -= discountGroupsOnion * (0.49 * 6 - 2.49);
                totalSaved += 2.49;
            }
            if (countPlain >= 12)
            {
                int discountGroupsPlain = countPlain / 12;
                totalCost -= discountGroupsPlain * (0.39 * 12 - 3.99);
                totalSaved += 3.99;
            }
            if (countEverything >= 6)
            {
                int discountGroupsEverything = countEverything / 6;
                totalCost -= discountGroupsEverything * (0.49 * 6 - 2.49);
                totalSaved += 2.49;
            }
            if (coffeeBagel && countCoffe == 1)
            {
                totalCost -= (0.99 + 0.49 - 1.25);
                totalSaved += 1.25;
            }

            //        System.out.println(countOnion);
            //        System.out.println(countPlain);
            //        System.out.println(countEverything);
            //        System.out.println(countCoffe);
            //        System.out.println(count);

            double finalValue = Math.Round(totalCost * 100) / 100.0;
            printReceipt(finalValue, count, totalSaved);
            return finalValue;
        }
        public void printReceipt(double totalCost, int totalProducts, double saved)
        {
            LocalDateTime date = LocalDateTime.FromDateTime;

            string newDate = date.format(DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss"));
            //        for (Inventory item : basketList) {
            //            System.out.println("SKU: " + item.SKU + ", Name: " + item.name + ", Variant: " + item.variant + ", Price: " + item.price);
            //        }
            Console.WriteLine("        ~~~ Bob's Bagels ~~~       \n" +
                    "        " + newDate + "\n" +
                    "----------------------------------\n" +
                    "Products----------Quant-Price\n" +
                    formatTableOrder() +

                    "----------------------------------\n" +
                    "Total              " + totalProducts + "   £" + totalCost + "\n" +
                    "\n    You saved a total of £" + saved + "\n" +
                    "             Thank you        \n" +
                    "          for your order!        ");
        }

        public string formatTableOrder()
        {
            Dictionary<string, int> countMap = new Dictionary<string,int>();
            Dictionary<string, double> priceMap = new Dictionary<string, double>();

            for (int i = 0; i < BasketList.Count; i++)
            {
                string key = BasketList[i].getVariant() + " " + BasketList[i].Name;
                countMap.Add(key, countMap.getOrDefault(key, 0) + 1);
                priceMap.Add(key, BasketList[i].Price);
            }

            StringBuilder out = new StringBuilder();
            for (Map.Entry<string, int> entry : countMap.entrySet())
            {
                string key = entry.getKey();
                double discount = 0.00;
                int count = entry.getValue();
                double total = count * priceMap[key];
            out.append(string.format("%-18s %2d   £%.2f\n", key, count, total));
                if (key.Contains("Onion"))
                {
                    if (count >= 6)
                    {
                        discount = 0.45;
                        string sdis = "(-£" + discount + ")";
                        out.append(string.format("%-10s %-8s   %-1s\n", " ", " ", sdis));
                    }
                }
                if (key.contains("Plain"))
                {
                    if (count >= 12)
                    {
                        discount = 0.69;
                        string sdis = "(-£" + discount + ")";
                        out.append(string.format("%-10s %-8s   %-1s\n", " ", " ", sdis));
                    }
                }
                if (key.Contains("Everything"))
                {
                    if (count >= 6)
                    {
                        discount = 0.45;
                        string sdis = "(-£" + discount + ")";
                        out.append(string.format("%-10s %-8s   %-1s\n", " ", " ", sdis));
                    }
                }


            }
            return out.toString();
        }


    }
}
