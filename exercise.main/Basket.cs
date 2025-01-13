using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public int capacity;
        public List<IItem> inventoryList;
        public List<IItem> basketList;

        #region Basket
        public Basket()
        {
            capacity = 3;
            inventoryList = new List<IItem>();
            basketList = new List<IItem>();

            inventoryList.Add(new Bagel("BGLO", 0.49d, "Bagel", "Onion"));
            inventoryList.Add(new Bagel("BGLP", 0.39d, "Bagel", "Plain"));
            inventoryList.Add(new Bagel("BGLE", 0.49d, "Bagel", "Everything"));
            inventoryList.Add(new Bagel("BGLS", 0.49d, "Bagel", "Sesame"));
            inventoryList.Add(new Coffee("COFB", 0.99d, "Coffee", "Black"));
            inventoryList.Add(new Coffee("COFW", 1.19d, "Coffee", "White"));
            inventoryList.Add(new Coffee("COFC", 1.29d, "Coffee", "Cappuccino"));
            inventoryList.Add(new Coffee("COFL", 1.29d, "Coffee", "Latte"));
            inventoryList.Add(new Filling("FILB", 0.12d, "Filling", "Bacon"));
            inventoryList.Add(new Filling("FILE", 0.12d, "Filling", "Egg"));
            inventoryList.Add(new Filling("FILC", 0.12d, "Filling", "Cheese"));
            inventoryList.Add(new Filling("FILX", 0.12d, "Filling", "Cream Cheese"));
            inventoryList.Add(new Filling("FILS", 0.12d, "Filling", "Smoked Salmon"));
            inventoryList.Add(new Filling("FILH", 0.12d, "Filling", "Ham"));

        }
        #endregion

        #region Add Item
        public bool AddItem(string itemSKU){

            for (int i = 0; i < inventoryList.Count; i++)
            {
                // Checks if the added item is viable in inventory
                if(basketList.Count < capacity)
                {
                    if (inventoryList[i].sku == itemSKU)
                    {
                        basketList.Add(inventoryList[i]);
                        return true;
                    }

                } else return false;
            }
            return false;
        }
        #endregion

        #region Remove Item
        public bool RemoveItem(string itemSKU) {

            var item = basketList.Find(item => item.sku == itemSKU);

            if (item != null)
            {
                basketList.Remove(item);
                Console.WriteLine($"{itemSKU} has been removed");
                return true;
            }
            Console.WriteLine($"{itemSKU} does not exist in basket");
            return false;
        }
        #endregion

        #region Calculate Cost
        public double totalCost()
        {
            return basketList.Sum(item => item.price);
        }
        #endregion

        #region Change Capacity
        public int changeCapacity(int capacity) { 
            // The idea is to copy the old basket into a new basket and overwrite
            List<IItem> list = new List<IItem>();
            this.capacity = capacity;

            if(basketList.Count != 0)
            {
                for (int i = 0; i < capacity; i++)
                {
                    list.Add(basketList[i]);
                }

                // Does not remove the filling to associated bagel
                foreach (var basketItem in basketList)
                {
                    if (basketItem.sku.StartsWith("FIL"))
                    {
                        list.Add(basketItem);
                    }
                }
            }
            basketList = list;
            return basketList.Count;

        }
        #endregion

        #region Check Price

        public double checkPrice(string itemSKU)
        {
            foreach(var inventoryItem in inventoryList)
            {
                if(itemSKU == inventoryItem.sku)
                {
                    return inventoryItem.price;
                }
            }
            return 0;
        }
        #endregion

        public bool AddFilling(int bagelIndex, string fillingSKU)
        {
            
            if (bagelIndex < 0 || bagelIndex >= basketList.Count)
            {
                return false;
            }

            var bagel = basketList[bagelIndex];
            if (!bagel.sku.StartsWith("BGL"))
            {
                return false;  
            }

            var filling = inventoryList.Find(x => x.sku == fillingSKU);
            if (filling == null)
            {
                return false;  
            }

            basketList.Insert(bagelIndex + 1, filling);
            return true;
        }

    }
}
