using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine;
using System;
using System.Collections.Generic;
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
        public List<Item> Receipt = new List<Item>();
        private int _maxcapacity = 7;

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

        public float Discounts()
        {
            //if basket has 12 bagels
            float discounts = 0;
            return discounts;
        }

        public string GetReceipt()
        {
            StringBuilder getReceipt = new StringBuilder();
            var Rec = orderBasket.GroupBy(orderBasket => orderBasket.ID);
            getReceipt.AppendLine("         ~~~ Bob's Bagels ~~~     \n");
            getReceipt.AppendLine($"        {DateTime.UtcNow.ToString()}");
            getReceipt.AppendLine("--------------------------------------\n");

            foreach(var rec in Rec)
            {
                //getReceipt.AppendLine($"{ rec.Key} {rec.Count()}");
                Inventory BobsInventory = new Inventory();
                BobsInventory.SetInventory();
                var currentItem = BobsInventory.Stock.Where(x => x.ID == rec.Key).FirstOrDefault();
                currentItem.Quantity = rec.Count();
                Receipt.Add(currentItem);
            }

            foreach (Item item in Receipt)
            {
                string fullName = $"{item.Variant} {item.Name}";
                getReceipt.AppendLine($"{fullName.PadRight(25)} {item.Quantity.ToString().PadRight(3)} $ {Math.Round(item.Price * item.Quantity, 2, MidpointRounding.AwayFromZero).ToString().PadLeft(6)} ");
            }
            getReceipt.AppendLine("--------------------------------------\n");
            getReceipt.AppendLine($"                  Total:      $ {Math.Round(SumBasket(), 2, MidpointRounding.AwayFromZero).ToString().PadLeft(6)}\n");
            getReceipt.AppendLine("       Thank you for your order!");
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
