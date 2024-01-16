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
                            if (inventory.IsItemInStock(filling))
                            {
                                Item fillingItem = inventory.GetFilling(filling);
                                additionalFillings.Add(new Tuple<string, decimal>(fillingItem.Variant, inventory.GetFillingCost(filling)));
                            }
                            else
                            {
                                throw new Exception("Invalid filling SKU!");
                            }

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

        public float TotalCostOfBasket()
        {
            float totalCost = 0f;
            foreach (Item item in basket)
            {
                
            }
            return 0f;
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