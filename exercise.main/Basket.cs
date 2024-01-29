using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace exercise.main
{
    public class Basket
    {
        private Inventory inventory;
        private int basketLimit;
        private List<Item> listItems;
        public Basket() 
        {
            listItems = new List<Item>();
            basketLimit = 4;
            inventory = new Inventory();
        }
        public List<Item> ListItems { get { return listItems; } }  
        public int BasketLimit { get {  return basketLimit; } }

        

        public string AddItemToBasket(string itemID, Inventory inventory)
        {
            if (!inventory.ShopInventory.ContainsKey(itemID))
            {
                return new string($"{itemID} is not a real itemID");
            }
            Item item = inventory.GetItem(itemID);



            if (listItems.Count < basketLimit)
            {
                listItems.Add(item);

                return new string($"{item.Variant} {item.Name} for: {item.Cost} was added to the basket");
            }
            else
            {
                return new string($"Basket is full! did not add {item.Variant} {item.Name} for: {item.Cost} to the basket");
            }


        }

        public string RemoveItemFromBasket(string itemCode)
        {

            if (listItems.Count > 0)
            {
                Item tempItem = null;
                foreach (Item item in listItems)
                {
                    if(item.ItemID == itemCode)
                    {
                         tempItem = item;
                        listItems.Remove(tempItem);
                        break;
                    }
                }
                
                if(tempItem != null)
                {
                    return new string($"{tempItem.Variant} {tempItem.Name} for: {tempItem.Cost} was removed from basket");
                }
                else
                {
                    return new string($"item with itemID {itemCode} was not found in basket");
                }

                
            }
            else
            {
                return new string($"Basket is empty!");
            }
        }

        public string ChangeBasketSize(int newBasketSize) 
        {

            int temp = basketLimit;
            basketLimit = newBasketSize;
            return new string($"Basket size was changed from {temp} to {basketLimit}");
        }

        public string GetBasketCost() 
        {
            float basketCost = 0f;

            foreach (Item item in listItems)
            {
                if(item is Bagle)
                {
                    Bagle bagle = (Bagle)item;  
                    basketCost += bagle.GetItemCost();
                }
                else
                {
                    basketCost += item.GetItemCost();
                }

                
            }
            

            return new string($"the Cost for all items in the basket is: {basketCost}");
        }

        public string GetItemCost(string itemID) 
        {
            foreach (Item item in listItems)
            {
                if (item.ItemID == itemID) 
                {
                    float cost = item.Cost;

                    return new string($"The {item.Variant} {item.Name} costs: {item.Cost}");
                }
            }

            return new string($"No item with ID: {itemID} found in basket");

        }




        public Item GetItemFromBasket(string itemID)
        {
           
            
            foreach (Item item in listItems) 
            {
                
                if(item.ItemID == itemID)
                {
                   return item;
                    
                }
                
            }
            return null;
            
        }

        //public string AddFillingToBagle(string itemID)
        //{
        //    throw new NotImplementedException();
        //    //GetItemFromBasket (itemID);

        //    //item.BagleFillings.Add(inventory.GetItem(itemID));
        //}

      
    }
}
