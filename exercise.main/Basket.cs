using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {

        private Inventory inventory { get; }
        private int Capacity { get; set; }

        private List<Item> basket = new List<Item>();

        public Basket(Inventory inventory)
        {
            this.inventory = inventory;
        }

       

        public bool AddToBasket(string sku, string extraFillings = "")
        {
            if (!IsFull())
            {
                Item bagel = inventory.GetBagel(sku);
                if (!string.IsNullOrEmpty(extraFillings))
                {
                    List<Tuple<string, decimal>> additionalFillings = new List<Tuple<string, decimal>>();

                    foreach (string filling in extraFillings.Split(" "))
                    {
                        Item fillingItem = inventory.GetFilling(filling);
                        additionalFillings.Add(new Tuple<string, decimal>(fillingItem.Variant, inventory.GetFillingCost(filling)));
                    }

                    bagel.Fillings.AddRange(additionalFillings);

                }
                basket.Add(bagel);
                return true;
            }
            throw new Exception("The basket is full!");
        }

        //! float totalPrice = bagel.Price + additionalFillings.Count * GetFillingCost("FIL");

        public bool RemoveFromBasket(string sku) {
            if (ContainsInBasket(sku))
            {
                foreach (Item item in basket)
                {
                    if (item.Sku.Equals(sku))
                    {
                        basket.Remove(item);
                        return true;
                    }
                }
            }

            return false;
        }

        public void ChangeBasketCapacity(int newCapacity) {
            Capacity = newCapacity;
        }

        public decimal TotalCostOfBasket()
        {
            decimal totalCost = 0m;
            foreach (Item item in basket)
            {
                totalCost += CalculateCost(item);
            }
            return totalCost;
        }

        private decimal CalculateCost(Item item)
        {
            decimal cost = item.Price;
            foreach (Tuple<string, decimal> filling in item.Fillings)
            {
                cost += filling.Item2;
            }
            return cost;
        }

        private bool IsFull()
        {
            return basket.Count > Capacity;
        }

        private bool ContainsInBasket(string sku)
        {
            foreach (Item item in basket) { 
                if (item.Sku.Equals(sku)) return true;
            }
            return false;
        }
        
        public int GetListCount()
        {
            return basket.Count;
        }

        public int GetCapacity()
        {
            return Capacity;
        }
        
    }
}