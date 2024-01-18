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
        private Dictionary<string, Item> listItems;
        public Basket() 
        {
            listItems = new Dictionary<string, Item>();
            basketLimit = 4;
            inventory = new Inventory();
        }
        public Dictionary<string,Item> ListItems { get { return listItems; } }  
        public int BasketLimit { get {  return basketLimit; } }

        

        public string AddItemToBasket(string itemID, Inventory inventory)
        {
            throw new NotImplementedException();
            //Item item = inventory.GetItem(itemID);



            //if (listItems.Count < basketLimit)
            //{
            //    listItems.Add(item.itemID,item);

            //    return new string($"{item.Variant} {item.Name} for: {item.Cost} was added to the basket");
            //}
            //else
            //{
            //    return new string($"Basket is full! did not add {item.Variant} {item.Name} for: {item.Cost} to the basket");
            //}


        }

        public string RemoveItemFromBasket(string itemCode)
        {
            throw new NotImplementedException();
            //if (listItems.Count > 0)
            //{
            //    Item tempItem = listItems[itemCode];
            //    listItems.Remove(itemCode);

            //    return new string($"{tempItem.Variant} {tempItem.Name} for: {tempItem.Cost} was removed to the basket");
            //}
            //else
            //{
            //    return new string($"Basket is empty!");
            //}
        }

        public string ChangeBasketSize(int newBasketSize) 
        {
            throw new NotImplementedException();
            //int temp = basketLimit;
            //basketLimit = newBasketSize;
            //return new string($"Basket size was changed from {temp} to {basketLimit}");
        }

        public string GetBasketCost() 
        {
            throw new NotImplementedException();
            //foreach(string item in listItems)
            //{

            //} 
        }

        public string GetItemCost(string itemID) 
        { 
            throw new NotImplementedException();
            //if (!listItems.ContainsKey(itemID))
            //{
            //    float tempFloat = listItems[itemID].GetTotalItemCost();

            //    return new string($"The {listItems[itemID].Variant} {listItems[itemID].Name} costs: {tempFloat}");
            //}
            //else
            //{
            //    return new string($"No item with ID: {itemID} found in basket");
            //}
            
        }

        public void GetFillingsCost() 
        { 
            
        }

        public Item GetItemFromBasket(string itemID)
        {
            throw new NotImplementedException();
            /*
            foreach (Item item in listItems) 
            {
                if(item.itemID == itemID)
                {
                   return item;
                    
                }
                
            }
            return null;
            */
        }

        //public string AddFillingToBagle(string itemID)
        //{
        //    throw new NotImplementedException();
        //    //GetItemFromBasket (itemID);

        //    //item.BagleFillings.Add(inventory.GetItem(itemID));
        //}

      
    }
}
