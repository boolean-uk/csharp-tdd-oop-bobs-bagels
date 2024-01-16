using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Basket
    {
        public List<Item> listItems {  get; }
        private int basketLimit = 4;
        private Inventory inventory = new Inventory();

        public string AddItemToBasket(string itemCode)
        {
            throw new NotImplementedException();
        }

        public string RemoveItemFromBasket(string itemCode)
        { 
            throw new NotImplementedException(); 
        }

        public string ChangeBasketSize(int newBasketSize) 
        { 
            throw new NotImplementedException(); 
        }

        public string GetBasketCost() 
        { 
            throw new NotImplementedException(); 
        }

        public string GetItemCost(string itemID) 
        { 
            throw new NotImplementedException(); 
        }

        public void GetFillingsCost() 
        { 
            throw new NotImplementedException(); 
        }

        public Item GetItemFromBasket(string itemID)
        {
            throw new NotImplementedException();
        }

        public string AddFillingToBagle(Item item,string itemID)
        {
            throw (new NotImplementedException());
        }
    }
}
