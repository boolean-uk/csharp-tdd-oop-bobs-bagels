using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace tdd_oop_bobs_bagels.CSharp.Main
{
    public class Basket
    {
        public List<Item> orderBasket = new List<Item>();
        private List<Item> _ReceiptStart = new List<Item>();
        public List<Item> ReceiptProcessed { get { return _ReceiptStart; } set { _ReceiptStart = value; } }
        private int _maxcapacity = 50;
        public double total_savings;

        public int MaxCapacity { get { return _maxcapacity; } set { _maxcapacity = value; } }


        public void AddItem(string itemID)
        {
            if (orderBasket.Count < MaxCapacity)
            {
                //find this item in inventory
                Inventory BobsInventory = new Inventory();
                BobsInventory.SetInventory();
                var currentItem = BobsInventory.Stock.Where(x => x.ID == itemID).FirstOrDefault();
                //add this item to the basket
                orderBasket.Add(currentItem);
                Console.WriteLine("Adding item");
            }
            else
            {
                Console.WriteLine("\nBasket is full!");
                Console.WriteLine("Remove Something or Call a Manager for Assistance");
                Thread.Sleep(2500);
            }
        }

        public void RemoveItem(string itemID)
        {
            itemID = itemID.Substring(0, 2);

            if (orderBasket.Exists(x => x.ID == itemID))
            {
                orderBasket.Remove(orderBasket.Where(item => item.ID == itemID).First());
            }
            else
            {
                Console.WriteLine("Item not in basket");
                Thread.Sleep(1500);
            }

        }

        public string ViewBasket()
        {
            StringBuilder inBasket = new StringBuilder();
            if (orderBasket.Count > 0)
            {
                inBasket.AppendLine(" Items in Shopping Basket:");
                inBasket.AppendLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                foreach (Item i in orderBasket)
                {
                    inBasket.AppendLine($" {i.ID} |  {i.Price} | {i.Variant} {i.Name}");
                }
                inBasket.AppendLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                inBasket.AppendLine($"Total Items: {orderBasket.Count}");
                inBasket.AppendLine($"Total Cost: {Math.Round(SumBasket(),2)}");
            }
            else
            {
                inBasket.AppendLine("Basket is empty");
            }
            return inBasket.ToString();
        }
        
        public float SumBasket()
        {
            float sum = orderBasket.Sum(Item => Item.Price);
            return sum;
        }

        public string GetReceipt()
        {
            StringBuilder getReceipt = new StringBuilder();
            var Rec = orderBasket.GroupBy(orderBasket => orderBasket.ID);
            getReceipt.AppendLine("               ~~~ Bob's Bagels ~~~             \n");
            getReceipt.AppendLine($"              {DateTime.UtcNow.ToString()}");
            getReceipt.AppendLine("------------------------------------------------\n");

            foreach(var rec in Rec)
            {
                
                Inventory BobsInventory = new Inventory();
                BobsInventory.SetInventory();
                var currentItem = BobsInventory.Stock.Where(x => x.ID == rec.Key).FirstOrDefault();
                currentItem.Quantity = rec.Count();
                _ReceiptStart.Add(currentItem);
            }

            //ReceiptProcessed = _ReceiptStart.ToList();

            while (ReceiptProcessed.Sum(x => x.Quantity) > 0)
            {
                //Get the 12x and 6x special offers
                foreach (Item item in ReceiptProcessed)
                {
                    string fullName = $"{item.Variant} {item.Name}";
                    if (item.SKU == "BGLP" && item.Quantity >= 12)
                    {
                        //how many times can we give discount12:
                        decimal d = item.Quantity/12;
                        int num_discounts = (int)Math.Floor(d);
                        item.Quantity -= (12 * num_discounts);
                        int quantity = 12 * num_discounts;
                        double price = (3.99 * num_discounts);
                        double savings = (0.69 * num_discounts);
                        total_savings += savings;
                        getReceipt.AppendLine($"{fullName.PadRight(35)} {quantity.ToString().PadRight(3)} $ {Math.Round(price, 2, MidpointRounding.AwayFromZero).ToString().PadLeft(6)} ");
                        getReceipt.AppendLine($"(-{savings.ToString()})".PadLeft(48));
                    }

                    if (item.SKU == "BGLO" && item.Quantity >= 6)
                    {
                        decimal d = item.Quantity / 6;
                        int num_discounts = (int)Math.Floor(d);
                        item.Quantity -= (6 * num_discounts);
                        int quantity = 12 * num_discounts;
                        double price = (2.49 * num_discounts);
                        double savings = (0.45 * num_discounts);
                        total_savings += savings;
                        getReceipt.AppendLine($"{fullName.PadRight(35)} {quantity.ToString().PadRight(3)} $ {Math.Round(price, 2, MidpointRounding.AwayFromZero).ToString().PadLeft(6)} ");
                        getReceipt.AppendLine($"(-{savings.ToString()})".PadLeft(48));
                    }

                    if (item.SKU == "BGLE" && item.Quantity >= 6)
                    {
                        decimal d = item.Quantity / 6;
                        int num_discounts = (int)Math.Floor(d);
                        item.Quantity -= (6 * num_discounts);
                        int quantity = 12 * num_discounts;
                        double price = (2.49 * num_discounts);
                        double savings = (0.45 * num_discounts);
                        total_savings += savings;
                        getReceipt.AppendLine($"{fullName.PadRight(35)} {quantity.ToString().PadRight(3)} $ {Math.Round(price, 2, MidpointRounding.AwayFromZero).ToString().PadLeft(6)} ");
                        getReceipt.AppendLine($"(-{savings.ToString()})".PadLeft(48));
                    }
                }

                //Get the Black Coffee & Bagel combos:
                foreach (Item item in ReceiptProcessed)
                {
                    int combos = 0;
                    //check for black coffee: 
                    int blackcoffee = ReceiptProcessed.Where(x => x.ID == "C1").Count();
                    if (item.Name == "Bagel" && item.Quantity>0 && blackcoffee!=0)
                    {
                        var coffee = ReceiptProcessed.Where(x => x.ID == "C1").FirstOrDefault();
                        //how many combos to make with this bagel:
                        combos = Math.Min(coffee.Quantity, item.Quantity);
                        item.Quantity -= combos;
                        coffee.Quantity -= combos;
                    }

                    if (combos != 0)
                    {
                        string fullName = $"Coffee & {item.Variant} Bagel Combo";
                        double price = 1.25;
                        int quantity = combos;
                        double savings = ((item.Price + 0.99) * quantity) - (price * quantity);
                        total_savings += savings;
                        getReceipt.AppendLine($"{fullName.PadRight(35)} {quantity.ToString().PadRight(3)} $ {Math.Round(price, 2, MidpointRounding.AwayFromZero).ToString().PadLeft(6)} ");
                        getReceipt.AppendLine($"(-{Math.Round(savings, 2, MidpointRounding.AwayFromZero).ToString()})".PadLeft(48));
                    }
                }

                //Get the remaining items for normal price:
                foreach (Item item in ReceiptProcessed)
                {
                    if (item.Quantity > 0)
                    {
                        string fullName = $"{item.Variant} {item.Name}";
                        getReceipt.AppendLine($"{fullName.PadRight(35)} {item.Quantity.ToString().PadRight(3)} $ {Math.Round(item.Price * item.Quantity, 2, MidpointRounding.AwayFromZero).ToString().PadLeft(6)} ");
                        item.Quantity -= item.Quantity;
                    }
                }
 
            }
            getReceipt.AppendLine("------------------------------------------------\n");
            getReceipt.AppendLine($"Total:                                 $ {Math.Round(SumBasket()-total_savings, 2, MidpointRounding.AwayFromZero).ToString().PadLeft(6)}");
            getReceipt.AppendLine($"\n    You saved a total of $ {Math.Round(total_savings, 2, MidpointRounding.AwayFromZero).ToString()} on this shop");
            getReceipt.AppendLine("\n         Thank you for your order!");
            return getReceipt.ToString();

        }

        private string secretCode { get; } = "007";
        public int EditMaximum(string managerCode, int newCapacity)
        {
            if (managerCode == secretCode)
            {
                _maxcapacity = newCapacity;
            }
            return _maxcapacity;
        }
    }
}
