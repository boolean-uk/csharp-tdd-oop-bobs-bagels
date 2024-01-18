using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        private Dictionary<Basket, int> basket;
        private int capacity;
        protected string SKU = "";

        private Dictionary<string, float> inventory;

        public Basket() 
        {

        }

        public Basket(Inventory inventory)
        {
            basket = new Dictionary<Basket, int>();
            capacity = 20;

            this.inventory = inventory.GetInventory();
        }

        public bool AddItem(Basket item)
        {
            if (item.SKU == "")
                return false;

            //Checks if the items is possible to order
            bool found = false;
            for (int i = 0; i < inventory.Count(); i++)
            {
                if (inventory.ElementAt(i).Key == item.SKU)
                    found = true;
            }

            if (!found)
                return false;

            //Adds the item to the basket, and the amount
            found = false;
            for (int i = 0; i < basket.Count(); i++)
            {
                if (basket.ElementAt(i).Key.SKU == item.SKU)
                {
                    found = true;
                    basket[basket.ElementAt(i).Key]++;
                }
            }
            if (!found)
                basket.Add(item, 1);

            return true;
        }

        public bool RemoveItem(string SKU)
        {
            //Searches for the item name instead
            bool found = false;
            for (int i = 0; i < basket.Count(); i++)
            {
                if (basket.ElementAt(i).Key.SKU == SKU)
                {
                    basket.Remove(basket.ElementAt(i).Key);
                    found = true;
                }
            }

            return found;
        }

        public bool RemoveItem(Basket item)
        {
            //If it does not contain item, it can't be removed
            if (!basket.ContainsKey(item))
                return false;

            basket.Remove(item);
            return true;
        }

        public bool BasketFull()
        {
            if (basket.Count() == capacity)
                return true;

            return false;
        }

        public int GetCapacity()
        {
           return capacity;
        }

        public int IncreaseCapacity(int amount)
        {
            if (amount > 0)
                capacity += amount;
            return capacity;
        }

        public bool ItemExists(string SKU)
        {
            //Searches for the item name instead
            for (int i = 0; i < basket.Count(); i++)
                return basket.ElementAt(i).Key.SKU == SKU;

            return false;
        }

        public bool ItemExists(Basket item)
        {
            return basket.ContainsKey(item);
        }
        
        public float TotalCost()
        {
            float total = 0;

            //Adds the costs together
            for (int i = 0; i < basket.Count(); i++)
                total += basket.ElementAt(i).Value;

            return total;
        }

        public Dictionary<Basket, int> GetBasket()
        {
            return basket;
        }

        public string GetSKU()
        {
            return SKU;
        }
    }
}