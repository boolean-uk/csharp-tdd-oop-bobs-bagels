using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Basket
    {

        private Dictionary<string, BasketItem> basket;
        private int capacity;
        private double totalPrice;
        Inventory inventory;

        public Basket()
        {
            this.basket = new Dictionary<string, BasketItem>();
            this.capacity = 10;
            this.totalPrice = 0;
            this.inventory = new Inventory();
        }

        public int GetNumItemsInBasket()
        {
            int sum = 0;
            foreach (KeyValuePair<string, BasketItem> item in basket)
            {
                sum += item.Value.Quantity;
            }
            return sum;
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach (KeyValuePair<string, BasketItem> item in basket)
            {
                total += item.Value.Quantity * item.Value.GetPrice;
            }
            return total;
        }

        public string AddItem(string item, int quantity)
        {
            if ((GetNumItemsInBasket() + quantity) > capacity)
            {
                return "There is no room in your basket for this order";
            }

            if (!inventory.GetMapTypeVariantToSKU.ContainsKey("item"))
            {
                return "Im sorry, that is not on the menu";
            }

            // Add
            string sku = inventory.GetMapTypeVariantToSKU[item];
            if (basket.ContainsKey(sku))
            {
                basket[sku].Quantity += quantity;
            }
            else 
            {
                basket.Add(sku, new BasketItem(
                    inventory.GetInventory[sku].GetName,
                    inventory.GetInventory[sku].GetType,
                    inventory.GetInventory[sku].GetPrice,
                    quantity));
            }
            // update price
            TotalPrice = CalculateTotal();
            return $"{basket[sku].GetNametype} has been added to the basket";
        }

        public string AddBagelWithFillings(int quantity, List<string> fillings)
        {
            if ((GetNumItemsInBasket() + quantity* (1 + fillings.Count)) > capacity) // each quantity is one bagle and num of fillings
            {
                return "There is no room in your basket for this order";
            }

            // Add plain bagle
            if (basket.ContainsKey("BGLP"))
            {
                basket["BGLP"].Quantity += quantity;
            }
            else
            {
                basket.Add("BGLP", new BasketItem(
                    inventory.GetInventory["BGLP"].GetName,
                    inventory.GetInventory["BGLP"].GetType,
                    inventory.GetInventory["BGLP"].GetPrice,
                    quantity
                ));
            }
            // Add Fillings
            foreach (string item in fillings)
            {


                if (!inventory.GetMapTypeVariantToSKU.ContainsKey(item))
                {
                    continue;
                }
                string sku = inventory.GetMapTypeVariantToSKU[item];
                if (basket.ContainsKey(sku))
                {
                    basket[sku].Quantity += quantity;
                }
                else
                {
                    basket.Add(sku, new BasketItem(
                        inventory.GetInventory[sku].GetName,
                        inventory.GetInventory[sku].GetType,
                        inventory.GetInventory[sku].GetPrice,
                        quantity));
                }
            }
            // update price
            TotalPrice = CalculateTotal();
            return $"Plain Bagel and chosen Fillings has been added to the basket";
        }

        public string RemoveItem(string item)
        {
            
            string sku = inventory.GetMapTypeVariantToSKU[item];
            if (!basket.ContainsKey(sku))
            {
                return "Item was not found in your basket";
            }
            // Remove
            else
            {
                basket.Remove(sku);
            }
            // update price
            TotalPrice = CalculateTotal();
            return $"{inventory.GetInventory[sku].GetNametype} has been removed from the basket";
        }



        public int Capacity { get { return capacity; } set { capacity = value; } }
        public double TotalPrice { get { return totalPrice; } set { totalPrice = value; } }
        public double PriceOfItem(string item) { return inventory.GetInventory[inventory.GetMapTypeVariantToSKU[item]].GetPrice; }

        public Dictionary<string, BasketItem> Baskets { get { return basket; } }
        public BasketItem GetBasketitem(string sku) { return basket[sku]; }
        public Inventory GetInventory { get { return inventory; } }

    }
}