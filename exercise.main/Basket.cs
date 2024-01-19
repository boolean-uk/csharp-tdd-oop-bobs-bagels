using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static exercise.main.Receipt;

namespace exercise.main
{
    public class Basket
    {
        public int BasketCapacity { get; set; } = 10;

        public List<Item> BagelList { get; } = new List<Item>();

        //user story 10
        //customers to only be able to order things that we stock in our inventory. 
        //implemented in this method
        public bool AddBagel(Item item)
        {
            Inventory inventory = new Inventory();
            // Check if the basket is full 
            if (BagelList.Count > BasketCapacity)
            {
                return false; // Basket is full
            }
            else
            {
                //check if the item that you want to add to basket is in stock
                if (inventory.Stock.Contains(inventory.GetItemBySKU(item.Sku)))
                {
                    //Add the item 
                    BagelList.Add(item);
                    return true;
                }
                else
                {
                    return false;
                }
            }    
        }

        public bool RemoveBagel(string bagelType)
        {
            // Check if the basket is empty
            if (BagelList.Count == 0)
            {
                return false; // Basket is empty
            }

            // Find the bagel to remove
            Item bagelToRemove = BagelList.Find(item => item.Sku == bagelType);

            // Check if the bagel was found
            if (bagelToRemove == null)
            {
                return false; // Bagel not found in the basket
            }

            // Remove the bagel from the BagelList
            BagelList.Remove(bagelToRemove);

            // Return true since the bagel is found and removed
            return true;
        }


        public bool IsBasketFull()
        {
            return BagelList.Count > BasketCapacity;
        }

        public bool ChangeBasketCapacity(int newCapacity)
        {
            if (newCapacity <= 0 || newCapacity == BasketCapacity)
            {
                return false; // Invalid or same capacity
            }
            BasketCapacity = newCapacity;

            //  If capacity changed successfully
            return true;
        }

        public bool RemoveItemThatDoesntExist(string bagelType)
        {
            return BagelList.Any(item => item.Sku == bagelType);
        }


        //user story 6
        // extension 1
        // Method to calculate the total cost of items in the basket, considering special offers.


        public double GetTotalCost()
        {
            double totalCost = 0;

            // Filter the items in the basket that have special offers

            var itemsWithOffers = BagelList.Where(item => item.Offer != null);

            // Iterate through each item with a special offer in the basket
            foreach (Item item in itemsWithOffers)
            {
                // Check if the quantity in the basket meets the offer requirement
                if (BagelList.Count(i => i.Sku == item.Sku) >= item.Offer.Quantity)
                {
                    // Calculate how many times the special offer applies based on the quantity.
                    int offerCount = BagelList.Count(i => i.Sku == item.Sku) / item.Offer.Quantity;

                    // Add the cost of the special offer to the total cost
                    totalCost += offerCount * item.Offer.SpecialPrice;
                }
                else
                {
                    // If there is no special offer, add the regular price to the total cost
                    totalCost += item.Price;
                }
            }

            return Math.Round(totalCost, 2);
        }




        //user story 7

        // Method to get the cost of a bagel without adding it to the basket
        public double GetBagelCost(string sku)
        {
            Inventory inventory = new Inventory();
            // Find the bagel in the inventory
            Item bagel = inventory.Stock.Find(item => item.Sku == sku);

            // Check if the bagel is found
            if (bagel != null)
            {
                // Return the cost of the bagel
                return bagel.Price;
            }

            return 0;
        }

        //user story 8
        //Method to get the chosen filling for the bagel
        public string GetChosenFilling(string Sku)
        {
            Inventory inventory = new Inventory();
            // Find the bagel in the inventory
            Item filling = inventory.Stock.Find(item => item.Name == "Filling" && item.Sku == Sku);

            // Check if the bagel is found
            if (filling != null)
            {
                // Return the chosen filling for the bagel
                return filling.Variant;
            }

            return "Bagel not found";
        }

        //user story 9
        //the cost of each filling before I add it to my bagel order.

        public double GetCostOfEachFilling(string Sku)
        {
            Inventory inventory = new Inventory();
            return inventory.GetItemBySKU(Sku).Price;
        }


        //Extension 2
        public Receipt GenerateReceipt()
        {
            var receipt = new Receipt
            {
                ShopName = "Bob's Bagels",
                Date = DateTime.Now
            };

            foreach (var item in BagelList)
            {
                receipt.Items.Add(new ReceiptItem
                {
                    Name = item.Name,
                    Quantity = BagelList.Count(i => i.Sku == item.Sku),
                    Price = (item.Offer != null) ? item.Offer.SpecialPrice : item.Price
                });
            }

            receipt.TotalCost = GetTotalCost();

            return receipt;
        }

        public void PrintReceipt()
        {
            var receipt = GenerateReceipt();
            receipt.PrintReceipt();
        }
    }

}
